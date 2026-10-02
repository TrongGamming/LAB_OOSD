using System;
using System.Data;
using System.Windows.Forms;
using EShopping.Services;

namespace EShopping.Forms
{
    /// <summary>UC07 Đặt hàng và thanh toán: loại phiếu, người nhận, thẻ tín dụng, tổng trị giá.</summary>
    public partial class FrmDatHang : Form
    {
        private bool _dangNap = true;
        private BangTinhTien _bang;

        public FrmDatHang()
        {
            InitializeComponent();
        }

        private void FrmDatHang_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow r in HeThong.DatHang.LayLoaiPhieu().Rows)
                {
                    string moTa = "Xử lý trong " + r["SoGioXuLy"] + " giờ"
                        + (r["NguongMienPhi"] == DBNull.Value ? ""
                           : string.Format(" – miễn phí khi tiền hàng từ {0:#,##0} đ", r["NguongMienPhi"]));
                    switch (Convert.ToString(r["MaLoaiPhieu"]))
                    {
                        case "THUONG": lblMoTaThuong.Text = moTa; break;
                        case "CPN": lblMoTaCPN.Text = moTa; break;
                        case "CPN_NGAY": lblMoTaCPNNgay.Text = moTa; break;
                    }
                }
                DataTable tinh = HeThong.DatHang.LayTinhThanh();
                GridHelper.NapCombo(cboTinh, tinh, "TenTinh", "MaTinh");
                GridHelper.NapCombo(cboLoaiThe, HeThong.DatHang.LayLoaiThe(), "TenLoaiThe", "MaLoaiThe");
                GridHelper.HienThi(dgvHang, HeThong.GioHang.LayChiTiet(PhienLamViec.MaGioHang),
                                   "TenSP", "*Sản phẩm", "SoLuong", "SL", "DonGia", "Đơn giá", "ThanhTien", "Thành tiền");
                numNam.Minimum = DateTime.Today.Year;
                chkLaToi.Checked = true;
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
            _dangNap = false;
            cboLoaiThe_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private string LoaiPhieu
        {
            get { return rdoCPNNgay.Checked ? "CPN_NGAY" : rdoCPN.Checked ? "CPN" : "THUONG"; }
        }

