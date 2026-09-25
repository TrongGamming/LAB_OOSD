using System;
using Oracle.ManagedDataAccess.Client;

namespace ThuVienSo.Services
{
    /// <summary>Kết quả trả về thống nhất từ tầng Service cho Form.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongDiep { get; private set; }
        public object DuLieu { get; private set; }

        public static KetQuaXuLy Ok(string thongDiep, object duLieu = null)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongDiep = thongDiep, DuLieu = duLieu };
        }

        public static KetQuaXuLy Loi(string thongDiep)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongDiep = thongDiep };
        }

        /// <summary>Đổi lỗi Oracle thành thông điệp tiếng Việt thân thiện.</summary>
        public static KetQuaXuLy TuLoi(Exception ex)
        {
            OracleException ora = ex as OracleException;
            if (ora != null)
            {
                // RAISE_APPLICATION_ERROR(-20001..-20999) trong procedure: lỗi nghiệp vụ
                if (ora.Number >= 20000 && ora.Number <= 20999) return Loi(ThongDiepNghiepVu(ora.Message));
                if (ora.Number == 2292) return Loi("Dữ liệu đang được sử dụng ở nơi khác nên không thể xóa.");
                if (ora.Number == 2291) return Loi("Dữ liệu tham chiếu không tồn tại.");
                if (ora.Number == 1) return Loi("Mã hoặc giá trị này đã tồn tại.");
                if (ora.Number == 1400) return Loi("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                if (ora.Number == 2290) return Loi("Dữ liệu không thỏa ràng buộc: " + TenRangBuoc(ora.Message));
                if (ora.Number == 1017) return Loi("Sai tài khoản Oracle trong chuỗi kết nối (App.config).");
                if (ora.Number == 12541 || ora.Number == 12514 || ora.Number == 12170 || ora.Number == 12545)
                    return Loi("Không kết nối được Oracle. Kiểm tra dịch vụ OracleServiceORCL, listener và chuỗi kết nối trong App.config.");
            }
            return Loi("Có lỗi xảy ra: " + ex.Message);
        }

        /// <summary>"ORA-20021: Nội dung\nORA-06512: at ..." -> "Nội dung".</summary>
        private static string ThongDiepNghiepVu(string message)
        {
            string dong = message.Split('\n')[0];
            int i = dong.IndexOf(": ", StringComparison.Ordinal);
            return (i >= 0 ? dong.Substring(i + 2) : dong).Trim();
        }

        private static string TenRangBuoc(string message)
        {
            int a = message.IndexOf('(');
            int b = message.IndexOf(')');
            return a >= 0 && b > a ? message.Substring(a + 1, b - a - 1) : message;
        }
    }
}
