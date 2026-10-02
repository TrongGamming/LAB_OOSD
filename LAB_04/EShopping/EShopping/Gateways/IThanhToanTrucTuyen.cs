namespace EShopping.Gateways
{
    /// <summary>Kết quả Hệ thống dịch vụ thanh toán trực tuyến trả về.</summary>
    public class KetQuaThanhToan
    {
        public bool ChapThuan { get; set; }
        public string MaGiaoDich { get; set; }
        /// <summary>Token đại diện cho thẻ – cửa hàng lưu token thay vì số thẻ.</summary>
        public string Token { get; set; }
        public string LyDo { get; set; }
    }

    /// <summary>Cổng kết nối tới Hệ thống dịch vụ thanh toán trực tuyến mà công ty đăng ký sử dụng.</summary>
    public interface IThanhToanTrucTuyen
    {
        /// <summary>Kiểm tra tính hợp lệ của thẻ, khả năng thanh toán và trừ tiền.</summary>
        KetQuaThanhToan XacThucVaThanhToan(string maLoaiThe, string soThe, string csv, int thang, int nam,
                                           string chuThe, decimal soTien);

        /// <summary>Hoàn tiền cho một giao dịch (khi đơn bị hủy).</summary>
        bool HoanTien(string maGiaoDich, decimal soTien);
    }
}
