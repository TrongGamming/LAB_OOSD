namespace ThuVienSo.Forms
{
    partial class FrmDatMua
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
            this.components = new System.ComponentModel.Container();
            this.grpGui = new System.Windows.Forms.GroupBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblNamXB = new System.Windows.Forms.Label();
            this.numNamXB = new System.Windows.Forms.NumericUpDown();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblGuiKetQua = new System.Windows.Forms.Label();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.lblDanhSach = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpGui.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGui
            // 
            this.grpGui.Controls.Add(this.lblTenSach);
            this.grpGui.Controls.Add(this.txtTenSach);
            this.grpGui.Controls.Add(this.lblNamXB);
            this.grpGui.Controls.Add(this.numNamXB);
            this.grpGui.Controls.Add(this.lblTacGia);
            this.grpGui.Controls.Add(this.txtTacGia);
            this.grpGui.Controls.Add(this.lblNXB);
            this.grpGui.Controls.Add(this.txtNXB);
            this.grpGui.Controls.Add(this.lblLyDo);
            this.grpGui.Controls.Add(this.txtLyDo);
            this.grpGui.Controls.Add(this.lblGuiKetQua);
            this.grpGui.Controls.Add(this.btnGui);
            this.grpGui.Controls.Add(this.btnNhapLai);
            this.grpGui.Location = new System.Drawing.Point(12, 8);
            this.grpGui.Name = "grpGui";
            this.grpGui.Size = new System.Drawing.Size(936, 206);
            this.grpGui.Text = "Gửi yêu cầu mới";
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(14, 32);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Text = "Tên sách *";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(120, 28);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(520, 25);
            this.txtTenSach.MaxLength = 255;
            this.txtTenSach.TabIndex = 2;
            // 
            // lblNamXB
            // 
            this.lblNamXB.AutoSize = true;
            this.lblNamXB.Location = new System.Drawing.Point(660, 32);
            this.lblNamXB.Name = "lblNamXB";
            this.lblNamXB.Text = "Năm XB *";
            // 
            // numNamXB
            // 
            this.numNamXB.Location = new System.Drawing.Point(740, 28);
            this.numNamXB.Name = "numNamXB";
            this.numNamXB.Size = new System.Drawing.Size(90, 25);
            this.numNamXB.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            this.numNamXB.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamXB.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            this.numNamXB.TabIndex = 4;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(14, 68);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Text = "Tác giả *";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(120, 64);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(520, 25);
            this.txtTacGia.MaxLength = 150;
            this.txtTacGia.TabIndex = 6;
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(660, 68);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Text = "NXB";
            // 
            // txtNXB
            // 
            this.txtNXB.Location = new System.Drawing.Point(700, 64);
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.Size = new System.Drawing.Size(220, 25);
            this.txtNXB.MaxLength = 150;
            this.txtNXB.TabIndex = 8;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(14, 104);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Text = "Lý do đề nghị";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(120, 100);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(800, 56);
            this.txtLyDo.MaxLength = 500;
            this.txtLyDo.Multiline = true;
            this.txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDo.TabIndex = 10;
            // 
            // lblGuiKetQua
            // 
            this.lblGuiKetQua.Location = new System.Drawing.Point(120, 168);
            this.lblGuiKetQua.Name = "lblGuiKetQua";
            this.lblGuiKetQua.Size = new System.Drawing.Size(560, 22);
            this.lblGuiKetQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblGuiKetQua.Text = "";
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(700, 164);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(110, 32);
            this.btnGui.TabIndex = 12;
            this.btnGui.Text = "Gửi";
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(816, 164);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(104, 32);
            this.btnNhapLai.TabIndex = 13;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Location = new System.Drawing.Point(12, 228);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.Text = "Yêu cầu đã gửi";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(640, 228);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Text = "Lọc";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.Location = new System.Drawing.Point(680, 224);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(180, 25);
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.TabIndex = 16;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.Location = new System.Drawing.Point(12, 256);
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.Size = new System.Drawing.Size(936, 330);
            this.dgvYeuCau.AllowUserToAddRows = false;
            this.dgvYeuCau.AllowUserToDeleteRows = false;
            this.dgvYeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYeuCau.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvYeuCau.MultiSelect = false;
            this.dgvYeuCau.RowHeadersVisible = false;
            this.dgvYeuCau.ReadOnly = true;
            this.dgvYeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYeuCau.TabIndex = 17;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(848, 596);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.TabIndex = 18;
            this.btnDong.Text = "Đóng";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // FrmDatMua
            // 
            this.AcceptButton = this.btnGui;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(960, 640);
            this.Controls.Add(this.grpGui);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.cboLocTrangThai);
            this.Controls.Add(this.dgvYeuCau);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDatMua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yêu cầu đặt mua tài liệu điện tử";
            this.Load += new System.EventHandler(this.FrmDatMua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.grpGui.ResumeLayout(false);
            this.grpGui.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpGui;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblNamXB;
        private System.Windows.Forms.NumericUpDown numNamXB;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblGuiKetQua;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Button btnNhapLai;
        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}
