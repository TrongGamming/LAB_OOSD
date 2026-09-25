namespace ThuVienSo.Forms
{
    partial class FrmNhapMaThe
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
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 30);
            this.lblTitle.Text = "NHẬP MÃ THẺ THƯ VIỆN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMaThe
            //
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(30, 64);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Text = "Mã thẻ";
            //
            // txtMaThe
            //
            this.txtMaThe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaThe.Location = new System.Drawing.Point(100, 60);
            this.txtMaThe.MaxLength = 12;
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(260, 25);
            this.txtMaThe.TabIndex = 0;
            //
            // lblThongTin
            //
            this.lblThongTin.Location = new System.Drawing.Point(30, 96);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(340, 40);
            //
            // btnXacNhan
            //
            this.btnXacNhan.Location = new System.Drawing.Point(100, 144);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 32);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(240, 144);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 32);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            //
            // FrmNhapMaThe
            //
            this.AcceptButton = this.btnXacNhan;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(400, 196);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMaThe);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNhapMaThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác thực mã thẻ thư viện";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}
