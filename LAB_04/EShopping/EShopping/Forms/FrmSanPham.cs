using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC01 Xem danh sách sản phẩm theo nhóm, UC02 Xem chi tiết, UC03.1 Thêm vào giỏ.</summary>
    public partial class FrmSanPham : Form
    {
        private const string TatCa = "";
        private DataTable _anh;
        private int _anhHienTai;

        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable nhom = HeThong.SanPham.LayNhom();
                DataRow tatCa = nhom.NewRow();
                tatCa["MaNhom"] = TatCa;
                tatCa["TenNhom"] = "(Tất cả sản phẩm)";
                tatCa["SoSanPham"] = 0;
                nhom.Rows.InsertAt(tatCa, 0);
                foreach (DataRow r in nhom.Rows)
                    if (Convert.ToString(r["MaNhom"]) != TatCa) r["TenNhom"] = r["TenNhom"] + " (" + r["SoSanPham"] + ")";
                lstNhom.DataSource = nhom;
                lstNhom.DisplayMember = "TenNhom";
                lstNhom.ValueMember = "MaNhom";
                lstNhom.SelectedIndex = nhom.Rows.Count > 1 ? 1 : 0;
                NapSanPham();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        public void ChonNhom(int viTri)
        {
            if (viTri < lstNhom.Items.Count) lstNhom.SelectedIndex = viTri;
        }

        public void ChonSanPham(string maSP)
        {
            foreach (DataGridViewRow r in dgvSanPham.Rows)
            {
                if (Convert.ToString(r.Cells["MaSP"].Value) != maSP) continue;
                r.Selected = true;
                dgvSanPham.CurrentCell = r.Cells["TenSP"];
                break;
            }
        }

        private void lstNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNhom.DataSource != null) NapSanPham();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            NapSanPham();
        }

        private void NapSanPham()
        {
            try
            {
                string nhom = lstNhom.SelectedValue == null ? TatCa : Convert.ToString(lstNhom.SelectedValue);
                DataTable t = HeThong.SanPham.LayDanhSach(nhom == TatCa ? null : nhom, txtTim.Text);
                GridHelper.HienThi(dgvSanPham, t, "TenSP", "*Tên sản phẩm", "NhaSanXuat", "Nhà sản xuất",
                                   "GiaBan", "Giá bán", "TinhTrang", "Tình trạng");
                foreach (DataGridViewRow r in dgvSanPham.Rows)
                    if (Convert.ToString(r.Cells["TinhTrang"].Value) != "Còn hàng") r.DefaultCellStyle.ForeColor = Color.Gray;
                if (t.Rows.Count == 0) HienChiTiet(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvSanPham);
            HienChiTiet(r == null ? null : r.Row);
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnThem_Click(sender, EventArgs.Empty);
        }

        private void HienChiTiet(DataRow sp)
        {
            _anh = null;
            _anhHienTai = 0;
            if (sp == null)
            {
                lblTenSP.Text = lblNSX.Text = lblGia.Text = lblTinhTrang.Text = txtMoTa.Text = lblSoAnh.Text = "";
                picAnh.Image = null;
                dgvThongSo.DataSource = null;
                btnThem.Enabled = false;
                return;
            }
            string ma = Convert.ToString(sp["MaSP"]);
            bool conHang = Convert.ToString(sp["TinhTrang"]) == "Còn hàng";
            lblTenSP.Text = Convert.ToString(sp["TenSP"]);
            lblNSX.Text = "Mã: " + ma + "   |   Nhà sản xuất: " + sp["NhaSanXuat"] + "   |   " + sp["TenNhom"];
            lblGia.Text = string.Format("{0:#,##0} đ", sp["GiaBan"]);
            lblTinhTrang.Text = conHang ? "● Còn hàng" : "● Hết hàng";
            lblTinhTrang.ForeColor = conHang ? Color.SeaGreen : Color.Firebrick;
            txtMoTa.Text = Convert.ToString(sp["MoTa"]);
            btnThem.Enabled = conHang;
            try
            {
                _anh = HeThong.SanPham.LayHinhAnh(ma);
                HienAnh();
                GridHelper.HienThi(dgvThongSo, HeThong.SanPham.LayThongSo(ma), "TenThongSo", "Thông số", "GiaTri", "*Giá trị");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void HienAnh()
        {
            Image cu = picAnh.Image;
            picAnh.Image = null;
            if (cu != null) cu.Dispose();
            int n = _anh == null ? 0 : _anh.Rows.Count;
            lblSoAnh.Text = n == 0 ? "Chưa có ảnh" : "Ảnh " + (_anhHienTai + 1) + " / " + n;
            btnAnhTruoc.Enabled = n > 1;
            btnAnhSau.Enabled = n > 1;
            if (n == 0) return;
            string duongDan = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                           Convert.ToString(_anh.Rows[_anhHienTai]["DuongDan"]).Replace('/', Path.DirectorySeparatorChar));
            if (!File.Exists(duongDan)) return;
            // Đọc qua MemoryStream để không khóa file ảnh
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(duongDan)))
                picAnh.Image = new Bitmap(Image.FromStream(ms));
        }

        private void btnAnhTruoc_Click(object sender, EventArgs e)
        {
            if (_anh == null || _anh.Rows.Count == 0) return;
            _anhHienTai = (_anhHienTai - 1 + _anh.Rows.Count) % _anh.Rows.Count;
            HienAnh();
        }

        private void btnAnhSau_Click(object sender, EventArgs e)
        {
            if (_anh == null || _anh.Rows.Count == 0) return;
            _anhHienTai = (_anhHienTai + 1) % _anh.Rows.Count;
            HienAnh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvSanPham);
            if (r == null) return;
            string maKH = PhienLamViec.LaKhachHang ? PhienLamViec.MaNguoiDung : null;
            KetQuaXuLy kq = HeThong.GioHang.ThemVaoGio(PhienLamViec.MaGioHang, maKH, Convert.ToString(r["MaSP"]), (int)numSL.Value);
            if (kq.ThanhCong)
            {
                PhienLamViec.MaGioHang = (long)kq.DuLieu;
                btnXemGio.Text = "Xem giỏ (" + HeThong.GioHang.DemSoLuong(PhienLamViec.MaGioHang) + ")";
                numSL.Value = 1;
            }
            GridHelper.ThongBao(this, kq, "Giỏ hàng");
        }

        private void btnXemGio_Click(object sender, EventArgs e)
        {
            using (FrmGioHang f = new FrmGioHang()) f.ShowDialog(this);
            NapSanPham();
        }
    }
}
