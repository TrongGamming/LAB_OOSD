using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC03.2–03.4 Xem giỏ hàng, cập nhật số lượng, loại bỏ sản phẩm; nút "Tính tiền" mở UC07.</summary>
    public partial class FrmGioHang : Form
    {
        public FrmGioHang()
        {
            InitializeComponent();
        }

        private void FrmGioHang_Load(object sender, EventArgs e)
        {
            NapGio();
        }

        private void NapGio()
        {
            try
            {
                DataTable t = HeThong.GioHang.LayChiTiet(PhienLamViec.MaGioHang);
                GridHelper.HienThi(dgvGio, t, "MaSP", "Mã SP", "TenSP", "*Tên sản phẩm", "DonGia", "Đơn giá hiện hành",
                                   "SoLuong", "Số lượng", "ThanhTien", "Thành tiền", "TinhTrang", "Tình trạng");
                decimal tong = 0;
                int soLuong = 0;
                foreach (DataRow r in t.Rows)
                {
                    tong += Convert.ToDecimal(r["ThanhTien"]);
                    soLuong += Convert.ToInt32(r["SoLuong"]);
                }
                foreach (DataGridViewRow r in dgvGio.Rows)
                    if (Convert.ToString(r.Cells["TinhTrang"].Value) != "Còn hàng") r.DefaultCellStyle.ForeColor = Color.Firebrick;
                lblTong.Text = t.Rows.Count == 0 ? "Giỏ hàng đang trống"
                    : string.Format("{0} sản phẩm – Tạm tính: {1:#,##0} đ", soLuong, tong);
                bool coHang = t.Rows.Count > 0;
                btnCapNhat.Enabled = btnXoa.Enabled = btnXoaHet.Enabled = btnTinhTien.Enabled = coHang;
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvGio_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvGio);
            if (r != null) numSL.Value = Math.Min(numSL.Maximum, Convert.ToDecimal(r["SoLuong"]));
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvGio);
            if (r == null) return;
            KetQuaXuLy kq = HeThong.GioHang.CapNhatSoLuong(PhienLamViec.MaGioHang, Convert.ToString(r["MaSP"]), (int)numSL.Value);
            if (!kq.ThanhCong) GridHelper.ThongBao(this, kq);
            NapGio();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvGio);
            if (r == null) return;
            if (!GridHelper.XacNhan(this, "Loại bỏ \"" + r["TenSP"] + "\" khỏi giỏ hàng?")) return;
            KetQuaXuLy kq = HeThong.GioHang.LoaiBo(PhienLamViec.MaGioHang, Convert.ToString(r["MaSP"]));
            if (!kq.ThanhCong) GridHelper.ThongBao(this, kq);
            NapGio();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            if (!GridHelper.XacNhan(this, "Xóa hết sản phẩm trong giỏ hàng?")) return;
            GridHelper.ThongBao(this, HeThong.GioHang.XoaHet(PhienLamViec.MaGioHang));
            NapGio();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>BR04: phải đăng nhập (hoặc đăng ký rồi đăng nhập) trước khi đặt hàng.</summary>
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (PhienLamViec.LaNhanVien)
            {
                MessageBox.Show(this, "Tài khoản nhân viên không dùng để đặt hàng.", "Thông báo");
                return;
            }
            if (!PhienLamViec.LaKhachHang)
            {
                MessageBox.Show(this, "Vui lòng đăng nhập (hoặc đăng ký tài khoản mới) để đặt hàng.", "Tính tiền",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (FrmDangNhap f = new FrmDangNhap())
                    if (f.ShowDialog(this) != DialogResult.OK) return;
                NapGio();
            }
            using (FrmDatHang f = new FrmDatHang())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            NapGio();
        }
    }
}
