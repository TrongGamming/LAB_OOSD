using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace QuanLyNhanSu
{
    internal static class KiemThu
    {
        static int total,passed;
        static readonly List<string> lines=new List<string>();
        static void Equal(decimal actual,decimal expected) { if(actual!=expected) throw new Exception("Mong đợi "+expected+", nhận "+actual); }
        static void Check(string name,Action test) { total++; try { test(); passed++; lines.Add("ĐẠT | "+name); } catch(Exception ex) { lines.Add("LỖI | "+name+" | "+ex.Message); } }
        static void Reject(string name,Action test) { Check(name,()=> { bool rejected=false; try { test(); } catch(ArgumentException) { rejected=true; } catch(InvalidOperationException) { rejected=true; } if(!rejected) throw new Exception("Đầu vào sai vẫn được chấp nhận."); }); }
        static decimal Scalar(string sql,params Oracle.ManagedDataAccess.Client.OracleParameter[] p) { return Convert.ToDecimal(Db.Scalar(sql,p)); }
        static void OracleReject(string name,int expected,Action test) { Check(name,()=> { try { test(); } catch(Oracle.ManagedDataAccess.Client.OracleException ex) { if(ex.Number==expected) return; throw; } throw new Exception("Ràng buộc không chặn dữ liệu sai."); }); }
        internal static int Run(string file,bool database)
        {
            total=passed=0; lines.Clear(); lines.Add("LAB07 • "+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" • "+(database?"Oracle + công thức":"công thức"));
            Check("Lương đủ 26 công, phụ cấp và hai khoản BH",()=> { var r=Payroll.Calculate(8000000,500000,208,0,26,.08m,.015m,0,0); Equal(r.LuongCong,8500000); Equal(r.BHXH,640000); Equal(r.BHYT,120000); Equal(r.ThucLinh,7740000); });
            Check("Phụ trội 1,5 cho 8 giờ",()=>Equal(Payroll.Calculate(8000000,0,0,8,26,0,0,0,0).TienPT,461538));
            Check("Công nửa tháng, thưởng và phạt",()=>Equal(Payroll.Calculate(8000000,500000,104,0,26,0,0,1000000,200000).ThucLinh,5050000));
            Check("Thử việc không BH và không công thì lương bằng 0",()=>Equal(Payroll.Calculate(6000000,0,0,0,26,0,0,0,0).ThucLinh,0));
            Reject("Từ chối công âm",()=>Payroll.Calculate(8000000,0,-1,0,26,0,0,0,0));
            Reject("Từ chối công vượt chuẩn",()=>Payroll.Calculate(8000000,0,209,0,26,0,0,0,0));
            Reject("Từ chối tổng tỷ lệ BH >= 1",()=>Payroll.Calculate(8000000,0,208,0,26,.9m,.1m,0,0));
            Reject("Từ chối công chuẩn bằng 0",()=>Payroll.Calculate(8000000,0,0,0,0,0,0,0,0));
            if(database) DatabaseCases();
            lines.Add("KẾT QUẢ: "+passed+"/"+total+" ca đạt."); File.WriteAllLines(file,lines,new UTF8Encoding(true)); return passed==total?0:1;
        }
        static void DatabaseCases()
        {
            string second=null,hd=null,assignment=null,award=null,direct=null,group=null,fine=null,bl=null;
            DateTime oct=new DateTime(DateTime.Today.Year,DateTime.Today.Month,1), nov=oct.AddMonths(1), day=oct.AddDays(4);
            Check("Kết nối Oracle và 20 bảng",()=> { Equal(Scalar("SELECT 1 FROM dual"),1); Equal(Scalar("SELECT COUNT(*) FROM user_tables"),20); });
            Reject("Không đánh giá trước hết thử việc",()=>HrService.Evaluate("NV01",true,new DateTime(2026,9,30)));
            Reject("Không ký hợp đồng khi chưa đánh giá đạt",()=>HrService.Contract("NV01","DAI_HAN",oct,null,8000000,500000,0,"CV01",0,"Điều khoản","Giám đốc","XH01","YT01",.08m,.015m));
            Check("Đánh giá đạt sau thời gian thử việc",()=>HrService.Evaluate("NV01",true,oct));
            Reject("Dài hạn thiếu BHYT không được lưu",()=>HrService.Contract("NV01","DAI_HAN",oct,null,8000000,500000,0,"CV01",0,"Điều khoản","Giám đốc","XH01","",.08m,.015m));
            Check("Ký dài hạn: tạo hợp đồng, BH và hai quyết định nguyên tử",()=> {
                hd=HrService.Contract("NV01","DAI_HAN",oct,null,8000000,500000,0,"CV01",0,"Điều khoản","Giám đốc","XH01","YT01",.08m,.015m);
                Equal(Scalar("SELECT COUNT(*) FROM HoSoBaoHiem WHERE MaHD=:h",Db.P("h",hd)),1);
                Equal(Scalar("SELECT COUNT(*) FROM QDLuong WHERE MaNV='NV01'"),1); Equal(Scalar("SELECT COUNT(*) FROM QDChucVu WHERE MaNV='NV01'"),1);
            });
            Reject("Không ký hợp đồng chồng thời gian",()=>HrService.Contract("NV01","NGAN_HAN",nov,nov.AddMonths(6),8000000,0,0,"CV01",0,"Điều khoản","Giám đốc","","",0,0));
            Check("Tuyển nhân viên thứ hai + quyết định thử việc",()=> { second=HrService.Recruit("Trần Bình",new DateTime(2001,1,1),"000000000002","0900000002","TP.HCM","PB02",new DateTime(2026,9,1),new DateTime(2026,9,30),6000000,"Điều khoản","Giám đốc"); Equal(Scalar("SELECT COUNT(*) FROM QDTuyenDung WHERE MaNV=:n",Db.P("n",second)),1); });
            Check("Ký ngắn hạn không bắt buộc BH",()=> { HrService.Evaluate(second,true,oct); HrService.Contract(second,"NGAN_HAN",oct,oct.AddMonths(12).AddDays(-1),7000000,0,0,"CV01",0,"Điều khoản","Giám đốc","","",0,0); });
            Check("Tăng lương và bổ nhiệm lưu lịch sử tháng sau",()=> { HrService.Salary("NV01",nov,9000000,500000,100000,"Giám đốc"); HrService.Position("NV01","CV02",nov,1000000,"Giám đốc"); Equal(Scalar("SELECT COUNT(*) FROM QDLuong WHERE MaNV='NV01'"),2); });
            Reject("Quyết định hiệu lực giữa tháng bị từ chối",()=>HrService.Salary("NV01",nov.AddDays(2),9000000,0,0,"Giám đốc"));
            Check("Lập kế hoạch tuần và phân công",()=>assignment=HrService.Schedule("NV01",day,"CA01",2,"Trưởng phòng"));
            Reject("Giờ công vượt ca bị từ chối",()=>HrService.Attendance(assignment,9,"Ban chấm công"));
            Reject("Không chốt khi còn ca chưa chấm",()=>HrService.MakePayroll(oct,26));
            Check("Lỗi chốt lương rollback toàn bộ bảng lương",()=>Equal(Scalar("SELECT COUNT(*) FROM BangLuong"),0));
            Check("Chấm công theo phân công",()=>HrService.Attendance(assignment,8,"Ban chấm công"));
            Check("Phiếu phụ trội có chi tiết nhân viên",()=> { string p=HrService.Overtime(day,"NGAY_LE",new[]{"NV01"},2,"Ban chấm công"); Equal(Scalar("SELECT SoGio FROM CTPhuTroi WHERE MaPT=:p",Db.P("p",p)),2); });
            Reject("Phụ trội cộng dồn vượt kế hoạch bị từ chối",()=>HrService.Overtime(day,"TANG_CA",new[]{"NV01"},1,"Ban chấm công"));
            Check("Lập thưởng cá nhân dự thảo",()=>award=HrService.Decision("KHEN_THUONG","Thành tích cá nhân","QUA_LUONG",false,"NV01",1000000));
            Reject("Không chi quyết định chưa ký",()=>HrService.Settle(award,"Thủ quỹ"));
            Check("Giám đốc ký và chốt phân bổ cá nhân",()=> { HrService.SignDecision(award,"Giám đốc"); Equal(Scalar("SELECT SUM(b.SoTien) FROM PhanBoQD b JOIN DoiTuongQD d ON d.MaDT=b.MaDT WHERE d.MaQD=:q",Db.P("q",award)),1000000); });
            Reject("Không ký lại quyết định",()=>HrService.SignDecision(award,"Giám đốc"));
            Check("Thưởng tập thể chia đều cho hai nhân viên",()=> { group=HrService.Decision("KHEN_THUONG","Thưởng tập thể","QUA_LUONG",true,"PB02",2000001); HrService.SignDecision(group,"Giám đốc"); Equal(Scalar("SELECT SUM(b.SoTien) FROM PhanBoQD b JOIN DoiTuongQD d ON d.MaDT=b.MaDT WHERE d.MaQD=:q",Db.P("q",group)),2000001); Equal(Scalar("SELECT COUNT(*) FROM PhanBoQD b JOIN DoiTuongQD d ON d.MaDT=b.MaDT WHERE d.MaQD=:q",Db.P("q",group)),2); });
            Check("Kỷ luật cá nhân qua lương",()=> { fine=HrService.Decision("KY_LUAT","Vi phạm nội quy","QUA_LUONG",false,"NV01",200000); HrService.SignDecision(fine,"Giám đốc"); });
            Check("Thưởng trực tiếp tạo phiếu chi",()=> { direct=HrService.Decision("KHEN_THUONG","Thưởng ngày lễ","TRUC_TIEP",false,"NV01",300000); HrService.SignDecision(direct,"Giám đốc"); HrService.Settle(direct,"Thủ quỹ"); Equal(Scalar("SELECT COUNT(*) FROM PhieuThuChi WHERE LoaiPhieu='CHI'"),1); });
            OracleReject("Không chi cùng phân bổ hai lần",1,()=>HrService.Settle(direct,"Thủ quỹ"));
            Check("Phạt tập thể trực tiếp tạo phiếu thu từng người",()=> { string q=HrService.Decision("KY_LUAT","Vi phạm tập thể","TRUC_TIEP",true,"PB02",100000); HrService.SignDecision(q,"Giám đốc"); HrService.Settle(q,"Thủ quỹ"); Equal(Scalar("SELECT COUNT(*) FROM PhieuThuChi WHERE LoaiPhieu='THU'"),2); });
            Check("Lập lương tháng: lương công + PT + thưởng - phạt - BH",()=> {
                bl=HrService.MakePayroll(oct,26); DataTable rows=HrService.PayrollList(oct); Equal(rows.Rows.Count,2);
                var r=rows.Select("MaNV='NV01'")[0]; Equal(Convert.ToDecimal(r["TienThuong"]),2000000.5m); Equal(Convert.ToDecimal(r["TienPhat"]),200000); Equal(Convert.ToDecimal(r["BHXH"]),640000); Equal(Convert.ToDecimal(r["BHYT"]),120000);
                Equal(Convert.ToDecimal(r["ThucLinh"]),1482308.5m);
                Equal(Scalar("SELECT COUNT(*) FROM PhanBoQD WHERE MaBL=:b",Db.P("b",bl)),4);
            });
            Reject("Không lập trùng lương tháng",()=>HrService.MakePayroll(oct,26));
            Reject("Không sửa công tháng đã khóa",()=>HrService.Schedule("NV01",day.AddDays(1),"CA01",0,"Trưởng phòng"));
            Reject("Không thêm quyết định lương tháng đã khóa",()=>HrService.Salary("NV01",oct,10000000,0,0,"Giám đốc"));
            Check("Lương tháng sau dùng mức mới và không thưởng hai lần",()=> { HrService.MakePayroll(nov,26); var r=HrService.PayrollList(nov).Select("MaNV='NV01'")[0]; Equal(Convert.ToDecimal(r["LuongCB"]),9000000); Equal(Convert.ToDecimal(r["PhuCap"]),1600000); Equal(Convert.ToDecimal(r["TienThuong"]),0); });
            Check("Tra cứu tên tiếng Việt và lịch sử quyết định",()=> { Equal(HrService.Employees("Nguyễn An").Rows.Count,1); Equal(HrService.History("NV01").Rows.Count,5); });
        }
    }
}
