namespace EShopping.Forms
{
    partial class FrmSanPham
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
            this.lblNhom = new System.Windows.Forms.Label();
            this.lstNhom = new System.Windows.Forms.ListBox();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnAnhTruoc = new System.Windows.Forms.Button();
            this.btnAnhSau = new System.Windows.Forms.Button();
            this.lblSoAnh = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblNSX = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblThongSo = new System.Windows.Forms.Label();
            this.dgvThongSo = new System.Windows.Forms.DataGridView();
            this.lblSL = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXemGio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Location = new System.Drawing.Point(12, 14);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhom.Text = "Nhóm sản phẩm";
            // 
            // lstNhom
            // 
            this.lstNhom.Location = new System.Drawing.Point(12, 40);
            this.lstNhom.Name = "lstNhom";
            this.lstNhom.Size = new System.Drawing.Size(220, 584);
            this.lstNhom.IntegralHeight = false;
            this.lstNhom.ItemHeight = 20;
            this.lstNhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.lstNhom.TabIndex = 1;
            this.lstNhom.SelectedIndexChanged += new System.EventHandler(this.lstNhom_SelectedIndexChanged);
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(244, 14);
            this.lblTim.Name = "lblTim";
            this.lblTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTim.Text = "Tìm theo tên / nhà sản xuất";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(244, 40);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(340, 25);
            this.txtTim.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(592, 38);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(110, 29);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Location = new System.Drawing.Point(244, 76);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.Size = new System.Drawing.Size(470, 548);
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.TabIndex = 5;
            this.dgvSanPham.SelectionChanged += new System.EventHandler(this.dgvSanPham_SelectionChanged);
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.picAnh);
            this.grpChiTiet.Controls.Add(this.btnAnhTruoc);
            this.grpChiTiet.Controls.Add(this.btnAnhSau);
            this.grpChiTiet.Controls.Add(this.lblSoAnh);
            this.grpChiTiet.Controls.Add(this.lblTenSP);
            this.grpChiTiet.Controls.Add(this.lblNSX);
            this.grpChiTiet.Controls.Add(this.lblGia);
            this.grpChiTiet.Controls.Add(this.lblTinhTrang);
            this.grpChiTiet.Controls.Add(this.txtMoTa);
            this.grpChiTiet.Controls.Add(this.lblThongSo);
            this.grpChiTiet.Controls.Add(this.dgvThongSo);
            this.grpChiTiet.Controls.Add(this.lblSL);
            this.grpChiTiet.Controls.Add(this.numSL);
            this.grpChiTiet.Controls.Add(this.btnThem);
            this.grpChiTiet.Controls.Add(this.btnXemGio);
            this.grpChiTiet.Location = new System.Drawing.Point(726, 8);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(442, 616);
            this.grpChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChiTiet.Text = "Chi tiết sản phẩm";
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(16, 26);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(300, 225);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnAnhTruoc
            // 
            this.btnAnhTruoc.Location = new System.Drawing.Point(326, 26);
            this.btnAnhTruoc.Name = "btnAnhTruoc";
            this.btnAnhTruoc.Size = new System.Drawing.Size(100, 30);
            this.btnAnhTruoc.TabIndex = 8;
            this.btnAnhTruoc.Text = "< Ảnh trước";
            this.btnAnhTruoc.Click += new System.EventHandler(this.btnAnhTruoc_Click);
            // 
            // btnAnhSau
            // 
            this.btnAnhSau.Location = new System.Drawing.Point(326, 62);
            this.btnAnhSau.Name = "btnAnhSau";
            this.btnAnhSau.Size = new System.Drawing.Size(100, 30);
            this.btnAnhSau.TabIndex = 9;
            this.btnAnhSau.Text = "Ảnh sau >";
            this.btnAnhSau.Click += new System.EventHandler(this.btnAnhSau_Click);
            // 
            // lblSoAnh
            // 
            this.lblSoAnh.Location = new System.Drawing.Point(326, 100);
            this.lblSoAnh.Name = "lblSoAnh";
            this.lblSoAnh.Size = new System.Drawing.Size(100, 22);
            this.lblSoAnh.ForeColor = System.Drawing.Color.DimGray;
            this.lblSoAnh.Text = "";
            // 
            // lblTenSP
            // 
            this.lblTenSP.Location = new System.Drawing.Point(16, 258);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(410, 26);
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.Text = "";
            // 
            // lblNSX
            // 
            this.lblNSX.Location = new System.Drawing.Point(16, 286);
            this.lblNSX.Name = "lblNSX";
            this.lblNSX.Size = new System.Drawing.Size(410, 22);
            this.lblNSX.Text = "";
            // 
            // lblGia
            // 
            this.lblGia.Location = new System.Drawing.Point(16, 310);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(220, 24);
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGia.ForeColor = System.Drawing.Color.Firebrick;
            this.lblGia.Text = "";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(240, 312);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(186, 22);
            this.lblTinhTrang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrang.Text = "";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(16, 340);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(410, 62);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.TabIndex = 15;
            // 
            // lblThongSo
            // 
            this.lblThongSo.AutoSize = true;
            this.lblThongSo.Location = new System.Drawing.Point(16, 408);
            this.lblThongSo.Name = "lblThongSo";
            this.lblThongSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongSo.Text = "Thông số kỹ thuật";
            // 
            // dgvThongSo
            // 
            this.dgvThongSo.Location = new System.Drawing.Point(16, 432);
            this.dgvThongSo.Name = "dgvThongSo";
            this.dgvThongSo.Size = new System.Drawing.Size(410, 120);
            this.dgvThongSo.AllowUserToAddRows = false;
            this.dgvThongSo.AllowUserToDeleteRows = false;
            this.dgvThongSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongSo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvThongSo.MultiSelect = false;
            this.dgvThongSo.RowHeadersVisible = false;
            this.dgvThongSo.ReadOnly = true;
            this.dgvThongSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongSo.TabIndex = 17;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(16, 568);
            this.lblSL.Name = "lblSL";
            this.lblSL.Text = "Số lượng";
            // 
            // numSL
            // 
            this.numSL.Location = new System.Drawing.Point(88, 564);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(70, 25);
            this.numSL.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.numSL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.TabIndex = 19;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(170, 562);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 32);
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm vào giỏ";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXemGio
            // 
            this.btnXemGio.Location = new System.Drawing.Point(308, 562);
            this.btnXemGio.Name = "btnXemGio";
            this.btnXemGio.Size = new System.Drawing.Size(118, 32);
            this.btnXemGio.TabIndex = 21;
            this.btnXemGio.Text = "Xem giỏ hàng";
            this.btnXemGio.Click += new System.EventHandler(this.btnXemGio_Click);
            // 
            // FrmSanPham
            // 
            this.AcceptButton = this.btnTim;
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.lblNhom);
            this.Controls.Add(this.lstNhom);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.grpChiTiet);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sản phẩm – e-SHOPPING";
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Load += new System.EventHandler(this.FrmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.ListBox lstNhom;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnAnhTruoc;
        private System.Windows.Forms.Button btnAnhSau;
        private System.Windows.Forms.Label lblSoAnh;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblNSX;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblThongSo;
        private System.Windows.Forms.DataGridView dgvThongSo;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXemGio;
    }
}
