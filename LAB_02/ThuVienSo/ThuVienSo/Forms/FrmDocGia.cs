using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.8 – Quản lý độc giả; cấp / gia hạn / khóa / báo mất thẻ thư viện.</summary>
    public partial class FrmDocGia : Form
    {
        private readonly TheService _service = new TheService();
        private bool _themMoi;
        private bool _dangNhap;
        private string _trangThaiThe;   // trạng thái thẻ của dòng đang chọn

        public FrmDocGia()
        {
            InitializeComponent();
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { new Muc("SinhVien", "Sinh viên"), new Muc("GiangVien", "Giảng viên"), new Muc("NhanVien", "Nhân viên") });
            cboLoai.SelectedIndex = 0;
            dtNgayCap.Value = DateTime.Today;
            dtHanDung.Value = DateTime.Today.AddYears(1);
            CheDo(false);
            NapLuoi(null);
        }

        private void NapLuoi(string chonMa)
        {
            try
            {
                GridHelper.HienThi(dgvDocGia, _service.LayDanhSachDocGia(txtTim.Text),
                    "MaDocGia", "Mã ĐG", "HoTen", "*Họ tên", "LoaiDocGia", "Loại", "DonVi", "Đơn vị", "Email", "*Email",
                    "MaThe", "Mã thẻ", "HanSuDung", "Hạn thẻ", "TrangThai", "Trạng thái thẻ", "DangMuon", "Đang mượn");
                if (chonMa == null) return;
                foreach (DataGridViewRow row in dgvDocGia.Rows)
                    if (Convert.ToString(row.Cells["MaDocGia"].Value) == chonMa)
                    {
                        dgvDocGia.CurrentCell = row.Cells["MaDocGia"];
                        break;
                    }
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            NapLuoi(null);
        }

        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNhap) return;
            DataRowView v = GridHelper.DongChon(dgvDocGia);
            if (v == null) return;
            txtMa.Text = Convert.ToString(v["MaDocGia"]);
            txtHoTen.Text = Convert.ToString(v["HoTen"]);
            GridHelper.ChonTheoMa(cboLoai, Convert.ToString(v["LoaiDocGia"]));
            txtDonVi.Text = Convert.ToString(v["DonVi"]);
            txtEmail.Text = Convert.ToString(v["Email"]);
            txtSDT.Text = Convert.ToString(v["SoDienThoai"]);
            dtNgaySinh.Checked = v["NgaySinh"] != DBNull.Value;
            if (dtNgaySinh.Checked) dtNgaySinh.Value = Convert.ToDateTime(v["NgaySinh"]);

            bool coThe = v["MaThe"] != DBNull.Value;
            _trangThaiThe = coThe ? Convert.ToString(v["TrangThai"]) : null;
            txtMaThe.Text = coThe ? Convert.ToString(v["MaThe"]) : "(chưa có thẻ)";
            txtTrangThaiThe.Text = TenTrangThai(_trangThaiThe);
            if (coThe)
            {
                dtNgayCap.Value = Convert.ToDateTime(v["NgayCap"]);
                DateTime han = Convert.ToDateTime(v["HanSuDung"]);
                // thẻ hết hạn: gợi ý hạn mới 1 năm để gia hạn / cấp lại
                dtHanDung.Value = han.Date > DateTime.Today ? han : DateTime.Today.AddYears(1);
            }
            else
            {
                dtNgayCap.Value = DateTime.Today;
                dtHanDung.Value = DateTime.Today.AddYears(1);
            }
            CapNhatNutThe();
        }

        private static string TenTrangThai(string tt)
        {
            switch (tt)
            {
                case "HoatDong": return "Hoạt động";
                case "HetHan": return "Hết hạn";
                case "Khoa": return "Bị khóa";
                case "Mat": return "Đã báo mất";
                default: return "";
            }
        }

        /// <summary>BR02: chỉ cấp thẻ mới khi độc giả không còn thẻ Hoạt động.</summary>
        private void CapNhatNutThe()
        {
            bool coDong = !_dangNhap && txtMa.Text.Length > 0 && !_themMoi;
            btnCapThe.Enabled = coDong && _trangThaiThe != "HoatDong";
            btnGiaHan.Enabled = coDong && (_trangThaiThe == "HoatDong" || _trangThaiThe == "HetHan");
            btnKhoaThe.Enabled = coDong && (_trangThaiThe == "HoatDong" || _trangThaiThe == "Khoa");
            btnKhoaThe.Text = _trangThaiThe == "Khoa" ? "Mở khóa thẻ" : "Khóa thẻ";
            btnBaoMat.Enabled = coDong && (_trangThaiThe == "HoatDong" || _trangThaiThe == "Khoa");
            dtNgayCap.Enabled = false;   // chỉ hiển thị; thẻ mới luôn cấp từ hôm nay
            dtHanDung.Enabled = btnCapThe.Enabled || btnGiaHan.Enabled;
        }

        private void CheDo(bool nhap)
        {
            _dangNhap = nhap;
            txtMa.ReadOnly = !(nhap && _themMoi);
            txtHoTen.ReadOnly = txtDonVi.ReadOnly = txtEmail.ReadOnly = txtSDT.ReadOnly = !nhap;
            cboLoai.Enabled = dtNgaySinh.Enabled = nhap;
            btnLuu.Enabled = btnHuy.Enabled = nhap;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTim.Enabled = dgvDocGia.Enabled = !nhap;
            grpThe.Enabled = !nhap;
            CapNhatNutThe();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _themMoi = true;
            try { txtMa.Text = _service.MaDocGiaMoi(); }
            catch (Exception ex) { GridHelper.LoiHeThong(this, ex); return; }
            txtHoTen.Clear();
            txtDonVi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            cboLoai.SelectedIndex = 0;
            dtNgaySinh.Checked = false;
            txtMaThe.Text = "";
            txtTrangThaiThe.Text = "";
            _trangThaiThe = null;
            CheDo(true);
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0) return;
            _themMoi = false;
            CheDo(true);
            txtHoTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DocGiaInfo dg = new DocGiaInfo
            {
                MaDocGia = txtMa.Text,
                HoTen = txtHoTen.Text,
                LoaiDocGia = GridHelper.MaChon(cboLoai),
                DonVi = txtDonVi.Text,
                NgaySinh = dtNgaySinh.Checked ? dtNgaySinh.Value.Date : (DateTime?)null,
                Email = txtEmail.Text,
                SoDienThoai = txtSDT.Text
            };
            KetQuaXuLy kq = _service.LuuDocGia(_themMoi, dg);
            if (!kq.ThanhCong)
            {
                GridHelper.ThongBao(this, kq, "Lưu độc giả");
                return;
            }
            bool vuaThem = _themMoi;
            _themMoi = false;
            CheDo(false);
            NapLuoi(dg.MaDocGia.Trim());
            if (vuaThem && GridHelper.XacNhan(this, kq.ThongDiep + " Cấp thẻ thư viện cho độc giả này luôn?"))
                btnCapThe_Click(null, EventArgs.Empty);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            _themMoi = false;
            CheDo(false);
            dgvDocGia_SelectionChanged(null, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0 || !GridHelper.XacNhan(this, "Xóa độc giả " + txtMa.Text + "?")) return;
            KetQuaXuLy kq = _service.XoaDocGia(txtMa.Text);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(this, kq.ThongDiep + Environment.NewLine + "Độc giả đã có thẻ / tài khoản / lịch sử mượn.",
                                "Xóa độc giả", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NapLuoi(null);
        }

        // ------------------------------------------------------------ thẻ thư viện
        private void btnCapThe_Click(object sender, EventArgs e)
        {
            // thẻ mới luôn cấp từ hôm nay; hạn lấy theo ô Hạn dùng nếu còn ở tương lai, ngược lại mặc định 1 năm
            DateTime han = dtHanDung.Value.Date > DateTime.Today ? dtHanDung.Value.Date : DateTime.Today.AddYears(1);
            KetQuaXuLy kq = _service.CapThe(txtMa.Text, DateTime.Today, han);
            GridHelper.ThongBao(this, kq, "Cấp thẻ");
            if (kq.ThanhCong) NapLuoi(txtMa.Text);
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.GiaHan(txtMaThe.Text, dtHanDung.Value);
            GridHelper.ThongBao(this, kq, "Gia hạn thẻ");
            if (kq.ThanhCong) NapLuoi(txtMa.Text);
        }

        private void btnKhoaThe_Click(object sender, EventArgs e)
        {
            bool moKhoa = _trangThaiThe == "Khoa";
            if (!GridHelper.XacNhan(this, (moKhoa ? "Mở khóa" : "Khóa") + " thẻ " + txtMaThe.Text + "?")) return;
            KetQuaXuLy kq = _service.DoiTrangThai(txtMaThe.Text, moKhoa ? "HoatDong" : "Khoa");
            GridHelper.ThongBao(this, kq, "Thẻ thư viện");
            if (kq.ThanhCong) NapLuoi(txtMa.Text);
        }

        private void btnBaoMat_Click(object sender, EventArgs e)
        {
            if (!GridHelper.XacNhan(this, "Ghi nhận mất thẻ " + txtMaThe.Text + "? Thẻ sẽ không dùng được nữa.")) return;
            KetQuaXuLy kq = _service.DoiTrangThai(txtMaThe.Text, "Mat");
            if (!kq.ThanhCong) { GridHelper.ThongBao(this, kq, "Báo mất thẻ"); return; }
            NapLuoi(txtMa.Text);
            if (GridHelper.XacNhan(this, "Đã ghi nhận mất thẻ. Cấp thẻ mới cho độc giả?"))
                btnCapThe_Click(null, EventArgs.Empty);
        }
    }
}
