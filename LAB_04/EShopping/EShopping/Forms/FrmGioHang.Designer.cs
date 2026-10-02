namespace EShopping.Forms
{
    partial class FrmGioHang
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
            this.dgvGio = new System.Windows.Forms.DataGridView();
            this.lblSL = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXoaHet = new System.Windows.Forms.Button();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(876, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "GIỎ HÀNG HIỆN TẠI";
            // 
            // dgvGio
            // 
            this.dgvGio.Location = new System.Drawing.Point(12, 54);
            this.dgvGio.Name = "dgvGio";
            this.dgvGio.Size = new System.Drawing.Size(876, 330);
            this.dgvGio.AllowUserToAddRows = false;
            this.dgvGio.AllowUserToDeleteRows = false;
            this.dgvGio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGio.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGio.MultiSelect = false;
            this.dgvGio.RowHeadersVisible = false;
            this.dgvGio.ReadOnly = true;
            this.dgvGio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGio.TabIndex = 1;
            this.dgvGio.SelectionChanged += new System.EventHandler(this.dgvGio_SelectionChanged);
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(12, 400);
            this.lblSL.Name = "lblSL";
            this.lblSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSL.Text = "Số lượng sản phẩm đang chọn";
            // 
            // numSL
            // 
            this.numSL.Location = new System.Drawing.Point(214, 396);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(70, 25);
            this.numSL.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.numSL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSL.TabIndex = 3;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(296, 394);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(130, 32);
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật SL";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(434, 394);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 32);
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Loại bỏ khỏi giỏ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXoaHet
            // 
            this.btnXoaHet.Location = new System.Drawing.Point(592, 394);
            this.btnXoaHet.Name = "btnXoaHet";
            this.btnXoaHet.Size = new System.Drawing.Size(120, 32);
            this.btnXoaHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaHet.TabIndex = 6;
            this.btnXoaHet.Text = "Xóa hết";
            this.btnXoaHet.Click += new System.EventHandler(this.btnXoaHet_Click);
            // 
            // lblTong
            // 
            this.lblTong.Location = new System.Drawing.Point(12, 442);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(876, 28);
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTong.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(12, 474);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGhiChu.Text = "Giá hiển thị là giá bán hiện hành từ Hệ thống quản lý sản phẩm.";
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Location = new System.Drawing.Point(596, 494);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(140, 34);
            this.btnTiepTuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTiepTuc.TabIndex = 9;
            this.btnTiepTuc.Text = "Tiếp tục mua";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(748, 494);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(140, 34);
            this.btnTinhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTinhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhTien.TabIndex = 10;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // FrmGioHang
            // 
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvGio);
            this.Controls.Add(this.lblSL);
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXoaHet);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnTinhTien);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmGioHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giỏ hàng";
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Load += new System.EventHandler(this.FrmGioHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGio;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXoaHet;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Button btnTinhTien;
    }
}
