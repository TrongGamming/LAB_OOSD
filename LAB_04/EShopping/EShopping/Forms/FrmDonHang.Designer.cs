namespace EShopping.Forms
{
    partial class FrmDonHang
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
            this.lblLoc = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dgvDon = new System.Windows.Forms.DataGridView();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.grpXuLy = new System.Windows.Forms.GroupBox();
            this.lblTrangThaiHT = new System.Windows.Forms.Label();
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.lblMoi = new System.Windows.Forms.Label();
            this.cboTrangThaiMoi = new System.Windows.Forms.ComboBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.grpXuLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(12, 16);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Text = "Trạng thái";
            // 
            // cboLoc
            // 
            this.cboLoc.Location = new System.Drawing.Point(90, 12);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(180, 25);
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.TabIndex = 1;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(280, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 29);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Location = new System.Drawing.Point(400, 16);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(688, 22);
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Text = "";
            // 
            // dgvDon
            // 
            this.dgvDon.Location = new System.Drawing.Point(12, 48);
            this.dgvDon.Name = "dgvDon";
            this.dgvDon.Size = new System.Drawing.Size(1076, 300);
            this.dgvDon.AllowUserToAddRows = false;
            this.dgvDon.AllowUserToDeleteRows = false;
            this.dgvDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDon.MultiSelect = false;
            this.dgvDon.RowHeadersVisible = false;
            this.dgvDon.ReadOnly = true;
            this.dgvDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDon.TabIndex = 4;
            this.dgvDon.SelectionChanged += new System.EventHandler(this.dgvDon_SelectionChanged);
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Location = new System.Drawing.Point(12, 358);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChiTiet.Text = "Chi tiết đơn hàng (đơn giá chốt tại thời điểm đặt)";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 382);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.Size = new System.Drawing.Size(640, 246);
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.TabIndex = 6;
            // 
            // grpXuLy
            // 
            this.grpXuLy.Controls.Add(this.lblTrangThaiHT);
            this.grpXuLy.Controls.Add(this.lblNguoiNhan);
            this.grpXuLy.Controls.Add(this.lblMoi);
            this.grpXuLy.Controls.Add(this.cboTrangThaiMoi);
            this.grpXuLy.Controls.Add(this.btnCapNhat);
            this.grpXuLy.Controls.Add(this.btnHuyDon);
            this.grpXuLy.Controls.Add(this.lblGhiChu);
            this.grpXuLy.Location = new System.Drawing.Point(664, 358);
            this.grpXuLy.Name = "grpXuLy";
            this.grpXuLy.Size = new System.Drawing.Size(424, 270);
            this.grpXuLy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpXuLy.Text = "Xử lý đơn hàng";
            // 
            // lblTrangThaiHT
            // 
            this.lblTrangThaiHT.Location = new System.Drawing.Point(16, 30);
            this.lblTrangThaiHT.Name = "lblTrangThaiHT";
            this.lblTrangThaiHT.Size = new System.Drawing.Size(392, 24);
            this.lblTrangThaiHT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiHT.Text = "";
            // 
            // lblNguoiNhan
            // 
            this.lblNguoiNhan.Location = new System.Drawing.Point(16, 58);
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Size = new System.Drawing.Size(392, 66);
            this.lblNguoiNhan.ForeColor = System.Drawing.Color.DimGray;
            this.lblNguoiNhan.Text = "";
            // 
            // lblMoi
            // 
            this.lblMoi.AutoSize = true;
            this.lblMoi.Location = new System.Drawing.Point(16, 136);
            this.lblMoi.Name = "lblMoi";
            this.lblMoi.Text = "Chuyển sang";
            // 
            // cboTrangThaiMoi
            // 
            this.cboTrangThaiMoi.Location = new System.Drawing.Point(110, 132);
            this.cboTrangThaiMoi.Name = "cboTrangThaiMoi";
            this.cboTrangThaiMoi.Size = new System.Drawing.Size(160, 25);
            this.cboTrangThaiMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiMoi.TabIndex = 11;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(280, 130);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(128, 29);
            this.btnCapNhat.TabIndex = 12;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Location = new System.Drawing.Point(16, 178);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(392, 34);
            this.btnHuyDon.TabIndex = 13;
            this.btnHuyDon.Text = "Hủy đơn hàng (chỉ khi đang Chờ xử lý)";
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(16, 222);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(392, 40);
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Text = "Hủy đơn sẽ hoàn tiền qua Hệ thống thanh toán trực tuyến.";
            // 
            // FrmDonHang
            // 
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.dgvDon);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.grpXuLy);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đơn đặt hàng";
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Load += new System.EventHandler(this.FrmDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.grpXuLy.ResumeLayout(false);
            this.grpXuLy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView dgvDon;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox grpXuLy;
        private System.Windows.Forms.Label lblTrangThaiHT;
        private System.Windows.Forms.Label lblNguoiNhan;
        private System.Windows.Forms.Label lblMoi;
        private System.Windows.Forms.ComboBox cboTrangThaiMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Label lblGhiChu;
    }
}
