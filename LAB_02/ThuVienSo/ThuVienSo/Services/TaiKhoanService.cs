using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ThuVienSo.Data;
using Oracle.ManagedDataAccess.Client;

namespace ThuVienSo.Services
{
    public class TaiKhoanService
    {
        private const int SoLanSaiToiDa = 5;   // BR16

        /// <summary>SHA-256(salt + mật khẩu UTF-16).</summary>
        public static byte[] BamMatKhau(byte[] salt, string matKhau)
        {
            byte[] mk = Encoding.Unicode.GetBytes(matKhau);
            using (SHA256 sha = SHA256.Create())
                return sha.ComputeHash(salt.Concat(mk).ToArray());
        }

        public KetQuaXuLy DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return KetQuaXuLy.Loi("Vui lòng nhập tên đăng nhập và mật khẩu.");
            try
            {
                DataTable t = Db.Query(@"SELECT tk.MaTaiKhoan, tk.MatKhauHash, tk.MatKhauSalt, tk.VaiTro, tk.TrangThai,
                                                tk.MaThuThu, tk.MaDocGia, COALESCE(tt.HoTen, dg.HoTen) AS HoTen
                                         FROM TaiKhoan tk
                                         LEFT JOIN ThuThu tt ON tt.MaThuThu = tk.MaThuThu
                                         LEFT JOIN DocGia dg ON dg.MaDocGia = tk.MaDocGia
                                         WHERE tk.TenDangNhap = :Ten",
                                        new OracleParameter("Ten", tenDangNhap.Trim()));
                // thông báo chung, không để lộ tên đăng nhập có tồn tại hay không
                if (t.Rows.Count == 0) return KetQuaXuLy.Loi("Sai tên đăng nhập hoặc mật khẩu.");

                DataRow r = t.Rows[0];
                int ma = Convert.ToInt32(r["MaTaiKhoan"]);
                if (Convert.ToString(r["TrangThai"]) == "TamKhoa")
                    return KetQuaXuLy.Loi("Tài khoản đang bị tạm khóa do nhập sai nhiều lần. Vui lòng liên hệ thủ thư.");

                byte[] hash = BamMatKhau((byte[])r["MatKhauSalt"], matKhau);
                if (!hash.SequenceEqual((byte[])r["MatKhauHash"]))
                {
                    Db.Execute(@"UPDATE TaiKhoan
                                 SET SoLanSaiLienTiep = SoLanSaiLienTiep + 1,
                                     TrangThai = CASE WHEN SoLanSaiLienTiep + 1 >= :MaxLan THEN 'TamKhoa' ELSE TrangThai END
                                 WHERE MaTaiKhoan = :Ma",
                               new OracleParameter("Ma", ma), new OracleParameter("MaxLan", SoLanSaiToiDa));
                    return KetQuaXuLy.Loi("Sai tên đăng nhập hoặc mật khẩu.");
                }

                Db.Execute("UPDATE TaiKhoan SET SoLanSaiLienTiep = 0, LanDangNhapCuoi = SYSTIMESTAMP WHERE MaTaiKhoan = :Ma",
                           new OracleParameter("Ma", ma));
                Phien.MaTaiKhoan = ma;
                Phien.TenDangNhap = tenDangNhap.Trim();
                Phien.VaiTro = Convert.ToString(r["VaiTro"]);
                Phien.MaThuThu = r["MaThuThu"] as string;
                Phien.MaDocGia = r["MaDocGia"] as string;
                Phien.HoTen = Convert.ToString(r["HoTen"]);
                return KetQuaXuLy.Ok("Đăng nhập thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>BR16: mật khẩu ít nhất 8 ký tự, có cả chữ và số.</summary>
        public static string KiemTraDoManh(string matKhau, string nhapLai)
        {
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 8 || !matKhau.Any(char.IsLetter) || !matKhau.Any(char.IsDigit))
                return "Mật khẩu phải có ít nhất 8 ký tự, gồm cả chữ và số.";
            if (matKhau != nhapLai) return "Nhập lại mật khẩu không khớp.";
            return null;
        }

        /// <summary>UC-TK-01 (bước kiểm tra): thẻ hợp lệ và chưa gắn tài khoản; trả về họ tên, email chủ thẻ.</summary>
        public KetQuaXuLy KiemTraTheDangKy(string maThe)
        {
            KetQuaXuLy kq = new TheService().XacThucMaThe(maThe);
            if (!kq.ThanhCong) return kq;
            DataRow the = (DataRow)kq.DuLieu;
            try
            {
                object n = Db.Scalar("SELECT COUNT(*) FROM TaiKhoan WHERE MaDocGia = :Ma",
                                     new OracleParameter("Ma", Convert.ToString(the["MaDocGia"])));
                if (Convert.ToInt32(n) > 0) return KetQuaXuLy.Loi("Độc giả của thẻ này đã có tài khoản.");
                return KetQuaXuLy.Ok(Convert.ToString(the["HoTen"]), the);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>UC-TK-01: đăng ký tài khoản độc giả.</summary>
        public KetQuaXuLy DangKy(string maThe, string email, string tenDangNhap, string matKhau, string nhapLai)
        {
            KetQuaXuLy the = KiemTraTheDangKy(maThe);
            if (!the.ThanhCong) return the;
            DataRow r = (DataRow)the.DuLieu;
            if (string.IsNullOrWhiteSpace(tenDangNhap) || tenDangNhap.Trim().Length < 4 || tenDangNhap.Contains(" "))
                return KetQuaXuLy.Loi("Tên đăng nhập phải từ 4 ký tự và không có khoảng trắng.");
            if (!string.Equals((email ?? "").Trim(), Convert.ToString(r["Email"]), StringComparison.OrdinalIgnoreCase))
                return KetQuaXuLy.Loi("Email không khớp với email đã đăng ký của độc giả.");
            string loiMk = KiemTraDoManh(matKhau, nhapLai);
            if (loiMk != null) return KetQuaXuLy.Loi(loiMk);

            byte[] salt = TaoSalt();
            try
            {
                Db.Execute(@"INSERT INTO TaiKhoan(TenDangNhap, MatKhauHash, MatKhauSalt, VaiTro, MaDocGia)
                             VALUES (:Ten, :Hash, :Salt, 'DocGia', :MaDG)",
                           new OracleParameter("Ten", tenDangNhap.Trim()),
                           new OracleParameter("Hash", OracleDbType.Raw) { Value = BamMatKhau(salt, matKhau) },
                           new OracleParameter("Salt", OracleDbType.Raw) { Value = salt },
                           new OracleParameter("MaDG", Convert.ToString(r["MaDocGia"])));
                return KetQuaXuLy.Ok("Đăng ký tài khoản thành công. Bạn có thể đăng nhập ngay.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // ORA-00001 -> tên đăng nhập đã tồn tại
            }
        }

        /// <summary>Đổi mật khẩu của tài khoản đang đăng nhập (sinh salt mới).</summary>
        public KetQuaXuLy DoiMatKhau(int maTaiKhoan, string matKhauCu, string matKhauMoi, string nhapLai)
        {
            try
            {
                DataTable t = Db.Query("SELECT MatKhauHash, MatKhauSalt FROM TaiKhoan WHERE MaTaiKhoan = :Ma",
                                       new OracleParameter("Ma", maTaiKhoan));
                if (t.Rows.Count == 0) return KetQuaXuLy.Loi("Không tìm thấy tài khoản.");
                if (!BamMatKhau((byte[])t.Rows[0]["MatKhauSalt"], matKhauCu ?? "").SequenceEqual((byte[])t.Rows[0]["MatKhauHash"]))
                    return KetQuaXuLy.Loi("Mật khẩu cũ không đúng.");
                if (matKhauMoi == matKhauCu) return KetQuaXuLy.Loi("Mật khẩu mới phải khác mật khẩu cũ.");
                string loi = KiemTraDoManh(matKhauMoi, nhapLai);
                if (loi != null) return KetQuaXuLy.Loi(loi);

                byte[] salt = TaoSalt();
                Db.Execute("UPDATE TaiKhoan SET MatKhauHash = :Hash, MatKhauSalt = :Salt WHERE MaTaiKhoan = :Ma",
                           new OracleParameter("Hash", OracleDbType.Raw) { Value = BamMatKhau(salt, matKhauMoi) },
                           new OracleParameter("Salt", OracleDbType.Raw) { Value = salt },
                           new OracleParameter("Ma", maTaiKhoan));
                return KetQuaXuLy.Ok("Đổi mật khẩu thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        private static byte[] TaoSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);
            return salt;
        }
    }
}
