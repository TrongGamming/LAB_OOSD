namespace ThuVienSo.Forms
{
    partial class FrmDoiMatKhau
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
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblNhapLai = new System.Windows.Forms.Label();
            this.txtNhapLai = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(416, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "ĐỔI MẬT KHẨU";
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Location = new System.Drawing.Point(30, 70);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Text = "Mật khẩu cũ";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(170, 66);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(240, 25);
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            this.txtMatKhauCu.TabIndex = 2;
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Location = new System.Drawing.Point(30, 108);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(170, 104);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(240, 25);
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            this.txtMatKhauMoi.TabIndex = 4;
            // 
            // lblNhapLai
            // 
            this.lblNhapLai.AutoSize = true;
            this.lblNhapLai.Location = new System.Drawing.Point(30, 146);
            this.lblNhapLai.Name = "lblNhapLai";
            this.lblNhapLai.Text = "Nhập lại";
            // 
            // txtNhapLai
            // 
            this.txtNhapLai.Location = new System.Drawing.Point(170, 142);
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.Size = new System.Drawing.Size(240, 25);
            this.txtNhapLai.UseSystemPasswordChar = true;
            this.txtNhapLai.TabIndex = 6;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(30, 180);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(380, 44);
            this.lblThongBao.ForeColor = System.Drawing.Color.DimGray;
            this.lblThongBao.Text = "Mật khẩu ít nhất 8 ký tự, gồm cả chữ và số.";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(170, 238);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(115, 32);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(295, 238);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(115, 32);
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            // 
            // FrmDoiMatKhau
            // 
            this.AcceptButton = this.btnLuu;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(440, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMatKhauCu);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblNhapLai);
            this.Controls.Add(this.txtNhapLai);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblNhapLai;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}
