using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyNhanSu
{
    internal static class HrService
    {
        static OracleParameter P(string n, object v) { return Db.P(n, v); }
        static string Id(OracleConnection c, OracleTransaction t, string prefix) { return Db.Id(c,t,"SEQ_NS",prefix); }
        static void Need(bool ok, string message) { if (!ok) throw new InvalidOperationException(message); }
        internal static string Text(string s) { Need(!string.IsNullOrWhiteSpace(s),"Vui lòng nhập đủ thông tin bắt buộc."); return s.Trim(); }
        static DataTable Read(OracleConnection c, OracleTransaction t, string sql, params OracleParameter[] p)
        {
            using(var cmd=Db.Command(c,t,sql,p)) using(var a=new OracleDataAdapter(cmd)) { var d=new DataTable(); a.Fill(d); return d; }
        }
        static DataRow One(OracleConnection c, OracleTransaction t, string sql, params OracleParameter[] p)
        { var d=Read(c,t,sql,p); Need(d.Rows.Count>0,"Không tìm thấy dữ liệu phù hợp."); return d.Rows[0]; }
        static decimal Num(DataRow r,string name) { return r[name]==DBNull.Value?0:Convert.ToDecimal(r[name]); }
        static void LockEmployee(OracleConnection c, OracleTransaction t, string nv)
        { One(c,t,"SELECT MaNV FROM NhanVien WHERE MaNV=:n FOR UPDATE",P("n",nv)); }
        static void OpenMonth(OracleConnection c, OracleTransaction t, DateTime day)
        { Need(Read(c,t,"SELECT MaBL FROM BangLuong WHERE Thang=TRUNC(:d,'MM')",P("d",day.Date)).Rows.Count==0,"Tháng đã lập lương, không được sửa dữ liệu đầu vào."); }
        static void Gate(OracleConnection c, OracleTransaction t)
        {
            // Serialize attendance, decisions and payroll: a small internal application.
            // All service writers acquire the same table lock first to avoid races.
            Db.Exec(c,t,"LOCK TABLE BangLuong IN EXCLUSIVE MODE");
        }
        internal static DataTable Employees(string keyword)
        {
            return Db.Query("SELECT n.MaNV,n.HoTen,p.TenPB,n.TrangThai,n.NgaySinh,n.DienThoai FROM NhanVien n JOIN PhongBan p ON p.MaPB=n.MaPB WHERE UPPER(n.MaNV||' '||n.HoTen) LIKE UPPER(:q) ORDER BY n.MaNV",P("q","%"+keyword+"%"));
        }
        internal static string Recruit(string name, DateTime birth, string cccd, string phone, string address,
            string department, DateTime from, DateTime to, decimal pay, string terms, string signer)
        {
            name=Text(name); terms=Text(terms); signer=Text(signer);
            Need(birth.Date<=from.AddYears(-18) && to>=from && pay>0,"Ngày sinh, thời gian thử việc hoặc lương không hợp lệ (giả định đủ 18 tuổi).");
            Need(System.Text.RegularExpressions.Regex.IsMatch(cccd,"^[0-9]{12}$"),"CCCD phải gồm 12 chữ số.");
            return Db.Atomic((c,t)=> {
                Gate(c,t); OpenMonth(c,t,from);
                string nv=Id(c,t,"NV"), qd=Id(c,t,"TD");
                Db.Exec(c,t,"INSERT INTO NhanVien VALUES(:n,:h,:b,:cc,:dt,:dc,:pb,'THU_VIEC')",P("n",nv),P("h",name),P("b",birth.Date),P("cc",cccd),P("dt",phone),P("dc",address),P("pb",department));
                Db.Exec(c,t,"INSERT INTO QDTuyenDung VALUES(:q,:n,:pb,:ky,:tu,:den,:l,:dk,:nk,'CHO')",P("q",qd),P("n",nv),P("pb",department),P("ky",from.Date),P("tu",from.Date),P("den",to.Date),P("l",pay),P("dk",terms),P("nk",signer));
                return nv;
            });
        }
        internal static void Evaluate(string nv, bool pass, DateTime date)
        {
            Db.Atomic((c,t)=> {
                Gate(c,t); LockEmployee(c,t,nv);
                var r=One(c,t,"SELECT DenNgay,KetQua FROM QDTuyenDung WHERE MaNV=:n",P("n",nv));
                Need(date.Date>Convert.ToDateTime(r["DenNgay"]),"Chỉ đánh giá sau ngày kết thúc thử việc.");
                Need(Convert.ToString(r["KetQua"])=="CHO","Đã đánh giá thử việc."); OpenMonth(c,t,date);
                Db.Exec(c,t,"UPDATE QDTuyenDung SET KetQua=:k WHERE MaNV=:n",P("k",pass?"DAT":"KHONG_DAT"),P("n",nv));
                if(!pass) Db.Exec(c,t,"UPDATE NhanVien SET TrangThai='NGHI_VIEC' WHERE MaNV=:n",P("n",nv));
                return true;
            });
        }
        internal static string Contract(string nv, string type, DateTime from, DateTime? to, decimal salary,
            decimal allowance, decimal hazard, string position, decimal positionPay, string terms, string signer,
            string social, string health, decimal rateXH, decimal rateYT)
        {
            Text(terms); Text(signer);
            Need(type=="DAI_HAN"||type=="NGAN_HAN","Loại hợp đồng không hợp lệ.");
            Need(!to.HasValue||to.Value.Date>=from.Date,"Ngày hết hạn không hợp lệ.");
            Need(type!="NGAN_HAN"||to.HasValue,"Hợp đồng ngắn hạn phải có ngày hết hạn.");
            Need(from.Day==1,"Bản lab áp dụng hợp đồng/quyết định lương từ ngày đầu tháng.");
            Payroll.Calculate(salary,allowance+hazard+positionPay,0,0,26,rateXH,rateYT,0,0);
            Need(allowance>=0&&hazard>=0&&positionPay>=0,"Phụ cấp không được âm.");
            if(type=="DAI_HAN") { Text(social); Text(health); }
            return Db.Atomic((c,t)=> {
                Gate(c,t); LockEmployee(c,t,nv); OpenMonth(c,t,from);
                var r=One(c,t,"SELECT * FROM QDTuyenDung WHERE MaNV=:n",P("n",nv));
                Need(Convert.ToString(r["KetQua"])=="DAT"&&from.Date>Convert.ToDateTime(r["DenNgay"]),"Cần đạt thử việc và bắt đầu hợp đồng sau thử việc.");
                Need(Read(c,t,"SELECT MaHD FROM HopDong WHERE MaNV=:n AND (DenNgay IS NULL OR DenNgay>=:d)",P("n",nv),P("d",from.Date)).Rows.Count==0,"Hợp đồng bị chồng thời gian.");
                string hd=Id(c,t,"HD");
                Db.Exec(c,t,"INSERT INTO HopDong VALUES(:h,:n,:l,:d,:d,:e,:dk,:nk)",P("h",hd),P("n",nv),P("l",type),P("d",from.Date),P("e",to),P("dk",terms),P("nk",signer));
                if(type=="DAI_HAN") Db.Exec(c,t,"INSERT INTO HoSoBaoHiem VALUES(:b,:h,:x,:y,:tx,:ty)",P("b",Id(c,t,"BH")),P("h",hd),P("x",social),P("y",health),P("tx",rateXH),P("ty",rateYT));
                SalaryCore(c,t,nv,from,salary,allowance,hazard,signer);
                PositionCore(c,t,nv,position,from,positionPay,signer);
                Db.Exec(c,t,"UPDATE NhanVien SET TrangThai='CHINH_THUC' WHERE MaNV=:n",P("n",nv)); return hd;
            });
        }
        static void SalaryCore(OracleConnection c,OracleTransaction t,string nv,DateTime date,decimal salary,decimal pc,decimal hazard,string signer)
        { Db.Exec(c,t,"INSERT INTO QDLuong VALUES(:q,:n,:d,:d,:l,:p,:h,:s)",P("q",Id(c,t,"LG")),P("n",nv),P("d",date.Date),P("l",salary),P("p",pc),P("h",hazard),P("s",signer)); }
        static void PositionCore(OracleConnection c,OracleTransaction t,string nv,string pos,DateTime date,decimal pc,string signer)
        { Db.Exec(c,t,"INSERT INTO QDChucVu VALUES(:q,:n,:v,:d,:d,:p,:s)",P("q",Id(c,t,"CV")),P("n",nv),P("v",pos),P("d",date.Date),P("p",pc),P("s",signer)); }
        internal static void Salary(string nv,DateTime date,decimal salary,decimal pc,decimal hazard,string signer)
        {
            Text(signer); Need(date.Day==1&&salary>0&&pc>=0&&hazard>=0,"Hiệu lực đầu tháng; lương > 0 và phụ cấp ≥ 0.");
            Db.Atomic((c,t)=> { Gate(c,t); LockEmployee(c,t,nv); OpenMonth(c,t,date); RequireContract(c,t,nv,date); SalaryCore(c,t,nv,date,salary,pc,hazard,signer); return true; });
        }
        internal static void Position(string nv,string pos,DateTime date,decimal pc,string signer)
        {
            Text(signer); Need(date.Day==1&&pc>=0,"Hiệu lực phải đầu tháng, phụ cấp không âm.");
            Db.Atomic((c,t)=> { Gate(c,t); LockEmployee(c,t,nv); OpenMonth(c,t,date); RequireContract(c,t,nv,date); PositionCore(c,t,nv,pos,date,pc,signer); return true; });
        }
        static DataRow RequireContract(OracleConnection c,OracleTransaction t,string nv,DateTime day)
        { return One(c,t,"SELECT * FROM HopDong WHERE MaNV=:n AND TuNgay<=:d AND (DenNgay IS NULL OR DenNgay>=:d)",P("n",nv),P("d",day.Date)); }
        internal static string Schedule(string nv,DateTime day,string shift,decimal plannedOT,string planner)
        {
            Text(planner); Need(plannedOT>=0&&plannedOT<=16,"Giờ phụ trội dự kiến phải từ 0 đến 16.");
            return Db.Atomic((c,t)=> {
                Gate(c,t); LockEmployee(c,t,nv); OpenMonth(c,t,day);
                var employee=One(c,t,"SELECT * FROM NhanVien WHERE MaNV=:n",P("n",nv));
                Need(Convert.ToString(employee["TrangThai"])!="NGHI_VIEC","Nhân viên đã nghỉ việc.");
                Need(Read(c,t,"SELECT MaQD FROM QDTuyenDung WHERE MaNV=:n AND :d BETWEEN TuNgay AND DenNgay UNION ALL SELECT MaHD FROM HopDong WHERE MaNV=:n AND TuNgay<=:d AND (DenNgay IS NULL OR DenNgay>=:d)",P("n",nv),P("d",day.Date)).Rows.Count>0,"Ngày phân công không thuộc thời gian làm việc.");
                string pb=Convert.ToString(employee["MaPB"]);
                var plans=Read(c,t,"SELECT MaKH FROM KeHoachTuan WHERE MaPB=:p AND DauTuan=TRUNC(:d,'IW')",P("p",pb),P("d",day.Date));
                string kh=plans.Rows.Count>0?Convert.ToString(plans.Rows[0][0]):Id(c,t,"KH");
                if(plans.Rows.Count==0) Db.Exec(c,t,"INSERT INTO KeHoachTuan VALUES(:k,:p,TRUNC(:d,'IW'),:s)",P("k",kh),P("p",pb),P("d",day.Date),P("s",planner));
                string pc=Id(c,t,"PC");
                Db.Exec(c,t,"INSERT INTO PhanCong VALUES(:p,:k,:n,:d,:ca,:g)",P("p",pc),P("k",kh),P("n",nv),P("d",day.Date),P("ca",shift),P("g",plannedOT)); return pc;
            });
        }
        internal static void Attendance(string assignment,decimal hours,string recorder)
        {
            Text(recorder); Need(hours>=0&&hours<=8,"Giờ công phải từ 0 đến 8.");
            Db.Atomic((c,t)=> {
                Gate(c,t); var p=One(c,t,"SELECT p.*,ca.SoGio FROM PhanCong p JOIN CaLam ca ON ca.MaCa=p.MaCa WHERE MaPC=:p",P("p",assignment));
                OpenMonth(c,t,Convert.ToDateTime(p["NgayLam"])); Need(hours<=Num(p,"SoGio"),"Giờ công vượt độ dài ca.");
                Db.Exec(c,t,"INSERT INTO ChamCong VALUES(:m,:p,:g,:s,NULL)",P("m",Id(c,t,"CC")),P("p",assignment),P("g",hours),P("s",recorder)); return true;
            });
        }
        internal static string Overtime(DateTime day,string kind,string[] employees,decimal hours,string recorder)
        {
            Text(recorder); Need(employees.Length>0&&employees.Distinct().Count()==employees.Length,"Danh sách nhân viên rỗng hoặc trùng.");
            Need(hours>0&&hours<=16,"Giờ phụ trội phải > 0 và ≤ 16.");
            Need(new[]{"TANG_CA","NGAY_LE","NGAY_NGHI"}.Contains(kind),"Hình thức không hợp lệ.");
            return Db.Atomic((c,t)=> {
                Gate(c,t); OpenMonth(c,t,day); string pt=Id(c,t,"PT");
                Db.Exec(c,t,"INSERT INTO PhieuPhuTroi VALUES(:p,:d,:l,:s)",P("p",pt),P("d",day.Date),P("l",kind),P("s",recorder));
                foreach(string nv in employees) {
                    LockEmployee(c,t,nv);
                    var r=One(c,t,"SELECT pc.GioPTDuKien,ca.SoGio FROM PhanCong pc JOIN CaLam ca ON ca.MaCa=pc.MaCa WHERE pc.MaNV=:n AND pc.NgayLam=:d",P("n",nv),P("d",day.Date));
                    var sums=One(c,t,"SELECT NVL(SUM(ct.SoGio),0) AS Tong FROM CTPhuTroi ct JOIN PhieuPhuTroi p ON p.MaPT=ct.MaPT WHERE ct.MaNV=:n AND p.NgayPT=:d",P("n",nv),P("d",day.Date));
                    Need(Num(sums,"Tong")+hours<=Num(r,"GioPTDuKien")&&Num(sums,"Tong")+hours+Num(r,"SoGio")<=24,"Phụ trội vượt kế hoạch hoặc tổng giờ/ngày vượt 24.");
                    Db.Exec(c,t,"INSERT INTO CTPhuTroi VALUES(:p,:n,:g)",P("p",pt),P("n",nv),P("g",hours));
                } return pt;
            });
        }
        internal static string Decision(string type,string reason,string method,bool group,string target,decimal amount)
        {
            Text(reason); Text(target); Need(amount>0,"Số tiền phải > 0.");
            Need(type=="KHEN_THUONG"||type=="KY_LUAT","Loại quyết định không hợp lệ.");
            Need(method=="TRUC_TIEP"||method=="QUA_LUONG","Cách xử lý không hợp lệ.");
            return Db.Atomic((c,t)=> {
                Gate(c,t); string q=Id(c,t,"QD");
                Db.Exec(c,t,"INSERT INTO QuyetDinhKTKL(MaQD,LoaiQD,LyDo,CachXuLy) VALUES(:q,:l,:r,:c)",P("q",q),P("l",type),P("r",reason),P("c",method));
                Db.Exec(c,t,"INSERT INTO DoiTuongQD VALUES(:d,:q,:n,:p,:s)",P("d",Id(c,t,"DT")),P("q",q),P("n",group?null:target),P("p",group?target:null),P("s",amount)); return q;
            });
        }
        internal static void SignDecision(string q,string director)
        {
            Text(director);
            Db.Atomic((c,t)=> {
                Gate(c,t); var decision=One(c,t,"SELECT * FROM QuyetDinhKTKL WHERE MaQD=:q FOR UPDATE",P("q",q));
                Need(Convert.ToString(decision["TrangThai"])=="DU_THAO","Quyết định đã ký, không được ký lại.");
                var targets=Read(c,t,"SELECT * FROM DoiTuongQD WHERE MaQD=:q",P("q",q)); Need(targets.Rows.Count>0,"Quyết định chưa có đối tượng.");
                foreach(DataRow target in targets.Rows) {
                    DataTable recipients=target["MaNV"]!=DBNull.Value?
                        Read(c,t,"SELECT MaNV FROM NhanVien WHERE MaNV=:n AND TrangThai<>'NGHI_VIEC'",P("n",target["MaNV"])):
                        Read(c,t,"SELECT MaNV FROM NhanVien WHERE MaPB=:p AND TrangThai<>'NGHI_VIEC' ORDER BY MaNV",P("p",target["MaPB"]));
                    Need(recipients.Rows.Count>0,"Đối tượng không có nhân viên đang làm việc.");
                    decimal total=Num(target,"SoTien"), part=Math.Floor(total/recipients.Rows.Count*100)/100, used=0;
                    Need(part>0,"Số tiền quá nhỏ để phân bổ.");
                    for(int i=0;i<recipients.Rows.Count;i++) {
                        decimal pay=i==recipients.Rows.Count-1?total-used:part; used+=pay;
                        Db.Exec(c,t,"INSERT INTO PhanBoQD VALUES(:m,:d,:n,:s,NULL)",P("m",Id(c,t,"PB")),P("d",target["MaDT"]),P("n",recipients.Rows[i]["MaNV"]),P("s",pay));
                    }
                }
                Db.Exec(c,t,"UPDATE QuyetDinhKTKL SET TrangThai='DA_KY',NguoiKy=:s,NgayKy=TRUNC(SYSDATE) WHERE MaQD=:q",P("s",director),P("q",q)); return true;
            });
        }
        internal static void Settle(string q,string cashier)
        {
            Text(cashier);
            Db.Atomic((c,t)=> {
                Gate(c,t); var r=One(c,t,"SELECT * FROM QuyetDinhKTKL WHERE MaQD=:q FOR UPDATE",P("q",q));
                Need(Convert.ToString(r["TrangThai"])=="DA_KY"&&Convert.ToString(r["CachXuLy"])=="TRUC_TIEP","Cần quyết định đã ký và xử lý trực tiếp.");
                var allocations=Read(c,t,"SELECT b.* FROM PhanBoQD b JOIN DoiTuongQD d ON d.MaDT=b.MaDT WHERE d.MaQD=:q",P("q",q));
                Need(allocations.Rows.Count>0,"Chưa phân bổ tiền.");
                foreach(DataRow a in allocations.Rows) Db.Exec(c,t,"INSERT INTO PhieuThuChi VALUES(:m,:p,:l,SYSDATE,:s,:n)",P("m",Id(c,t,"PH")),P("p",a["MaPBQD"]),P("l",Convert.ToString(r["LoaiQD"])=="KHEN_THUONG"?"CHI":"THU"),P("s",a["SoTien"]),P("n",cashier));
                return true;
            });
        }
        internal static string MakePayroll(DateTime month,int standardDays)
        {
            month=new DateTime(month.Year,month.Month,1); DateTime end=month.AddMonths(1).AddDays(-1);
            Need(standardDays>=1&&standardDays<=31,"Công chuẩn phải từ 1 đến 31.");
            return Db.Atomic((c,t)=> {
                Gate(c,t); OpenMonth(c,t,month); string bl=Id(c,t,"BL");
                var staff=Read(c,t,"SELECT n.MaNV FROM NhanVien n WHERE EXISTS(SELECT 1 FROM QDTuyenDung td WHERE td.MaNV=n.MaNV AND td.TuNgay<=:e AND td.DenNgay>=:d) OR EXISTS(SELECT 1 FROM HopDong h WHERE h.MaNV=n.MaNV AND h.TuNgay<=:e AND (h.DenNgay IS NULL OR h.DenNgay>=:d)) ORDER BY n.MaNV",P("d",month),P("e",end));
                Need(staff.Rows.Count>0,"Không có nhân viên trong kỳ.");
                Db.Exec(c,t,"INSERT INTO BangLuong(MaBL,Thang,CongChuan) VALUES(:b,:d,:c)",P("b",bl),P("d",month),P("c",standardDays));
                foreach(DataRow employee in staff.Rows) {
                    string nv=Convert.ToString(employee["MaNV"]); LockEmployee(c,t,nv);
                    decimal salary=0, allowance=0, xh=0, yt=0;
                    var hd=Read(c,t,"SELECT h.*,b.TyLeXH,b.TyLeYT FROM HopDong h LEFT JOIN HoSoBaoHiem b ON b.MaHD=h.MaHD WHERE h.MaNV=:n AND h.TuNgay<=:d AND (h.DenNgay IS NULL OR h.DenNgay>=:e)",P("n",nv),P("d",month),P("e",end));
                    if(hd.Rows.Count>0) {
                        var sal=One(c,t,"SELECT * FROM (SELECT * FROM QDLuong WHERE MaNV=:n AND HieuLuc<=:d ORDER BY HieuLuc DESC) WHERE ROWNUM=1",P("n",nv),P("d",month));
                        salary=Num(sal,"LuongCB"); allowance=Num(sal,"PCLuong")+Num(sal,"PCDocHai");
                        var pos=Read(c,t,"SELECT * FROM (SELECT * FROM QDChucVu WHERE MaNV=:n AND HieuLuc<=:d ORDER BY HieuLuc DESC) WHERE ROWNUM=1",P("n",nv),P("d",month));
                        if(pos.Rows.Count>0) allowance+=Num(pos.Rows[0],"PhuCap");
                        if(Convert.ToString(hd.Rows[0]["LoaiHD"])=="DAI_HAN") {
                            Need(hd.Rows[0]["TyLeXH"]!=DBNull.Value,"Hợp đồng dài hạn thiếu hồ sơ bảo hiểm.");
                            xh=Num(hd.Rows[0],"TyLeXH"); yt=Num(hd.Rows[0],"TyLeYT");
                        }
                    } else {
                        var trial=Read(c,t,"SELECT * FROM QDTuyenDung WHERE MaNV=:n AND TuNgay<=:d AND DenNgay>=:e",P("n",nv),P("d",month),P("e",end));
                        Need(trial.Rows.Count>0,"Tháng chuyển tiếp/chưa đủ trọn tháng của "+nv+" chưa được hỗ trợ. Không tạo bảng lương.");
                        salary=Num(trial.Rows[0],"LuongThuViec");
                    }
                    var missing=Read(c,t,"SELECT p.MaPC FROM PhanCong p LEFT JOIN ChamCong cc ON cc.MaPC=p.MaPC WHERE p.MaNV=:n AND p.NgayLam BETWEEN :d AND :e AND cc.MaCC IS NULL",P("n",nv),P("d",month),P("e",end));
                    Need(missing.Rows.Count==0,"Còn ca chưa chấm công của "+nv+".");
                    var reg=One(c,t,"SELECT NVL(SUM(cc.GioLam),0) AS Gio FROM ChamCong cc JOIN PhanCong p ON p.MaPC=cc.MaPC WHERE p.MaNV=:n AND p.NgayLam BETWEEN :d AND :e",P("n",nv),P("d",month),P("e",end));
                    var ot=One(c,t,"SELECT NVL(SUM(ct.SoGio),0) AS Gio FROM CTPhuTroi ct JOIN PhieuPhuTroi p ON p.MaPT=ct.MaPT WHERE ct.MaNV=:n AND p.NgayPT BETWEEN :d AND :e",P("n",nv),P("d",month),P("e",end));
                    var awards=Read(c,t,"SELECT b.*,q.LoaiQD FROM PhanBoQD b JOIN DoiTuongQD d ON d.MaDT=b.MaDT JOIN QuyetDinhKTKL q ON q.MaQD=d.MaQD WHERE b.MaNV=:n AND b.MaBL IS NULL AND q.TrangThai='DA_KY' AND q.CachXuLy='QUA_LUONG' AND q.NgayKy<=:e ORDER BY b.MaPBQD",P("n",nv),P("e",end));
                    decimal bonus=0,fine=0; foreach(DataRow a in awards.Rows) { if(Convert.ToString(a["LoaiQD"])=="KHEN_THUONG") bonus+=Num(a,"SoTien"); else fine+=Num(a,"SoTien"); }
                    var result=Payroll.Calculate(salary,allowance,Num(reg,"Gio"),Num(ot,"Gio"),standardDays,xh,yt,bonus,fine);
                    Db.Exec(c,t,"INSERT INTO CTLuong VALUES(:b,:n,:l,:p,:g,:o,:lc,:pt,:th,:ph,:xh,:yt,:tl)",P("b",bl),P("n",nv),P("l",salary),P("p",allowance),P("g",Num(reg,"Gio")),P("o",Num(ot,"Gio")),P("lc",result.LuongCong),P("pt",result.TienPT),P("th",bonus),P("ph",fine),P("xh",result.BHXH),P("yt",result.BHYT),P("tl",result.ThucLinh));
                    foreach(DataRow a in awards.Rows) Db.Exec(c,t,"UPDATE PhanBoQD SET MaBL=:b WHERE MaPBQD=:p",P("b",bl),P("p",a["MaPBQD"]));
                } return bl;
            });
        }
        internal static DataTable DecisionList()
        { return Db.Query("SELECT q.MaQD,q.LoaiQD,q.LyDo,q.CachXuLy,q.TrangThai,q.NguoiKy,d.MaNV,d.MaPB,d.SoTien FROM QuyetDinhKTKL q JOIN DoiTuongQD d ON d.MaQD=q.MaQD ORDER BY q.MaQD"); }
        internal static DataTable PayrollList(DateTime month)
        { return Db.Query("SELECT ct.* FROM CTLuong ct JOIN BangLuong b ON b.MaBL=ct.MaBL WHERE b.Thang=TRUNC(:d,'MM') ORDER BY ct.MaNV",P("d",month)); }
        internal static DataTable History(string nv)
        { return Db.Query("SELECT 'TUYEN_DUNG' Loai,MaQD Ma,TuNgay HieuLuc,LuongThuViec SoTien FROM QDTuyenDung WHERE MaNV=:n UNION ALL SELECT 'LUONG',MaQD,HieuLuc,LuongCB FROM QDLuong WHERE MaNV=:n UNION ALL SELECT 'CHUC_VU',MaQD,HieuLuc,PhuCap FROM QDChucVu WHERE MaNV=:n ORDER BY HieuLuc",P("n",nv)); }
    }
}
