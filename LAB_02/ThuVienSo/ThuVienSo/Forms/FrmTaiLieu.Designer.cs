namespace ThuVienSo.Forms
{
    partial class FrmTaiLieu
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboHinhThuc = new System.Windows.Forms.ComboBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblChuDe = new System.Windows.Forms.Label();
            this.cboChuDe = new System.Windows.Forms.ComboBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.clbTacGia = new System.Windows.Forms.CheckedListBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.grpDienTu = new System.Windows.Forms.GroupBox();
            this.lblTep = new System.Windows.Forms.Label();
            this.txtDuongDanTep = new System.Windows.Forms.TextBox();
            this.btnChonTep = new System.Windows.Forms.Button();
            this.lblDinhDang = new System.Windows.Forms.Label();
            this.cboDinhDang = new System.Windows.Forms.ComboBox();
            this.lblDungLuong = new System.Windows.Forms.Label();
            this.numDungLuong = new System.Windows.Forms.NumericUpDown();
            this.chkChoPhepTai = new System.Windows.Forms.CheckBox();
            this.lblGhiChuDienTu = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.dgvTaiLieu = new System.Windows.Forms.DataGridView();
            this.grpBanSao = new System.Windows.Forms.GroupBox();
            this.dgvBanSao = new System.Windows.Forms.DataGridView();
            this.lblSoBan = new System.Windows.Forms.Label();
            this.numSoBan = new System.Windows.Forms.NumericUpDown();
            this.lblKe = new System.Windows.Forms.Label();
            this.txtViTriKe = new System.Windows.Forms.TextBox();
            this.btnThemBanSao = new System.Windows.Forms.Button();
            this.lblTinhTrangBS = new System.Windows.Forms.Label();
            this.cboTinhTrangBS = new System.Windows.Forms.ComboBox();
            this.btnDoiTinhTrang = new System.Windows.Forms.Button();
            this.btnXoaBanSao = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.grpDienTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDungLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieu)).BeginInit();
            this.grpBanSao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanSao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoBan)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMa);
            this.grpThongTin.Controls.Add(this.txtMa);
            this.grpThongTin.Controls.Add(this.lblLoai);
            this.grpThongTin.Controls.Add(this.cboLoai);
            this.grpThongTin.Controls.Add(this.lblHinhThuc);
            this.grpThongTin.Controls.Add(this.cboHinhThuc);
            this.grpThongTin.Controls.Add(this.lblTen);
            this.grpThongTin.Controls.Add(this.txtTen);
            this.grpThongTin.Controls.Add(this.lblChuDe);
            this.grpThongTin.Controls.Add(this.cboChuDe);
            this.grpThongTin.Controls.Add(this.lblNXB);
            this.grpThongTin.Controls.Add(this.cboNXB);
            this.grpThongTin.Controls.Add(this.lblNam);
            this.grpThongTin.Controls.Add(this.numNam);
            this.grpThongTin.Controls.Add(this.lblTacGia);
            this.grpThongTin.Controls.Add(this.clbTacGia);
            this.grpThongTin.Controls.Add(this.lblMoTa);
            this.grpThongTin.Controls.Add(this.txtMoTa);
            this.grpThongTin.Location = new System.Drawing.Point(12, 8);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(700, 300);
            this.grpThongTin.Text = "Thông tin tài liệu";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(14, 32);
            this.lblMa.Name = "lblMa";
            this.lblMa.Text = "Mã tài liệu";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(110, 28);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(120, 25);
            this.txtMa.MaxLength = 10;
            this.txtMa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa.ReadOnly = true;
            this.txtMa.TabIndex = 2;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(250, 32);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Text = "Loại";
            // 
            // cboLoai
            // 
            this.cboLoai.Location = new System.Drawing.Point(300, 28);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(150, 25);
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.TabIndex = 4;
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(466, 32);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Text = "Hình thức";
            // 
            // cboHinhThuc
            // 
            this.cboHinhThuc.Location = new System.Drawing.Point(544, 28);
            this.cboHinhThuc.Name = "cboHinhThuc";
            this.cboHinhThuc.Size = new System.Drawing.Size(140, 25);
            this.cboHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThuc.TabIndex = 6;
            this.cboHinhThuc.SelectedIndexChanged += new System.EventHandler(this.cboHinhThuc_SelectedIndexChanged);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(14, 68);
            this.lblTen.Name = "lblTen";
            this.lblTen.Text = "Tên tài liệu";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(110, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(574, 25);
            this.txtTen.MaxLength = 255;
            this.txtTen.ReadOnly = true;
            this.txtTen.TabIndex = 8;
            // 
            // lblChuDe
            // 
            this.lblChuDe.AutoSize = true;
            this.lblChuDe.Location = new System.Drawing.Point(14, 104);
            this.lblChuDe.Name = "lblChuDe";
            this.lblChuDe.Text = "Chủ đề";
            // 
            // cboChuDe
            // 
            this.cboChuDe.Location = new System.Drawing.Point(110, 100);
            this.cboChuDe.Name = "cboChuDe";
            this.cboChuDe.Size = new System.Drawing.Size(230, 25);
            this.cboChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuDe.TabIndex = 10;
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(356, 104);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Text = "NXB";
            // 
            // cboNXB
            // 
            this.cboNXB.Location = new System.Drawing.Point(400, 100);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(180, 25);
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.TabIndex = 12;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(594, 104);
            this.lblNam.Name = "lblNam";
            this.lblNam.Text = "Năm";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(634, 100);
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(60, 25);
            this.numNam.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNam.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            this.numNam.TabIndex = 14;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(14, 140);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Text = "Tác giả";
            // 
            // clbTacGia
            // 
            this.clbTacGia.Location = new System.Drawing.Point(110, 138);
            this.clbTacGia.Name = "clbTacGia";
            this.clbTacGia.Size = new System.Drawing.Size(270, 148);
            this.clbTacGia.CheckOnClick = true;
            this.clbTacGia.IntegralHeight = false;
            this.clbTacGia.TabIndex = 16;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(396, 140);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(450, 138);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(234, 148);
            this.txtMoTa.MaxLength = 1000;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.TabIndex = 18;
            // 
            // grpDienTu
            // 
            this.grpDienTu.Controls.Add(this.lblTep);
            this.grpDienTu.Controls.Add(this.txtDuongDanTep);
            this.grpDienTu.Controls.Add(this.btnChonTep);
            this.grpDienTu.Controls.Add(this.lblDinhDang);
            this.grpDienTu.Controls.Add(this.cboDinhDang);
            this.grpDienTu.Controls.Add(this.lblDungLuong);
            this.grpDienTu.Controls.Add(this.numDungLuong);
            this.grpDienTu.Controls.Add(this.chkChoPhepTai);
            this.grpDienTu.Controls.Add(this.lblGhiChuDienTu);
            this.grpDienTu.Location = new System.Drawing.Point(724, 8);
            this.grpDienTu.Name = "grpDienTu";
            this.grpDienTu.Size = new System.Drawing.Size(444, 300);
            this.grpDienTu.Text = "Sách điện tử";
            // 
            // lblTep
            // 
            this.lblTep.AutoSize = true;
            this.lblTep.Location = new System.Drawing.Point(14, 34);
            this.lblTep.Name = "lblTep";
            this.lblTep.Text = "Tệp";
            // 
            // txtDuongDanTep
            // 
            this.txtDuongDanTep.Location = new System.Drawing.Point(100, 30);
            this.txtDuongDanTep.Name = "txtDuongDanTep";
            this.txtDuongDanTep.Size = new System.Drawing.Size(280, 25);
            this.txtDuongDanTep.MaxLength = 400;
            this.txtDuongDanTep.TabIndex = 21;
            // 
            // btnChonTep
            // 
            this.btnChonTep.Location = new System.Drawing.Point(386, 28);
            this.btnChonTep.Name = "btnChonTep";
            this.btnChonTep.Size = new System.Drawing.Size(44, 29);
            this.btnChonTep.TabIndex = 22;
            this.btnChonTep.Text = "…";
            this.btnChonTep.Click += new System.EventHandler(this.btnChonTep_Click);
            // 
            // lblDinhDang
            // 
            this.lblDinhDang.AutoSize = true;
            this.lblDinhDang.Location = new System.Drawing.Point(14, 74);
            this.lblDinhDang.Name = "lblDinhDang";
            this.lblDinhDang.Text = "Định dạng";
            // 
            // cboDinhDang
            // 
            this.cboDinhDang.Location = new System.Drawing.Point(100, 70);
            this.cboDinhDang.Name = "cboDinhDang";
            this.cboDinhDang.Size = new System.Drawing.Size(110, 25);
            this.cboDinhDang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinhDang.TabIndex = 24;
            // 
            // lblDungLuong
            // 
            this.lblDungLuong.AutoSize = true;
            this.lblDungLuong.Location = new System.Drawing.Point(230, 74);
            this.lblDungLuong.Name = "lblDungLuong";
            this.lblDungLuong.Text = "Dung lượng (MB)";
            // 
            // numDungLuong
            // 
            this.numDungLuong.Location = new System.Drawing.Point(350, 70);
            this.numDungLuong.Name = "numDungLuong";
            this.numDungLuong.Size = new System.Drawing.Size(80, 25);
            this.numDungLuong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDungLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDungLuong.DecimalPlaces = 2;
            this.numDungLuong.TabIndex = 26;
            // 
            // chkChoPhepTai
            // 
            this.chkChoPhepTai.AutoSize = true;
            this.chkChoPhepTai.Location = new System.Drawing.Point(100, 112);
            this.chkChoPhepTai.Name = "chkChoPhepTai";
            this.chkChoPhepTai.Checked = true;
            this.chkChoPhepTai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChoPhepTai.TabIndex = 27;
            this.chkChoPhepTai.Text = "Cho phép tải về";
            // 
            // lblGhiChuDienTu
            // 
            this.lblGhiChuDienTu.Location = new System.Drawing.Point(14, 150);
            this.lblGhiChuDienTu.Name = "lblGhiChuDienTu";
            this.lblGhiChuDienTu.Size = new System.Drawing.Size(416, 40);
            this.lblGhiChuDienTu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChuDienTu.Text = "Chỉ nhập khi hình thức là Điện tử hoặc Cả hai.";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 318);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(108, 318);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(204, 318);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 32);
            this.btnLuu.Enabled = false;
            this.btnLuu.TabIndex = 31;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(300, 318);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 32);
            this.btnHuy.Enabled = false;
            this.btnHuy.TabIndex = 32;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(396, 318);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(492, 318);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 34;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(600, 324);
            this.lblTim.Name = "lblTim";
            this.lblTim.Text = "Tìm";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(640, 320);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(180, 25);
            this.txtTim.TabIndex = 36;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // dgvTaiLieu
            // 
            this.dgvTaiLieu.Location = new System.Drawing.Point(12, 360);
            this.dgvTaiLieu.Name = "dgvTaiLieu";
            this.dgvTaiLieu.Size = new System.Drawing.Size(808, 328);
            this.dgvTaiLieu.AllowUserToAddRows = false;
            this.dgvTaiLieu.AllowUserToDeleteRows = false;
            this.dgvTaiLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiLieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTaiLieu.MultiSelect = false;
            this.dgvTaiLieu.RowHeadersVisible = false;
            this.dgvTaiLieu.ReadOnly = true;
            this.dgvTaiLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiLieu.TabIndex = 37;
            this.dgvTaiLieu.SelectionChanged += new System.EventHandler(this.dgvTaiLieu_SelectionChanged);
            // 
            // grpBanSao
            // 
            this.grpBanSao.Controls.Add(this.dgvBanSao);
            this.grpBanSao.Controls.Add(this.lblSoBan);
            this.grpBanSao.Controls.Add(this.numSoBan);
            this.grpBanSao.Controls.Add(this.lblKe);
            this.grpBanSao.Controls.Add(this.txtViTriKe);
            this.grpBanSao.Controls.Add(this.btnThemBanSao);
            this.grpBanSao.Controls.Add(this.lblTinhTrangBS);
            this.grpBanSao.Controls.Add(this.cboTinhTrangBS);
            this.grpBanSao.Controls.Add(this.btnDoiTinhTrang);
            this.grpBanSao.Controls.Add(this.btnXoaBanSao);
            this.grpBanSao.Location = new System.Drawing.Point(832, 318);
            this.grpBanSao.Name = "grpBanSao";
            this.grpBanSao.Size = new System.Drawing.Size(336, 370);
            this.grpBanSao.Text = "Bản sao (bản in)";
            // 
            // dgvBanSao
            // 
            this.dgvBanSao.Location = new System.Drawing.Point(12, 26);
            this.dgvBanSao.Name = "dgvBanSao";
            this.dgvBanSao.Size = new System.Drawing.Size(312, 200);
            this.dgvBanSao.AllowUserToAddRows = false;
            this.dgvBanSao.AllowUserToDeleteRows = false;
            this.dgvBanSao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanSao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBanSao.MultiSelect = false;
            this.dgvBanSao.RowHeadersVisible = false;
            this.dgvBanSao.ReadOnly = true;
            this.dgvBanSao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanSao.TabIndex = 39;
            // 
            // lblSoBan
            // 
            this.lblSoBan.AutoSize = true;
            this.lblSoBan.Location = new System.Drawing.Point(12, 240);
            this.lblSoBan.Name = "lblSoBan";
            this.lblSoBan.Text = "Số bản";
            // 
            // numSoBan
            // 
            this.numSoBan.Location = new System.Drawing.Point(70, 236);
            this.numSoBan.Name = "numSoBan";
            this.numSoBan.Size = new System.Drawing.Size(60, 25);
            this.numSoBan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoBan.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numSoBan.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoBan.TabIndex = 41;
            // 
            // lblKe
            // 
            this.lblKe.AutoSize = true;
            this.lblKe.Location = new System.Drawing.Point(142, 240);
            this.lblKe.Name = "lblKe";
            this.lblKe.Text = "Kệ";
            // 
            // txtViTriKe
            // 
            this.txtViTriKe.Location = new System.Drawing.Point(172, 236);
            this.txtViTriKe.Name = "txtViTriKe";
            this.txtViTriKe.Size = new System.Drawing.Size(60, 25);
            this.txtViTriKe.MaxLength = 10;
            this.txtViTriKe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtViTriKe.TabIndex = 43;
            // 
            // btnThemBanSao
            // 
            this.btnThemBanSao.Location = new System.Drawing.Point(240, 234);
            this.btnThemBanSao.Name = "btnThemBanSao";
            this.btnThemBanSao.Size = new System.Drawing.Size(84, 29);
            this.btnThemBanSao.TabIndex = 44;
            this.btnThemBanSao.Text = "Thêm";
            this.btnThemBanSao.Click += new System.EventHandler(this.btnThemBanSao_Click);
            // 
            // lblTinhTrangBS
            // 
            this.lblTinhTrangBS.AutoSize = true;
            this.lblTinhTrangBS.Location = new System.Drawing.Point(12, 282);
            this.lblTinhTrangBS.Name = "lblTinhTrangBS";
            this.lblTinhTrangBS.Text = "Tình trạng";
            // 
            // cboTinhTrangBS
            // 
            this.cboTinhTrangBS.Location = new System.Drawing.Point(90, 278);
            this.cboTinhTrangBS.Name = "cboTinhTrangBS";
            this.cboTinhTrangBS.Size = new System.Drawing.Size(140, 25);
            this.cboTinhTrangBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrangBS.TabIndex = 46;
            // 
            // btnDoiTinhTrang
            // 
            this.btnDoiTinhTrang.Location = new System.Drawing.Point(240, 276);
            this.btnDoiTinhTrang.Name = "btnDoiTinhTrang";
            this.btnDoiTinhTrang.Size = new System.Drawing.Size(84, 29);
            this.btnDoiTinhTrang.TabIndex = 47;
            this.btnDoiTinhTrang.Text = "Đổi";
            this.btnDoiTinhTrang.Click += new System.EventHandler(this.btnDoiTinhTrang_Click);
            // 
            // btnXoaBanSao
            // 
            this.btnXoaBanSao.Location = new System.Drawing.Point(12, 324);
            this.btnXoaBanSao.Name = "btnXoaBanSao";
            this.btnXoaBanSao.Size = new System.Drawing.Size(312, 32);
            this.btnXoaBanSao.TabIndex = 48;
            this.btnXoaBanSao.Text = "Xóa bản sao đang chọn";
            this.btnXoaBanSao.Click += new System.EventHandler(this.btnXoaBanSao_Click);
            // 
            // FrmTaiLieu
            // 
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpDienTu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.dgvTaiLieu);
            this.Controls.Add(this.grpBanSao);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTaiLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý tài liệu";
            this.Load += new System.EventHandler(this.FrmTaiLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDungLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanSao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoBan)).EndInit();
            this.grpBanSao.ResumeLayout(false);
            this.grpBanSao.PerformLayout();
            this.grpDienTu.ResumeLayout(false);
            this.grpDienTu.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.ComboBox cboHinhThuc;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblChuDe;
        private System.Windows.Forms.ComboBox cboChuDe;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.CheckedListBox clbTacGia;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.GroupBox grpDienTu;
        private System.Windows.Forms.Label lblTep;
        private System.Windows.Forms.TextBox txtDuongDanTep;
        private System.Windows.Forms.Button btnChonTep;
        private System.Windows.Forms.Label lblDinhDang;
        private System.Windows.Forms.ComboBox cboDinhDang;
        private System.Windows.Forms.Label lblDungLuong;
        private System.Windows.Forms.NumericUpDown numDungLuong;
        private System.Windows.Forms.CheckBox chkChoPhepTai;
        private System.Windows.Forms.Label lblGhiChuDienTu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.DataGridView dgvTaiLieu;
        private System.Windows.Forms.GroupBox grpBanSao;
        private System.Windows.Forms.DataGridView dgvBanSao;
        private System.Windows.Forms.Label lblSoBan;
        private System.Windows.Forms.NumericUpDown numSoBan;
        private System.Windows.Forms.Label lblKe;
        private System.Windows.Forms.TextBox txtViTriKe;
        private System.Windows.Forms.Button btnThemBanSao;
        private System.Windows.Forms.Label lblTinhTrangBS;
        private System.Windows.Forms.ComboBox cboTinhTrangBS;
        private System.Windows.Forms.Button btnDoiTinhTrang;
        private System.Windows.Forms.Button btnXoaBanSao;
    }
}
