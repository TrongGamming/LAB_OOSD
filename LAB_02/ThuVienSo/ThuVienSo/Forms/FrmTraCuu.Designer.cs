namespace ThuVienSo.Forms
{
    partial class FrmTraCuu
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
            this.grpTieuChi = new System.Windows.Forms.GroupBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblNamXB = new System.Windows.Forms.Label();
            this.numNamXB = new System.Windows.Forms.NumericUpDown();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblChuDe = new System.Windows.Forms.Label();
            this.cboChuDe = new System.Windows.Forms.ComboBox();
            this.rdoTatCa = new System.Windows.Forms.RadioButton();
            this.rdoBanIn = new System.Windows.Forms.RadioButton();
            this.rdoDienTu = new System.Windows.Forms.RadioButton();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnXoaLoc = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnDocTrucTuyen = new System.Windows.Forms.Button();
            this.btnTaiVe = new System.Windows.Forms.Button();
            this.btnDangKyMuon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpTieuChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            //
            // grpTieuChi
            //
            this.grpTieuChi.Controls.Add(this.lblTuKhoa);
            this.grpTieuChi.Controls.Add(this.txtTuKhoa);
            this.grpTieuChi.Controls.Add(this.lblTacGia);
            this.grpTieuChi.Controls.Add(this.txtTacGia);
            this.grpTieuChi.Controls.Add(this.lblNamXB);
            this.grpTieuChi.Controls.Add(this.numNamXB);
            this.grpTieuChi.Controls.Add(this.lblLoai);
            this.grpTieuChi.Controls.Add(this.cboLoai);
            this.grpTieuChi.Controls.Add(this.lblChuDe);
            this.grpTieuChi.Controls.Add(this.cboChuDe);
            this.grpTieuChi.Controls.Add(this.rdoTatCa);
            this.grpTieuChi.Controls.Add(this.rdoBanIn);
            this.grpTieuChi.Controls.Add(this.rdoDienTu);
            this.grpTieuChi.Controls.Add(this.btnTim);
            this.grpTieuChi.Controls.Add(this.btnXoaLoc);
            this.grpTieuChi.Location = new System.Drawing.Point(12, 8);
            this.grpTieuChi.Name = "grpTieuChi";
            this.grpTieuChi.Size = new System.Drawing.Size(996, 118);
            this.grpTieuChi.Text = "Tiêu chí tìm kiếm";
            //
            // lblTuKhoa
            //
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(14, 32);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Text = "Từ khóa";
            //
            // txtTuKhoa
            //
            this.txtTuKhoa.Location = new System.Drawing.Point(90, 28);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(330, 25);
            this.txtTuKhoa.TabIndex = 0;
            //
            // lblTacGia
            //
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(440, 32);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Text = "Tác giả";
            //
            // txtTacGia
            //
            this.txtTacGia.Location = new System.Drawing.Point(504, 28);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(230, 25);
            this.txtTacGia.TabIndex = 1;
            //
            // lblNamXB
            //
            this.lblNamXB.AutoSize = true;
            this.lblNamXB.Location = new System.Drawing.Point(754, 32);
            this.lblNamXB.Name = "lblNamXB";
            this.lblNamXB.Text = "Năm XB";
            //
            // numNamXB
            //
            this.numNamXB.Location = new System.Drawing.Point(820, 28);
            this.numNamXB.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamXB.Name = "numNamXB";
            this.numNamXB.Size = new System.Drawing.Size(90, 25);
            this.numNamXB.TabIndex = 2;
            //
            // lblLoai
            //
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(14, 72);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Text = "Loại";
            //
            // cboLoai
            //
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new System.Drawing.Point(90, 68);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(130, 25);
            this.cboLoai.TabIndex = 3;
            //
            // lblChuDe
            //
            this.lblChuDe.AutoSize = true;
            this.lblChuDe.Location = new System.Drawing.Point(236, 72);
            this.lblChuDe.Name = "lblChuDe";
            this.lblChuDe.Text = "Chủ đề";
            //
            // cboChuDe
            //
            this.cboChuDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuDe.Location = new System.Drawing.Point(296, 68);
            this.cboChuDe.Name = "cboChuDe";
            this.cboChuDe.Size = new System.Drawing.Size(200, 25);
            this.cboChuDe.TabIndex = 4;
            //
            // rdoTatCa
            //
            this.rdoTatCa.AutoSize = true;
            this.rdoTatCa.Checked = true;
            this.rdoTatCa.Location = new System.Drawing.Point(516, 70);
            this.rdoTatCa.Name = "rdoTatCa";
            this.rdoTatCa.TabIndex = 5;
            this.rdoTatCa.TabStop = true;
            this.rdoTatCa.Text = "Tất cả";
            //
            // rdoBanIn
            //
            this.rdoBanIn.AutoSize = true;
            this.rdoBanIn.Location = new System.Drawing.Point(590, 70);
            this.rdoBanIn.Name = "rdoBanIn";
            this.rdoBanIn.TabIndex = 6;
            this.rdoBanIn.Text = "Bản in";
            //
            // rdoDienTu
            //
            this.rdoDienTu.AutoSize = true;
            this.rdoDienTu.Location = new System.Drawing.Point(664, 70);
            this.rdoDienTu.Name = "rdoDienTu";
            this.rdoDienTu.TabIndex = 7;
            this.rdoDienTu.Text = "Điện tử";
            //
            // btnTim
            //
            this.btnTim.Location = new System.Drawing.Point(770, 64);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 32);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            //
            // btnXoaLoc
            //
            this.btnXoaLoc.Location = new System.Drawing.Point(880, 64);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(100, 32);
            this.btnXoaLoc.TabIndex = 9;
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.Click += new System.EventHandler(this.btnXoaLoc_Click);
            //
            // lblKetQua
            //
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKetQua.Location = new System.Drawing.Point(12, 134);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Text = "Kết quả";
            //
            // dgvKetQua
            //
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKetQua.Location = new System.Drawing.Point(12, 156);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(690, 430);
            this.dgvKetQua.TabIndex = 10;
            this.dgvKetQua.SelectionChanged += new System.EventHandler(this.dgvKetQua_SelectionChanged);
            //
            // grpChiTiet
            //
            this.grpChiTiet.Controls.Add(this.lblChiTiet);
            this.grpChiTiet.Controls.Add(this.txtMoTa);
            this.grpChiTiet.Controls.Add(this.btnDocTrucTuyen);
            this.grpChiTiet.Controls.Add(this.btnTaiVe);
            this.grpChiTiet.Controls.Add(this.btnDangKyMuon);
            this.grpChiTiet.Location = new System.Drawing.Point(714, 134);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(294, 452);
            this.grpChiTiet.Text = "Chi tiết tài liệu";
            //
            // lblChiTiet
            //
            this.lblChiTiet.Location = new System.Drawing.Point(12, 26);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(270, 210);
            this.lblChiTiet.Text = "Chọn một tài liệu trong danh sách.";
            //
            // txtMoTa
            //
            this.txtMoTa.BackColor = System.Drawing.SystemColors.Window;
            this.txtMoTa.Location = new System.Drawing.Point(12, 242);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(270, 72);
            //
            // btnDocTrucTuyen
            //
            this.btnDocTrucTuyen.Enabled = false;
            this.btnDocTrucTuyen.Location = new System.Drawing.Point(12, 326);
            this.btnDocTrucTuyen.Name = "btnDocTrucTuyen";
            this.btnDocTrucTuyen.Size = new System.Drawing.Size(270, 34);
            this.btnDocTrucTuyen.TabIndex = 11;
            this.btnDocTrucTuyen.Text = "Đọc trực tuyến";
            this.btnDocTrucTuyen.Click += new System.EventHandler(this.btnDocTrucTuyen_Click);
            //
            // btnTaiVe
            //
            this.btnTaiVe.Enabled = false;
            this.btnTaiVe.Location = new System.Drawing.Point(12, 366);
            this.btnTaiVe.Name = "btnTaiVe";
            this.btnTaiVe.Size = new System.Drawing.Size(270, 34);
            this.btnTaiVe.TabIndex = 12;
            this.btnTaiVe.Text = "Tải về (cần mã thẻ)";
            this.btnTaiVe.Click += new System.EventHandler(this.btnTaiVe_Click);
            //
            // btnDangKyMuon
            //
            this.btnDangKyMuon.Enabled = false;
            this.btnDangKyMuon.Location = new System.Drawing.Point(12, 406);
            this.btnDangKyMuon.Name = "btnDangKyMuon";
            this.btnDangKyMuon.Size = new System.Drawing.Size(270, 34);
            this.btnDangKyMuon.TabIndex = 13;
            this.btnDangKyMuon.Text = "Đăng ký mượn";
            this.btnDangKyMuon.Click += new System.EventHandler(this.btnDangKyMuon_Click);
            //
            // btnDong
            //
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(908, 596);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            //
            // FrmTraCuu
            //
            this.AcceptButton = this.btnTim;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.grpTieuChi);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTraCuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tra cứu tài liệu";
            this.Load += new System.EventHandler(this.FrmTraCuu_Load);
            this.grpTieuChi.ResumeLayout(false);
            this.grpTieuChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpTieuChi;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblNamXB;
        private System.Windows.Forms.NumericUpDown numNamXB;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblChuDe;
        private System.Windows.Forms.ComboBox cboChuDe;
        private System.Windows.Forms.RadioButton rdoTatCa;
        private System.Windows.Forms.RadioButton rdoBanIn;
        private System.Windows.Forms.RadioButton rdoDienTu;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnXoaLoc;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnDocTrucTuyen;
        private System.Windows.Forms.Button btnTaiVe;
        private System.Windows.Forms.Button btnDangKyMuon;
        private System.Windows.Forms.Button btnDong;
    }
}
