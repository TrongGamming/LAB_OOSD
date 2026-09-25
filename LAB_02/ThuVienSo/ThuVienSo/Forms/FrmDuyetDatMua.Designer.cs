namespace ThuVienSo.Forms
{
    partial class FrmDuyetDatMua
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
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.grpQuyetDinh = new System.Windows.Forms.GroupBox();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.rdoChapNhan = new System.Windows.Forms.RadioButton();
            this.rdoTuChoi = new System.Windows.Forms.RadioButton();
            this.rdoDeSau = new System.Windows.Forms.RadioButton();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblLienKet = new System.Windows.Forms.Label();
            this.cboTaiLieuLienKet = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.grpQuyetDinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(12, 18);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Location = new System.Drawing.Point(90, 14);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(150, 25);
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.TabIndex = 1;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(260, 18);
            this.lblTu.Name = "lblTu";
            this.lblTu.Text = "Từ";
            // 
            // dtTu
            // 
            this.dtTu.Location = new System.Drawing.Point(290, 14);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(130, 25);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 3;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(434, 18);
            this.lblDen.Name = "lblDen";
            this.lblDen.Text = "Đến";
            // 
            // dtDen
            // 
            this.dtDen.Location = new System.Drawing.Point(470, 14);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(130, 25);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(616, 12);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 30);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.Location = new System.Drawing.Point(12, 52);
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.Size = new System.Drawing.Size(1016, 300);
            this.dgvYeuCau.AllowUserToAddRows = false;
            this.dgvYeuCau.AllowUserToDeleteRows = false;
            this.dgvYeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYeuCau.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvYeuCau.MultiSelect = false;
            this.dgvYeuCau.RowHeadersVisible = false;
            this.dgvYeuCau.ReadOnly = true;
            this.dgvYeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYeuCau.TabIndex = 7;
            this.dgvYeuCau.SelectionChanged += new System.EventHandler(this.dgvYeuCau_SelectionChanged);
            // 
            // grpQuyetDinh
            // 
            this.grpQuyetDinh.Controls.Add(this.lblChiTiet);
            this.grpQuyetDinh.Controls.Add(this.lblCanhBao);
            this.grpQuyetDinh.Controls.Add(this.rdoChapNhan);
            this.grpQuyetDinh.Controls.Add(this.rdoTuChoi);
            this.grpQuyetDinh.Controls.Add(this.rdoDeSau);
            this.grpQuyetDinh.Controls.Add(this.lblLyDo);
            this.grpQuyetDinh.Controls.Add(this.txtLyDo);
            this.grpQuyetDinh.Controls.Add(this.lblLienKet);
            this.grpQuyetDinh.Controls.Add(this.cboTaiLieuLienKet);
            this.grpQuyetDinh.Controls.Add(this.btnLuu);
            this.grpQuyetDinh.Controls.Add(this.btnDong);
            this.grpQuyetDinh.Location = new System.Drawing.Point(12, 362);
            this.grpQuyetDinh.Name = "grpQuyetDinh";
            this.grpQuyetDinh.Size = new System.Drawing.Size(1016, 270);
            this.grpQuyetDinh.Text = "Quyết định";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.Location = new System.Drawing.Point(14, 28);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(988, 44);
            this.lblChiTiet.Text = "Chọn một yêu cầu trong danh sách.";
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.Location = new System.Drawing.Point(14, 76);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(988, 22);
            this.lblCanhBao.ForeColor = System.Drawing.Color.Chocolate;
            this.lblCanhBao.Text = "";
            // 
            // rdoChapNhan
            // 
            this.rdoChapNhan.AutoSize = true;
            this.rdoChapNhan.Location = new System.Drawing.Point(14, 108);
            this.rdoChapNhan.Name = "rdoChapNhan";
            this.rdoChapNhan.Checked = true;
            this.rdoChapNhan.TabStop = true;
            this.rdoChapNhan.TabIndex = 11;
            this.rdoChapNhan.Text = "Chấp nhận";
            // 
            // rdoTuChoi
            // 
            this.rdoTuChoi.AutoSize = true;
            this.rdoTuChoi.Location = new System.Drawing.Point(140, 108);
            this.rdoTuChoi.Name = "rdoTuChoi";
            this.rdoTuChoi.TabIndex = 12;
            this.rdoTuChoi.Text = "Từ chối";
            // 
            // rdoDeSau
            // 
            this.rdoDeSau.AutoSize = true;
            this.rdoDeSau.Location = new System.Drawing.Point(250, 108);
            this.rdoDeSau.Name = "rdoDeSau";
            this.rdoDeSau.TabIndex = 13;
            this.rdoDeSau.Text = "Để lại xử lý sau";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(14, 146);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Text = "Lý do / ghi chú";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(130, 142);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(872, 52);
            this.txtLyDo.MaxLength = 500;
            this.txtLyDo.Multiline = true;
            this.txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDo.TabIndex = 15;
            // 
            // lblLienKet
            // 
            this.lblLienKet.AutoSize = true;
            this.lblLienKet.Location = new System.Drawing.Point(14, 212);
            this.lblLienKet.Name = "lblLienKet";
            this.lblLienKet.Text = "Liên kết tài liệu";
            // 
            // cboTaiLieuLienKet
            // 
            this.cboTaiLieuLienKet.Location = new System.Drawing.Point(130, 208);
            this.cboTaiLieuLienKet.Name = "cboTaiLieuLienKet";
            this.cboTaiLieuLienKet.Size = new System.Drawing.Size(420, 25);
            this.cboTaiLieuLienKet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaiLieuLienKet.TabIndex = 17;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(740, 206);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 32);
            this.btnLuu.Enabled = false;
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "Lưu quyết định";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(896, 206);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(106, 32);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.TabIndex = 19;
            this.btnDong.Text = "Đóng";
            // 
            // FrmDuyetDatMua
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1040, 680);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTu);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblDen);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dgvYeuCau);
            this.Controls.Add(this.grpQuyetDinh);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDuyetDatMua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xét duyệt yêu cầu đặt mua";
            this.Load += new System.EventHandler(this.FrmDuyetDatMua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.grpQuyetDinh.ResumeLayout(false);
            this.grpQuyetDinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.GroupBox grpQuyetDinh;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.RadioButton rdoChapNhan;
        private System.Windows.Forms.RadioButton rdoTuChoi;
        private System.Windows.Forms.RadioButton rdoDeSau;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblLienKet;
        private System.Windows.Forms.ComboBox cboTaiLieuLienKet;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
    }
}
