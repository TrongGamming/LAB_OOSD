namespace ThuVienSo.Forms
{
    partial class FrmDanhMuc
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
            this.tabChuDe = new System.Windows.Forms.TabPage();
            this.tabTacGia = new System.Windows.Forms.TabPage();
            this.tabNXB = new System.Windows.Forms.TabPage();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            //
            // tabs
            //
            this.tabs.Controls.Add(this.tabChuDe);
            this.tabs.Controls.Add(this.tabTacGia);
            this.tabs.Controls.Add(this.tabNXB);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(836, 30);
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            //
            // tabChuDe
            //
            this.tabChuDe.Name = "tabChuDe";
            this.tabChuDe.Text = "Chủ đề";
            //
            // tabTacGia
            //
            this.tabTacGia.Name = "tabTacGia";
            this.tabTacGia.Text = "Tác giả";
            //
            // tabNXB
            //
            this.tabNXB.Name = "tabNXB";
            this.tabNXB.Text = "Nhà xuất bản";
            //
            // lblMa
            //
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(24, 62);
            this.lblMa.Name = "lblMa";
            this.lblMa.Text = "Mã";
            //
            // txtMa
            //
            this.txtMa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMa.Location = new System.Drawing.Point(130, 58);
            this.txtMa.MaxLength = 10;
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(140, 25);
            this.txtMa.TabIndex = 0;
            //
            // lbl1
            //
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(300, 62);
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Tên";
            //
            // txt1
            //
            this.txt1.Location = new System.Drawing.Point(400, 58);
            this.txt1.MaxLength = 150;
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(440, 25);
            this.txt1.TabIndex = 1;
            //
            // lbl2
            //
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(24, 100);
            this.lbl2.Name = "lbl2";
            this.lbl2.Text = "Mô tả";
            //
            // txt2
            //
            this.txt2.Location = new System.Drawing.Point(130, 96);
            this.txt2.MaxLength = 255;
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(450, 25);
            this.txt2.TabIndex = 2;
            //
            // lbl3
            //
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(600, 100);
            this.lbl3.Name = "lbl3";
            this.lbl3.Text = "Điện thoại";
            //
            // txt3
            //
            this.txt3.Location = new System.Drawing.Point(690, 96);
            this.txt3.MaxLength = 15;
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(150, 25);
            this.txt3.TabIndex = 3;
            //
            // btnThem
            //
            this.btnThem.Location = new System.Drawing.Point(24, 140);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 32);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnSua
            //
            this.btnSua.Location = new System.Drawing.Point(134, 140);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 32);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            //
            // btnLuu
            //
            this.btnLuu.Enabled = false;
            this.btnLuu.Location = new System.Drawing.Point(244, 140);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 32);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            //
            // btnHuy
            //
            this.btnHuy.Enabled = false;
            this.btnHuy.Location = new System.Drawing.Point(354, 140);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 32);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            //
            // btnXoa
            //
            this.btnXoa.Location = new System.Drawing.Point(464, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 32);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnDong
            //
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(740, 140);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            //
            // dgv
            //
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.Location = new System.Drawing.Point(24, 186);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(816, 330);
            this.dgv.TabIndex = 10;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            //
            // FrmDanhMuc
            //
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(864, 532);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục chủ đề – tác giả – nhà xuất bản";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabChuDe;
        private System.Windows.Forms.TabPage tabTacGia;
        private System.Windows.Forms.TabPage tabNXB;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgv;
    }
}
