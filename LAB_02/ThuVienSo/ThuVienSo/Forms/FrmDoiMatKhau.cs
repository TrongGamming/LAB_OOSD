using System;
using System.Drawing;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.13 – Đổi mật khẩu tài khoản đang đăng nhập.</summary>
    public partial class FrmDoiMatKhau : Form
    {
        private readonly TaiKhoanService _service = new TaiKhoanService();

        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.DoiMatKhau(Phien.MaTaiKhoan, txtMatKhauCu.Text, txtMatKhauMoi.Text, txtNhapLai.Text);
            if (!kq.ThanhCong)
            {
                lblThongBao.ForeColor = Color.Firebrick;
                lblThongBao.Text = kq.ThongDiep;
                return;
            }
            MessageBox.Show(this, kq.ThongDiep, "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}
