using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using EShopping.Data;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Services
{
    /// <summary>UC04 Đăng ký tài khoản, UC05 Đăng nhập, UC06 Đăng xuất.</summary>
    public class TaiKhoanService
    {
        private static readonly Regex _giayTo = new Regex(@"^(\d{9}|\d{12}|[A-Z]\d{7,8})$");
        private static readonly Regex _dienThoai = new Regex(@"^0\d{9,10}$");
        private static readonly Regex _email = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static readonly Regex _tenDN = new Regex(@"^[a-z0-9._]{4,50}$");

        private readonly GioHangService _gio;

        public TaiKhoanService(GioHangService gio)
        {
            _gio = gio;
        }

        /// <summary>BR13: kiểm tra thông tin bắt buộc, định dạng và tính duy nhất trước khi tạo tài khoản.</summary>
        public KetQuaXuLy DangKy(KhachHangDto kh, string matKhau, string nhapLai)
        {
            string loi = KiemTraDangKy(kh, matKhau, nhapLai);
            if (loi != null) return KetQuaXuLy.Fail(loi);
            try
            {
                object n = Db.Scalar(@"SELECT COUNT(*) FROM KhachHang WHERE TenDangNhap = :t OR SoGiayTo = :g",
                                     new OracleParameter("t", kh.TenDangNhap), new OracleParameter("g", kh.SoGiayTo));
                if (Convert.ToInt32(n) > 0)
                    return KetQuaXuLy.Fail("Tên đăng nhập hoặc số CMND/Passport đã được đăng ký.");
                n = Db.Scalar("SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = :t", new OracleParameter("t", kh.TenDangNhap));
                if (Convert.ToInt32(n) > 0) return KetQuaXuLy.Fail("Tên đăng nhập đã được sử dụng.");

                string ma = Db.SinhMa("SEQ_KhachHang", "KH", 3);
                string salt = TaoSalt();
                Db.Execute(@"INSERT INTO KhachHang(MaKH, HoTen, NgaySinh, SoGiayTo, DiaChi, DienThoai, TenDangNhap,
                                                   MatKhauHash, Salt, Email)
                             VALUES (:ma, :ten, :ns, :gt, :dc, :dt, :tdn, :mk, :salt, :email)",
                           new OracleParameter("ma", ma), new OracleParameter("ten", kh.HoTen.Trim()),
                           new OracleParameter("ns", OracleDbType.Date) { Value = kh.NgaySinh.Date },
                           new OracleParameter("gt", kh.SoGiayTo), new OracleParameter("dc", kh.DiaChi.Trim()),
                           new OracleParameter("dt", kh.DienThoai), new OracleParameter("tdn", kh.TenDangNhap),
                           new OracleParameter("mk", BamMatKhau(matKhau, salt)), new OracleParameter("salt", salt),
                           new OracleParameter("email", string.IsNullOrEmpty(kh.Email) ? (object)DBNull.Value : kh.Email));
                return KetQuaXuLy.Ok("Đăng ký thành công. Mã khách hàng của bạn là " + ma + ".", ma);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Tên đăng nhập hoặc số CMND/Passport đã được đăng ký.");
            }
        }

        public static string KiemTraDangKy(KhachHangDto kh, string matKhau, string nhapLai)
        {
            if (kh == null) return "Thiếu thông tin khách hàng.";
            kh.SoGiayTo = (kh.SoGiayTo ?? "").Trim().ToUpper();
            kh.DienThoai = (kh.DienThoai ?? "").Trim();
            kh.Email = (kh.Email ?? "").Trim();
            kh.TenDangNhap = (kh.TenDangNhap ?? "").Trim().ToLower();
            if (string.IsNullOrWhiteSpace(kh.HoTen)) return "Chưa nhập họ tên.";
            if (kh.NgaySinh.Date >= DateTime.Today) return "Ngày sinh phải trước ngày hiện tại.";
            if (!_giayTo.IsMatch(kh.SoGiayTo)) return "Số CMND/CCCD gồm 9 hoặc 12 chữ số; Passport gồm 1 chữ cái và 7-8 chữ số.";
            if (string.IsNullOrWhiteSpace(kh.DiaChi)) return "Chưa nhập địa chỉ.";
            if (!_dienThoai.IsMatch(kh.DienThoai)) return "Số điện thoại gồm 10-11 chữ số, bắt đầu bằng 0.";
            if (kh.Email.Length > 0 && !_email.IsMatch(kh.Email)) return "Địa chỉ email không đúng định dạng.";
            if (!_tenDN.IsMatch(kh.TenDangNhap)) return "Tên đăng nhập 4-50 ký tự, chỉ gồm chữ thường, số, dấu chấm, gạch dưới.";
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6) return "Mật khẩu phải có ít nhất 6 ký tự.";
            if (matKhau != nhapLai) return "Mật khẩu nhập lại không khớp.";
            return null;
        }

        /// <summary>
        /// Đăng nhập cho cả khách hàng và nhân viên. Khách hàng đăng nhập thì giỏ hàng đang chọn
        /// lúc còn là khách vãng lai được gộp vào giỏ hàng của tài khoản.
        /// </summary>
        public KetQuaXuLy DangNhap(string tenDangNhap, string matKhau)
        {
            string ten = (tenDangNhap ?? "").Trim().ToLower();
            if (ten.Length == 0 || string.IsNullOrEmpty(matKhau))
                return KetQuaXuLy.Fail("Vui lòng nhập tên đăng nhập và mật khẩu.");
            try
            {
                DataTable kh = Db.Query(@"SELECT MaKH, HoTen, DiaChi, DienThoai, Email, MatKhauHash, Salt, TrangThai
                                          FROM KhachHang WHERE TenDangNhap = :t", new OracleParameter("t", ten));
                if (kh.Rows.Count == 1)
                {
                    DataRow r = kh.Rows[0];
                    if (!DungMatKhau(r, matKhau)) return KetQuaXuLy.Fail("Sai tên đăng nhập hoặc mật khẩu.");
                    if (Convert.ToString(r["TrangThai"]) != "Hoạt động") return KetQuaXuLy.Fail("Tài khoản đang bị khóa.");
                    string maKH = Convert.ToString(r["MaKH"]);
                    long gioTam = PhienLamViec.MaGioHang;
                    PhienLamViec.DatKhachHang(maKH, Convert.ToString(r["HoTen"]), Convert.ToString(r["DiaChi"]),
                                              Convert.ToString(r["DienThoai"]), Convert.ToString(r["Email"]));
                    PhienLamViec.MaGioHang = gioTam != 0 ? _gio.GopGioHang(gioTam, maKH) : _gio.LayGioDangMua(maKH);
                    return KetQuaXuLy.Ok("Xin chào " + PhienLamViec.HoTen + ".");
                }

                DataTable nv = Db.Query("SELECT MaNV, HoTen, VaiTro, MatKhauHash, Salt FROM NhanVien WHERE TenDangNhap = :t",
                                        new OracleParameter("t", ten));
                if (nv.Rows.Count == 1 && DungMatKhau(nv.Rows[0], matKhau))
                {
                    DataRow r = nv.Rows[0];
                    PhienLamViec.DatNhanVien(Convert.ToString(r["MaNV"]), Convert.ToString(r["HoTen"]), Convert.ToString(r["VaiTro"]));
                    return KetQuaXuLy.Ok("Xin chào " + PhienLamViec.HoTen + " (" + PhienLamViec.VaiTro + ").");
                }
                return KetQuaXuLy.Fail("Sai tên đăng nhập hoặc mật khẩu.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public void DangXuat()
        {
            PhienLamViec.DangXuat();
        }

        private static bool DungMatKhau(DataRow r, string matKhau)
        {
            return string.Equals(BamMatKhau(matKhau, Convert.ToString(r["Salt"])), Convert.ToString(r["MatKhauHash"]),
                                 StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>SHA-256(Salt + MatKhau), chuỗi hex in hoa 64 ký tự.</summary>
        internal static string BamMatKhau(string matKhau, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(salt + matKhau));
                StringBuilder sb = new StringBuilder();
                foreach (byte x in b) sb.Append(x.ToString("X2"));
                return sb.ToString();
            }
        }

        private static string TaoSalt()
        {
            byte[] b = new byte[8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) rng.GetBytes(b);
            return BitConverter.ToString(b).Replace("-", "");
        }
    }
}
