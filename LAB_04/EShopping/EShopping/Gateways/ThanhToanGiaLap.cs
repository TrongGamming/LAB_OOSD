using System;
using System.Security.Cryptography;
using System.Text;
using EShopping.Services;

namespace EShopping.Gateways
{
    /// <summary>
    /// Giả lập Hệ thống dịch vụ thanh toán trực tuyến cho môi trường lab (sandbox), theo quy ước thẻ thử:
    /// số thẻ tận cùng 0002 → không đủ khả năng thanh toán; tận cùng 0069 → thẻ bị khóa;
    /// giao dịch trên 100 triệu → vượt hạn mức; các thẻ hợp lệ còn lại → chấp thuận.
    /// </summary>
    public class ThanhToanGiaLap : IThanhToanTrucTuyen
    {
        private const decimal HanMuc = 100000000m;

        public KetQuaThanhToan XacThucVaThanhToan(string maLoaiThe, string soThe, string csv, int thang, int nam,
                                                  string chuThe, decimal soTien)
        {
            string so = KiemTraThe.ChuanHoa(soThe);
            if (!KiemTraThe.Luhn(so)) return TuChoi("Số thẻ không tồn tại.");
            DateTime nay = DateTime.Today;
            if (nam < nay.Year || (nam == nay.Year && thang < nay.Month)) return TuChoi("Thẻ đã hết hạn.");
            if (so.EndsWith("0002")) return TuChoi("Thẻ không đủ khả năng thanh toán.");
            if (so.EndsWith("0069")) return TuChoi("Thẻ đã bị ngân hàng phát hành khóa.");
            if (soTien > HanMuc) return TuChoi("Giao dịch vượt hạn mức của thẻ.");
            return new KetQuaThanhToan
            {
                ChapThuan = true,
                MaGiaoDich = "GD" + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper(),
                Token = "TOK-" + maLoaiThe + "-" + Bam(maLoaiThe + so).Substring(0, 24)
            };
        }

        public bool HoanTien(string maGiaoDich, decimal soTien)
        {
            return !string.IsNullOrEmpty(maGiaoDich) && soTien >= 0;
        }

        private static KetQuaThanhToan TuChoi(string lyDo)
        {
            return new KetQuaThanhToan { ChapThuan = false, LyDo = lyDo };
        }

        private static string Bam(string s)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
                StringBuilder sb = new StringBuilder();
                foreach (byte x in b) sb.Append(x.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
