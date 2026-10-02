using System;
using System.Collections.Generic;
using System.Data;
using EShopping.Data;
using EShopping.Gateways;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Services
{
    /// <summary>UC08 Theo dõi / hủy đơn hàng (khách) và UC09 Xử lý đơn hàng (nhân viên).</summary>
    public class DonHangService
    {
        public const string ChoXuLy = "Chờ xử lý";
        public const string DangXuLy = "Đang xử lý";
        public const string DangGiao = "Đang giao";
        public const string DaGiao = "Đã giao";
        public const string DaHuy = "Đã hủy";

        public static readonly string[] CacTrangThai = { ChoXuLy, DangXuLy, DangGiao, DaGiao, DaHuy };

        /// <summary>Chuyển trạng thái hợp lệ theo biểu đồ trạng thái Đơn đặt hàng.</summary>
        private static readonly Dictionary<string, string[]> _chuyenHopLe = new Dictionary<string, string[]>
        {
            { ChoXuLy, new[] { DangXuLy, DaHuy } },
            { DangXuLy, new[] { DangGiao, DaHuy } },
            { DangGiao, new[] { DaGiao } },
            { DaGiao, new string[0] },
            { DaHuy, new string[0] },
        };

        private readonly IThanhToanTrucTuyen _thanhToan;

        public DonHangService(IThanhToanTrucTuyen thanhToan)
        {
            _thanhToan = thanhToan;
        }

        public static string[] TrangThaiKeTiep(string hienTai)
        {
            string[] ds;
            return hienTai != null && _chuyenHopLe.TryGetValue(hienTai, out ds) ? ds : new string[0];
        }

        /// <summary>maKH = null: mọi đơn (nhân viên); trangThai = null: mọi trạng thái.</summary>
        public DataTable LayDon(string maKH, string trangThai)
        {
            return Db.Query(@"SELECT SoDonHang, ThoiDiemDat, MaKH, HoTen, TenLoai, TenNguoiNhan, DiaChiNhan, TenTinh,
                                     DienThoaiNhan, TongTienHang, PhiGiaoHang, LePhiThe, TongTriGia, SoTheAn, MaGiaoDich,
                                     TrangThai, DaGuiEmail
                              FROM V_DonHang
                              WHERE (:kh IS NULL OR MaKH = :kh) AND (:tt IS NULL OR TrangThai = :tt)
                              ORDER BY ThoiDiemDat DESC",
                            new OracleParameter("kh", (object)maKH ?? DBNull.Value),
                            new OracleParameter("tt", (object)trangThai ?? DBNull.Value));
        }

        public DataTable LayChiTiet(string soDon)
        {
            return Db.Query(@"SELECT c.MaSP, s.TenSP, c.SoLuong, c.DonGia, c.ThanhTien
                              FROM ChiTietDonHang c JOIN SanPham s ON s.MaSP = c.MaSP
                              WHERE c.SoDonHang = :so ORDER BY s.TenSP", new OracleParameter("so", soDon ?? ""));
        }

        /// <summary>Nhân viên chuyển trạng thái đơn; chuyển sang "Đã hủy" thì hoàn tiền cho khách.</summary>
        public KetQuaXuLy ChuyenTrangThai(string soDon, string trangThaiMoi)
        {
            try
            {
                DataTable t = Db.Query("SELECT TrangThai, TongTriGia, MaGiaoDich, MaKH FROM DonDatHang WHERE SoDonHang = :so",
                                       new OracleParameter("so", soDon ?? ""));
                if (t.Rows.Count == 0) return KetQuaXuLy.Fail("Không tìm thấy đơn hàng.");
                string cu = Convert.ToString(t.Rows[0]["TrangThai"]);
                if (Array.IndexOf(TrangThaiKeTiep(cu), trangThaiMoi) < 0)
                    return KetQuaXuLy.Fail("Không thể chuyển đơn từ \"" + cu + "\" sang \"" + trangThaiMoi + "\".");
                if (trangThaiMoi == DaHuy) return Huy(soDon, cu, t.Rows[0]);

                int n = Db.Execute("UPDATE DonDatHang SET TrangThai = :moi WHERE SoDonHang = :so AND TrangThai = :cu",
                                   new OracleParameter("moi", trangThaiMoi), new OracleParameter("so", soDon),
                                   new OracleParameter("cu", cu));
                return n == 1 ? KetQuaXuLy.Ok("Đơn " + soDon + " đã chuyển sang \"" + trangThaiMoi + "\".")
                              : KetQuaXuLy.Fail("Đơn hàng vừa được người khác cập nhật, vui lòng tải lại.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Khách chỉ được hủy đơn của chính mình khi đơn còn "Chờ xử lý".</summary>
        public KetQuaXuLy HuyDon(string soDon, string maKH)
        {
            try
            {
                DataTable t = Db.Query("SELECT TrangThai, TongTriGia, MaGiaoDich, MaKH FROM DonDatHang WHERE SoDonHang = :so",
                                       new OracleParameter("so", soDon ?? ""));
                if (t.Rows.Count == 0 || Convert.ToString(t.Rows[0]["MaKH"]) != maKH)
                    return KetQuaXuLy.Fail("Không tìm thấy đơn hàng của bạn.");
                string cu = Convert.ToString(t.Rows[0]["TrangThai"]);
                if (cu != ChoXuLy)
                    return KetQuaXuLy.Fail("Đơn đang ở trạng thái \"" + cu + "\", chỉ hủy được khi đơn còn \"Chờ xử lý\".");
                return Huy(soDon, cu, t.Rows[0]);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        private KetQuaXuLy Huy(string soDon, string cu, DataRow don)
        {
            string gd = Convert.ToString(don["MaGiaoDich"]);
            decimal tien = Convert.ToDecimal(don["TongTriGia"]);
            if (!_thanhToan.HoanTien(gd, tien))
                return KetQuaXuLy.Fail("Hệ thống thanh toán chưa xác nhận hoàn tiền, đơn chưa được hủy.");
            int n = 0;
            Db.Transaction((cn, tx) =>
            {
                n = Db.Execute(cn, tx, "UPDATE DonDatHang SET TrangThai = :moi WHERE SoDonHang = :so AND TrangThai = :cu",
                               new OracleParameter("moi", DaHuy), new OracleParameter("so", soDon),
                               new OracleParameter("cu", cu));
                if (n == 1)
                    Db.Execute(cn, tx, @"INSERT INTO NhatKyThanhToan(MaNhatKy, MaKH, MaLoaiThe, SoTheAn, SoTien, KetQua, MaGiaoDich, LyDo)
                                         SELECT SEQ_NhatKyTT.NEXTVAL, d.MaKH, t.MaLoaiThe, t.SoTheAn, d.TongTriGia, N'Hoàn tiền',
                                                d.MaGiaoDich, N'Hủy đơn ' || d.SoDonHang
                                         FROM DonDatHang d JOIN TheTinDung t ON t.MaThe = d.MaThe WHERE d.SoDonHang = :so",
                               new OracleParameter("so", soDon));
            });
            return n == 1 ? KetQuaXuLy.Ok(string.Format("Đã hủy đơn {0} và hoàn {1:#,##0} đ vào thẻ của khách.", soDon, tien))
                          : KetQuaXuLy.Fail("Đơn hàng vừa được người khác cập nhật, vui lòng tải lại.");
        }
    }
}
