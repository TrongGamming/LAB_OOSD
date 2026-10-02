using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>
    /// UC08 (khách hàng): theo dõi, hủy đơn của mình. UC09 (nhân viên): xem mọi đơn, chuyển trạng thái.
    /// </summary>
    public partial class FrmDonHang : Form
    {
        private const string TatCa = "(Tất cả)";

        public FrmDonHang()
        {
            InitializeComponent();
        }

        private bool LaNhanVien
        {
            get { return PhienLamViec.LaNhanVien; }
        }

        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            List<string> loc = new List<string> { TatCa };
            loc.AddRange(DonHangService.CacTrangThai);
            cboLoc.DataSource = loc;
            Text = LaNhanVien ? "Xử lý đơn đặt hàng" : "Đơn hàng của tôi";
            lblTieuDe.Text = LaNhanVien ? "Tất cả đơn hàng – nhân viên " + PhienLamViec.HoTen
                                        : "Đơn hàng của " + PhienLamViec.HoTen;
            lblMoi.Visible = cboTrangThaiMoi.Visible = btnCapNhat.Visible = LaNhanVien;
            btnHuyDon.Visible = !LaNhanVien;
            NapDon();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            NapDon();
        }

        private void NapDon()
        {
            try
            {
                string tt = Convert.ToString(cboLoc.SelectedItem);
                DataTable t = HeThong.DonHang.LayDon(LaNhanVien ? null : PhienLamViec.MaNguoiDung, tt == TatCa ? null : tt);
                if (LaNhanVien)
                    GridHelper.HienThi(dgvDon, t, "SoDonHang", "Số đơn", "ThoiDiemDat", "Thời điểm đặt", "HoTen", "Khách hàng",
                                       "TenLoai", "*Loại phiếu", "TenTinh", "Tỉnh nhận", "TongTriGia", "Tổng trị giá",
                                       "SoTheAn", "Thẻ", "TrangThai", "Trạng thái");
                else
                    GridHelper.HienThi(dgvDon, t, "SoDonHang", "Số đơn", "ThoiDiemDat", "Thời điểm đặt", "TenLoai", "*Loại phiếu",
                                       "TenNguoiNhan", "Người nhận", "TongTienHang", "Tiền hàng", "PhiGiaoHang", "Phí giao",
                                       "TongTriGia", "Tổng trị giá", "TrangThai", "Trạng thái");
                if (t.Rows.Count == 0) HienDon(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvDon_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvDon);
            HienDon(r == null ? null : r.Row);
        }

        private void HienDon(DataRow d)
        {
            if (d == null)
            {
                lblTrangThaiHT.Text = lblNguoiNhan.Text = "";
                dgvChiTiet.DataSource = null;
                btnCapNhat.Enabled = btnHuyDon.Enabled = false;
                cboTrangThaiMoi.DataSource = null;
                return;
            }
            string tt = Convert.ToString(d["TrangThai"]);
            lblTrangThaiHT.Text = "Đơn " + d["SoDonHang"] + ": " + tt;
            lblNguoiNhan.Text = "Giao cho " + d["TenNguoiNhan"] + " – " + d["DienThoaiNhan"] + Environment.NewLine
                                + d["DiaChiNhan"] + ", " + d["TenTinh"] + Environment.NewLine
                                + "Email xác nhận: " + (Convert.ToString(d["DaGuiEmail"]) == "Y" ? "đã gửi" : "chưa gửi");
            string[] ke = DonHangService.TrangThaiKeTiep(tt);
            cboTrangThaiMoi.DataSource = ke;
            btnCapNhat.Enabled = ke.Length > 0;
            btnHuyDon.Enabled = tt == DonHangService.ChoXuLy;
            try
            {
                GridHelper.HienThi(dgvChiTiet, HeThong.DonHang.LayChiTiet(Convert.ToString(d["SoDonHang"])),
                                   "MaSP", "Mã SP", "TenSP", "*Sản phẩm", "SoLuong", "SL", "DonGia", "Đơn giá", "ThanhTien", "Thành tiền");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private string DonChon()
        {
            DataRowView r = GridHelper.DongChon(dgvDon);
            return r == null ? null : Convert.ToString(r["SoDonHang"]);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string so = DonChon();
            string moi = Convert.ToString(cboTrangThaiMoi.SelectedItem);
            if (so == null || moi.Length == 0) return;
            if (moi == DonHangService.DaHuy && !GridHelper.XacNhan(this, "Hủy đơn " + so + " và hoàn tiền cho khách?")) return;
            GridHelper.ThongBao(this, HeThong.DonHang.ChuyenTrangThai(so, moi));
            NapDon();
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            string so = DonChon();
            if (so == null) return;
            if (!GridHelper.XacNhan(this, "Bạn chắc chắn muốn hủy đơn " + so + "?")) return;
            GridHelper.ThongBao(this, HeThong.DonHang.HuyDon(so, PhienLamViec.MaNguoiDung));
            NapDon();
        }
    }
}
