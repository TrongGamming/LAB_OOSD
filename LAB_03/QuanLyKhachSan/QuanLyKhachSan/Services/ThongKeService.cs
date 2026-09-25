using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Thống kê theo khoảng thời gian cho người quản lý.</summary>
    public class ThongKeService
    {
        private static OracleParameter[] Khoang(DateTime tu, DateTime den)
        {
            return new[]
            {
                new OracleParameter("tu", OracleDbType.Date) { Value = tu.Date },
                new OracleParameter("den", OracleDbType.Date) { Value = den.Date }
            };
        }

        /// <summary>Tổng hợp: số phiếu đặt, số hóa đơn, doanh thu phòng/dịch vụ, tiền đền bù, đã thanh toán.</summary>
        public DataTable TongHop(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE NgayLap >= :tu AND NgayLap < :den + 1)          AS SoPhieuDat,
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai = N'Đang ở')                          AS DangO,
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai = N'No-show'
                                                      AND NgayLap >= :tu AND NgayLap < :den + 1)          AS NoShow,
                (SELECT COUNT(*) FROM HoaDon WHERE NgayLap >= :tu AND NgayLap < :den + 1)                 AS SoHoaDon,
                (SELECT NVL(SUM(TienPhong), 0) FROM HoaDon WHERE NgayLap >= :tu AND NgayLap < :den + 1)   AS TienPhong,
                (SELECT NVL(SUM(TienDichVu), 0) FROM HoaDon WHERE NgayLap >= :tu AND NgayLap < :den + 1)  AS TienDichVu,
                (SELECT NVL(SUM(TongTien), 0) FROM PhieuDenBu WHERE NgayLap >= :tu AND NgayLap < :den + 1) AS TienDenBu,
                (SELECT NVL(SUM(SoTien), 0) FROM ThanhToan
                  WHERE NgayThanhToan >= :tu AND NgayThanhToan < :den + 1)                                AS DaThanhToan
              FROM dual", Khoang(tu, den));
        }

        /// <summary>Dịch vụ được sử dụng trong khoảng thời gian.</summary>
        public DataTable ThongKeDichVu(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT d.MaDV, d.TenDV, d.DonViTinh, SUM(c.SoLuong) AS SoLuong, SUM(c.ThanhTien) AS ThanhTien
                              FROM PhieuSuDungDV h
                              JOIN ChiTietPhieuSuDungDV c ON c.SoPhieuSDDV = h.SoPhieuSDDV
                              JOIN DichVu d ON d.MaDV = c.MaDV
                              WHERE h.NgaySuDung >= :tu AND h.NgaySuDung < :den + 1
                              GROUP BY d.MaDV, d.TenDV, d.DonViTinh
                              ORDER BY SUM(c.ThanhTien) DESC", Khoang(tu, den));
        }

        /// <summary>Công suất phòng: số lượt đặt và doanh thu theo từng phòng.</summary>
        public DataTable ThongKePhong(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT p.SoPhong, k.TenKhuVuc, p.TrangThai,
                                     COUNT(c.SoPhieuDat) AS SoLuot,
                                     NVL(SUM(c.DonGiaApDung), 0) AS DoanhThu
                              FROM Phong p
                              JOIN KhuVuc k ON k.MaKhuVuc = p.MaKhuVuc
                              LEFT JOIN ChiTietDatPhong c ON c.SoPhong = p.SoPhong
                              LEFT JOIN PhieuDatPhong d ON d.SoPhieuDat = c.SoPhieuDat
                                   AND d.NgayLap >= :tu AND d.NgayLap < :den + 1
                                   AND d.TrangThai <> N'Hủy'
                              GROUP BY p.SoPhong, k.TenKhuVuc, p.TrangThai
                              ORDER BY p.SoPhong", Khoang(tu, den));
        }

        /// <summary>Hóa đơn trong kỳ kèm số tiền đã thanh toán và còn lại.</summary>
        public DataTable ThongKeHoaDon(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT h.SoHoaDon, h.SoPhieuDat, k.HoTen, h.NgayLap, h.TongTien, h.TrangThai,
                                     NVL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon = h.SoHoaDon), 0) AS TongDaThanhToan,
                                     h.TongTien - NVL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon = h.SoHoaDon), 0) AS ConLai
                              FROM HoaDon h
                              JOIN PhieuDatPhong d ON d.SoPhieuDat = h.SoPhieuDat
                              JOIN KhachHang k ON k.MaKhach = d.MaKhach
                              WHERE h.NgayLap >= :tu AND h.NgayLap < :den + 1
                              ORDER BY h.NgayLap DESC", Khoang(tu, den));
        }
    }
}
