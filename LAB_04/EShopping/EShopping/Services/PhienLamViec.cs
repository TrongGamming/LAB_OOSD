namespace EShopping.Services
{
    /// <summary>Người đang dùng ứng dụng và giỏ hàng hiện tại (khách vãng lai cũng có giỏ, MaKH = NULL).</summary>
    public static class PhienLamViec
    {
        public const string VaiTroKhachHang = "Khách hàng";

        public static string MaNguoiDung { get; private set; }
        public static string HoTen { get; private set; }
        public static string VaiTro { get; private set; }
        public static string DiaChi { get; private set; }
        public static string DienThoai { get; private set; }
        public static string Email { get; private set; }

        /// <summary>0 = chưa có giỏ hàng.</summary>
        public static long MaGioHang { get; set; }

        public static bool DaDangNhap { get { return MaNguoiDung != null; } }
        public static bool LaKhachHang { get { return VaiTro == VaiTroKhachHang; } }
        public static bool LaNhanVien { get { return DaDangNhap && !LaKhachHang; } }

        public static void DatKhachHang(string maKH, string hoTen, string diaChi, string dienThoai, string email)
        {
            MaNguoiDung = maKH;
            HoTen = hoTen;
            VaiTro = VaiTroKhachHang;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            Email = email;
        }

        public static void DatNhanVien(string maNV, string hoTen, string vaiTro)
        {
            MaNguoiDung = maNV;
            HoTen = hoTen;
            VaiTro = vaiTro;
            DiaChi = DienThoai = Email = null;
            MaGioHang = 0;
        }

        public static void DangXuat()
        {
            MaNguoiDung = HoTen = VaiTro = DiaChi = DienThoai = Email = null;
            MaGioHang = 0;
        }
    }
}
