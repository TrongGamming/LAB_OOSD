namespace EShopping.Forms
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
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.flpChucNang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnGioHang = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnQuanTri = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.stsBar = new System.Windows.Forms.StatusStrip();
            this.lblKetNoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.flpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(696, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "e-SHOPPING – CỬA HÀNG ABC";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(12, 60);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(696, 22);
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMoTa.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTa.Text = "Mùa mua sắm Giáng Sinh và năm mới";
            // 
            // lblXinChao
            // 
            this.lblXinChao.Location = new System.Drawing.Point(12, 86);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(696, 24);
            this.lblXinChao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblXinChao.Text = "Bạn đang xem với tư cách khách vãng lai";
            // 
            // flpChucNang
            // 
            this.flpChucNang.Controls.Add(this.btnSanPham);
            this.flpChucNang.Controls.Add(this.btnGioHang);
            this.flpChucNang.Controls.Add(this.btnDonHang);
            this.flpChucNang.Controls.Add(this.btnQuanTri);
            this.flpChucNang.Controls.Add(this.btnDangNhap);
            this.flpChucNang.Controls.Add(this.btnDangKy);
            this.flpChucNang.Controls.Add(this.btnThoat);
            this.flpChucNang.Location = new System.Drawing.Point(100, 122);
            this.flpChucNang.Name = "flpChucNang";
            this.flpChucNang.Size = new System.Drawing.Size(520, 330);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(0, 0);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(240, 50);
            this.btnSanPham.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnSanPham.TabIndex = 4;
            this.btnSanPham.Text = "Xem sản phẩm";
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnGioHang
            // 
            this.btnGioHang.Location = new System.Drawing.Point(0, 0);
            this.btnGioHang.Name = "btnGioHang";
            this.btnGioHang.Size = new System.Drawing.Size(240, 50);
            this.btnGioHang.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnGioHang.TabIndex = 5;
            this.btnGioHang.Text = "Giỏ hàng (0)";
            this.btnGioHang.Click += new System.EventHandler(this.btnGioHang_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Location = new System.Drawing.Point(0, 0);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(240, 50);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnDonHang.TabIndex = 6;
            this.btnDonHang.Text = "Đơn hàng của tôi";
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnQuanTri
            // 
            this.btnQuanTri.Location = new System.Drawing.Point(0, 0);
            this.btnQuanTri.Name = "btnQuanTri";
            this.btnQuanTri.Size = new System.Drawing.Size(240, 50);
            this.btnQuanTri.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnQuanTri.TabIndex = 7;
            this.btnQuanTri.Text = "Quản trị cửa hàng";
            this.btnQuanTri.Click += new System.EventHandler(this.btnQuanTri_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(0, 0);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(240, 50);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnDangNhap.TabIndex = 8;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(0, 0);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(240, 50);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnDangKy.TabIndex = 9;
            this.btnDangKy.Text = "Đăng ký tài khoản";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(240, 50);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // stsBar
            // 
            this.stsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblKetNoi });
            this.stsBar.Location = new System.Drawing.Point(0, 478);
            this.stsBar.Name = "stsBar";
            this.stsBar.Size = new System.Drawing.Size(720, 22);
            // 
            // lblKetNoi
            // 
            this.lblKetNoi.Name = "lblKetNoi";
            this.lblKetNoi.Text = "Đang kiểm tra kết nối Oracle...";
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(720, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblXinChao);
            this.Controls.Add(this.flpChucNang);
            this.Controls.Add(this.stsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-SHOPPING – Cửa hàng ABC";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.flpChucNang.ResumeLayout(false);
            this.flpChucNang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.FlowLayoutPanel flpChucNang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnGioHang;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnQuanTri;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.StatusStrip stsBar;
        private System.Windows.Forms.ToolStripStatusLabel lblKetNoi;
    }
}
