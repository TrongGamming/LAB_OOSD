using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    internal sealed class MainForm : Form
    {
        readonly TabControl tabs=new TabControl { Dock=DockStyle.Fill };
        readonly Label status=new Label { Dock=DockStyle.Bottom,Height=34,Text="Sẵn sàng • Hãy chọn chức năng. Dữ liệu chỉ lưu khi bấm nút xác nhận.",Padding=new Padding(12,8,0,0),BackColor=Color.FromArgb(229,239,244) };
        readonly List<Action> reload=new List<Action>();
        static TextBox Input(string value="") { return new TextBox { Text=value }; }
        static DateTimePicker Date(DateTime value) { return new DateTimePicker { Format=DateTimePickerFormat.Custom,CustomFormat="dd/MM/yyyy",Value=value }; }
        static NumericUpDown Money(decimal value=0,decimal max=1000000000) { return new NumericUpDown { Maximum=max,Minimum=0,Value=value,ThousandsSeparator=true,DecimalPlaces=2,Increment=100000 }; }
        static ComboBox Combo()
        {
            var c=new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList,DrawMode=DrawMode.OwnerDrawFixed,ItemHeight=22 };
            c.DrawItem+=(s,e)=> { e.DrawBackground(); if(e.Index>=0) TextRenderer.DrawText(e.Graphics,c.GetItemText(c.Items[e.Index]),c.Font,e.Bounds,e.ForeColor,TextFormatFlags.Left|TextFormatFlags.VerticalCenter); e.DrawFocusRectangle(); }; return c;
        }
        static ComboBox Options(params string[] items) { var c=Combo(); c.Items.AddRange(items); c.SelectedIndex=0; return c; }
        ComboBox Lookup(string sql)
        {
            var combo=Combo();
            Action load=()=> { var d=Db.Query(sql); combo.DisplayMember=d.Columns[1].ColumnName; combo.ValueMember=d.Columns[0].ColumnName; combo.DataSource=d; };
            combo.DropDown+=(s,e)=>Safe(load); reload.Add(load); return combo;
        }
        static string Selected(ComboBox c) { return c.SelectedValue==null?"":Convert.ToString(c.SelectedValue); }
        static string Choice(ComboBox c) { return Convert.ToString(c.SelectedItem); }
        void Safe(Action action)
        {
            Cursor=Cursors.WaitCursor;
            try { action(); status.Text="Thao tác hoàn tất lúc "+DateTime.Now.ToString("HH:mm:ss"); }
            catch(Oracle.ManagedDataAccess.Client.OracleException ex) {
                string message=ex.Number==1?"Dữ liệu trùng hoặc thao tác đã thực hiện trước đó.":ex.Number==2291?"Mã tham chiếu chưa tồn tại. Hãy kiểm tra lại.":"Lỗi Oracle: "+ex.Message;
                status.Text=message; MessageBox.Show(this,message,"Không thể thực hiện",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch(Exception ex) { status.Text=ex.Message; MessageBox.Show(this,ex.Message,"Kiểm tra thông tin",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            finally { Cursor=Cursors.Default; }
        }
        sealed class Pane
        {
            internal FlowLayoutPanel Fields;
            internal DataGridView Grid;
        }
        Pane Page(string name,string hint)
        {
            var page=new TabPage(name) { BackColor=Color.White };
            var panel=new SplitContainer { Size=new Size(1250,700),Dock=DockStyle.Fill,FixedPanel=FixedPanel.Panel1,SplitterDistance=485,Panel1MinSize=460 };
            var fields=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,WrapContents=false,AutoScroll=true,Padding=new Padding(12) };
            fields.Controls.Add(new Label { Text=hint,Width=430,Height=58,ForeColor=Color.FromArgb(30,75,100) });
            var grid=new DataGridView { Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.DisplayedCells,BackgroundColor=Color.White,RowHeadersVisible=false,SelectionMode=DataGridViewSelectionMode.FullRowSelect,MultiSelect=false };
            panel.Panel1.Controls.Add(fields); panel.Panel2.Controls.Add(grid); page.Controls.Add(panel); tabs.TabPages.Add(page);
            return new Pane { Fields=fields,Grid=grid };
        }
        static void Field(Pane p,string label,Control input)
        {
            var row=new Panel { Width=435,Height=35 };
            row.Controls.Add(new Label { Text=label,Width=165,Top=7,Height=25 }); input.SetBounds(170,2,250,28); input.AccessibleName=label; row.Controls.Add(input); p.Fields.Controls.Add(row);
        }
        void Button(Pane p,string title,Action action)
        {
            var button=new Button { Text=title,Width=420,Height=36,BackColor=Color.FromArgb(25,90,120),ForeColor=Color.White,FlatStyle=FlatStyle.Flat,Margin=new Padding(0,7,0,3) };
            button.Click+=(s,e)=>Safe(action); p.Fields.Controls.Add(button);
        }
        static void Notice(string text) { MessageBox.Show(text,"Đã lưu",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        public MainForm()
        {
            Text="LAB 07 • QUẢN LÝ NHÂN SỰ CÔNG TY SƠN ĐÔNG Á"; Size=new Size(1280,840); MinimumSize=new Size(1100,700);
            StartPosition=FormStartPosition.CenterScreen; Font=new Font("Segoe UI",10);
            var header=new Label { Dock=DockStyle.Top,Height=56,Text="ĐÔNG Á  /  Quản lý nhân sự",Font=new Font("Segoe UI",19,FontStyle.Bold),Padding=new Padding(16,10,0,0),ForeColor=Color.White,BackColor=Color.FromArgb(18,57,77) };
            Controls.Add(tabs); Controls.Add(status); Controls.Add(header);
            Recruitment(); Contracts(); Changes(); Timekeeping(); Awards(); Salaries(); Search();
            Shown+=(s,e)=> { try { foreach(var load in reload) load(); status.Text="Đã kết nối Oracle • Chọn một tab để bắt đầu."; } catch(Exception ex) { status.Text="Chưa kết nối Oracle: "+ex.Message+" • Kiểm tra App.config hoặc LAB07_CONNECTION."; } };
        }
        void Recruitment()
        {
            var p=Page("1. Tuyển dụng","Nhập nhân viên và quyết định thử việc. Đánh giá sau ngày kết thúc thử việc.");
            var name=Input(); var birth=Date(new DateTime(2000,1,1)); var cccd=Input(); var phone=Input(); var address=Input();
            var pb=Lookup("SELECT MaPB,TenPB FROM PhongBan ORDER BY MaPB");
            var from=Date(new DateTime(2026,11,1)); var to=Date(new DateTime(2026,11,30)); var pay=Money(6000000); var terms=Input("Thử việc và đánh giá theo thỏa thuận hai bên."); var signer=Input("Giám đốc");
            Field(p,"Họ và tên *",name); Field(p,"Ngày sinh *",birth); Field(p,"CCCD (12 số) *",cccd); Field(p,"Điện thoại",phone); Field(p,"Địa chỉ",address); Field(p,"Phòng ban *",pb);
            Field(p,"Bắt đầu thử việc *",from); Field(p,"Kết thúc thử việc *",to); Field(p,"Lương thử việc *",pay); Field(p,"Điều khoản *",terms); Field(p,"Người ký *",signer);
            Button(p,"Lưu nhân viên & quyết định tuyển dụng",()=> { string nv=HrService.Recruit(name.Text,birth.Value,cccd.Text,phone.Text,address.Text,Selected(pb),from.Value,to.Value,pay.Value,terms.Text,signer.Text); p.Grid.DataSource=HrService.Employees(nv); Notice("Mã nhân viên: "+nv); });
            var employee=Input("NV01"); var result=Options("DAT","KHONG_DAT"); var date=Date(DateTime.Today);
            Field(p,"Mã NV đánh giá *",employee); Field(p,"Kết quả *",result); Field(p,"Ngày đánh giá *",date);
            Button(p,"Xác nhận kết quả thử việc",()=> { HrService.Evaluate(employee.Text,Choice(result)=="DAT",date.Value); p.Grid.DataSource=HrService.Employees(employee.Text); });
        }
        void Contracts()
        {
            var p=Page("2. Hợp đồng & BH","Chỉ ký sau thử việc đạt. Hợp đồng dài hạn bắt buộc có cả BHXH và BHYT. Tỷ lệ là giả định cấu hình của lab.");
            var nv=Input("NV01"); var type=Options("DAI_HAN","NGAN_HAN"); var from=Date(new DateTime(2026,10,1)); var to=Date(new DateTime(2027,9,30)); var hasEnd=new CheckBox { Text="Có ngày hết hạn",Checked=false };
            var salary=Money(8000000); var pc=Money(500000); var hazard=Money(); var cv=Lookup("SELECT MaCV,TenCV FROM ChucVu ORDER BY MaCV"); var pccv=Money(); var terms=Input("Thỏa thuận công việc, quyền và nghĩa vụ hai bên."); var signer=Input("Giám đốc"); var xh=Input(); var yt=Input(); var rx=Money(.08m,1); rx.Increment=.001m; rx.DecimalPlaces=3; var ry=Money(.015m,1); ry.Increment=.001m; ry.DecimalPlaces=3;
            Field(p,"Mã nhân viên *",nv); Field(p,"Loại hợp đồng *",type); Field(p,"Hiệu lực đầu tháng *",from); Field(p,"Hết hạn?",hasEnd); Field(p,"Ngày hết hạn",to);
            Field(p,"Lương cơ bản *",salary); Field(p,"Phụ cấp lương",pc); Field(p,"Phụ cấp độc hại",hazard); Field(p,"Chức vụ *",cv); Field(p,"Phụ cấp chức vụ",pccv); Field(p,"Điều khoản *",terms); Field(p,"Người ký *",signer);
            Field(p,"Số BHXH (dài hạn)",xh); Field(p,"Số BHYT (dài hạn)",yt); Field(p,"Tỷ lệ BHXH (0..1)",rx); Field(p,"Tỷ lệ BHYT (0..1)",ry);
            Button(p,"Ký hợp đồng, lập quyết định & hồ sơ BH",()=> { string hd=HrService.Contract(nv.Text,Choice(type),from.Value,hasEnd.Checked?(DateTime?)to.Value:null,salary.Value,pc.Value,hazard.Value,Selected(cv),pccv.Value,terms.Text,signer.Text,xh.Text,yt.Text,rx.Value,ry.Value); p.Grid.DataSource=Db.Query("SELECT MaHD,MaNV,LoaiHD,TuNgay,DenNgay FROM HopDong"); Notice("Hợp đồng: "+hd); });
        }
        void Changes()
        {
            var p=Page("3. Lương & chức vụ","Lập quyết định mới để giữ lịch sử tăng lương/bổ nhiệm. Hiệu lực đầu tháng chưa khóa lương.");
            var nv=Input("NV01"); var date=Date(new DateTime(2026,11,1)); var pay=Money(9000000); var pc=Money(500000); var hazard=Money(); var signer=Input("Giám đốc");
            Field(p,"Mã nhân viên *",nv); Field(p,"Ngày hiệu lực *",date); Field(p,"Người ký *",signer); Field(p,"Lương cơ bản *",pay); Field(p,"Phụ cấp lương",pc); Field(p,"Phụ cấp độc hại",hazard);
            Button(p,"Ban hành quyết định lương mới",()=> { HrService.Salary(nv.Text,date.Value,pay.Value,pc.Value,hazard.Value,signer.Text); p.Grid.DataSource=HrService.History(nv.Text); });
            var cv=Lookup("SELECT MaCV,TenCV FROM ChucVu ORDER BY MaCV"); var pccv=Money(1000000);
            Field(p,"Chức vụ *",cv); Field(p,"Phụ cấp chức vụ",pccv);
            Button(p,"Ban hành quyết định chức vụ mới",()=> { HrService.Position(nv.Text,Selected(cv),date.Value,pccv.Value,signer.Text); p.Grid.DataSource=HrService.History(nv.Text); });
            Button(p,"Xem lịch sử quyết định",()=>p.Grid.DataSource=HrService.History(nv.Text));
        }
        void Timekeeping()
        {
            var p=Page("4. Công & phụ trội","Trưởng phòng lập phân công theo tuần; ban chấm công ghi giờ thực tế. Một phiếu phụ trội có thể gồm nhiều NV (phân cách bằng dấu phẩy).");
            var nv=Input("NV01"); var date=Date(new DateTime(2026,10,5)); var ca=Lookup("SELECT MaCa,TenCa FROM CaLam ORDER BY MaCa"); var plan=Money(2,16); plan.Increment=1; var planner=Input("Trưởng phòng"); var pc=Input();
            Field(p,"Mã NV phân công *",nv); Field(p,"Ngày làm *",date); Field(p,"Ca làm *",ca); Field(p,"Giờ PT dự kiến",plan); Field(p,"Người lập kế hoạch *",planner);
            Button(p,"Lưu phân công vào kế hoạch tuần",()=> { pc.Text=HrService.Schedule(nv.Text,date.Value,Selected(ca),plan.Value,planner.Text); p.Grid.DataSource=Db.Query("SELECT * FROM PhanCong ORDER BY NgayLam DESC"); });
            var hours=Money(8,8); hours.Increment=1; var recorder=Input("Ban chấm công"); Field(p,"Mã phân công *",pc); Field(p,"Giờ làm thực tế *",hours); Field(p,"Người chấm *",recorder);
            Button(p,"Ghi nhận chấm công",()=> { HrService.Attendance(pc.Text,hours.Value,recorder.Text); p.Grid.DataSource=Db.Query("SELECT * FROM ChamCong"); });
            var list=Input("NV01"); var kind=Options("TANG_CA","NGAY_LE","NGAY_NGHI"); var ot=Money(2,16); ot.Increment=1;
            Field(p,"DS mã NV phụ trội *",list); Field(p,"Hình thức *",kind); Field(p,"Giờ PT mỗi NV *",ot);
            Button(p,"Lập phiếu phụ trội (ngày làm ở trên)",()=> { string id=HrService.Overtime(date.Value,Choice(kind),list.Text.Split(',').Select(x=>x.Trim()).Where(x=>x!="").ToArray(),ot.Value,recorder.Text); p.Grid.DataSource=Db.Query("SELECT p.MaPT,p.NgayPT,p.HinhThuc,c.MaNV,c.SoGio FROM PhieuPhuTroi p JOIN CTPhuTroi c ON c.MaPT=p.MaPT"); Notice("Phiếu: "+id); });
        }
        void Awards()
        {
            var p=Page("5. Thưởng & kỷ luật","Lập dự thảo → giám đốc ký → xử lý trực tiếp hoặc qua lương. Thưởng tập thể chia đều, lưu người nhận tại thời điểm ký.");
            var type=Options("KHEN_THUONG","KY_LUAT"); var reason=Input("Thành tích công tác"); var method=Options("QUA_LUONG","TRUC_TIEP"); var scope=Options("CA_NHAN","PHONG_BAN"); var target=Input("NV01"); var amount=Money(1000000); var qd=Input(); var signer=Input("Giám đốc"); var cashier=Input("Thủ quỹ");
            Field(p,"Loại quyết định *",type); Field(p,"Lý do *",reason); Field(p,"Cách xử lý tiền *",method); Field(p,"Đối tượng *",scope); Field(p,"Mã NV / mã phòng *",target); Field(p,"Tổng tiền đối tượng *",amount);
            Button(p,"1. Lưu dự thảo quyết định",()=> { qd.Text=HrService.Decision(Choice(type),reason.Text,Choice(method),Choice(scope)=="PHONG_BAN",target.Text,amount.Value); p.Grid.DataSource=HrService.DecisionList(); });
            Field(p,"Mã quyết định *",qd); Field(p,"Giám đốc ký *",signer);
            Button(p,"2. Ký & chốt danh sách phân bổ",()=> { HrService.SignDecision(qd.Text,signer.Text); p.Grid.DataSource=HrService.DecisionList(); });
            Field(p,"Người thu / chi *",cashier);
            Button(p,"3. Xác nhận đã thu / chi trực tiếp",()=> { if(MessageBox.Show(this,"Xác nhận tiền đã được thu/chi thực tế?","Xác nhận thu chi",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes) return; HrService.Settle(qd.Text,cashier.Text); p.Grid.DataSource=Db.Query("SELECT * FROM PhieuThuChi"); });
            Button(p,"Xem các quyết định",()=>p.Grid.DataSource=HrService.DecisionList());
            Button(p,"Xem phân bổ & tháng đã tính lương",()=>p.Grid.DataSource=Db.Query("SELECT * FROM PhanBoQD ORDER BY MaPBQD"));
        }
        void Salaries()
        {
            var p=Page("6. Bảng lương","Lập và khóa cả tháng trong một giao dịch. Chỉ hỗ trợ kỳ trọn tháng. Phụ trội = lương giờ cơ bản × giờ PT × 1,5. BH tính trên lương cơ bản.");
            var date=Date(new DateTime(2026,10,1)); var days=Money(26,31); days.DecimalPlaces=0; days.Minimum=1; days.Increment=1; Field(p,"Tháng tính lương *",date); Field(p,"Số ngày công chuẩn *",days);
            Button(p,"Lập & khóa bảng lương tháng",()=> { if(MessageBox.Show(this,"Khóa bảng lương tháng này? Không thể ghi thêm công/quyết định lương vào tháng đã khóa.","Chốt lương",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes) return; string bl=HrService.MakePayroll(date.Value,(int)days.Value); p.Grid.DataSource=HrService.PayrollList(date.Value); Notice("Đã lập "+bl); });
            Button(p,"Xem bảng lương",()=>p.Grid.DataSource=HrService.PayrollList(date.Value));
            Button(p,"Xuất bảng đang xem ra CSV",()=> { NeedGrid(p.Grid); using(var dlg=new SaveFileDialog { Filter="CSV UTF-8|*.csv",FileName="BangLuong_"+date.Value.ToString("yyyyMM")+".csv" }) if(dlg.ShowDialog()==DialogResult.OK) Export((DataTable)p.Grid.DataSource,dlg.FileName); });
        }
        static void NeedGrid(DataGridView grid) { if(!(grid.DataSource is DataTable)) throw new InvalidOperationException("Hãy xem bảng lương trước khi xuất."); }
        static void Export(DataTable table,string path)
        {
            Func<object,string> quote=v=>"\""+Convert.ToString(v).Replace("\"","\"\"")+"\"";
            var lines=new List<string> { string.Join(",",table.Columns.Cast<DataColumn>().Select(c=>quote(c.ColumnName))) };
            lines.AddRange(table.Rows.Cast<DataRow>().Select(r=>string.Join(",",r.ItemArray.Select(quote)))); File.WriteAllLines(path,lines,new System.Text.UTF8Encoding(true));
        }
        void Search()
        {
            var p=Page("7. Tra cứu & danh mục","Tra cứu nhân viên theo mã hoặc tên, xem lịch sử. Danh mục phòng ban/chức vụ/ca làm được bảo trì bằng SQL trong bản lab.");
            var keyword=Input(); var nv=Input("NV01"); Field(p,"Mã / tên nhân viên",keyword); Button(p,"Tìm nhân viên",()=>p.Grid.DataSource=HrService.Employees(keyword.Text)); Field(p,"Mã NV xem lịch sử",nv); Button(p,"Xem quyết định của nhân viên",()=>p.Grid.DataSource=HrService.History(nv.Text));
            Button(p,"Phòng ban",()=>p.Grid.DataSource=Db.Query("SELECT * FROM PhongBan")); Button(p,"Chức vụ",()=>p.Grid.DataSource=Db.Query("SELECT * FROM ChucVu")); Button(p,"Ca làm",()=>p.Grid.DataSource=Db.Query("SELECT * FROM CaLam"));
            reload.Add(()=>p.Grid.DataSource=HrService.Employees(""));
        }
        internal static void CaptureScreens(string directory)
        {
            Directory.CreateDirectory(directory);
            using(var form=new MainForm()) {
                form.Show(); Application.DoEvents();
                for(int i=0;i<form.tabs.TabCount;i++) {
                    form.tabs.SelectedIndex=i; Application.DoEvents();
                    var grid=form.tabs.TabPages[i].Controls[0] as SplitContainer;
                    if(grid!=null) {
                        var view=grid.Panel2.Controls[0] as DataGridView;
                        if(i==0||i==1) view.DataSource=HrService.Employees("");
                        if(i==2) view.DataSource=HrService.History("NV01");
                        if(i==3) view.DataSource=Db.Query("SELECT p.MaNV,p.NgayLam,cc.GioLam FROM PhanCong p JOIN ChamCong cc ON cc.MaPC=p.MaPC");
                        if(i==4) view.DataSource=HrService.DecisionList();
                        if(i==5) view.DataSource=HrService.PayrollList(new DateTime(2026,10,1));
                    }
                    Application.DoEvents(); using(var bitmap=new Bitmap(form.Width,form.Height)) {
                        form.DrawToBitmap(bitmap,new Rectangle(Point.Empty,bitmap.Size));
                        // Native ComboBox text is omitted by WM_PRINT/DrawToBitmap.
                        // Render the actual selected value at the control's coordinates.
                        using(var graphics=Graphics.FromImage(bitmap)) PaintComboText(form,form,graphics);
                        bitmap.Save(Path.Combine(directory,"Tab"+(i+1)+".png"));
                    }
                } form.Close();
            }
        }
        static void PaintComboText(Control parent,Form form,Graphics graphics)
        {
            foreach(Control child in parent.Controls) {
                var combo=child as ComboBox;
                if(combo!=null&&combo.Visible&&combo.SelectedIndex>=0) {
                    Point pos=form.PointToClient(combo.PointToScreen(Point.Empty));
                    pos.Offset(form.PointToScreen(Point.Empty).X-form.Left,form.PointToScreen(Point.Empty).Y-form.Top);
                    var rect=new Rectangle(pos.X+4,pos.Y+2,combo.Width-26,combo.Height-4);
                    graphics.FillRectangle(Brushes.White,rect); TextRenderer.DrawText(graphics,combo.GetItemText(combo.SelectedItem),combo.Font,rect,Color.Black,TextFormatFlags.Left|TextFormatFlags.VerticalCenter);
                }
                PaintComboText(child,form,graphics);
            }
        }
    }
}
