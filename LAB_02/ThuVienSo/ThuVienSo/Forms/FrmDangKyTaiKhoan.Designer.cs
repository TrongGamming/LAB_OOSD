namespace ThuVienSo.Forms
{
    partial class FrmDangKyTaiKhoan
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
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblNhapLai = new System.Windows.Forms.Label();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(496, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(30, 70);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Text = "Mã thẻ thư viện *";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(190, 66);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(180, 25);
            this.txtMaThe.MaxLength = 12;
            this.txtMaThe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaThe.TabIndex = 2;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(380, 64);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(100, 29);
            this.btnKiemTra.TabIndex = 3;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(30, 108);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(190, 104);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(290, 25);
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 146);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email đã đăng ký *";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(190, 142);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 25);
            this.txtEmail.Enabled = false;
            this.txtEmail.TabIndex = 7;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 184);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Text = "Tên đăng nhập *";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(190, 180);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(290, 25);
            this.txtTenDangNhap.MaxLength = 50;
            this.txtTenDangNhap.Enabled = false;
            this.txtTenDangNhap.TabIndex = 9;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(30, 222);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu *";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(190, 218);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(290, 25);
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.Enabled = false;
            this.txtMatKhau.TabIndex = 11;
            // 
            // lblNhapLai
            // 
            this.lblNhapLai.AutoSize = true;
            this.lblNhapLai.Location = new System.Drawing.Point(30, 260);
            this.lblNhapLai.Name = "lblNhapLai";
            this.lblNhapLai.Text = "Nhập lại mật khẩu *";
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(190, 256);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(290, 25);
            this.txtNhapLai.UseSystemPasswordChar = true;
            this.txtNhapLai.Enabled = false;
            this.txtNhapLai.TabIndex = 13;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(30, 292);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Text = "Mật khẩu ít nhất 8 ký tự, gồm cả chữ và số.";
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(30, 318);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(460, 40);
            this.lblThongBao.ForeColor = System.Drawing.Color.Firebrick;
            this.lblThongBao.Text = "";
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(190, 364);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(140, 32);
            this.btnDangKy.Enabled = false;
            this.btnDangKy.TabIndex = 16;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(340, 364);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 32);
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.TabIndex = 17;
            this.btnHuy.Text = "Hủy";
            // 
            // FrmDangKyTaiKhoan
            // 
            this.AcceptButton = this.btnKiemTra;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(520, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMaThe);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblNhapLai);
            this.Controls.Add(this.txtNhapLai);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDangKyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký tài khoản độc giả";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblNhapLai;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
    }
}
