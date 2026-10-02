namespace EShopping.Forms
{
    partial class FrmQuanTri
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
            this.tabPhi = new System.Windows.Forms.TabPage();
            this.lblKV = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblLP = new System.Windows.Forms.Label();
            this.cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.lblPhi = new System.Windows.Forms.Label();
            this.numPhi = new System.Windows.Forms.NumericUpDown();
            this.btnLuuPhi = new System.Windows.Forms.Button();
            this.dgvPhi = new System.Windows.Forms.DataGridView();
            this.grpLoaiPhieu = new System.Windows.Forms.GroupBox();
            this.dgvLoaiPhieu = new System.Windows.Forms.DataGridView();
            this.lblGio = new System.Windows.Forms.Label();
            this.numGio = new System.Windows.Forms.NumericUpDown();
            this.lblNguong = new System.Windows.Forms.Label();
            this.numNguong = new System.Windows.Forms.NumericUpDown();
            this.btnLuuLoaiPhieu = new System.Windows.Forms.Button();
            this.tabThe = new System.Windows.Forms.TabPage();
            this.dgvThe = new System.Windows.Forms.DataGridView();
            this.lblLePhi = new System.Windows.Forms.Label();
            this.numLePhi = new System.Windows.Forms.NumericUpDown();
            this.btnLuuLePhi = new System.Windows.Forms.Button();
            this.lblQuyTac = new System.Windows.Forms.Label();
            this.tabNhatKy = new System.Windows.Forms.TabPage();
            this.dgvNhatKy = new System.Windows.Forms.DataGridView();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.tabPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhi)).BeginInit();
            this.grpLoaiPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNguong)).BeginInit();
            this.tabThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLePhi)).BeginInit();
            this.tabNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).BeginInit();
            this.tabEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPhi);
            this.tabs.Controls.Add(this.tabThe);
            this.tabs.Controls.Add(this.tabNhatKy);
            this.tabs.Controls.Add(this.tabEmail);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(976, 576);
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // tabPhi
            // 
            this.tabPhi.Controls.Add(this.lblKV);
            this.tabPhi.Controls.Add(this.cboKhuVuc);
            this.tabPhi.Controls.Add(this.lblLP);
            this.tabPhi.Controls.Add(this.cboLoaiPhieu);
            this.tabPhi.Controls.Add(this.lblPhi);
            this.tabPhi.Controls.Add(this.numPhi);
            this.tabPhi.Controls.Add(this.btnLuuPhi);
            this.tabPhi.Controls.Add(this.dgvPhi);
            this.tabPhi.Controls.Add(this.grpLoaiPhieu);
            this.tabPhi.Name = "tabPhi";
            this.tabPhi.Size = new System.Drawing.Size(968, 546);
            this.tabPhi.Text = "Biểu phí giao hàng";
            this.tabPhi.UseVisualStyleBackColor = true;
            // 
            // lblKV
            // 
            this.lblKV.AutoSize = true;
            this.lblKV.Location = new System.Drawing.Point(16, 18);
            this.lblKV.Name = "lblKV";
            this.lblKV.Text = "Khu vực";
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.Location = new System.Drawing.Point(80, 14);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(200, 25);
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.TabIndex = 3;
            // 
            // lblLP
            // 
            this.lblLP.AutoSize = true;
            this.lblLP.Location = new System.Drawing.Point(296, 18);
            this.lblLP.Name = "lblLP";
            this.lblLP.Text = "Loại phiếu";
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.Location = new System.Drawing.Point(376, 14);
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.Size = new System.Drawing.Size(230, 25);
            this.cboLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhieu.TabIndex = 5;
            // 
            // lblPhi
            // 
            this.lblPhi.AutoSize = true;
            this.lblPhi.Location = new System.Drawing.Point(622, 18);
            this.lblPhi.Name = "lblPhi";
            this.lblPhi.Text = "Phí (đ)";
            // 
            // numPhi
            // 
            this.numPhi.Location = new System.Drawing.Point(680, 14);
            this.numPhi.Name = "numPhi";
            this.numPhi.Size = new System.Drawing.Size(110, 25);
            this.numPhi.ThousandsSeparator = true;
            this.numPhi.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numPhi.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numPhi.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numPhi.TabIndex = 7;
            // 
            // btnLuuPhi
            // 
            this.btnLuuPhi.Location = new System.Drawing.Point(804, 12);
            this.btnLuuPhi.Name = "btnLuuPhi";
            this.btnLuuPhi.Size = new System.Drawing.Size(140, 29);
            this.btnLuuPhi.TabIndex = 8;
            this.btnLuuPhi.Text = "Lưu biểu phí";
            this.btnLuuPhi.Click += new System.EventHandler(this.btnLuuPhi_Click);
            // 
            // dgvPhi
            // 
            this.dgvPhi.Location = new System.Drawing.Point(16, 52);
            this.dgvPhi.Name = "dgvPhi";
            this.dgvPhi.Size = new System.Drawing.Size(600, 478);
            this.dgvPhi.AllowUserToAddRows = false;
            this.dgvPhi.AllowUserToDeleteRows = false;
            this.dgvPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhi.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhi.MultiSelect = false;
            this.dgvPhi.RowHeadersVisible = false;
            this.dgvPhi.ReadOnly = true;
            this.dgvPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhi.TabIndex = 9;
            this.dgvPhi.SelectionChanged += new System.EventHandler(this.dgvPhi_SelectionChanged);
            // 
            // grpLoaiPhieu
            // 
            this.grpLoaiPhieu.Controls.Add(this.dgvLoaiPhieu);
            this.grpLoaiPhieu.Controls.Add(this.lblGio);
            this.grpLoaiPhieu.Controls.Add(this.numGio);
            this.grpLoaiPhieu.Controls.Add(this.lblNguong);
            this.grpLoaiPhieu.Controls.Add(this.numNguong);
            this.grpLoaiPhieu.Controls.Add(this.btnLuuLoaiPhieu);
            this.grpLoaiPhieu.Location = new System.Drawing.Point(630, 52);
            this.grpLoaiPhieu.Name = "grpLoaiPhieu";
            this.grpLoaiPhieu.Size = new System.Drawing.Size(322, 478);
            this.grpLoaiPhieu.Text = "Loại phiếu – ngưỡng miễn phí";
            // 
            // dgvLoaiPhieu
            // 
            this.dgvLoaiPhieu.Location = new System.Drawing.Point(12, 26);
            this.dgvLoaiPhieu.Name = "dgvLoaiPhieu";
            this.dgvLoaiPhieu.Size = new System.Drawing.Size(298, 250);
            this.dgvLoaiPhieu.AllowUserToAddRows = false;
            this.dgvLoaiPhieu.AllowUserToDeleteRows = false;
            this.dgvLoaiPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLoaiPhieu.MultiSelect = false;
            this.dgvLoaiPhieu.RowHeadersVisible = false;
            this.dgvLoaiPhieu.ReadOnly = true;
            this.dgvLoaiPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiPhieu.TabIndex = 11;
            this.dgvLoaiPhieu.SelectionChanged += new System.EventHandler(this.dgvLoaiPhieu_SelectionChanged);
            // 
            // lblGio
            // 
            this.lblGio.AutoSize = true;
            this.lblGio.Location = new System.Drawing.Point(12, 292);
            this.lblGio.Name = "lblGio";
            this.lblGio.Text = "Số giờ xử lý";
            // 
            // numGio
            // 
            this.numGio.Location = new System.Drawing.Point(150, 288);
            this.numGio.Name = "numGio";
            this.numGio.Size = new System.Drawing.Size(100, 25);
            this.numGio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numGio.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            this.numGio.TabIndex = 13;
            // 
            // lblNguong
            // 
            this.lblNguong.AutoSize = true;
            this.lblNguong.Location = new System.Drawing.Point(12, 328);
            this.lblNguong.Name = "lblNguong";
            this.lblNguong.Text = "Ngưỡng miễn phí (đ)";
            // 
            // numNguong
            // 
            this.numNguong.Location = new System.Drawing.Point(150, 324);
            this.numNguong.Name = "numNguong";
            this.numNguong.Size = new System.Drawing.Size(150, 25);
            this.numNguong.ThousandsSeparator = true;
            this.numNguong.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numNguong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numNguong.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numNguong.TabIndex = 15;
            // 
            // btnLuuLoaiPhieu
            // 
            this.btnLuuLoaiPhieu.Location = new System.Drawing.Point(150, 364);
            this.btnLuuLoaiPhieu.Name = "btnLuuLoaiPhieu";
            this.btnLuuLoaiPhieu.Size = new System.Drawing.Size(150, 30);
            this.btnLuuLoaiPhieu.TabIndex = 16;
            this.btnLuuLoaiPhieu.Text = "Lưu loại phiếu";
            this.btnLuuLoaiPhieu.Click += new System.EventHandler(this.btnLuuLoaiPhieu_Click);
            // 
            // tabThe
            // 
            this.tabThe.Controls.Add(this.dgvThe);
            this.tabThe.Controls.Add(this.lblLePhi);
            this.tabThe.Controls.Add(this.numLePhi);
            this.tabThe.Controls.Add(this.btnLuuLePhi);
            this.tabThe.Controls.Add(this.lblQuyTac);
            this.tabThe.Name = "tabThe";
            this.tabThe.Size = new System.Drawing.Size(968, 546);
            this.tabThe.Text = "Loại thẻ và lệ phí";
            this.tabThe.UseVisualStyleBackColor = true;
            // 
            // dgvThe
            // 
            this.dgvThe.Location = new System.Drawing.Point(16, 16);
            this.dgvThe.Name = "dgvThe";
            this.dgvThe.Size = new System.Drawing.Size(936, 300);
            this.dgvThe.AllowUserToAddRows = false;
            this.dgvThe.AllowUserToDeleteRows = false;
            this.dgvThe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThe.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvThe.MultiSelect = false;
            this.dgvThe.RowHeadersVisible = false;
            this.dgvThe.ReadOnly = true;
            this.dgvThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThe.TabIndex = 18;
            this.dgvThe.SelectionChanged += new System.EventHandler(this.dgvThe_SelectionChanged);
            // 
            // lblLePhi
            // 
            this.lblLePhi.AutoSize = true;
            this.lblLePhi.Location = new System.Drawing.Point(16, 334);
            this.lblLePhi.Name = "lblLePhi";
            this.lblLePhi.Text = "Lệ phí mỗi giao dịch (đ)";
            // 
            // numLePhi
            // 
            this.numLePhi.Location = new System.Drawing.Point(200, 330);
            this.numLePhi.Name = "numLePhi";
            this.numLePhi.Size = new System.Drawing.Size(120, 25);
            this.numLePhi.ThousandsSeparator = true;
            this.numLePhi.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numLePhi.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numLePhi.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numLePhi.TabIndex = 20;
            // 
            // btnLuuLePhi
            // 
            this.btnLuuLePhi.Location = new System.Drawing.Point(334, 328);
            this.btnLuuLePhi.Name = "btnLuuLePhi";
            this.btnLuuLePhi.Size = new System.Drawing.Size(140, 29);
            this.btnLuuLePhi.TabIndex = 21;
            this.btnLuuLePhi.Text = "Lưu lệ phí";
            this.btnLuuLePhi.Click += new System.EventHandler(this.btnLuuLePhi_Click);
            // 
            // lblQuyTac
            // 
            this.lblQuyTac.AutoSize = true;
            this.lblQuyTac.Location = new System.Drawing.Point(16, 372);
            this.lblQuyTac.Name = "lblQuyTac";
            this.lblQuyTac.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuyTac.Text = "VISA / MasterCard / Discover: số thẻ 16 chữ số, CSV 3 chữ số.  American Express: số thẻ 15 chữ số, CSV 4 chữ số.";
            // 
            // tabNhatKy
            // 
            this.tabNhatKy.Controls.Add(this.dgvNhatKy);
            this.tabNhatKy.Name = "tabNhatKy";
            this.tabNhatKy.Size = new System.Drawing.Size(968, 546);
            this.tabNhatKy.Text = "Nhật ký thanh toán";
            this.tabNhatKy.UseVisualStyleBackColor = true;
            // 
            // dgvNhatKy
            // 
            this.dgvNhatKy.Location = new System.Drawing.Point(16, 16);
            this.dgvNhatKy.Name = "dgvNhatKy";
            this.dgvNhatKy.Size = new System.Drawing.Size(936, 514);
            this.dgvNhatKy.AllowUserToAddRows = false;
            this.dgvNhatKy.AllowUserToDeleteRows = false;
            this.dgvNhatKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhatKy.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNhatKy.MultiSelect = false;
            this.dgvNhatKy.RowHeadersVisible = false;
            this.dgvNhatKy.ReadOnly = true;
            this.dgvNhatKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhatKy.TabIndex = 24;
            // 
            // tabEmail
            // 
            this.tabEmail.Controls.Add(this.dgvEmail);
            this.tabEmail.Controls.Add(this.txtNoiDung);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Size = new System.Drawing.Size(968, 546);
            this.tabEmail.Text = "Email xác nhận";
            this.tabEmail.UseVisualStyleBackColor = true;
            // 
            // dgvEmail
            // 
            this.dgvEmail.Location = new System.Drawing.Point(16, 16);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.Size = new System.Drawing.Size(936, 300);
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmail.MultiSelect = false;
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.ReadOnly = true;
            this.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmail.TabIndex = 26;
            this.dgvEmail.SelectionChanged += new System.EventHandler(this.dgvEmail_SelectionChanged);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(16, 326);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(936, 204);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.TabIndex = 27;
            // 
            // FrmQuanTri
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmQuanTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản trị cửa hàng";
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Load += new System.EventHandler(this.FrmQuanTri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNguong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLePhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.tabEmail.ResumeLayout(false);
            this.tabEmail.PerformLayout();
            this.tabNhatKy.ResumeLayout(false);
            this.tabNhatKy.PerformLayout();
            this.tabThe.ResumeLayout(false);
            this.tabThe.PerformLayout();
            this.grpLoaiPhieu.ResumeLayout(false);
            this.grpLoaiPhieu.PerformLayout();
            this.tabPhi.ResumeLayout(false);
            this.tabPhi.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPhi;
        private System.Windows.Forms.Label lblKV;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Label lblLP;
        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.Label lblPhi;
        private System.Windows.Forms.NumericUpDown numPhi;
        private System.Windows.Forms.Button btnLuuPhi;
        private System.Windows.Forms.DataGridView dgvPhi;
        private System.Windows.Forms.GroupBox grpLoaiPhieu;
        private System.Windows.Forms.DataGridView dgvLoaiPhieu;
        private System.Windows.Forms.Label lblGio;
        private System.Windows.Forms.NumericUpDown numGio;
        private System.Windows.Forms.Label lblNguong;
        private System.Windows.Forms.NumericUpDown numNguong;
        private System.Windows.Forms.Button btnLuuLoaiPhieu;
        private System.Windows.Forms.TabPage tabThe;
        private System.Windows.Forms.DataGridView dgvThe;
        private System.Windows.Forms.Label lblLePhi;
        private System.Windows.Forms.NumericUpDown numLePhi;
        private System.Windows.Forms.Button btnLuuLePhi;
        private System.Windows.Forms.Label lblQuyTac;
        private System.Windows.Forms.TabPage tabNhatKy;
        private System.Windows.Forms.DataGridView dgvNhatKy;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.TextBox txtNoiDung;
    }
}
