using System;
using System.Data;
using EShopping.Data;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Services
{
    /// <summary>UC10 Biểu phí giao hàng, UC11 Loại thẻ và lệ phí, UC12 Nhật ký thanh toán & email.</summary>
    public class QuanTriService
    {
        public DataTable LayKhuVuc()
        {
            return Db.Query("SELECT MaKhuVuc, TenKhuVuc FROM KhuVucGiaoHang ORDER BY TenKhuVuc");
        }

        public DataTable LayLoaiPhieu()
        {
            return Db.Query("SELECT MaLoaiPhieu, TenLoai, SoGioXuLy, NguongMienPhi FROM LoaiPhieuDatHang ORDER BY SoGioXuLy DESC");
        }

        public DataTable LayBangPhi()
        {
            return Db.Query(@"SELECT b.MaKhuVuc, k.TenKhuVuc, b.MaLoaiPhieu, l.TenLoai, b.PhiGiao
                              FROM BangPhiGiaoHang b
                              JOIN KhuVucGiaoHang k ON k.MaKhuVuc = b.MaKhuVuc
                              JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = b.MaLoaiPhieu
                              ORDER BY k.TenKhuVuc, l.SoGioXuLy DESC");
        }

        public KetQuaXuLy LuuBangPhi(string maKhuVuc, string maLoaiPhieu, decimal phi)
        {
            if (string.IsNullOrEmpty(maKhuVuc) || string.IsNullOrEmpty(maLoaiPhieu))
                return KetQuaXuLy.Fail("Chưa chọn khu vực và loại phiếu.");
            if (phi < 0) return KetQuaXuLy.Fail("Phí giao hàng không được âm.");
            try
            {
                Db.Execute(@"MERGE INTO BangPhiGiaoHang b
                             USING (SELECT :kv AS MaKhuVuc, :lp AS MaLoaiPhieu FROM dual) x
                             ON (b.MaKhuVuc = x.MaKhuVuc AND b.MaLoaiPhieu = x.MaLoaiPhieu)
                             WHEN MATCHED THEN UPDATE SET b.PhiGiao = :phi
                             WHEN NOT MATCHED THEN INSERT (MaKhuVuc, MaLoaiPhieu, PhiGiao) VALUES (x.MaKhuVuc, x.MaLoaiPhieu, :phi)",
                           new OracleParameter("kv", maKhuVuc), new OracleParameter("lp", maLoaiPhieu),
                           new OracleParameter("phi", phi));
                return KetQuaXuLy.Ok("Đã lưu biểu phí giao hàng.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>nguong = 0 nghĩa là loại phiếu này không bao giờ miễn phí (lưu NULL).</summary>
        public KetQuaXuLy LuuLoaiPhieu(string maLoaiPhieu, int soGio, decimal nguong)
        {
            if (string.IsNullOrEmpty(maLoaiPhieu)) return KetQuaXuLy.Fail("Chưa chọn loại phiếu.");
            if (soGio <= 0) return KetQuaXuLy.Fail("Số giờ xử lý phải lớn hơn 0.");
            try
            {
                Db.Execute("UPDATE LoaiPhieuDatHang SET SoGioXuLy = :gio, NguongMienPhi = :ng WHERE MaLoaiPhieu = :ma",
                           new OracleParameter("gio", soGio),
                           new OracleParameter("ng", nguong > 0 ? (object)nguong : DBNull.Value),
                           new OracleParameter("ma", maLoaiPhieu));
                return KetQuaXuLy.Ok("Đã lưu loại phiếu đặt hàng.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public DataTable LayLoaiThe()
        {
            return Db.Query("SELECT MaLoaiThe, TenLoaiThe, DoDaiSoThe, DoDaiCSV, LePhiGiaoDich FROM LoaiThe ORDER BY MaLoaiThe");
        }

        public KetQuaXuLy LuuLePhi(string maLoaiThe, decimal lePhi)
        {
            if (string.IsNullOrEmpty(maLoaiThe)) return KetQuaXuLy.Fail("Chưa chọn loại thẻ.");
            if (lePhi < 0) return KetQuaXuLy.Fail("Lệ phí không được âm.");
            try
            {
                Db.Execute("UPDATE LoaiThe SET LePhiGiaoDich = :lp WHERE MaLoaiThe = :ma",
                           new OracleParameter("lp", lePhi), new OracleParameter("ma", maLoaiThe));
                return KetQuaXuLy.Ok("Đã lưu lệ phí giao dịch của thẻ " + maLoaiThe + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public DataTable LayNhatKyThanhToan()
        {
            return Db.Query(@"SELECT n.MaNhatKy, n.ThoiDiem, n.MaKH, k.HoTen, n.MaLoaiThe, n.SoTheAn, n.SoTien, n.KetQua,
                                     n.MaGiaoDich, n.LyDo
                              FROM NhatKyThanhToan n JOIN KhachHang k ON k.MaKH = n.MaKH
                              ORDER BY n.ThoiDiem DESC, n.MaNhatKy DESC");
        }

        public DataTable LayNhatKyEmail()
        {
            return Db.Query(@"SELECT MaEmail, ThoiDiemGui, SoDonHang, DiaChiEmail, TieuDe, NoiDung
                              FROM NhatKyEmail ORDER BY ThoiDiemGui DESC, MaEmail DESC");
        }
    }
}
