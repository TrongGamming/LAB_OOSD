using System;
using EShopping.Data;
using EShopping.Gateways;

namespace EShopping.Services
{
    /// <summary>
    /// Nơi duy nhất khởi tạo các dịch vụ và gắn chúng với cài đặt cụ thể của hệ thống ngoài.
    /// Đổi sang cổng thanh toán / máy chủ mail thật chỉ cần sửa ở đây.
    /// </summary>
    public static class HeThong
    {
        public static readonly IHeThongQuanLySanPham SanPham = new HtqlspOracle();
        public static readonly IThanhToanTrucTuyen ThanhToan = new ThanhToanGiaLap();
        public static readonly IEmailSender Email = new EmailFileSender();

        public static readonly GioHangService GioHang = new GioHangService(SanPham);
        public static readonly TaiKhoanService TaiKhoan = new TaiKhoanService(GioHang);
        public static readonly DatHangService DatHang = new DatHangService(ThanhToan, Email);
        public static readonly DonHangService DonHang = new DonHangService(ThanhToan);
        public static readonly QuanTriService QuanTri = new QuanTriService();

        /// <summary>Kiểm tra kết nối Oracle; trả về mô tả "USER@service" hoặc ném lỗi.</summary>
        public static string KiemTraKetNoi()
        {
            object o = Db.Scalar("SELECT USER || '@' || SYS_CONTEXT('USERENV', 'SERVICE_NAME') FROM dual");
            return Convert.ToString(o);
        }
    }
}
