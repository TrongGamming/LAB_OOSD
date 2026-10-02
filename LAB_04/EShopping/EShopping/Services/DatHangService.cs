using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using EShopping.Data;
using EShopping.Gateways;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Services
{
    /// <summary>UC07 Đặt hàng và thanh toán (chức năng "Tính tiền").</summary>
    public class DatHangService
    {
        private static readonly Regex _dienThoai = new Regex(@"^0\d{9,10}$");
        private readonly IThanhToanTrucTuyen _thanhToan;
        private readonly IEmailSender _email;

        public DatHangService(IThanhToanTrucTuyen thanhToan, IEmailSender email)
        {
            _thanhToan = thanhToan;
            _email = email;
        }

        public DataTable LayLoaiPhieu()
        {
            return Db.Query("SELECT MaLoaiPhieu, TenLoai, SoGioXuLy, NguongMienPhi FROM LoaiPhieuDatHang ORDER BY SoGioXuLy DESC");
        }

        public DataTable LayTinhThanh()
        {
            return Db.Query(@"SELECT t.MaTinh, t.TenTinh, k.TenKhuVuc FROM TinhThanh t
                              JOIN KhuVucGiaoHang k ON k.MaKhuVuc = t.MaKhuVuc ORDER BY t.TenTinh");
        }

        public DataTable LayLoaiThe()
        {
            return Db.Query("SELECT MaLoaiThe, TenLoaiThe, DoDaiSoThe, DoDaiCSV, LePhiGiaoDich FROM LoaiThe ORDER BY MaLoaiThe");
        }

        public LoaiTheDto LayLoaiThe(string maLoaiThe)
        {
            DataTable t = Db.Query("SELECT MaLoaiThe, TenLoaiThe, DoDaiSoThe, DoDaiCSV, LePhiGiaoDich FROM LoaiThe WHERE MaLoaiThe = :ma",
                                   new OracleParameter("ma", maLoaiThe ?? ""));
            if (t.Rows.Count == 0) return null;
            DataRow r = t.Rows[0];
            return new LoaiTheDto
            {
                MaLoaiThe = Convert.ToString(r["MaLoaiThe"]),
                TenLoaiThe = Convert.ToString(r["TenLoaiThe"]),
                DoDaiSoThe = Convert.ToInt32(r["DoDaiSoThe"]),
                DoDaiCSV = Convert.ToInt32(r["DoDaiCSV"]),
                LePhiGiaoDich = Convert.ToDecimal(r["LePhiGiaoDich"])
            };
        }

        /// <summary>
        /// BR05–BR07, BR10: tiền hàng theo giá hiện hành + phí giao (khu vực của tỉnh nhận × loại phiếu,
        /// miễn phí khi đạt ngưỡng – tính bởi hàm FN_TinhPhiGiao) + lệ phí của loại thẻ.
        /// </summary>
        public BangTinhTien TinhTien(long maGio, string maLoaiPhieu, string maTinh, string maLoaiThe)
        {
            BangTinhTien b = new BangTinhTien();
            DataTable t = Db.Query(@"SELECT COUNT(*) AS SoMatHang,
                                            NVL(SUM(CASE WHEN s.TinhTrang = N'Còn hàng' THEN s.GiaBan * c.SoLuong END), 0) AS TongTienHang,
                                            NVL(SUM(CASE WHEN s.TinhTrang = N'Còn hàng' THEN 0 ELSE 1 END), 0) AS SoMatHangHetHang
                                     FROM ChiTietGioHang c JOIN SanPham s ON s.MaSP = c.MaSP
                                     WHERE c.MaGioHang = :gio", new OracleParameter("gio", maGio));
            b.SoMatHang = Convert.ToInt32(t.Rows[0]["SoMatHang"]);
            b.TongTienHang = Convert.ToDecimal(t.Rows[0]["TongTienHang"]);
            b.SoMatHangHetHang = Convert.ToInt32(t.Rows[0]["SoMatHangHetHang"]);

            DataTable lp = Db.Query("SELECT SoGioXuLy, NguongMienPhi FROM LoaiPhieuDatHang WHERE MaLoaiPhieu = :lp",
                                    new OracleParameter("lp", maLoaiPhieu ?? ""));
            if (lp.Rows.Count == 1)
            {
                b.SoGioXuLy = Convert.ToInt32(lp.Rows[0]["SoGioXuLy"]);
                if (lp.Rows[0]["NguongMienPhi"] != DBNull.Value) b.NguongMienPhi = Convert.ToDecimal(lp.Rows[0]["NguongMienPhi"]);
            }
            if (!string.IsNullOrEmpty(maTinh) && !string.IsNullOrEmpty(maLoaiPhieu))
            {
                object goc = Db.Scalar(@"SELECT b.PhiGiao FROM BangPhiGiaoHang b JOIN TinhThanh t ON t.MaKhuVuc = b.MaKhuVuc
                                         WHERE t.MaTinh = :t AND b.MaLoaiPhieu = :lp",
                                       new OracleParameter("t", maTinh), new OracleParameter("lp", maLoaiPhieu));
                b.PhiGiaoGoc = goc == null || goc == DBNull.Value ? 0 : Convert.ToDecimal(goc);
                b.PhiGiaoHang = Convert.ToDecimal(Db.Scalar("SELECT FN_TinhPhiGiao(:t, :lp, :tong) FROM dual",
                                                            new OracleParameter("t", maTinh), new OracleParameter("lp", maLoaiPhieu),
                                                            new OracleParameter("tong", b.TongTienHang)));
            }
            LoaiTheDto the = LayLoaiThe(maLoaiThe);
            b.LePhiThe = the == null ? 0 : the.LePhiGiaoDich;
            return b;
        }

        /// <summary>Kiểm tra dữ liệu người nhận và thẻ; null = hợp lệ.</summary>
        public string KiemTraYeuCau(YeuCauDatHang yc, LoaiTheDto loaiThe)
        {
            if (yc == null || string.IsNullOrEmpty(yc.MaKH)) return "Bạn cần đăng nhập trước khi đặt hàng.";
            if (yc.MaGioHang == 0) return "Giỏ hàng đang trống.";
            if (string.IsNullOrEmpty(yc.MaLoaiPhieu)) return "Chưa chọn loại phiếu đặt hàng.";
            if (string.IsNullOrWhiteSpace(yc.NguoiNhan)) return "Chưa nhập họ tên người nhận.";
            if (!_dienThoai.IsMatch((yc.DienThoai ?? "").Trim())) return "Điện thoại người nhận gồm 10-11 chữ số, bắt đầu bằng 0.";
            if (string.IsNullOrEmpty(yc.MaTinh)) return "Chưa chọn tỉnh/thành nhận hàng.";
            if (string.IsNullOrWhiteSpace(yc.DiaChi)) return "Chưa nhập địa chỉ nhận hàng.";
            return KiemTraThe.KiemTra(loaiThe, yc.SoThe, yc.Csv, yc.ThangHetHan, yc.NamHetHan, yc.TenChuThe, DateTime.Today);
        }

        /// <summary>
        /// Quy trình đặt hàng: kiểm tra → gửi Hệ thống thanh toán xác thực + trừ tiền → ghi đơn trong một transaction
        /// → gửi email xác nhận (không kèm thông tin thẻ). DuLieu trả về là số đơn hàng.
        /// </summary>
        public KetQuaXuLy DatHang(YeuCauDatHang yc)
        {
            try
            {
                LoaiTheDto loaiThe = LayLoaiThe(yc == null ? null : yc.MaLoaiThe);
                string loi = KiemTraYeuCau(yc, loaiThe);
                if (loi != null) return KetQuaXuLy.Fail(loi);

                BangTinhTien b = TinhTien(yc.MaGioHang, yc.MaLoaiPhieu, yc.MaTinh, yc.MaLoaiThe);
                if (b.SoMatHang == 0) return KetQuaXuLy.Fail("Giỏ hàng đang trống.");
                if (b.SoMatHangHetHang > 0)
                    return KetQuaXuLy.Fail("Có " + b.SoMatHangHetHang + " sản phẩm trong giỏ vừa hết hàng, vui lòng loại bỏ trước khi đặt.");

                string soTheAn = KiemTraThe.AnSoThe(yc.SoThe);
                KetQuaThanhToan tt = _thanhToan.XacThucVaThanhToan(loaiThe.MaLoaiThe, yc.SoThe, yc.Csv, yc.ThangHetHan,
                                                                   yc.NamHetHan, yc.TenChuThe, b.TongTriGia);
                if (!tt.ChapThuan)
                {
                    GhiNhatKy(yc.MaKH, loaiThe.MaLoaiThe, soTheAn, b.TongTriGia, "Từ chối", null, tt.LyDo);
                    return KetQuaXuLy.Fail("Thanh toán bị từ chối: " + tt.LyDo + " Vui lòng dùng thẻ khác.");
                }

                string soDon = Db.SinhMa("SEQ_DonHang", "DH", 6);
                try
                {
                    Db.Transaction((cn, tx) =>
                    {
                        object maThe = Db.Scalar(cn, tx, "SELECT MaThe FROM TheTinDung WHERE TokenThanhToan = :tok",
                                                 new OracleParameter("tok", tt.Token));
                        if (maThe == null || maThe == DBNull.Value)
                        {
                            maThe = Db.Scalar(cn, tx, "SELECT SEQ_The.NEXTVAL FROM dual");
                            Db.Execute(cn, tx, @"INSERT INTO TheTinDung(MaThe, MaKH, MaLoaiThe, SoTheAn, ThangHetHan, NamHetHan,
                                                                       TenChuThe, TokenThanhToan)
                                                 VALUES (:ma, :kh, :loai, :so, :th, :nam, :chu, :tok)",
                                       new OracleParameter("ma", maThe), new OracleParameter("kh", yc.MaKH),
                                       new OracleParameter("loai", loaiThe.MaLoaiThe), new OracleParameter("so", soTheAn),
                                       new OracleParameter("th", yc.ThangHetHan), new OracleParameter("nam", yc.NamHetHan),
                                       new OracleParameter("chu", yc.TenChuThe.Trim().ToUpper()), new OracleParameter("tok", tt.Token));
                        }
                        Db.Execute(cn, tx, @"INSERT INTO DonDatHang(SoDonHang, MaKH, MaLoaiPhieu, TenNguoiNhan, DiaChiNhan, MaTinh,
                                                                   DienThoaiNhan, TongTienHang, PhiGiaoHang, LePhiThe, MaThe, MaGiaoDich)
                                             VALUES (:so, :kh, :lp, :ten, :dc, :tinh, :dt, :tien, :phi, :lephi, :the, :gd)",
                                   new OracleParameter("so", soDon), new OracleParameter("kh", yc.MaKH),
                                   new OracleParameter("lp", yc.MaLoaiPhieu), new OracleParameter("ten", yc.NguoiNhan.Trim()),
                                   new OracleParameter("dc", yc.DiaChi.Trim()), new OracleParameter("tinh", yc.MaTinh),
                                   new OracleParameter("dt", yc.DienThoai.Trim()), new OracleParameter("tien", b.TongTienHang),
                                   new OracleParameter("phi", b.PhiGiaoHang), new OracleParameter("lephi", b.LePhiThe),
                                   new OracleParameter("the", maThe), new OracleParameter("gd", tt.MaGiaoDich));
                        // BR02: chốt đơn giá tại thời điểm đặt
                        Db.Execute(cn, tx, @"INSERT INTO ChiTietDonHang(SoDonHang, MaSP, SoLuong, DonGia)
                                             SELECT :so, c.MaSP, c.SoLuong, s.GiaBan
                                             FROM ChiTietGioHang c JOIN SanPham s ON s.MaSP = c.MaSP
                                             WHERE c.MaGioHang = :gio",
                                   new OracleParameter("so", soDon), new OracleParameter("gio", yc.MaGioHang));
                        Db.Execute(cn, tx, "UPDATE GioHang SET TrangThai = N'Đã chuyển thành đơn', MaKH = :kh WHERE MaGioHang = :gio",
                                   new OracleParameter("kh", yc.MaKH), new OracleParameter("gio", yc.MaGioHang));
                        Db.Execute(cn, tx, @"INSERT INTO NhatKyThanhToan(MaNhatKy, MaKH, MaLoaiThe, SoTheAn, SoTien, KetQua, MaGiaoDich)
                                             VALUES (SEQ_NhatKyTT.NEXTVAL, :kh, :loai, :so, :tien, N'Chấp thuận', :gd)",
                                   new OracleParameter("kh", yc.MaKH), new OracleParameter("loai", loaiThe.MaLoaiThe),
                                   new OracleParameter("so", soTheAn), new OracleParameter("tien", b.TongTriGia),
                                   new OracleParameter("gd", tt.MaGiaoDich));
                    });
                }
                catch
                {
                    // Đã trừ tiền nhưng không ghi được đơn -> hoàn tiền ngay để không thu tiền khách oan.
                    _thanhToan.HoanTien(tt.MaGiaoDich, b.TongTriGia);
                    throw;
                }

                string thongBao = "Đặt hàng thành công. Mã đơn hàng: " + soDon + ".";
                if (GuiEmailXacNhan(soDon)) thongBao += " Email xác nhận đã được gửi.";
                return KetQuaXuLy.Ok(thongBao, soDon);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        private static void GhiNhatKy(string maKH, string loaiThe, string soTheAn, decimal soTien, string ketQua,
                                      string maGiaoDich, string lyDo)
        {
            Db.Execute(@"INSERT INTO NhatKyThanhToan(MaNhatKy, MaKH, MaLoaiThe, SoTheAn, SoTien, KetQua, MaGiaoDich, LyDo)
                         VALUES (SEQ_NhatKyTT.NEXTVAL, :kh, :loai, :so, :tien, :kq, :gd, :ld)",
                       new OracleParameter("kh", maKH), new OracleParameter("loai", loaiThe),
                       new OracleParameter("so", soTheAn), new OracleParameter("tien", soTien),
                       new OracleParameter("kq", ketQua), new OracleParameter("gd", (object)maGiaoDich ?? DBNull.Value),
                       new OracleParameter("ld", (object)lyDo ?? DBNull.Value));
        }

        /// <summary>BR12: chỉ gửi khi khách có email; nội dung không chứa bất kỳ thông tin thẻ tín dụng nào.</summary>
        private bool GuiEmailXacNhan(string soDon)
        {
            try
            {
                DataTable d = Db.Query(@"SELECT d.SoDonHang, d.ThoiDiemDat, k.HoTen, k.Email, l.TenLoai, l.SoGioXuLy,
                                                d.TenNguoiNhan, d.DiaChiNhan, t.TenTinh, d.DienThoaiNhan,
                                                d.TongTienHang, d.PhiGiaoHang, d.LePhiThe, d.TongTriGia
                                         FROM DonDatHang d JOIN KhachHang k ON k.MaKH = d.MaKH
                                         JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = d.MaLoaiPhieu
                                         JOIN TinhThanh t ON t.MaTinh = d.MaTinh
                                         WHERE d.SoDonHang = :so", new OracleParameter("so", soDon));
                if (d.Rows.Count == 0) return false;
                DataRow r = d.Rows[0];
                string email = Convert.ToString(r["Email"]);
                if (string.IsNullOrWhiteSpace(email)) return false;

                DataTable ct = Db.Query(@"SELECT s.TenSP, c.SoLuong, c.DonGia, c.ThanhTien FROM ChiTietDonHang c
                                          JOIN SanPham s ON s.MaSP = c.MaSP WHERE c.SoDonHang = :so ORDER BY s.TenSP",
                                        new OracleParameter("so", soDon));
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Kính gửi " + r["HoTen"] + ",");
                sb.AppendLine();
                sb.AppendLine("Cửa hàng ABC xác nhận đã nhận đơn đặt hàng " + soDon + " lúc "
                              + Convert.ToDateTime(r["ThoiDiemDat"]).ToString("dd/MM/yyyy HH:mm") + ".");
                sb.AppendLine("Loại phiếu: " + r["TenLoai"] + " (xử lý trong khoảng " + r["SoGioXuLy"] + " giờ).");
                sb.AppendLine();
                sb.AppendLine("Sản phẩm:");
                int i = 1;
                foreach (DataRow c in ct.Rows)
                    sb.AppendLine(string.Format("  {0}. {1} x {2} = {3:#,##0} đ", i++, c["TenSP"], c["SoLuong"], c["ThanhTien"]));
                sb.AppendLine();
                sb.AppendLine(string.Format("Tiền hàng      : {0:#,##0} đ", r["TongTienHang"]));
                sb.AppendLine(string.Format("Phí giao hàng  : {0:#,##0} đ", r["PhiGiaoHang"]));
                sb.AppendLine(string.Format("Lệ phí thẻ     : {0:#,##0} đ", r["LePhiThe"]));
                sb.AppendLine(string.Format("TỔNG TRỊ GIÁ   : {0:#,##0} đ", r["TongTriGia"]));
                sb.AppendLine();
                sb.AppendLine("Người nhận: " + r["TenNguoiNhan"] + " - " + r["DienThoaiNhan"]);
                sb.AppendLine("Địa chỉ   : " + r["DiaChiNhan"] + ", " + r["TenTinh"]);
                sb.AppendLine();
                sb.AppendLine("Vì lý do an ninh, email này không chứa thông tin thẻ tín dụng đã dùng để thanh toán.");
                sb.AppendLine("Trân trọng,");
                sb.AppendLine("e-SHOPPING – Cửa hàng ABC");

                string tieuDe = "[e-SHOPPING] Xác nhận đơn hàng " + soDon;
                string noiDung = sb.ToString();
                if (!_email.Gui(email, tieuDe, noiDung)) return false;
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, @"INSERT INTO NhatKyEmail(MaEmail, SoDonHang, DiaChiEmail, TieuDe, NoiDung)
                                         VALUES (SEQ_Email.NEXTVAL, :so, :em, :td, :nd)",
                               new OracleParameter("so", soDon), new OracleParameter("em", email),
                               new OracleParameter("td", tieuDe), new OracleParameter("nd", OracleDbType.NClob) { Value = noiDung });
                    Db.Execute(cn, tx, "UPDATE DonDatHang SET DaGuiEmail = 'Y' WHERE SoDonHang = :so", new OracleParameter("so", soDon));
                });
                return true;
            }
            catch
            {
                // Lỗi gửi email không làm hỏng đơn hàng đã ghi nhận; DaGuiEmail giữ 'N' để gửi lại sau.
                return false;
            }
        }
    }
}