        /// <summary>Tính lại tiền mỗi khi đổi loại phiếu, tỉnh nhận hoặc loại thẻ.</summary>
        private void TinhLai(object sender, EventArgs e)
        {
            if (_dangNap) return;
            DataRowView tinh = cboTinh.SelectedItem as DataRowView;
            lblKhuVuc.Text = tinh == null ? "" : Convert.ToString(tinh["TenKhuVuc"]);
            try
            {
                _bang = HeThong.DatHang.TinhTien(PhienLamViec.MaGioHang, LoaiPhieu, GridHelper.GiaTri(cboTinh),
                                                 GridHelper.GiaTri(cboLoaiThe));
                lblTienHang.Text = string.Format("{0:#,##0} đ", _bang.TongTienHang);
                lblPhiGiao.Text = string.Format("{0:#,##0} đ", _bang.PhiGiaoHang);
                lblLePhi.Text = string.Format("{0:#,##0} đ", _bang.LePhiThe);
                lblTong.Text = string.Format("{0:#,##0} đ", _bang.TongTriGia);
                if (_bang.DuocMienPhi)
                    lblMienPhi.Text = string.Format("Đơn từ {0:#,##0} đ được miễn phí giao hàng (tiết kiệm {1:#,##0} đ).",
                                                    _bang.NguongMienPhi, _bang.PhiGiaoGoc);
                else if (_bang.NguongMienPhi.HasValue)
                    lblMienPhi.Text = string.Format("Mua thêm {0:#,##0} đ để được miễn phí giao hàng.",
                                                    _bang.NguongMienPhi.Value - _bang.TongTienHang);
                else
                    lblMienPhi.Text = "";
                lblXuLy.Text = "Thời gian xử lý dự kiến: " + _bang.SoGioXuLy + " giờ kể từ lúc đặt.";
                btnDatHang.Enabled = _bang.SoMatHang > 0 && _bang.SoMatHangHetHang == 0;
                if (_bang.SoMatHangHetHang > 0) lblXuLy.Text = "Có sản phẩm đã hết hàng trong giỏ – hãy loại bỏ trước khi đặt.";
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void cboLoaiThe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView r = cboLoaiThe.SelectedItem as DataRowView;
            if (r != null)
            {
                int csv = Convert.ToInt32(r["DoDaiCSV"]);
                txtCSV.MaxLength = csv;
                lblGoiYThe.Text = string.Format("{0}: {1} chữ số, CSV {2} chữ số, lệ phí {3:#,##0} đ/lần.",
                                                r["TenLoaiThe"], r["DoDaiSoThe"], csv, r["LePhiGiaoDich"]);
            }
            TinhLai(sender, e);
        }

        /// <summary>BR08: người nhận có thể khác người mua; đánh dấu thì lấy thông tin của chính khách.</summary>
        private void chkLaToi_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkLaToi.Checked) return;
            txtTenNhan.Text = PhienLamViec.HoTen;
            txtDTNhan.Text = PhienLamViec.DienThoai;
            txtDiaChiNhan.Text = PhienLamViec.DiaChi;
        }

        /// <summary>Điền sẵn dữ liệu thử (dùng khi chụp ảnh màn hình cho báo cáo).</summary>
        public void DienMau(string maTinh, bool cpn, string loaiThe, string soThe, string csv, string chuThe)
        {
            chkLaToi.Checked = false;
            cboLoaiThe.SelectedValue = loaiThe;
            txtTenNhan.Text = "Nguyễn Thị Hoa";
            txtDTNhan.Text = "0987654321";
            txtDiaChiNhan.Text = "88 Nguyễn Huệ, Phú Hội";
            cboTinh.SelectedValue = maTinh;
            rdoCPN.Checked = cpn;
            txtSoThe.Text = soThe;
            txtCSV.Text = csv;
            txtChuThe.Text = chuThe;
            TinhLai(null, EventArgs.Empty);
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            err.Clear();
            YeuCauDatHang yc = new YeuCauDatHang
            {
                MaKH = PhienLamViec.MaNguoiDung,
                MaGioHang = PhienLamViec.MaGioHang,
                MaLoaiPhieu = LoaiPhieu,
                NguoiNhan = txtTenNhan.Text,
                DienThoai = txtDTNhan.Text,
                DiaChi = txtDiaChiNhan.Text,
                MaTinh = GridHelper.GiaTri(cboTinh),
                MaLoaiThe = GridHelper.GiaTri(cboLoaiThe),
                SoThe = txtSoThe.Text,
                Csv = txtCSV.Text,
                ThangHetHan = (int)numThang.Value,
                NamHetHan = (int)numNam.Value,
                TenChuThe = txtChuThe.Text
            };
            if (_bang != null && !GridHelper.XacNhan(this, string.Format(
                    "Xác nhận đặt hàng và thanh toán {0:#,##0} đ bằng thẻ {1}?", _bang.TongTriGia, KiemTraThe.AnSoThe(yc.SoThe))))
                return;

            Cursor = Cursors.WaitCursor;
            KetQuaXuLy kq = HeThong.DatHang.DatHang(yc);
            Cursor = Cursors.Default;
            if (!kq.ThanhCong)
            {
                Control o = kq.ThongBao.Contains("thẻ") || kq.ThongBao.Contains("Thẻ") || kq.ThongBao.Contains("CSV")
                    ? (kq.ThongBao.Contains("CSV") ? (Control)txtCSV : txtSoThe)
                    : kq.ThongBao.Contains("người nhận") ? (Control)txtTenNhan : null;
                if (o != null) err.SetError(o, kq.ThongBao);
                GridHelper.ThongBao(this, kq, "Đặt hàng");
                return;
            }
            PhienLamViec.MaGioHang = 0;
            GridHelper.ThongBao(this, kq, "Đặt hàng");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
