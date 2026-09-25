using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.2 – UC-TK-01: Đăng ký tài khoản độc giả («extend» UC-TK-02).</summary>
    public partial class FrmDangKyTaiKhoan : Form
    {
        private readonly TaiKhoanService _service = new TaiKhoanService();

        /// <summary>Tên đăng nhập vừa tạo, để FrmDangNhap điền sẵn.</summary>
        public string TenDangNhapMoi { get; private set; }

        public FrmDangKyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.KiemTraTheDangKy(txtMaThe.Text);
            MoKhoaNhap(kq.ThanhCong);
            if (!kq.ThanhCong)
            {
                txtHoTen.Clear();
                lblThongBao.Text = kq.ThongDiep;
                return;
            }
            txtHoTen.Text = kq.ThongDiep;
            lblThongBao.Text = "";
            AcceptButton = btnDangKy;
            txtEmail.Focus();
        }

        private void MoKhoaNhap(bool mo)
        {
            txtEmail.Enabled = txtTenDangNhap.Enabled = txtMatKhau.Enabled = txtNhapLai.Enabled = btnDangKy.Enabled = mo;
            txtMaThe.ReadOnly = mo;   // đã kiểm tra thì khóa mã thẻ
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.DangKy(txtMaThe.Text, txtEmail.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtNhapLai.Text);
            if (!kq.ThanhCong)
            {
                lblThongBao.Text = kq.ThongDiep;
                return;
            }
            MessageBox.Show(this, kq.ThongDiep, "Đăng ký tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TenDangNhapMoi = txtTenDangNhap.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
