namespace ThuVienSo.Forms
{
    partial class FrmDocGia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpDocGia = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.grpThe = new System.Windows.Forms.GroupBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.dtNgayCap = new System.Windows.Forms.DateTimePicker();
            this.lblHanDung = new System.Windows.Forms.Label();
            this.dtHanDung = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThaiThe = new System.Windows.Forms.Label();
            this.txtTrangThaiThe = new System.Windows.Forms.TextBox();
            this.btnCapThe = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnKhoaThe = new System.Windows.Forms.Button();
            this.btnBaoMat = new System.Windows.Forms.Button();
            this.lblGhiChuThe = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.grpDocGia.SuspendLayout();
            this.grpThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDocGia
            // 
            this.grpDocGia.Controls.Add(this.lblMa);
            this.grpDocGia.Controls.Add(this.txtMa);
            this.grpDocGia.Controls.Add(this.lblLoai);
            this.grpDocGia.Controls.Add(this.cboLoai);
            this.grpDocGia.Controls.Add(this.lblHoTen);
            this.grpDocGia.Controls.Add(this.txtHoTen);
            this.grpDocGia.Controls.Add(this.lblDonVi);
            this.grpDocGia.Controls.Add(this.txtDonVi);
            this.grpDocGia.Controls.Add(this.lblEmail);
            this.grpDocGia.Controls.Add(this.txtEmail);
            this.grpDocGia.Controls.Add(this.lblSDT);
            this.grpDocGia.Controls.Add(this.txtSDT);
            this.grpDocGia.Controls.Add(this.lblNgaySinh);
            this.grpDocGia.Controls.Add(this.dtNgaySinh);
            this.grpDocGia.Location = new System.Drawing.Point(12, 8);
            this.grpDocGia.Name = "grpDocGia";
            this.grpDocGia.Size = new System.Drawing.Size(620, 214);
            this.grpDocGia.Text = "Thông tin độc giả";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(14, 32);
            this.lblMa.Name = "lblMa";
            this.lblMa.Text = "Mã độc giả";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(110, 28);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(110, 25);
            this.txtMa.MaxLength = 10;
            this.txtMa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa.ReadOnly = true;
            this.txtMa.TabIndex = 2;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(240, 32);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Text = "Loại";
            // 
            // cboLoai
            // 
            this.cboLoai.Location = new System.Drawing.Point(290, 28);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(150, 25);
            this.cboLoai.Enabled = false;
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.TabIndex = 4;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(14, 68);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(110, 64);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(490, 25);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.TabIndex = 6;
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Location = new System.Drawing.Point(14, 104);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Text = "Đơn vị";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(110, 100);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(490, 25);
            this.txtDonVi.MaxLength = 100;
            this.txtDonVi.ReadOnly = true;
            this.txtDonVi.TabIndex = 8;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 140);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 25);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.ReadOnly = true;
            this.txtEmail.TabIndex = 10;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(404, 140);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Text = "SĐT";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(450, 136);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(150, 25);
            this.txtSDT.MaxLength = 15;
            this.txtSDT.ReadOnly = true;
            this.txtSDT.TabIndex = 12;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(14, 176);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Location = new System.Drawing.Point(110, 172);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(150, 25);
            this.dtNgaySinh.ShowCheckBox = true;
            this.dtNgaySinh.Enabled = false;
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.TabIndex = 14;
            // 
            // grpThe
            // 
            this.grpThe.Controls.Add(this.lblMaThe);
            this.grpThe.Controls.Add(this.txtMaThe);
            this.grpThe.Controls.Add(this.lblNgayCap);
            this.grpThe.Controls.Add(this.dtNgayCap);
            this.grpThe.Controls.Add(this.lblHanDung);
            this.grpThe.Controls.Add(this.dtHanDung);
            this.grpThe.Controls.Add(this.lblTrangThaiThe);
            this.grpThe.Controls.Add(this.txtTrangThaiThe);
            this.grpThe.Controls.Add(this.btnCapThe);
            this.grpThe.Controls.Add(this.btnGiaHan);
            this.grpThe.Controls.Add(this.btnKhoaThe);
            this.grpThe.Controls.Add(this.btnBaoMat);
            this.grpThe.Controls.Add(this.lblGhiChuThe);
            this.grpThe.Location = new System.Drawing.Point(644, 8);
            this.grpThe.Name = "grpThe";
            this.grpThe.Size = new System.Drawing.Size(464, 214);
            this.grpThe.Text = "Thẻ thư viện";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(14, 32);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Text = "Mã thẻ";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(100, 28);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(180, 25);
            this.txtMaThe.ReadOnly = true;
            this.txtMaThe.TabIndex = 17;
            // 
            // lblNgayCap
            // 
            this.lblNgayCap.AutoSize = true;
            this.lblNgayCap.Location = new System.Drawing.Point(14, 68);
            this.lblNgayCap.Name = "lblNgayCap";
            this.lblNgayCap.Text = "Ngày cấp";
            // 
            // dtNgayCap
            // 
            this.dtNgayCap.Location = new System.Drawing.Point(100, 64);
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(180, 25);
            this.dtNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayCap.CustomFormat = "dd/MM/yyyy";
            this.dtNgayCap.TabIndex = 19;
            // 
            // lblHanDung
            // 
            this.lblHanDung.AutoSize = true;
            this.lblHanDung.Location = new System.Drawing.Point(14, 104);
            this.lblHanDung.Name = "lblHanDung";
            this.lblHanDung.Text = "Hạn dùng";
            // 
            // dtHanDung
            // 
            this.dtHanDung.Location = new System.Drawing.Point(100, 100);
            this.dtHanDung.Name = "dtHanDung";
            this.dtHanDung.Size = new System.Drawing.Size(180, 25);
            this.dtHanDung.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHanDung.CustomFormat = "dd/MM/yyyy";
            this.dtHanDung.TabIndex = 21;
            // 
            // lblTrangThaiThe
            // 
            this.lblTrangThaiThe.AutoSize = true;
            this.lblTrangThaiThe.Location = new System.Drawing.Point(14, 140);
            this.lblTrangThaiThe.Name = "lblTrangThaiThe";
            this.lblTrangThaiThe.Text = "Trạng thái";
            // 
            // txtTrangThaiThe
            // 
            this.txtTrangThaiThe.Location = new System.Drawing.Point(100, 136);
            this.txtTrangThaiThe.Name = "txtTrangThaiThe";
            this.txtTrangThaiThe.Size = new System.Drawing.Size(180, 25);
            this.txtTrangThaiThe.ReadOnly = true;
            this.txtTrangThaiThe.TabIndex = 23;
            // 
            // btnCapThe
            // 
            this.btnCapThe.Location = new System.Drawing.Point(298, 26);
            this.btnCapThe.Name = "btnCapThe";
            this.btnCapThe.Size = new System.Drawing.Size(150, 30);
            this.btnCapThe.TabIndex = 24;
            this.btnCapThe.Text = "Cấp thẻ mới";
            this.btnCapThe.Click += new System.EventHandler(this.btnCapThe_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(298, 62);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(150, 30);
            this.btnGiaHan.TabIndex = 25;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnKhoaThe
            // 
            this.btnKhoaThe.Location = new System.Drawing.Point(298, 98);
            this.btnKhoaThe.Name = "btnKhoaThe";
            this.btnKhoaThe.Size = new System.Drawing.Size(150, 30);
            this.btnKhoaThe.TabIndex = 26;
            this.btnKhoaThe.Text = "Khóa thẻ";
            this.btnKhoaThe.Click += new System.EventHandler(this.btnKhoaThe_Click);
            // 
            // btnBaoMat
            // 
            this.btnBaoMat.Location = new System.Drawing.Point(298, 134);
            this.btnBaoMat.Name = "btnBaoMat";
            this.btnBaoMat.Size = new System.Drawing.Size(150, 30);
            this.btnBaoMat.TabIndex = 27;
            this.btnBaoMat.Text = "Báo mất thẻ";
            this.btnBaoMat.Click += new System.EventHandler(this.btnBaoMat_Click);
            // 
            // lblGhiChuThe
            // 
            this.lblGhiChuThe.AutoSize = true;
            this.lblGhiChuThe.Location = new System.Drawing.Point(14, 176);
            this.lblGhiChuThe.Name = "lblGhiChuThe";
            this.lblGhiChuThe.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChuThe.Text = "Mỗi độc giả chỉ có một thẻ đang hoạt động.";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 232);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(108, 232);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(204, 232);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 32);
            this.btnLuu.Enabled = false;
            this.btnLuu.TabIndex = 31;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(300, 232);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 32);
            this.btnHuy.Enabled = false;
            this.btnHuy.TabIndex = 32;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(396, 232);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(660, 238);
            this.lblTim.Name = "lblTim";
            this.lblTim.Text = "Tìm";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(700, 234);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(300, 25);
            this.txtTim.TabIndex = 35;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(1008, 232);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 32);
            this.btnTim.TabIndex = 36;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.Location = new System.Drawing.Point(12, 274);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.Size = new System.Drawing.Size(1096, 394);
            this.dgvDocGia.AllowUserToAddRows = false;
            this.dgvDocGia.AllowUserToDeleteRows = false;
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocGia.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDocGia.MultiSelect = false;
            this.dgvDocGia.RowHeadersVisible = false;
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGia.TabIndex = 37;
            this.dgvDocGia.SelectionChanged += new System.EventHandler(this.dgvDocGia_SelectionChanged);
            // 
            // FrmDocGia
            // 
            this.AcceptButton = this.btnTim;
            this.ClientSize = new System.Drawing.Size(1120, 680);
            this.Controls.Add(this.grpDocGia);
            this.Controls.Add(this.grpThe);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dgvDocGia);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Độc giả và thẻ thư viện";
            this.Load += new System.EventHandler(this.FrmDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.grpThe.ResumeLayout(false);
            this.grpThe.PerformLayout();
            this.grpDocGia.ResumeLayout(false);
            this.grpDocGia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDocGia;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.GroupBox grpThe;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.DateTimePicker dtNgayCap;
        private System.Windows.Forms.Label lblHanDung;
        private System.Windows.Forms.DateTimePicker dtHanDung;
        private System.Windows.Forms.Label lblTrangThaiThe;
        private System.Windows.Forms.TextBox txtTrangThaiThe;
        private System.Windows.Forms.Button btnCapThe;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnKhoaThe;
        private System.Windows.Forms.Button btnBaoMat;
        private System.Windows.Forms.Label lblGhiChuThe;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvDocGia;
    }
}
