using System;
using System.Linq;

namespace EShopping.Services
{
    /// <summary>BR09: kiểm tra định dạng thẻ tín dụng trước khi gửi sang Hệ thống thanh toán.</summary>
    public static class KiemTraThe
    {
        /// <summary>Bỏ khoảng trắng và dấu gạch người dùng gõ cho dễ đọc.</summary>
        public static string ChuanHoa(string soThe)
        {
            return new string((soThe ?? "").Where(ch => ch != ' ' && ch != '-').ToArray());
        }

        /// <summary>Trả về null nếu hợp lệ, ngược lại là câu báo lỗi.</summary>
        public static string KiemTra(LoaiTheDto loai, string soThe, string csv, int thang, int nam, string chuThe, DateTime homNay)
        {
            if (loai == null) return "Chưa chọn loại thẻ.";
            string so = ChuanHoa(soThe);
            if (so.Length == 0) return "Chưa nhập số thẻ.";
            if (!so.All(char.IsDigit)) return "Số thẻ chỉ gồm chữ số.";
            if (so.Length != loai.DoDaiSoThe)
                return string.Format("Thẻ {0} phải có {1} chữ số (đang nhập {2}).", loai.TenLoaiThe, loai.DoDaiSoThe, so.Length);
            if (!Luhn(so)) return "Số thẻ không hợp lệ (sai chữ số kiểm tra).";
            string c = (csv ?? "").Trim();
            if (c.Length != loai.DoDaiCSV || !c.All(char.IsDigit))
                return string.Format("Mã CSV của thẻ {0} gồm {1} chữ số.", loai.TenLoaiThe, loai.DoDaiCSV);
            if (thang < 1 || thang > 12) return "Tháng hết hạn không hợp lệ.";
            if (nam < homNay.Year || (nam == homNay.Year && thang < homNay.Month)) return "Thẻ đã hết hạn sử dụng.";
            if (string.IsNullOrWhiteSpace(chuThe)) return "Chưa nhập họ tên chủ thẻ.";
            return null;
        }

        /// <summary>Thuật toán Luhn (mod 10) dùng cho mọi loại thẻ VISA, Master, Discover, AmEx.</summary>
        public static bool Luhn(string so)
        {
            int tong = 0;
            bool gapDoi = false;
            for (int i = so.Length - 1; i >= 0; i--)
            {
                int d = so[i] - '0';
                if (gapDoi)
                {
                    d *= 2;
                    if (d > 9) d -= 9;
                }
                tong += d;
                gapDoi = !gapDoi;
            }
            return tong % 10 == 0;
        }

        /// <summary>Che số thẻ, chỉ giữ 4 số cuối: **** **** **** 1111 hoặc **** ****** *0005 (AmEx).</summary>
        public static string AnSoThe(string soThe)
        {
            string so = ChuanHoa(soThe);
            string cuoi = so.Length >= 4 ? so.Substring(so.Length - 4) : so;
            return so.Length == 15 ? "**** ****** *" + cuoi : "**** **** **** " + cuoi;
        }
    }
}
