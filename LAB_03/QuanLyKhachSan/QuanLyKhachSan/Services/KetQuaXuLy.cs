using System;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyKhachSan.Services
{
    /// <summary>Kết quả trả về thống nhất từ tầng Service cho Form.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }
        public object DuLieu { get; private set; }

        public static KetQuaXuLy Ok(string thongBao, object duLieu = null)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao, DuLieu = duLieu };
        }

        public static KetQuaXuLy Fail(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
        }

        /// <summary>Đổi lỗi Oracle thành câu thông báo tiếng Việt, không hiện lỗi thô lên Form.</summary>
        public static KetQuaXuLy TuLoi(Exception ex, string khiTrungKhoa = null)
        {
            OracleException ora = ex as OracleException;
            if (ora != null)
            {
                if (ora.Number == 1) return Fail(khiTrungKhoa ?? "Dữ liệu đã tồn tại (trùng khóa chính hoặc ràng buộc duy nhất).");
                if (ora.Number == 2291) return Fail("Dữ liệu tham chiếu không tồn tại, vui lòng chọn lại.");
                if (ora.Number == 2292) return Fail("Dữ liệu đang được sử dụng ở nơi khác nên không thể xóa.");
                if (ora.Number == 1400) return Fail("Vui lòng nhập đầy đủ các thông tin bắt buộc.");
                if (ora.Number == 2290) return Fail("Dữ liệu không thỏa ràng buộc của cơ sở dữ liệu: " + TenRangBuoc(ora.Message));
                if (ora.Number == 1017) return Fail("Sai tài khoản Oracle trong chuỗi kết nối (App.config).");
                if (ora.Number == 12541 || ora.Number == 12514 || ora.Number == 12170 || ora.Number == 12545)
                    return Fail("Không kết nối được Oracle. Kiểm tra dịch vụ OracleServiceORCL, listener và App.config.");
            }
            return Fail("Có lỗi xảy ra: " + ex.Message);
        }

        private static string TenRangBuoc(string message)
        {
            int a = message.IndexOf('(');
            int b = message.IndexOf(')');
            return a >= 0 && b > a ? message.Substring(a + 1, b - a - 1) : message;
        }
    }
}
