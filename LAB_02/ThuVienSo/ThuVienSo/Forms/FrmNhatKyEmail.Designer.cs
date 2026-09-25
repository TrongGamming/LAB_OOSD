namespace ThuVienSo.Forms
{
    partial class FrmNhatKyEmail
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
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnChayNgay = new System.Windows.Forms.Button();
            this.lblLanChay = new System.Windows.Forms.Label();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnGuiLai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(12, 18);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Text = "Ngày tạo";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(84, 14);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(150, 25);
            this.dtNgay.ShowCheckBox = true;
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(250, 18);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Location = new System.Drawing.Point(330, 14);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(140, 25);
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.TabIndex = 3;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(482, 12);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(90, 30);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnChayNgay
            // 
            this.btnChayNgay.Location = new System.Drawing.Point(900, 12);
            this.btnChayNgay.Name = "btnChayNgay";
            this.btnChayNgay.Size = new System.Drawing.Size(188, 30);
            this.btnChayNgay.TabIndex = 5;
            this.btnChayNgay.Text = "Chạy nhắc hạn ngay";
            this.btnChayNgay.Click += new System.EventHandler(this.btnChayNgay_Click);
            // 
            // lblLanChay
            // 
            this.lblLanChay.Location = new System.Drawing.Point(12, 52);
            this.lblLanChay.Name = "lblLanChay";
            this.lblLanChay.Size = new System.Drawing.Size(1076, 22);
            this.lblLanChay.ForeColor = System.Drawing.Color.DimGray;
            this.lblLanChay.Text = "";
            // 
            // dgvEmail
            // 
            this.dgvEmail.Location = new System.Drawing.Point(12, 78);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.Size = new System.Drawing.Size(1076, 460);
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmail.MultiSelect = true;
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmail.TabIndex = 7;
            this.dgvEmail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmail_CellFormatting);
            // 
            // lblKetQua
            // 
            this.lblKetQua.Location = new System.Drawing.Point(12, 550);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(760, 52);
            this.lblKetQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblKetQua.Text = "";
            // 
            // btnGuiLai
            // 
            this.btnGuiLai.Location = new System.Drawing.Point(780, 548);
            this.btnGuiLai.Name = "btnGuiLai";
            this.btnGuiLai.Size = new System.Drawing.Size(200, 34);
            this.btnGuiLai.TabIndex = 9;
            this.btnGuiLai.Text = "Gửi lại email lỗi đã chọn";
            this.btnGuiLai.Click += new System.EventHandler(this.btnGuiLai_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(988, 548);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            // 
            // FrmNhatKyEmail
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.btnChayNgay);
            this.Controls.Add(this.lblLanChay);
            this.Controls.Add(this.dgvEmail);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.btnGuiLai);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNhatKyEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhật ký email nhắc hạn";
            this.Load += new System.EventHandler(this.FrmNhatKyEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnChayNgay;
        private System.Windows.Forms.Label lblLanChay;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnGuiLai;
        private System.Windows.Forms.Button btnDong;
    }
}
