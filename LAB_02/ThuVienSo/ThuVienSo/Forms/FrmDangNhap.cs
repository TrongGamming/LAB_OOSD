using System;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.1 – UC-TK-02: Đăng nhập (mở FrmDangKyTaiKhoan theo quan hệ «extend»).</summary>
    public partial class FrmDangNhap : Form
    {
        private readonly TaiKhoanService _service = new TaiKhoanService();

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            Cursor = Cursors.WaitCursor;
            KetQuaXuLy kq = _service.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
            Cursor = Cursors.Default;
            if (!kq.ThanhCong)
            {
                lblThongBao.Text = kq.ThongDiep;
                txtMatKhau.SelectAll();
                txtMatKhau.Focus();
                return;
            }
            DialogResult = DialogResult.OK;   // Program mở FrmMain
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (FrmDangKyTaiKhoan f = new FrmDangKyTaiKhoan())
            {
                if (f.ShowDialog(this) != DialogResult.OK) return;
                txtTenDangNhap.Text = f.TenDangNhapMoi;   // điền sẵn tên vừa tạo
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                lblThongBao.Text = "";
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
