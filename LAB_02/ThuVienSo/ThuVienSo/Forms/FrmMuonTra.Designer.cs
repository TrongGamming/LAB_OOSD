namespace ThuVienSo.Forms
{
    partial class FrmMuonTra
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.lblDangKyTieuDe = new System.Windows.Forms.Label();
            this.btnTaiDangKy = new System.Windows.Forms.Button();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.btnHuyDangKy = new System.Windows.Forms.Button();
            this.btnChuyenLapPhieu = new System.Windows.Forms.Button();
            this.tabLapPhieu = new System.Windows.Forms.TabPage();
            this.grpDocGia = new System.Windows.Forms.GroupBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.lblHanMuc = new System.Windows.Forms.Label();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.grpBanSao = new System.Windows.Forms.GroupBox();
            this.lblMaBanSao = new System.Windows.Forms.Label();
            this.txtMaBanSao = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblDangKy = new System.Windows.Forms.Label();
            this.cboDangKy = new System.Windows.Forms.ComboBox();
            this.btnLayDangKy = new System.Windows.Forms.Button();
            this.dgvBanSaoChon = new System.Windows.Forms.DataGridView();
            this.colMaBanSao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDangKyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.tabTraSach = new System.Windows.Forms.TabPage();
            this.lblMaBanSaoTra = new System.Windows.Forms.Label();
            this.txtMaBanSaoTra = new System.Windows.Forms.TextBox();
            this.lblMaTheTra = new System.Windows.Forms.Label();
            this.txtMaTheTra = new System.Windows.Forms.TextBox();
            this.btnTimPhieu = new System.Windows.Forms.Button();
            this.dgvPhieuDangMo = new System.Windows.Forms.DataGridView();
            this.grpTinhTrang = new System.Windows.Forms.GroupBox();
            this.rdoNguyenVen = new System.Windows.Forms.RadioButton();
            this.rdoHuHong = new System.Windows.Forms.RadioButton();
            this.rdoMat = new System.Windows.Forms.RadioButton();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblKetQuaTra = new System.Windows.Forms.Label();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.tabTinhTrang = new System.Windows.Forms.TabPage();
            this.lblTimTT = new System.Windows.Forms.Label();
            this.txtTimTT = new System.Windows.Forms.TextBox();
            this.chkChiQuaHan = new System.Windows.Forms.CheckBox();
            this.btnTimTT = new System.Windows.Forms.Button();
            this.dgvTinhTrang = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.tabLapPhieu.SuspendLayout();
            this.grpDocGia.SuspendLayout();
            this.grpBanSao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanSaoChon)).BeginInit();
            this.tabTraSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDangMo)).BeginInit();
            this.grpTinhTrang.SuspendLayout();
            this.tabTinhTrang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhTrang)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabDangKy);
            this.tabs.Controls.Add(this.tabLapPhieu);
            this.tabs.Controls.Add(this.tabTraSach);
            this.tabs.Controls.Add(this.tabTinhTrang);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(956, 566);
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabDangKy
            // 
            this.tabDangKy.Controls.Add(this.lblDangKyTieuDe);
            this.tabDangKy.Controls.Add(this.btnTaiDangKy);
            this.tabDangKy.Controls.Add(this.dgvDangKy);
            this.tabDangKy.Controls.Add(this.btnHuyDangKy);
            this.tabDangKy.Controls.Add(this.btnChuyenLapPhieu);
            this.tabDangKy.Name = "tabDangKy";
            this.tabDangKy.Size = new System.Drawing.Size(948, 536);
            this.tabDangKy.Text = "Đăng ký chờ nhận";
            this.tabDangKy.UseVisualStyleBackColor = true;
            // 
            // lblDangKyTieuDe
            // 
            this.lblDangKyTieuDe.AutoSize = true;
            this.lblDangKyTieuDe.Location = new System.Drawing.Point(16, 18);
            this.lblDangKyTieuDe.Name = "lblDangKyTieuDe";
            this.lblDangKyTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDangKyTieuDe.Text = "Các đăng ký đang giữ chỗ (tô đỏ: đã quá hạn nhận, sẽ bị hủy)";
            // 
            // btnTaiDangKy
            // 
            this.btnTaiDangKy.Location = new System.Drawing.Point(800, 12);
            this.btnTaiDangKy.Name = "btnTaiDangKy";
            this.btnTaiDangKy.Size = new System.Drawing.Size(130, 30);
            this.btnTaiDangKy.TabIndex = 3;
            this.btnTaiDangKy.Text = "Làm mới";
            this.btnTaiDangKy.Click += new System.EventHandler(this.btnTaiDangKy_Click);
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.Location = new System.Drawing.Point(16, 50);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.Size = new System.Drawing.Size(914, 420);
            this.dgvDangKy.AllowUserToAddRows = false;
            this.dgvDangKy.AllowUserToDeleteRows = false;
            this.dgvDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangKy.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDangKy.MultiSelect = false;
            this.dgvDangKy.RowHeadersVisible = false;
            this.dgvDangKy.ReadOnly = true;
            this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKy.TabIndex = 4;
            this.dgvDangKy.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDangKy_CellFormatting);
            // 
            // btnHuyDangKy
            // 
            this.btnHuyDangKy.Location = new System.Drawing.Point(16, 484);
            this.btnHuyDangKy.Name = "btnHuyDangKy";
            this.btnHuyDangKy.Size = new System.Drawing.Size(160, 34);
            this.btnHuyDangKy.TabIndex = 5;
            this.btnHuyDangKy.Text = "Hủy đăng ký";
            this.btnHuyDangKy.Click += new System.EventHandler(this.btnHuyDangKy_Click);
            // 
            // btnChuyenLapPhieu
            // 
            this.btnChuyenLapPhieu.Location = new System.Drawing.Point(730, 484);
            this.btnChuyenLapPhieu.Name = "btnChuyenLapPhieu";
            this.btnChuyenLapPhieu.Size = new System.Drawing.Size(200, 34);
            this.btnChuyenLapPhieu.TabIndex = 6;
            this.btnChuyenLapPhieu.Text = "Lập phiếu cho đăng ký này";
            this.btnChuyenLapPhieu.Click += new System.EventHandler(this.btnChuyenLapPhieu_Click);
            // 
            // tabLapPhieu
            // 
            this.tabLapPhieu.Controls.Add(this.grpDocGia);
            this.tabLapPhieu.Controls.Add(this.grpBanSao);
            this.tabLapPhieu.Name = "tabLapPhieu";
            this.tabLapPhieu.Size = new System.Drawing.Size(948, 536);
            this.tabLapPhieu.Text = "Lập phiếu mượn";
            this.tabLapPhieu.UseVisualStyleBackColor = true;
            // 
            // grpDocGia
            // 
            this.grpDocGia.Controls.Add(this.lblMaThe);
            this.grpDocGia.Controls.Add(this.txtMaThe);
            this.grpDocGia.Controls.Add(this.btnKiemTra);
            this.grpDocGia.Controls.Add(this.lblDocGia);
            this.grpDocGia.Controls.Add(this.lblHanMuc);
            this.grpDocGia.Controls.Add(this.lblHanTra);
            this.grpDocGia.Location = new System.Drawing.Point(12, 10);
            this.grpDocGia.Name = "grpDocGia";
            this.grpDocGia.Size = new System.Drawing.Size(922, 120);
            this.grpDocGia.Text = "Độc giả";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(16, 32);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Text = "Mã thẻ";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(80, 28);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(180, 25);
            this.txtMaThe.MaxLength = 12;
            this.txtMaThe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaThe.TabIndex = 10;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(270, 26);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 29);
            this.btnKiemTra.TabIndex = 11;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // lblDocGia
            // 
            this.lblDocGia.Location = new System.Drawing.Point(386, 31);
            this.lblDocGia.Name = "lblDocGia";
            this.lblDocGia.Size = new System.Drawing.Size(520, 22);
            this.lblDocGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDocGia.Text = "Nhập mã thẻ và bấm Kiểm tra.";
            // 
            // lblHanMuc
            // 
            this.lblHanMuc.Location = new System.Drawing.Point(16, 64);
            this.lblHanMuc.Name = "lblHanMuc";
            this.lblHanMuc.Size = new System.Drawing.Size(600, 22);
            this.lblHanMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHanMuc.Text = "";
            // 
            // lblHanTra
            // 
            this.lblHanTra.Location = new System.Drawing.Point(16, 90);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(600, 22);
            this.lblHanTra.ForeColor = System.Drawing.Color.DimGray;
            this.lblHanTra.Text = "Ngày mượn: hôm nay – Hạn trả: ngày mượn + 14 ngày";
            // 
            // grpBanSao
            // 
            this.grpBanSao.Controls.Add(this.lblMaBanSao);
            this.grpBanSao.Controls.Add(this.txtMaBanSao);
            this.grpBanSao.Controls.Add(this.btnThem);
            this.grpBanSao.Controls.Add(this.lblDangKy);
            this.grpBanSao.Controls.Add(this.cboDangKy);
            this.grpBanSao.Controls.Add(this.btnLayDangKy);
            this.grpBanSao.Controls.Add(this.dgvBanSaoChon);
            this.grpBanSao.Controls.Add(this.btnXoaDong);
            this.grpBanSao.Controls.Add(this.btnLapPhieu);
            this.grpBanSao.Location = new System.Drawing.Point(12, 138);
            this.grpBanSao.Name = "grpBanSao";
            this.grpBanSao.Size = new System.Drawing.Size(922, 386);
            this.grpBanSao.Enabled = false;
            this.grpBanSao.Text = "Bản sao giao cho độc giả";
            // 
            // lblMaBanSao
            // 
            this.lblMaBanSao.AutoSize = true;
            this.lblMaBanSao.Location = new System.Drawing.Point(16, 32);
            this.lblMaBanSao.Name = "lblMaBanSao";
            this.lblMaBanSao.Text = "Quét mã bản sao";
            // 
            // txtMaBanSao
            // 
            this.txtMaBanSao.Location = new System.Drawing.Point(130, 28);
            this.txtMaBanSao.Name = "txtMaBanSao";
            this.txtMaBanSao.Size = new System.Drawing.Size(150, 25);
            this.txtMaBanSao.MaxLength = 10;
            this.txtMaBanSao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaBanSao.TabIndex = 17;
            this.txtMaBanSao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaBanSao_KeyDown);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(290, 26);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 29);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblDangKy
            // 
            this.lblDangKy.AutoSize = true;
            this.lblDangKy.Location = new System.Drawing.Point(400, 32);
            this.lblDangKy.Name = "lblDangKy";
            this.lblDangKy.Text = "hoặc lấy từ đăng ký";
            // 
            // cboDangKy
            // 
            this.cboDangKy.Location = new System.Drawing.Point(530, 28);
            this.cboDangKy.Name = "cboDangKy";
            this.cboDangKy.Size = new System.Drawing.Size(280, 25);
            this.cboDangKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDangKy.TabIndex = 20;
            // 
            // btnLayDangKy
            // 
            this.btnLayDangKy.Location = new System.Drawing.Point(820, 26);
            this.btnLayDangKy.Name = "btnLayDangKy";
            this.btnLayDangKy.Size = new System.Drawing.Size(86, 29);
            this.btnLayDangKy.TabIndex = 21;
            this.btnLayDangKy.Text = "Lấy";
            this.btnLayDangKy.Click += new System.EventHandler(this.btnLayDangKy_Click);
            // 
            // dgvBanSaoChon
            // 
            this.dgvBanSaoChon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colMaBanSao, this.colTenTaiLieu, this.colMaDangKy, this.colDangKyId, this.colKetQua });
            this.dgvBanSaoChon.Location = new System.Drawing.Point(16, 66);
            this.dgvBanSaoChon.Name = "dgvBanSaoChon";
            this.dgvBanSaoChon.Size = new System.Drawing.Size(890, 262);
            this.dgvBanSaoChon.AllowUserToAddRows = false;
            this.dgvBanSaoChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanSaoChon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBanSaoChon.MultiSelect = false;
            this.dgvBanSaoChon.ReadOnly = true;
            this.dgvBanSaoChon.RowHeadersVisible = false;
            this.dgvBanSaoChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanSaoChon.TabIndex = 22;
            // 
            // colMaBanSao
            // 
            this.colMaBanSao.Name = "colMaBanSao";
            this.colMaBanSao.FillWeight = 60F;
            this.colMaBanSao.HeaderText = "Mã bản sao";
            // 
            // colTenTaiLieu
            // 
            this.colTenTaiLieu.Name = "colTenTaiLieu";
            this.colTenTaiLieu.FillWeight = 150F;
            this.colTenTaiLieu.HeaderText = "Tên tài liệu";
            // 
            // colMaDangKy
            // 
            this.colMaDangKy.Name = "colMaDangKy";
            this.colMaDangKy.FillWeight = 60F;
            this.colMaDangKy.HeaderText = "Mã đăng ký";
            // 
            // colDangKyId
            // 
            this.colDangKyId.Name = "colDangKyId";
            this.colDangKyId.FillWeight = 100F;
            this.colDangKyId.Visible = false;
            this.colDangKyId.HeaderText = "DangKyId";
            // 
            // colKetQua
            // 
            this.colKetQua.Name = "colKetQua";
            this.colKetQua.FillWeight = 150F;
            this.colKetQua.HeaderText = "Kết quả";
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(16, 340);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(120, 32);
            this.btnXoaDong.TabIndex = 28;
            this.btnXoaDong.Text = "Bỏ dòng chọn";
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(756, 340);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(150, 32);
            this.btnLapPhieu.TabIndex = 29;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // tabTraSach
            // 
            this.tabTraSach.Controls.Add(this.lblMaBanSaoTra);
            this.tabTraSach.Controls.Add(this.txtMaBanSaoTra);
            this.tabTraSach.Controls.Add(this.lblMaTheTra);
            this.tabTraSach.Controls.Add(this.txtMaTheTra);
            this.tabTraSach.Controls.Add(this.btnTimPhieu);
            this.tabTraSach.Controls.Add(this.dgvPhieuDangMo);
            this.tabTraSach.Controls.Add(this.grpTinhTrang);
            this.tabTraSach.Controls.Add(this.lblKetQuaTra);
            this.tabTraSach.Controls.Add(this.btnXacNhanTra);
            this.tabTraSach.Name = "tabTraSach";
            this.tabTraSach.Size = new System.Drawing.Size(948, 536);
            this.tabTraSach.Text = "Trả sách";
            this.tabTraSach.UseVisualStyleBackColor = true;
            // 
            // lblMaBanSaoTra
            // 
            this.lblMaBanSaoTra.AutoSize = true;
            this.lblMaBanSaoTra.Location = new System.Drawing.Point(16, 22);
            this.lblMaBanSaoTra.Name = "lblMaBanSaoTra";
            this.lblMaBanSaoTra.Text = "Quét mã bản sao";
            // 
            // txtMaBanSaoTra
            // 
            this.txtMaBanSaoTra.Location = new System.Drawing.Point(130, 18);
            this.txtMaBanSaoTra.Name = "txtMaBanSaoTra";
            this.txtMaBanSaoTra.Size = new System.Drawing.Size(150, 25);
            this.txtMaBanSaoTra.MaxLength = 10;
            this.txtMaBanSaoTra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaBanSaoTra.TabIndex = 32;
            // 
            // lblMaTheTra
            // 
            this.lblMaTheTra.AutoSize = true;
            this.lblMaTheTra.Location = new System.Drawing.Point(300, 22);
            this.lblMaTheTra.Name = "lblMaTheTra";
            this.lblMaTheTra.Text = "hoặc mã thẻ";
            // 
            // txtMaTheTra
            // 
            this.txtMaTheTra.Location = new System.Drawing.Point(390, 18);
            this.txtMaTheTra.Name = "txtMaTheTra";
            this.txtMaTheTra.Size = new System.Drawing.Size(170, 25);
            this.txtMaTheTra.MaxLength = 12;
            this.txtMaTheTra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaTheTra.TabIndex = 34;
            // 
            // btnTimPhieu
            // 
            this.btnTimPhieu.Location = new System.Drawing.Point(574, 16);
            this.btnTimPhieu.Name = "btnTimPhieu";
            this.btnTimPhieu.Size = new System.Drawing.Size(100, 29);
            this.btnTimPhieu.TabIndex = 35;
            this.btnTimPhieu.Text = "Tìm phiếu";
            this.btnTimPhieu.Click += new System.EventHandler(this.btnTimPhieu_Click);
            // 
            // dgvPhieuDangMo
            // 
            this.dgvPhieuDangMo.Location = new System.Drawing.Point(16, 58);
            this.dgvPhieuDangMo.Name = "dgvPhieuDangMo";
            this.dgvPhieuDangMo.Size = new System.Drawing.Size(916, 240);
            this.dgvPhieuDangMo.AllowUserToAddRows = false;
            this.dgvPhieuDangMo.AllowUserToDeleteRows = false;
            this.dgvPhieuDangMo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuDangMo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieuDangMo.MultiSelect = false;
            this.dgvPhieuDangMo.RowHeadersVisible = false;
            this.dgvPhieuDangMo.ReadOnly = true;
            this.dgvPhieuDangMo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuDangMo.TabIndex = 36;
            this.dgvPhieuDangMo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhieuDangMo_CellFormatting);
            // 
            // grpTinhTrang
            // 
            this.grpTinhTrang.Controls.Add(this.rdoNguyenVen);
            this.grpTinhTrang.Controls.Add(this.rdoHuHong);
            this.grpTinhTrang.Controls.Add(this.rdoMat);
            this.grpTinhTrang.Controls.Add(this.lblGhiChu);
            this.grpTinhTrang.Controls.Add(this.txtGhiChu);
            this.grpTinhTrang.Location = new System.Drawing.Point(16, 310);
            this.grpTinhTrang.Name = "grpTinhTrang";
            this.grpTinhTrang.Size = new System.Drawing.Size(916, 130);
            this.grpTinhTrang.Text = "Tình trạng sách khi trả";
            // 
            // rdoNguyenVen
            // 
            this.rdoNguyenVen.AutoSize = true;
            this.rdoNguyenVen.Location = new System.Drawing.Point(18, 30);
            this.rdoNguyenVen.Name = "rdoNguyenVen";
            this.rdoNguyenVen.Checked = true;
            this.rdoNguyenVen.TabStop = true;
            this.rdoNguyenVen.TabIndex = 38;
            this.rdoNguyenVen.Text = "Nguyên vẹn";
            // 
            // rdoHuHong
            // 
            this.rdoHuHong.AutoSize = true;
            this.rdoHuHong.Location = new System.Drawing.Point(160, 30);
            this.rdoHuHong.Name = "rdoHuHong";
            this.rdoHuHong.TabIndex = 39;
            this.rdoHuHong.Text = "Hư hỏng (rách, mất trang…)";
            // 
            // rdoMat
            // 
            this.rdoMat.AutoSize = true;
            this.rdoMat.Location = new System.Drawing.Point(400, 30);
            this.rdoMat.Name = "rdoMat";
            this.rdoMat.TabIndex = 40;
            this.rdoMat.Text = "Báo mất sách";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(18, 70);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(90, 64);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(808, 52);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.TabIndex = 42;
            // 
            // lblKetQuaTra
            // 
            this.lblKetQuaTra.Location = new System.Drawing.Point(16, 452);
            this.lblKetQuaTra.Name = "lblKetQuaTra";
            this.lblKetQuaTra.Size = new System.Drawing.Size(750, 60);
            this.lblKetQuaTra.Text = "";
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.Location = new System.Drawing.Point(782, 452);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(150, 34);
            this.btnXacNhanTra.TabIndex = 44;
            this.btnXacNhanTra.Text = "Xác nhận trả";
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // tabTinhTrang
            // 
            this.tabTinhTrang.Controls.Add(this.lblTimTT);
            this.tabTinhTrang.Controls.Add(this.txtTimTT);
            this.tabTinhTrang.Controls.Add(this.chkChiQuaHan);
            this.tabTinhTrang.Controls.Add(this.btnTimTT);
            this.tabTinhTrang.Controls.Add(this.dgvTinhTrang);
            this.tabTinhTrang.Name = "tabTinhTrang";
            this.tabTinhTrang.Size = new System.Drawing.Size(948, 536);
            this.tabTinhTrang.Text = "Tình trạng mượn";
            this.tabTinhTrang.UseVisualStyleBackColor = true;
            // 
            // lblTimTT
            // 
            this.lblTimTT.AutoSize = true;
            this.lblTimTT.Location = new System.Drawing.Point(16, 22);
            this.lblTimTT.Name = "lblTimTT";
            this.lblTimTT.Text = "Tài liệu / bản sao / độc giả";
            // 
            // txtTimTT
            // 
            this.txtTimTT.Location = new System.Drawing.Point(210, 18);
            this.txtTimTT.Name = "txtTimTT";
            this.txtTimTT.Size = new System.Drawing.Size(300, 25);
            this.txtTimTT.TabIndex = 47;
            // 
            // chkChiQuaHan
            // 
            this.chkChiQuaHan.AutoSize = true;
            this.chkChiQuaHan.Location = new System.Drawing.Point(526, 20);
            this.chkChiQuaHan.Name = "chkChiQuaHan";
            this.chkChiQuaHan.TabIndex = 48;
            this.chkChiQuaHan.Text = "Chỉ phiếu quá hạn";
            // 
            // btnTimTT
            // 
            this.btnTimTT.Location = new System.Drawing.Point(690, 16);
            this.btnTimTT.Name = "btnTimTT";
            this.btnTimTT.Size = new System.Drawing.Size(100, 29);
            this.btnTimTT.TabIndex = 49;
            this.btnTimTT.Text = "Tìm";
            this.btnTimTT.Click += new System.EventHandler(this.btnTimTT_Click);
            // 
            // dgvTinhTrang
            // 
            this.dgvTinhTrang.Location = new System.Drawing.Point(16, 58);
            this.dgvTinhTrang.Name = "dgvTinhTrang";
            this.dgvTinhTrang.Size = new System.Drawing.Size(916, 462);
            this.dgvTinhTrang.AllowUserToAddRows = false;
            this.dgvTinhTrang.AllowUserToDeleteRows = false;
            this.dgvTinhTrang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTinhTrang.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTinhTrang.MultiSelect = false;
            this.dgvTinhTrang.RowHeadersVisible = false;
            this.dgvTinhTrang.ReadOnly = true;
            this.dgvTinhTrang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTinhTrang.TabIndex = 50;
            this.dgvTinhTrang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTinhTrang_CellFormatting);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(868, 586);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.TabIndex = 51;
            this.btnDong.Text = "Đóng";
            // 
            // FrmMuonTra
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(980, 630);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mượn – trả sách";
            this.Load += new System.EventHandler(this.FrmMuonTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanSaoChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDangMo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhTrang)).EndInit();
            this.tabTinhTrang.ResumeLayout(false);
            this.tabTinhTrang.PerformLayout();
            this.grpTinhTrang.ResumeLayout(false);
            this.grpTinhTrang.PerformLayout();
            this.tabTraSach.ResumeLayout(false);
            this.tabTraSach.PerformLayout();
            this.grpBanSao.ResumeLayout(false);
            this.grpBanSao.PerformLayout();
            this.grpDocGia.ResumeLayout(false);
            this.grpDocGia.PerformLayout();
            this.tabLapPhieu.ResumeLayout(false);
            this.tabLapPhieu.PerformLayout();
            this.tabDangKy.ResumeLayout(false);
            this.tabDangKy.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabDangKy;
        private System.Windows.Forms.Label lblDangKyTieuDe;
        private System.Windows.Forms.Button btnTaiDangKy;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Button btnHuyDangKy;
        private System.Windows.Forms.Button btnChuyenLapPhieu;
        private System.Windows.Forms.TabPage tabLapPhieu;
        private System.Windows.Forms.GroupBox grpDocGia;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblHanMuc;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.GroupBox grpBanSao;
        private System.Windows.Forms.Label lblMaBanSao;
        private System.Windows.Forms.TextBox txtMaBanSao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblDangKy;
        private System.Windows.Forms.ComboBox cboDangKy;
        private System.Windows.Forms.Button btnLayDangKy;
        private System.Windows.Forms.DataGridView dgvBanSaoChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBanSao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDangKyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.TabPage tabTraSach;
        private System.Windows.Forms.Label lblMaBanSaoTra;
        private System.Windows.Forms.TextBox txtMaBanSaoTra;
        private System.Windows.Forms.Label lblMaTheTra;
        private System.Windows.Forms.TextBox txtMaTheTra;
        private System.Windows.Forms.Button btnTimPhieu;
        private System.Windows.Forms.DataGridView dgvPhieuDangMo;
        private System.Windows.Forms.GroupBox grpTinhTrang;
        private System.Windows.Forms.RadioButton rdoNguyenVen;
        private System.Windows.Forms.RadioButton rdoHuHong;
        private System.Windows.Forms.RadioButton rdoMat;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblKetQuaTra;
        private System.Windows.Forms.Button btnXacNhanTra;
        private System.Windows.Forms.TabPage tabTinhTrang;
        private System.Windows.Forms.Label lblTimTT;
        private System.Windows.Forms.TextBox txtTimTT;
        private System.Windows.Forms.CheckBox chkChiQuaHan;
        private System.Windows.Forms.Button btnTimTT;
        private System.Windows.Forms.DataGridView dgvTinhTrang;
        private System.Windows.Forms.Button btnDong;
    }
}
