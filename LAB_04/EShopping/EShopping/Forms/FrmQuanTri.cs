using System;
using System.Data;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC10 Biểu phí giao hàng, UC11 Loại thẻ và lệ phí, UC12 Nhật ký thanh toán và email.</summary>
    public partial class FrmQuanTri : Form
    {
        private readonly QuanTriService _svc = HeThong.QuanTri;

        public FrmQuanTri()
        {
            InitializeComponent();
        }

        private void FrmQuanTri_Load(object sender, EventArgs e)
        {
            try
            {
                GridHelper.NapCombo(cboKhuVuc, _svc.LayKhuVuc(), "TenKhuVuc", "MaKhuVuc");
                GridHelper.NapCombo(cboLoaiPhieu, _svc.LayLoaiPhieu(), "TenLoai", "MaLoaiPhieu");
                NapPhi();
                NapLoaiPhieu();
                NapThe();
                GridHelper.HienThi(dgvNhatKy, _svc.LayNhatKyThanhToan(), "ThoiDiem", "Thời điểm", "MaKH", "Mã KH", "HoTen", "Khách hàng",
                                   "MaLoaiThe", "Loại thẻ", "SoTheAn", "Số thẻ (đã che)", "SoTien", "Số tiền", "KetQua", "Kết quả",
                                   "MaGiaoDich", "Mã giao dịch", "LyDo", "*Lý do");
                GridHelper.HienThi(dgvEmail, _svc.LayNhatKyEmail(), "ThoiDiemGui", "Thời điểm gửi", "SoDonHang", "Số đơn",
                                   "DiaChiEmail", "Email", "TieuDe", "*Tiêu đề");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        public void ChonTab(int i)
        {
            tabs.SelectedIndex = i;
        }

        private void NapPhi()
        {
            GridHelper.HienThi(dgvPhi, _svc.LayBangPhi(), "TenKhuVuc", "*Khu vực", "TenLoai", "*Loại phiếu", "PhiGiao", "Phí giao (đ)");
        }

        private void NapLoaiPhieu()
        {
            GridHelper.HienThi(dgvLoaiPhieu, _svc.LayLoaiPhieu(), "TenLoai", "*Loại phiếu", "SoGioXuLy", "Giờ",
                               "NguongMienPhi", "Ngưỡng miễn phí");
        }

        private void NapThe()
        {
            GridHelper.HienThi(dgvThe, _svc.LayLoaiThe(), "MaLoaiThe", "Mã", "TenLoaiThe", "*Loại thẻ", "DoDaiSoThe", "Số chữ số thẻ",
                               "DoDaiCSV", "Số chữ số CSV", "LePhiGiaoDich", "Lệ phí / giao dịch");
        }

        private void dgvPhi_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhi);
            if (r == null) return;
            cboKhuVuc.SelectedValue = r["MaKhuVuc"];
            cboLoaiPhieu.SelectedValue = r["MaLoaiPhieu"];
            numPhi.Value = Convert.ToDecimal(r["PhiGiao"]);
        }

        private void btnLuuPhi_Click(object sender, EventArgs e)
        {
            GridHelper.ThongBao(this, _svc.LuuBangPhi(GridHelper.GiaTri(cboKhuVuc), GridHelper.GiaTri(cboLoaiPhieu), numPhi.Value));
            NapPhi();
        }

        private void dgvLoaiPhieu_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvLoaiPhieu);
            if (r == null) return;
            numGio.Value = Convert.ToDecimal(r["SoGioXuLy"]);
            numNguong.Value = r["NguongMienPhi"] == DBNull.Value ? 0 : Convert.ToDecimal(r["NguongMienPhi"]);
        }

        private void btnLuuLoaiPhieu_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvLoaiPhieu);
            if (r == null) return;
            GridHelper.ThongBao(this, _svc.LuuLoaiPhieu(Convert.ToString(r["MaLoaiPhieu"]), (int)numGio.Value, numNguong.Value));
            NapLoaiPhieu();
        }

        private void dgvThe_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvThe);
            if (r != null) numLePhi.Value = Convert.ToDecimal(r["LePhiGiaoDich"]);
        }

        private void btnLuuLePhi_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvThe);
            if (r == null) return;
            GridHelper.ThongBao(this, _svc.LuuLePhi(Convert.ToString(r["MaLoaiThe"]), numLePhi.Value));
            NapThe();
        }

        private void dgvEmail_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvEmail);
            txtNoiDung.Text = r == null ? "" : Convert.ToString(r["NoiDung"]).Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }
    }
}
