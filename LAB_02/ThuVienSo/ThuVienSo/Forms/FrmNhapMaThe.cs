using System;
using System.Drawing;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>UC-XT-01: dialog dùng chung cho Tải về và Đăng ký mượn.</summary>
    public partial class FrmNhapMaThe : Form
    {
        private readonly TheService _service = new TheService();

        /// <summary>Mã thẻ đã xác thực hợp lệ (khi DialogResult = OK).</summary>
        public string MaThe { get; private set; }

        public FrmNhapMaThe()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.XacThucMaThe(txtMaThe.Text);
            lblThongTin.ForeColor = kq.ThanhCong ? Color.FromArgb(31, 78, 121) : Color.Firebrick;
            lblThongTin.Text = kq.ThongDiep;
            if (!kq.ThanhCong)
            {
                txtMaThe.SelectAll();
                txtMaThe.Focus();
                return;
            }
            MaThe = txtMaThe.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
