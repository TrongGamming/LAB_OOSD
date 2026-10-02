using System;
using System.Data;
using EShopping.Data;
using EShopping.Gateways;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Services
{
    /// <summary>UC03 Quản lý giỏ hàng: thêm, xem, cập nhật số lượng, loại bỏ, gộp giỏ khi đăng nhập.</summary>
    public class GioHangService
    {
        public const int SoLuongToiDa = 99;
        private readonly IHeThongQuanLySanPham _sp;

        public GioHangService(IHeThongQuanLySanPham sp)
        {
            _sp = sp;
        }

        /// <summary>Giỏ "Đang mua" của khách; 0 nếu chưa có.</summary>
        public long LayGioDangMua(string maKH)
        {
            object o = Db.Scalar("SELECT MaGioHang FROM GioHang WHERE MaKH = :kh AND TrangThai = N'Đang mua'",
                                 new OracleParameter("kh", maKH ?? ""));
            return o == null || o == DBNull.Value ? 0 : Convert.ToInt64(o);
        }

        private long TaoGio(string maKH)
        {
            long ma = Convert.ToInt64(Db.Scalar("SELECT SEQ_GioHang.NEXTVAL FROM dual"));
            Db.Execute("INSERT INTO GioHang(MaGioHang, MaKH) VALUES (:ma, :kh)",
                       new OracleParameter("ma", ma), new OracleParameter("kh", (object)maKH ?? DBNull.Value));
            return ma;
        }

        /// <summary>
        /// BR03: chỉ sản phẩm "Còn hàng" mới được thêm. Sản phẩm đã có trong giỏ thì cộng dồn số lượng.
        /// DuLieu trả về là mã giỏ hàng (giỏ được tạo mới nếu maGio = 0).
        /// </summary>
        public KetQuaXuLy ThemVaoGio(long maGio, string maKH, string maSP, int soLuong)
        {
            if (soLuong < 1 || soLuong > SoLuongToiDa) return KetQuaXuLy.Fail("Số lượng phải từ 1 đến " + SoLuongToiDa + ".");
            try
            {
                DataRow sp = _sp.LaySanPham(maSP);
                if (sp == null) return KetQuaXuLy.Fail("Không tìm thấy sản phẩm.");
                if (Convert.ToString(sp["TinhTrang"]) != "Còn hàng")
                    return KetQuaXuLy.Fail("Sản phẩm \"" + sp["TenSP"] + "\" đã hết hàng, không thể thêm vào giỏ.");
                if (maGio == 0) maGio = maKH != null ? LayGioDangMua(maKH) : 0;
                if (maGio == 0) maGio = TaoGio(maKH);
                Db.Execute(@"MERGE INTO ChiTietGioHang c
                             USING (SELECT :gio AS MaGioHang, :sp AS MaSP FROM dual) x
                             ON (c.MaGioHang = x.MaGioHang AND c.MaSP = x.MaSP)
                             WHEN MATCHED THEN UPDATE SET c.SoLuong = LEAST(c.SoLuong + :sl, 99)
                             WHEN NOT MATCHED THEN INSERT (MaGioHang, MaSP, SoLuong) VALUES (x.MaGioHang, x.MaSP, :sl)",
                           new OracleParameter("gio", maGio), new OracleParameter("sp", maSP),
                           new OracleParameter("sl", soLuong));
                return KetQuaXuLy.Ok("Đã thêm \"" + sp["TenSP"] + "\" vào giỏ hàng.", maGio);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Danh sách mặt hàng trong giỏ theo GIÁ BÁN HIỆN HÀNH (BR02).</summary>
        public DataTable LayChiTiet(long maGio)
        {
            return Db.Query(@"SELECT c.MaSP, s.TenSP, s.NhaSanXuat, s.GiaBan AS DonGia, c.SoLuong,
                                     s.GiaBan * c.SoLuong AS ThanhTien, s.TinhTrang
                              FROM ChiTietGioHang c JOIN SanPham s ON s.MaSP = c.MaSP
                              WHERE c.MaGioHang = :gio ORDER BY c.NgayThem, s.TenSP",
                            new OracleParameter("gio", maGio));
        }

        public int DemSoLuong(long maGio)
        {
            if (maGio == 0) return 0;
            object o = Db.Scalar("SELECT NVL(SUM(SoLuong), 0) FROM ChiTietGioHang WHERE MaGioHang = :gio",
                                 new OracleParameter("gio", maGio));
            return Convert.ToInt32(o);
        }

        public KetQuaXuLy CapNhatSoLuong(long maGio, string maSP, int soLuong)
        {
            if (soLuong < 1 || soLuong > SoLuongToiDa)
                return KetQuaXuLy.Fail("Số lượng phải từ 1 đến " + SoLuongToiDa + ". Muốn bỏ sản phẩm hãy dùng \"Loại bỏ\".");
            try
            {
                int n = Db.Execute("UPDATE ChiTietGioHang SET SoLuong = :sl WHERE MaGioHang = :gio AND MaSP = :sp",
                                   new OracleParameter("sl", soLuong), new OracleParameter("gio", maGio),
                                   new OracleParameter("sp", maSP));
                return n == 1 ? KetQuaXuLy.Ok("Đã cập nhật số lượng.") : KetQuaXuLy.Fail("Sản phẩm không còn trong giỏ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy LoaiBo(long maGio, string maSP)
        {
            try
            {
                int n = Db.Execute("DELETE FROM ChiTietGioHang WHERE MaGioHang = :gio AND MaSP = :sp",
                                   new OracleParameter("gio", maGio), new OracleParameter("sp", maSP));
                return n == 1 ? KetQuaXuLy.Ok("Đã loại bỏ sản phẩm khỏi giỏ.") : KetQuaXuLy.Fail("Sản phẩm không còn trong giỏ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy XoaHet(long maGio)
        {
            try
            {
                Db.Execute("DELETE FROM ChiTietGioHang WHERE MaGioHang = :gio", new OracleParameter("gio", maGio));
                return KetQuaXuLy.Ok("Đã xóa hết sản phẩm trong giỏ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>
        /// Gộp giỏ của khách vãng lai vào giỏ đang mua của tài khoản (cộng dồn số lượng, tối đa 99);
        /// nếu tài khoản chưa có giỏ thì giỏ tạm được gán cho tài khoản. Trả về mã giỏ dùng tiếp.
        /// </summary>
        public long GopGioHang(long maGioTam, string maKH)
        {
            long gioKhach = LayGioDangMua(maKH);
            if (gioKhach == maGioTam) return gioKhach;
            if (gioKhach == 0)
            {
                Db.Execute("UPDATE GioHang SET MaKH = :kh WHERE MaGioHang = :gio AND MaKH IS NULL",
                           new OracleParameter("kh", maKH), new OracleParameter("gio", maGioTam));
                return maGioTam;
            }
            Db.Transaction((cn, tx) =>
            {
                Db.Execute(cn, tx, @"MERGE INTO ChiTietGioHang c
                                     USING (SELECT MaSP, SoLuong FROM ChiTietGioHang WHERE MaGioHang = :tam) x
                                     ON (c.MaGioHang = :gio AND c.MaSP = x.MaSP)
                                     WHEN MATCHED THEN UPDATE SET c.SoLuong = LEAST(c.SoLuong + x.SoLuong, 99)
                                     WHEN NOT MATCHED THEN INSERT (MaGioHang, MaSP, SoLuong) VALUES (:gio, x.MaSP, x.SoLuong)",
                           new OracleParameter("tam", maGioTam), new OracleParameter("gio", gioKhach));
                Db.Execute(cn, tx, "DELETE FROM GioHang WHERE MaGioHang = :tam AND MaKH IS NULL",
                           new OracleParameter("tam", maGioTam));
            });
            return gioKhach;
        }
    }
}
