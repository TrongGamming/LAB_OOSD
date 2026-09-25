namespace ThuVienSo.Forms
{
    partial class FrmBaoCao
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
            this.lblTu = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblTenLuotMuon = new System.Windows.Forms.Label();
            this.lblLuotMuon = new System.Windows.Forms.Label();
            this.lblTenQuaHan = new System.Windows.Forms.Label();
            this.lblQuaHan = new System.Windows.Forms.Label();
            this.lblTenLuotTai = new System.Windows.Forms.Label();
            this.lblLuotTai = new System.Windows.Forms.Label();
            this.lblTenDatMua = new System.Windows.Forms.Label();
            this.lblDatMua = new System.Windows.Forms.Label();
            this.lblTenEmail = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabTheoChuDe = new System.Windows.Forms.TabPage();
            this.dgvTheoChuDe = new System.Windows.Forms.DataGridView();
            this.tabQuaHan = new System.Windows.Forms.TabPage();
            this.dgvQuaHan = new System.Windows.Forms.DataGridView();
            this.tabTopTai = new System.Windows.Forms.TabPage();
            this.dgvTopTai = new System.Windows.Forms.DataGridView();
            this.tabDatMua = new System.Windows.Forms.TabPage();
            this.dgvDatMua = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabTheoChuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoChuDe)).BeginInit();
            this.tabQuaHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).BeginInit();
            this.tabTopTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTai)).BeginInit();
            this.tabDatMua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatMua)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(12, 18);
            this.lblTu.Name = "lblTu";
            this.lblTu.Text = "Từ ngày";
            // 
            // dtTu
            // 
            this.dtTu.Location = new System.Drawing.Point(80, 14);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(130, 25);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(226, 18);
            this.lblDen.Name = "lblDen";
            this.lblDen.Text = "Đến ngày";
            // 
            // dtDen
            // 
            this.dtDen.Location = new System.Drawing.Point(300, 14);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(130, 25);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(450, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(556, 12);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 30);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "Xuất Excel (CSV)";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(716, 18);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(312, 22);
            this.lblThongBao.ForeColor = System.Drawing.Color.DimGray;
            this.lblThongBao.Text = "";
            // 
            // lblTenLuotMuon
            // 
            this.lblTenLuotMuon.Location = new System.Drawing.Point(12, 56);
            this.lblTenLuotMuon.Name = "lblTenLuotMuon";
            this.lblTenLuotMuon.Size = new System.Drawing.Size(196, 22);
            this.lblTenLuotMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenLuotMuon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenLuotMuon.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenLuotMuon.Text = "Lượt mượn";
            // 
            // lblLuotMuon
            // 
            this.lblLuotMuon.Location = new System.Drawing.Point(12, 78);
            this.lblLuotMuon.Name = "lblLuotMuon";
            this.lblLuotMuon.Size = new System.Drawing.Size(196, 44);
            this.lblLuotMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLuotMuon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLuotMuon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLuotMuon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblLuotMuon.Text = "0";
            // 
            // lblTenQuaHan
            // 
            this.lblTenQuaHan.Location = new System.Drawing.Point(216, 56);
            this.lblTenQuaHan.Name = "lblTenQuaHan";
            this.lblTenQuaHan.Size = new System.Drawing.Size(196, 22);
            this.lblTenQuaHan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenQuaHan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenQuaHan.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenQuaHan.Text = "Đang quá hạn";
            // 
            // lblQuaHan
            // 
            this.lblQuaHan.Location = new System.Drawing.Point(216, 78);
            this.lblQuaHan.Name = "lblQuaHan";
            this.lblQuaHan.Size = new System.Drawing.Size(196, 44);
            this.lblQuaHan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuaHan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuaHan.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblQuaHan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblQuaHan.Text = "0";
            // 
            // lblTenLuotTai
            // 
            this.lblTenLuotTai.Location = new System.Drawing.Point(420, 56);
            this.lblTenLuotTai.Name = "lblTenLuotTai";
            this.lblTenLuotTai.Size = new System.Drawing.Size(196, 22);
            this.lblTenLuotTai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenLuotTai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenLuotTai.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenLuotTai.Text = "Lượt tải ebook";
            // 
            // lblLuotTai
            // 
            this.lblLuotTai.Location = new System.Drawing.Point(420, 78);
            this.lblLuotTai.Name = "lblLuotTai";
            this.lblLuotTai.Size = new System.Drawing.Size(196, 44);
            this.lblLuotTai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLuotTai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLuotTai.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLuotTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblLuotTai.Text = "0";
            // 
            // lblTenDatMua
            // 
            this.lblTenDatMua.Location = new System.Drawing.Point(624, 56);
            this.lblTenDatMua.Name = "lblTenDatMua";
            this.lblTenDatMua.Size = new System.Drawing.Size(196, 22);
            this.lblTenDatMua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenDatMua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenDatMua.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenDatMua.Text = "Yêu cầu đặt mua";
            // 
            // lblDatMua
            // 
            this.lblDatMua.Location = new System.Drawing.Point(624, 78);
            this.lblDatMua.Name = "lblDatMua";
            this.lblDatMua.Size = new System.Drawing.Size(196, 44);
            this.lblDatMua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatMua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDatMua.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDatMua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDatMua.Text = "0";
            // 
            // lblTenEmail
            // 
            this.lblTenEmail.Location = new System.Drawing.Point(828, 56);
            this.lblTenEmail.Name = "lblTenEmail";
            this.lblTenEmail.Size = new System.Drawing.Size(196, 22);
            this.lblTenEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenEmail.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenEmail.Text = "Email nhắc đã gửi";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(828, 78);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(196, 44);
            this.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblEmail.Text = "0";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabTheoChuDe);
            this.tabs.Controls.Add(this.tabQuaHan);
            this.tabs.Controls.Add(this.tabTopTai);
            this.tabs.Controls.Add(this.tabDatMua);
            this.tabs.Location = new System.Drawing.Point(12, 134);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(1016, 474);
            // 
            // tabTheoChuDe
            // 
            this.tabTheoChuDe.Controls.Add(this.dgvTheoChuDe);
            this.tabTheoChuDe.Name = "tabTheoChuDe";
            this.tabTheoChuDe.Size = new System.Drawing.Size(1008, 440);
            this.tabTheoChuDe.Text = "Mượn theo chủ đề";
            this.tabTheoChuDe.UseVisualStyleBackColor = true;
            // 
            // dgvTheoChuDe
            // 
            this.dgvTheoChuDe.Location = new System.Drawing.Point(6, 6);
            this.dgvTheoChuDe.Name = "dgvTheoChuDe";
            this.dgvTheoChuDe.Size = new System.Drawing.Size(996, 428);
            this.dgvTheoChuDe.AllowUserToAddRows = false;
            this.dgvTheoChuDe.AllowUserToDeleteRows = false;
            this.dgvTheoChuDe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTheoChuDe.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTheoChuDe.MultiSelect = false;
            this.dgvTheoChuDe.RowHeadersVisible = false;
            this.dgvTheoChuDe.ReadOnly = true;
            this.dgvTheoChuDe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheoChuDe.TabIndex = 19;
            // 
            // tabQuaHan
            // 
            this.tabQuaHan.Controls.Add(this.dgvQuaHan);
            this.tabQuaHan.Name = "tabQuaHan";
            this.tabQuaHan.Size = new System.Drawing.Size(1008, 440);
            this.tabQuaHan.Text = "Danh sách quá hạn";
            this.tabQuaHan.UseVisualStyleBackColor = true;
            // 
            // dgvQuaHan
            // 
            this.dgvQuaHan.Location = new System.Drawing.Point(6, 6);
            this.dgvQuaHan.Name = "dgvQuaHan";
            this.dgvQuaHan.Size = new System.Drawing.Size(996, 428);
            this.dgvQuaHan.AllowUserToAddRows = false;
            this.dgvQuaHan.AllowUserToDeleteRows = false;
            this.dgvQuaHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuaHan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvQuaHan.MultiSelect = false;
            this.dgvQuaHan.RowHeadersVisible = false;
            this.dgvQuaHan.ReadOnly = true;
            this.dgvQuaHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuaHan.TabIndex = 21;
            // 
            // tabTopTai
            // 
            this.tabTopTai.Controls.Add(this.dgvTopTai);
            this.tabTopTai.Name = "tabTopTai";
            this.tabTopTai.Size = new System.Drawing.Size(1008, 440);
            this.tabTopTai.Text = "Top tài liệu được tải";
            this.tabTopTai.UseVisualStyleBackColor = true;
            // 
            // dgvTopTai
            // 
            this.dgvTopTai.Location = new System.Drawing.Point(6, 6);
            this.dgvTopTai.Name = "dgvTopTai";
            this.dgvTopTai.Size = new System.Drawing.Size(996, 428);
            this.dgvTopTai.AllowUserToAddRows = false;
            this.dgvTopTai.AllowUserToDeleteRows = false;
            this.dgvTopTai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopTai.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTopTai.MultiSelect = false;
            this.dgvTopTai.RowHeadersVisible = false;
            this.dgvTopTai.ReadOnly = true;
            this.dgvTopTai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopTai.TabIndex = 23;
            // 
            // tabDatMua
            // 
            this.tabDatMua.Controls.Add(this.dgvDatMua);
            this.tabDatMua.Name = "tabDatMua";
            this.tabDatMua.Size = new System.Drawing.Size(1008, 440);
            this.tabDatMua.Text = "Đặt mua theo trạng thái";
            this.tabDatMua.UseVisualStyleBackColor = true;
            // 
            // dgvDatMua
            // 
            this.dgvDatMua.Location = new System.Drawing.Point(6, 6);
            this.dgvDatMua.Name = "dgvDatMua";
            this.dgvDatMua.Size = new System.Drawing.Size(996, 428);
            this.dgvDatMua.AllowUserToAddRows = false;
            this.dgvDatMua.AllowUserToDeleteRows = false;
            this.dgvDatMua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatMua.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatMua.MultiSelect = false;
            this.dgvDatMua.RowHeadersVisible = false;
            this.dgvDatMua.ReadOnly = true;
            this.dgvDatMua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatMua.TabIndex = 25;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(928, 612);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 26);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.TabIndex = 26;
            this.btnDong.Text = "Đóng";
            // 
            // FrmBaoCao
            // 
            this.AcceptButton = this.btnXem;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.lblTu);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblDen);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.lblTenLuotMuon);
            this.Controls.Add(this.lblLuotMuon);
            this.Controls.Add(this.lblTenQuaHan);
            this.Controls.Add(this.lblQuaHan);
            this.Controls.Add(this.lblTenLuotTai);
            this.Controls.Add(this.lblLuotTai);
            this.Controls.Add(this.lblTenDatMua);
            this.Controls.Add(this.lblDatMua);
            this.Controls.Add(this.lblTenEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo – thống kê";
            this.Load += new System.EventHandler(this.FrmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoChuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatMua)).EndInit();
            this.tabDatMua.ResumeLayout(false);
            this.tabDatMua.PerformLayout();
            this.tabTopTai.ResumeLayout(false);
            this.tabTopTai.PerformLayout();
            this.tabQuaHan.ResumeLayout(false);
            this.tabQuaHan.PerformLayout();
            this.tabTheoChuDe.ResumeLayout(false);
            this.tabTheoChuDe.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblTenLuotMuon;
        private System.Windows.Forms.Label lblLuotMuon;
        private System.Windows.Forms.Label lblTenQuaHan;
        private System.Windows.Forms.Label lblQuaHan;
        private System.Windows.Forms.Label lblTenLuotTai;
        private System.Windows.Forms.Label lblLuotTai;
        private System.Windows.Forms.Label lblTenDatMua;
        private System.Windows.Forms.Label lblDatMua;
        private System.Windows.Forms.Label lblTenEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabTheoChuDe;
        private System.Windows.Forms.DataGridView dgvTheoChuDe;
        private System.Windows.Forms.TabPage tabQuaHan;
        private System.Windows.Forms.DataGridView dgvQuaHan;
        private System.Windows.Forms.TabPage tabTopTai;
        private System.Windows.Forms.DataGridView dgvTopTai;
        private System.Windows.Forms.TabPage tabDatMua;
        private System.Windows.Forms.DataGridView dgvDatMua;
        private System.Windows.Forms.Button btnDong;
    }
}
