namespace ThuVienSo.Forms
{
    partial class FrmMain
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.flpChucNang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTaiLieu = new System.Windows.Forms.Button();
            this.btnDocGia = new System.Windows.Forms.Button();
            this.btnMuonTra = new System.Windows.Forms.Button();
            this.btnDuyetDatMua = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnNhatKyEmail = new System.Windows.Forms.Button();
            this.btnDatMua = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.stsBar = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.flpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(736, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN SỐ";
            // 
            // lblXinChao
            // 
            this.lblXinChao.Location = new System.Drawing.Point(12, 66);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(736, 22);
            this.lblXinChao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblXinChao.ForeColor = System.Drawing.Color.DimGray;
            this.lblXinChao.Text = "Xin chào";
            // 
            // flpChucNang
            // 
            this.flpChucNang.Controls.Add(this.btnTraCuu);
            this.flpChucNang.Controls.Add(this.btnDanhMuc);
            this.flpChucNang.Controls.Add(this.btnTaiLieu);
            this.flpChucNang.Controls.Add(this.btnDocGia);
            this.flpChucNang.Controls.Add(this.btnMuonTra);
            this.flpChucNang.Controls.Add(this.btnDuyetDatMua);
            this.flpChucNang.Controls.Add(this.btnBaoCao);
            this.flpChucNang.Controls.Add(this.btnNhatKyEmail);
            this.flpChucNang.Controls.Add(this.btnDatMua);
            this.flpChucNang.Controls.Add(this.btnDoiMatKhau);
            this.flpChucNang.Controls.Add(this.btnDangXuat);
            this.flpChucNang.Controls.Add(this.btnThoat);
            this.flpChucNang.Location = new System.Drawing.Point(90, 96);
            this.flpChucNang.Name = "flpChucNang";
            this.flpChucNang.Size = new System.Drawing.Size(590, 366);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(0, 0);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(270, 48);
            this.btnTraCuu.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnTraCuu.TabIndex = 3;
            this.btnTraCuu.Text = "Tra cứu tài liệu";
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(270, 48);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDanhMuc.TabIndex = 4;
            this.btnDanhMuc.Text = "Danh mục (Chủ đề / Tác giả / NXB)";
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTaiLieu
            // 
            this.btnTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.btnTaiLieu.Name = "btnTaiLieu";
            this.btnTaiLieu.Size = new System.Drawing.Size(270, 48);
            this.btnTaiLieu.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnTaiLieu.TabIndex = 5;
            this.btnTaiLieu.Text = "Quản lý tài liệu";
            this.btnTaiLieu.Click += new System.EventHandler(this.btnTaiLieu_Click);
            // 
            // btnDocGia
            // 
            this.btnDocGia.Location = new System.Drawing.Point(0, 0);
            this.btnDocGia.Name = "btnDocGia";
            this.btnDocGia.Size = new System.Drawing.Size(270, 48);
            this.btnDocGia.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDocGia.TabIndex = 6;
            this.btnDocGia.Text = "Độc giả và thẻ";
            this.btnDocGia.Click += new System.EventHandler(this.btnDocGia_Click);
            // 
            // btnMuonTra
            // 
            this.btnMuonTra.Location = new System.Drawing.Point(0, 0);
            this.btnMuonTra.Name = "btnMuonTra";
            this.btnMuonTra.Size = new System.Drawing.Size(270, 48);
            this.btnMuonTra.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnMuonTra.TabIndex = 7;
            this.btnMuonTra.Text = "Mượn - Trả sách";
            this.btnMuonTra.Click += new System.EventHandler(this.btnMuonTra_Click);
            // 
            // btnDuyetDatMua
            // 
            this.btnDuyetDatMua.Location = new System.Drawing.Point(0, 0);
            this.btnDuyetDatMua.Name = "btnDuyetDatMua";
            this.btnDuyetDatMua.Size = new System.Drawing.Size(270, 48);
            this.btnDuyetDatMua.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDuyetDatMua.TabIndex = 8;
            this.btnDuyetDatMua.Text = "Duyệt yêu cầu đặt mua";
            this.btnDuyetDatMua.Click += new System.EventHandler(this.btnDuyetDatMua_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(0, 0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(270, 48);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnBaoCao.TabIndex = 9;
            this.btnBaoCao.Text = "Báo cáo - Thống kê";
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnNhatKyEmail
            // 
            this.btnNhatKyEmail.Location = new System.Drawing.Point(0, 0);
            this.btnNhatKyEmail.Name = "btnNhatKyEmail";
            this.btnNhatKyEmail.Size = new System.Drawing.Size(270, 48);
            this.btnNhatKyEmail.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnNhatKyEmail.TabIndex = 10;
            this.btnNhatKyEmail.Text = "Nhật ký email nhắc hạn";
            this.btnNhatKyEmail.Click += new System.EventHandler(this.btnNhatKyEmail_Click);
            // 
            // btnDatMua
            // 
            this.btnDatMua.Location = new System.Drawing.Point(0, 0);
            this.btnDatMua.Name = "btnDatMua";
            this.btnDatMua.Size = new System.Drawing.Size(270, 48);
            this.btnDatMua.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDatMua.TabIndex = 11;
            this.btnDatMua.Text = "Yêu cầu đặt mua tài liệu";
            this.btnDatMua.Click += new System.EventHandler(this.btnDatMua_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 0);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(270, 48);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDoiMatKhau.TabIndex = 12;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(0, 0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(270, 48);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDangXuat.TabIndex = 13;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(270, 48);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // stsBar
            // 
            this.stsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblTrangThai });
            this.stsBar.Location = new System.Drawing.Point(0, 498);
            this.stsBar.Name = "stsBar";
            this.stsBar.Size = new System.Drawing.Size(760, 22);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Sẵn sàng";
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblXinChao);
            this.Controls.Add(this.flpChucNang);
            this.Controls.Add(this.stsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện số";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.flpChucNang.ResumeLayout(false);
            this.flpChucNang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.FlowLayoutPanel flpChucNang;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTaiLieu;
        private System.Windows.Forms.Button btnDocGia;
        private System.Windows.Forms.Button btnMuonTra;
        private System.Windows.Forms.Button btnDuyetDatMua;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnNhatKyEmail;
        private System.Windows.Forms.Button btnDatMua;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.StatusStrip stsBar;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
    }
}
