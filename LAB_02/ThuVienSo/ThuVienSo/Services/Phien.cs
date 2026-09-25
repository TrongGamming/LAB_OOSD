namespace ThuVienSo.Services
{
    /// <summary>Thông tin người dùng đang đăng nhập.</summary>
    public static class Phien
    {
        public static int MaTaiKhoan { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
        public static string MaThuThu { get; set; }
        public static string MaDocGia { get; set; }
        public static string HoTen { get; set; }

        public static bool LaThuThu
        {
            get { return VaiTro == "ThuThu"; }
        }

        public static void DangXuat()
        {
            MaTaiKhoan = 0;
            TenDangNhap = VaiTro = MaThuThu = MaDocGia = HoTen = null;
        }
    }
}
