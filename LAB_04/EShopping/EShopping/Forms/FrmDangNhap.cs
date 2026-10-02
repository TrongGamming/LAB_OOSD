using System;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC05 Đăng nhập (khách hàng hoặc nhân viên).</summary>
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = HeThong.TaiKhoan.DangNhap(txtTen.Text, txtMatKhau.Text);
            if (!kq.ThanhCong)
            {
                lblLoi.Text = kq.ThongBao;
                txtMatKhau.SelectAll();
                txtMatKhau.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>Chưa có tài khoản: mở form đăng ký, đăng ký xong điền sẵn tên đăng nhập.</summary>
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (FrmDangKy f = new FrmDangKy())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    txtTen.Text = f.TenDangNhapMoi;
                    lblLoi.Text = "";
                    txtMatKhau.Focus();
                }
            }
        }
    }
}
