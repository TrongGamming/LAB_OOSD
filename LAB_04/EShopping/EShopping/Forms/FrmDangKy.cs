using System;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC04 Đăng ký tài khoản khách hàng.</summary>
    public partial class FrmDangKy : Form
    {
        public string TenDangNhapMoi { get; private set; }

        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            dtNgaySinh.MaxDate = DateTime.Today;
            dtNgaySinh.Value = DateTime.Today.AddYears(-20);
        }

        private KhachHangDto DocForm()
        {
            return new KhachHangDto
            {
                HoTen = txtHoTen.Text,
                NgaySinh = dtNgaySinh.Value.Date,
                SoGiayTo = txtSoGiayTo.Text,
                DiaChi = txtDiaChi.Text,
                DienThoai = txtDienThoai.Text,
                Email = txtEmail.Text,
                TenDangNhap = txtTenDN.Text
            };
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            err.Clear();
            KhachHangDto kh = DocForm();
            KetQuaXuLy kq = HeThong.TaiKhoan.DangKy(kh, txtMatKhau.Text, txtNhapLai.Text);
            if (!kq.ThanhCong)
            {
                Control o = ODangLoi(kq.ThongBao);
                if (o != null)
                {
                    err.SetError(o, kq.ThongBao);
                    o.Focus();
                }
                GridHelper.ThongBao(this, kq, "Đăng ký");
                return;
            }
            GridHelper.ThongBao(this, kq, "Đăng ký");
            TenDangNhapMoi = kh.TenDangNhap;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>Ô nhập tương ứng với câu báo lỗi để gắn ErrorProvider.</summary>
        private Control ODangLoi(string loi)
        {
            if (loi.Contains("họ tên")) return txtHoTen;
            if (loi.Contains("Ngày sinh")) return dtNgaySinh;
            if (loi.Contains("CMND")) return txtSoGiayTo;
            if (loi.Contains("địa chỉ") && !loi.Contains("email")) return txtDiaChi;
            if (loi.Contains("điện thoại")) return txtDienThoai;
            if (loi.Contains("email")) return txtEmail;
            if (loi.Contains("Tên đăng nhập")) return txtTenDN;
            if (loi.Contains("nhập lại")) return txtNhapLai;
            if (loi.Contains("Mật khẩu")) return txtMatKhau;
            return null;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
