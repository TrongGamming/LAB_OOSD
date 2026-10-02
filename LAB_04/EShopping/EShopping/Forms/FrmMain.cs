using System;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>Màn hình chính: kiểm tra kết nối Oracle, hiển thị người dùng và mở các chức năng theo vai trò.</summary>
    public partial class FrmMain : Form
    {
        private bool _daKetNoi;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                lblKetNoi.Text = "Đã kết nối Oracle: " + HeThong.KiemTraKetNoi();
                _daKetNoi = true;
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Chưa kết nối được Oracle";
                GridHelper.LoiHeThong(this, ex);
            }
            CapNhatGiaoDien();
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            if (_daKetNoi) CapNhatGiaoDien();
        }

        /// <summary>Ẩn/hiện chức năng theo vai trò và cập nhật số lượng trong giỏ.</summary>
        public void CapNhatGiaoDien()
        {
            bool kh = PhienLamViec.LaKhachHang, nv = PhienLamViec.LaNhanVien;
            lblXinChao.Text = !PhienLamViec.DaDangNhap ? "Bạn đang xem với tư cách khách vãng lai"
                : "Xin chào " + PhienLamViec.HoTen + " (" + PhienLamViec.VaiTro + ")";
            btnSanPham.Visible = !nv;
            btnGioHang.Visible = !nv;
            btnDonHang.Visible = kh || nv;
            btnDonHang.Text = nv ? "Xử lý đơn hàng" : "Đơn hàng của tôi";
            btnQuanTri.Visible = nv;
            btnDangKy.Visible = !PhienLamViec.DaDangNhap;
            btnDangNhap.Text = PhienLamViec.DaDangNhap ? "Đăng xuất" : "Đăng nhập";
            foreach (Control c in flpChucNang.Controls) c.Enabled = _daKetNoi || c == btnThoat;
            try
            {
                if (_daKetNoi) btnGioHang.Text = "Giỏ hàng (" + HeThong.GioHang.DemSoLuong(PhienLamViec.MaGioHang) + ")";
            }
            catch (Exception)
            {
                btnGioHang.Text = "Giỏ hàng";
            }
        }

        private void MoForm(Form f)
        {
            using (f) f.ShowDialog(this);
            CapNhatGiaoDien();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            MoForm(new FrmSanPham());
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            MoForm(new FrmGioHang());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            MoForm(new FrmDonHang());
        }

        private void btnQuanTri_Click(object sender, EventArgs e)
        {
            MoForm(new FrmQuanTri());
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (PhienLamViec.DaDangNhap)
            {
                if (!GridHelper.XacNhan(this, "Đăng xuất khỏi tài khoản " + PhienLamViec.HoTen + "?")) return;
                HeThong.TaiKhoan.DangXuat();
                CapNhatGiaoDien();
                return;
            }
            MoForm(new FrmDangNhap());
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            MoForm(new FrmDangKy());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
