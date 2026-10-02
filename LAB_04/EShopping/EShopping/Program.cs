using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using EShopping.Forms;

namespace EShopping
{
    internal static class Program
    {
        /// <summary>
        /// Không tham số: chạy ứng dụng bình thường.
        /// /kiemthu FILE  : chạy kịch bản kiểm thử end-to-end với Oracle, ghi kết quả ra FILE.
        /// /chupanh THU_MUC: mở lần lượt từng form với dữ liệu thật và lưu ảnh PNG (dùng cho báo cáo).
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            // Hiển thị số tiền kiểu Việt Nam: 1.890.000 đ
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length >= 2 && args[0] == "/kiemthu") return KiemThu.ChayKichBan(args[1]);
            if (args.Length >= 2 && args[0] == "/chupanh") return KiemThu.ChupAnh(args[1]);
            Application.Run(new FrmMain());
            return 0;
        }
    }
}
