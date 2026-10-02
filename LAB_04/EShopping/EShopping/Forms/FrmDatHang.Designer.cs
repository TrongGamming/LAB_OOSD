namespace EShopping.Forms
{
    partial class FrmDatHang
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpLoai = new System.Windows.Forms.GroupBox();
            this.rdoThuong = new System.Windows.Forms.RadioButton();
            this.rdoCPN = new System.Windows.Forms.RadioButton();
            this.rdoCPNNgay = new System.Windows.Forms.RadioButton();
            this.lblMoTaThuong = new System.Windows.Forms.Label();
            this.lblMoTaCPN = new System.Windows.Forms.Label();
            this.lblMoTaCPNNgay = new System.Windows.Forms.Label();
            this.grpNhan = new System.Windows.Forms.GroupBox();
            this.chkLaToi = new System.Windows.Forms.CheckBox();
            this.lblTenNhan = new System.Windows.Forms.Label();
            this.txtTenNhan = new System.Windows.Forms.TextBox();
            this.lblDTNhan = new System.Windows.Forms.Label();
            this.txtDTNhan = new System.Windows.Forms.TextBox();
            this.lblTinh = new System.Windows.Forms.Label();
            this.cboTinh = new System.Windows.Forms.ComboBox();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.lblDiaChiNhan = new System.Windows.Forms.Label();
            this.txtDiaChiNhan = new System.Windows.Forms.TextBox();
            this.lblHang = new System.Windows.Forms.Label();
            this.dgvHang = new System.Windows.Forms.DataGridView();
            this.grpThe = new System.Windows.Forms.GroupBox();
            this.lblLoaiThe = new System.Windows.Forms.Label();
            this.cboLoaiThe = new System.Windows.Forms.ComboBox();
            this.lblSoThe = new System.Windows.Forms.Label();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.lblHan = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblChuThe = new System.Windows.Forms.Label();
            this.txtChuThe = new System.Windows.Forms.TextBox();
            this.lblCSV = new System.Windows.Forms.Label();
            this.txtCSV = new System.Windows.Forms.TextBox();
            this.lblGoiYThe = new System.Windows.Forms.Label();
            this.grpTien = new System.Windows.Forms.GroupBox();
            this.lblTienHangT = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblPhiGiaoT = new System.Windows.Forms.Label();
            this.lblPhiGiao = new System.Windows.Forms.Label();
            this.lblMienPhi = new System.Windows.Forms.Label();
            this.lblLePhiT = new System.Windows.Forms.Label();
            this.lblLePhi = new System.Windows.Forms.Label();
            this.lblTongT = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblXuLy = new System.Windows.Forms.Label();
            this.btnDatHang = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpLoai.SuspendLayout();
            this.grpNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).BeginInit();
            this.grpThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.grpTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(976, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "ĐẶT HÀNG VÀ THANH TOÁN";
            // 
            // grpLoai
            // 
            this.grpLoai.Controls.Add(this.rdoThuong);
            this.grpLoai.Controls.Add(this.rdoCPN);
            this.grpLoai.Controls.Add(this.rdoCPNNgay);
            this.grpLoai.Controls.Add(this.lblMoTaThuong);
            this.grpLoai.Controls.Add(this.lblMoTaCPN);
            this.grpLoai.Controls.Add(this.lblMoTaCPNNgay);
            this.grpLoai.Location = new System.Drawing.Point(12, 48);
            this.grpLoai.Name = "grpLoai";
            this.grpLoai.Size = new System.Drawing.Size(480, 156);
            this.grpLoai.Text = "1. Loại phiếu đặt hàng";
            // 
            // rdoThuong
            // 
            this.rdoThuong.AutoSize = true;
            this.rdoThuong.Location = new System.Drawing.Point(16, 28);
            this.rdoThuong.Name = "rdoThuong";
            this.rdoThuong.Checked = true;
            this.rdoThuong.TabStop = true;
            this.rdoThuong.TabIndex = 2;
            this.rdoThuong.Text = "Phiếu đặt hàng thường";
            this.rdoThuong.CheckedChanged += new System.EventHandler(this.TinhLai);
            // 
            // rdoCPN
            // 
            this.rdoCPN.AutoSize = true;
            this.rdoCPN.Location = new System.Drawing.Point(16, 70);
            this.rdoCPN.Name = "rdoCPN";
            this.rdoCPN.TabIndex = 3;
            this.rdoCPN.Text = "Chuyển phát nhanh";
            this.rdoCPN.CheckedChanged += new System.EventHandler(this.TinhLai);
            // 
            // rdoCPNNgay
            // 
            this.rdoCPNNgay.AutoSize = true;
            this.rdoCPNNgay.Location = new System.Drawing.Point(16, 112);
            this.rdoCPNNgay.Name = "rdoCPNNgay";
            this.rdoCPNNgay.TabIndex = 4;
            this.rdoCPNNgay.Text = "Chuyển phát nhanh trong ngày";
            this.rdoCPNNgay.CheckedChanged += new System.EventHandler(this.TinhLai);
            // 
            // lblMoTaThuong
            // 
            this.lblMoTaThuong.Location = new System.Drawing.Point(34, 48);
            this.lblMoTaThuong.Name = "lblMoTaThuong";
            this.lblMoTaThuong.Size = new System.Drawing.Size(430, 20);
            this.lblMoTaThuong.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTaThuong.Text = "";
            // 
            // lblMoTaCPN
            // 
            this.lblMoTaCPN.Location = new System.Drawing.Point(34, 90);
            this.lblMoTaCPN.Name = "lblMoTaCPN";
            this.lblMoTaCPN.Size = new System.Drawing.Size(430, 20);
            this.lblMoTaCPN.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTaCPN.Text = "";
            // 
            // lblMoTaCPNNgay
            // 
            this.lblMoTaCPNNgay.Location = new System.Drawing.Point(34, 132);
            this.lblMoTaCPNNgay.Name = "lblMoTaCPNNgay";
            this.lblMoTaCPNNgay.Size = new System.Drawing.Size(430, 20);
            this.lblMoTaCPNNgay.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTaCPNNgay.Text = "";
            // 
            // grpNhan
            // 
            this.grpNhan.Controls.Add(this.chkLaToi);
            this.grpNhan.Controls.Add(this.lblTenNhan);
            this.grpNhan.Controls.Add(this.txtTenNhan);
            this.grpNhan.Controls.Add(this.lblDTNhan);
            this.grpNhan.Controls.Add(this.txtDTNhan);
            this.grpNhan.Controls.Add(this.lblTinh);
            this.grpNhan.Controls.Add(this.cboTinh);
            this.grpNhan.Controls.Add(this.lblKhuVuc);
            this.grpNhan.Controls.Add(this.lblDiaChiNhan);
            this.grpNhan.Controls.Add(this.txtDiaChiNhan);
            this.grpNhan.Location = new System.Drawing.Point(12, 212);
            this.grpNhan.Name = "grpNhan";
            this.grpNhan.Size = new System.Drawing.Size(480, 214);
            this.grpNhan.Text = "2. Thông tin người nhận hàng";
            // 
            // chkLaToi
            // 
            this.chkLaToi.AutoSize = true;
            this.chkLaToi.Location = new System.Drawing.Point(16, 26);
            this.chkLaToi.Name = "chkLaToi";
            this.chkLaToi.TabIndex = 9;
            this.chkLaToi.Text = "Người nhận chính là tôi";
            this.chkLaToi.CheckedChanged += new System.EventHandler(this.chkLaToi_CheckedChanged);
            // 
            // lblTenNhan
            // 
            this.lblTenNhan.AutoSize = true;
            this.lblTenNhan.Location = new System.Drawing.Point(16, 62);
            this.lblTenNhan.Name = "lblTenNhan";
            this.lblTenNhan.Text = "Họ tên";
            // 
            // txtTenNhan
            // 
            this.txtTenNhan.Location = new System.Drawing.Point(120, 58);
            this.txtTenNhan.Name = "txtTenNhan";
            this.txtTenNhan.Size = new System.Drawing.Size(344, 25);
            this.txtTenNhan.MaxLength = 100;
            this.txtTenNhan.TabIndex = 11;
            // 
            // lblDTNhan
            // 
            this.lblDTNhan.AutoSize = true;
            this.lblDTNhan.Location = new System.Drawing.Point(16, 98);
            this.lblDTNhan.Name = "lblDTNhan";
            this.lblDTNhan.Text = "Điện thoại";
            // 
            // txtDTNhan
            // 
            this.txtDTNhan.Location = new System.Drawing.Point(120, 94);
            this.txtDTNhan.Name = "txtDTNhan";
            this.txtDTNhan.Size = new System.Drawing.Size(160, 25);
            this.txtDTNhan.MaxLength = 15;
            this.txtDTNhan.TabIndex = 13;
            // 
            // lblTinh
            // 
            this.lblTinh.AutoSize = true;
            this.lblTinh.Location = new System.Drawing.Point(16, 134);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Text = "Tỉnh / thành";
            // 
            // cboTinh
            // 
            this.cboTinh.Location = new System.Drawing.Point(120, 130);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(180, 25);
            this.cboTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinh.TabIndex = 15;
            this.cboTinh.SelectedIndexChanged += new System.EventHandler(this.TinhLai);
            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.Location = new System.Drawing.Point(306, 134);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(168, 20);
            this.lblKhuVuc.ForeColor = System.Drawing.Color.DimGray;
            this.lblKhuVuc.Text = "";
            // 
            // lblDiaChiNhan
            // 
            this.lblDiaChiNhan.AutoSize = true;
            this.lblDiaChiNhan.Location = new System.Drawing.Point(16, 170);
            this.lblDiaChiNhan.Name = "lblDiaChiNhan";
            this.lblDiaChiNhan.Text = "Địa chỉ";
            // 
            // txtDiaChiNhan
            // 
            this.txtDiaChiNhan.Location = new System.Drawing.Point(120, 166);
            this.txtDiaChiNhan.Name = "txtDiaChiNhan";
            this.txtDiaChiNhan.Size = new System.Drawing.Size(344, 25);
            this.txtDiaChiNhan.MaxLength = 250;
            this.txtDiaChiNhan.TabIndex = 18;
            // 
            // lblHang
            // 
            this.lblHang.AutoSize = true;
            this.lblHang.Location = new System.Drawing.Point(12, 434);
            this.lblHang.Name = "lblHang";
            this.lblHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHang.Text = "Sản phẩm đặt mua";
            // 
            // dgvHang
            // 
            this.dgvHang.Location = new System.Drawing.Point(12, 458);
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.Size = new System.Drawing.Size(480, 176);
            this.dgvHang.AllowUserToAddRows = false;
            this.dgvHang.AllowUserToDeleteRows = false;
            this.dgvHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHang.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHang.MultiSelect = false;
            this.dgvHang.RowHeadersVisible = false;
            this.dgvHang.ReadOnly = true;
            this.dgvHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHang.TabIndex = 20;
            // 
            // grpThe
            // 
            this.grpThe.Controls.Add(this.lblLoaiThe);
            this.grpThe.Controls.Add(this.cboLoaiThe);
            this.grpThe.Controls.Add(this.lblSoThe);
            this.grpThe.Controls.Add(this.txtSoThe);
            this.grpThe.Controls.Add(this.lblHan);
            this.grpThe.Controls.Add(this.numThang);
            this.grpThe.Controls.Add(this.numNam);
            this.grpThe.Controls.Add(this.lblChuThe);
            this.grpThe.Controls.Add(this.txtChuThe);
            this.grpThe.Controls.Add(this.lblCSV);
            this.grpThe.Controls.Add(this.txtCSV);
            this.grpThe.Controls.Add(this.lblGoiYThe);
            this.grpThe.Location = new System.Drawing.Point(506, 48);
            this.grpThe.Name = "grpThe";
            this.grpThe.Size = new System.Drawing.Size(482, 250);
            this.grpThe.Text = "3. Thanh toán bằng thẻ tín dụng";
            // 
            // lblLoaiThe
            // 
            this.lblLoaiThe.AutoSize = true;
            this.lblLoaiThe.Location = new System.Drawing.Point(16, 32);
            this.lblLoaiThe.Name = "lblLoaiThe";
            this.lblLoaiThe.Text = "Loại thẻ";
            // 
            // cboLoaiThe
            // 
            this.cboLoaiThe.Location = new System.Drawing.Point(140, 28);
            this.cboLoaiThe.Name = "cboLoaiThe";
            this.cboLoaiThe.Size = new System.Drawing.Size(200, 25);
            this.cboLoaiThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThe.TabIndex = 23;
            this.cboLoaiThe.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThe_SelectedIndexChanged);
            // 
            // lblSoThe
            // 
            this.lblSoThe.AutoSize = true;
            this.lblSoThe.Location = new System.Drawing.Point(16, 68);
            this.lblSoThe.Name = "lblSoThe";
            this.lblSoThe.Text = "Số thẻ";
            // 
            // txtSoThe
            // 
            this.txtSoThe.Location = new System.Drawing.Point(140, 64);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Size = new System.Drawing.Size(220, 25);
            this.txtSoThe.MaxLength = 19;
            this.txtSoThe.TabIndex = 25;
            // 
            // lblHan
            // 
            this.lblHan.AutoSize = true;
            this.lblHan.Location = new System.Drawing.Point(16, 104);
            this.lblHan.Name = "lblHan";
            this.lblHan.Text = "Hết hạn (tháng/năm)";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(160, 100);
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(60, 25);
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.Value = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.TabIndex = 27;
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(230, 100);
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(80, 25);
            this.numNam.Minimum = new decimal(new int[] { 2026, 0, 0, 0 });
            this.numNam.Maximum = new decimal(new int[] { 2045, 0, 0, 0 });
            this.numNam.Value = new decimal(new int[] { 2028, 0, 0, 0 });
            this.numNam.TabIndex = 28;
            // 
            // lblChuThe
            // 
            this.lblChuThe.AutoSize = true;
            this.lblChuThe.Location = new System.Drawing.Point(16, 140);
            this.lblChuThe.Name = "lblChuThe";
            this.lblChuThe.Text = "Tên chủ thẻ";
            // 
            // txtChuThe
            // 
            this.txtChuThe.Location = new System.Drawing.Point(140, 136);
            this.txtChuThe.Name = "txtChuThe";
            this.txtChuThe.Size = new System.Drawing.Size(320, 25);
            this.txtChuThe.MaxLength = 100;
            this.txtChuThe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChuThe.TabIndex = 30;
            // 
            // lblCSV
            // 
            this.lblCSV.AutoSize = true;
            this.lblCSV.Location = new System.Drawing.Point(16, 176);
            this.lblCSV.Name = "lblCSV";
            this.lblCSV.Text = "Mã CSV";
            // 
            // txtCSV
            // 
            this.txtCSV.Location = new System.Drawing.Point(140, 172);
            this.txtCSV.Name = "txtCSV";
            this.txtCSV.Size = new System.Drawing.Size(80, 25);
            this.txtCSV.MaxLength = 4;
            this.txtCSV.UseSystemPasswordChar = true;
            this.txtCSV.TabIndex = 32;
            // 
            // lblGoiYThe
            // 
            this.lblGoiYThe.Location = new System.Drawing.Point(16, 210);
            this.lblGoiYThe.Name = "lblGoiYThe";
            this.lblGoiYThe.Size = new System.Drawing.Size(450, 22);
            this.lblGoiYThe.ForeColor = System.Drawing.Color.DimGray;
            this.lblGoiYThe.Text = "";
            // 
            // grpTien
            // 
            this.grpTien.Controls.Add(this.lblTienHangT);
            this.grpTien.Controls.Add(this.lblTienHang);
            this.grpTien.Controls.Add(this.lblPhiGiaoT);
            this.grpTien.Controls.Add(this.lblPhiGiao);
            this.grpTien.Controls.Add(this.lblMienPhi);
            this.grpTien.Controls.Add(this.lblLePhiT);
            this.grpTien.Controls.Add(this.lblLePhi);
            this.grpTien.Controls.Add(this.lblTongT);
            this.grpTien.Controls.Add(this.lblTong);
            this.grpTien.Controls.Add(this.lblXuLy);
            this.grpTien.Location = new System.Drawing.Point(506, 306);
            this.grpTien.Name = "grpTien";
            this.grpTien.Size = new System.Drawing.Size(482, 232);
            this.grpTien.Text = "4. Tổng trị giá đơn đặt hàng";
            // 
            // lblTienHangT
            // 
            this.lblTienHangT.AutoSize = true;
            this.lblTienHangT.Location = new System.Drawing.Point(16, 32);
            this.lblTienHangT.Name = "lblTienHangT";
            this.lblTienHangT.Text = "Tiền hàng";
            // 
            // lblTienHang
            // 
            this.lblTienHang.Location = new System.Drawing.Point(250, 32);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(210, 22);
            this.lblTienHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienHang.Text = "0 đ";
            // 
            // lblPhiGiaoT
            // 
            this.lblPhiGiaoT.AutoSize = true;
            this.lblPhiGiaoT.Location = new System.Drawing.Point(16, 64);
            this.lblPhiGiaoT.Name = "lblPhiGiaoT";
            this.lblPhiGiaoT.Text = "Phí giao hàng";
            // 
            // lblPhiGiao
            // 
            this.lblPhiGiao.Location = new System.Drawing.Point(250, 64);
            this.lblPhiGiao.Name = "lblPhiGiao";
            this.lblPhiGiao.Size = new System.Drawing.Size(210, 22);
            this.lblPhiGiao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhiGiao.Text = "0 đ";
            // 
            // lblMienPhi
            // 
            this.lblMienPhi.Location = new System.Drawing.Point(16, 92);
            this.lblMienPhi.Name = "lblMienPhi";
            this.lblMienPhi.Size = new System.Drawing.Size(450, 22);
            this.lblMienPhi.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblMienPhi.Text = "";
            // 
            // lblLePhiT
            // 
            this.lblLePhiT.AutoSize = true;
            this.lblLePhiT.Location = new System.Drawing.Point(16, 122);
            this.lblLePhiT.Name = "lblLePhiT";
            this.lblLePhiT.Text = "Lệ phí thanh toán thẻ";
            // 
            // lblLePhi
            // 
            this.lblLePhi.Location = new System.Drawing.Point(250, 122);
            this.lblLePhi.Name = "lblLePhi";
            this.lblLePhi.Size = new System.Drawing.Size(210, 22);
            this.lblLePhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLePhi.Text = "0 đ";
            // 
            // lblTongT
            // 
            this.lblTongT.AutoSize = true;
            this.lblTongT.Location = new System.Drawing.Point(16, 166);
            this.lblTongT.Name = "lblTongT";
            this.lblTongT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongT.Text = "TỔNG TRỊ GIÁ";
            // 
            // lblTong
            // 
            this.lblTong.Location = new System.Drawing.Point(200, 162);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(260, 30);
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTong.Text = "0 đ";
            // 
            // lblXuLy
            // 
            this.lblXuLy.Location = new System.Drawing.Point(16, 200);
            this.lblXuLy.Name = "lblXuLy";
            this.lblXuLy.Size = new System.Drawing.Size(450, 22);
            this.lblXuLy.ForeColor = System.Drawing.Color.DimGray;
            this.lblXuLy.Text = "";
            // 
            // btnDatHang
            // 
            this.btnDatHang.Location = new System.Drawing.Point(690, 600);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(150, 36);
            this.btnDatHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatHang.TabIndex = 45;
            this.btnDatHang.Text = "Đặt hàng";
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(848, 600);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 36);
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.TabIndex = 46;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // FrmDatHang
            // 
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(1000, 690);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpLoai);
            this.Controls.Add(this.grpNhan);
            this.Controls.Add(this.lblHang);
            this.Controls.Add(this.dgvHang);
            this.Controls.Add(this.grpThe);
            this.Controls.Add(this.grpTien);
            this.Controls.Add(this.btnDatHang);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt hàng và thanh toán";
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Load += new System.EventHandler(this.FrmDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.grpTien.ResumeLayout(false);
            this.grpTien.PerformLayout();
            this.grpThe.ResumeLayout(false);
            this.grpThe.PerformLayout();
            this.grpNhan.ResumeLayout(false);
            this.grpNhan.PerformLayout();
            this.grpLoai.ResumeLayout(false);
            this.grpLoai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpLoai;
        private System.Windows.Forms.RadioButton rdoThuong;
        private System.Windows.Forms.RadioButton rdoCPN;
        private System.Windows.Forms.RadioButton rdoCPNNgay;
        private System.Windows.Forms.Label lblMoTaThuong;
        private System.Windows.Forms.Label lblMoTaCPN;
        private System.Windows.Forms.Label lblMoTaCPNNgay;
        private System.Windows.Forms.GroupBox grpNhan;
        private System.Windows.Forms.CheckBox chkLaToi;
        private System.Windows.Forms.Label lblTenNhan;
        private System.Windows.Forms.TextBox txtTenNhan;
        private System.Windows.Forms.Label lblDTNhan;
        private System.Windows.Forms.TextBox txtDTNhan;
        private System.Windows.Forms.Label lblTinh;
        private System.Windows.Forms.ComboBox cboTinh;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.Label lblDiaChiNhan;
        private System.Windows.Forms.TextBox txtDiaChiNhan;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.DataGridView dgvHang;
        private System.Windows.Forms.GroupBox grpThe;
        private System.Windows.Forms.Label lblLoaiThe;
        private System.Windows.Forms.ComboBox cboLoaiThe;
        private System.Windows.Forms.Label lblSoThe;
        private System.Windows.Forms.TextBox txtSoThe;
        private System.Windows.Forms.Label lblHan;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblChuThe;
        private System.Windows.Forms.TextBox txtChuThe;
        private System.Windows.Forms.Label lblCSV;
        private System.Windows.Forms.TextBox txtCSV;
        private System.Windows.Forms.Label lblGoiYThe;
        private System.Windows.Forms.GroupBox grpTien;
        private System.Windows.Forms.Label lblTienHangT;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Label lblPhiGiaoT;
        private System.Windows.Forms.Label lblPhiGiao;
        private System.Windows.Forms.Label lblMienPhi;
        private System.Windows.Forms.Label lblLePhiT;
        private System.Windows.Forms.Label lblLePhi;
        private System.Windows.Forms.Label lblTongT;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblXuLy;
        private System.Windows.Forms.Button btnDatHang;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ErrorProvider err;
    }
}
