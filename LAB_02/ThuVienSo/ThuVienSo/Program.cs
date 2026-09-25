using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThuVienSo.Forms;
using ThuVienSo.Services;

namespace ThuVienSo
{
    internal static class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            // UC-TĐ-01: Bộ lập lịch (Windows Task Scheduler) chạy "ThuVienSo.exe /nhachan" lúc 06:00 hằng ngày
            if (args.Any(a => a.Equals("/nhachan", StringComparison.OrdinalIgnoreCase)))
                return ChayNhacHan();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Đăng nhập -> Trang chủ; Đăng xuất (Retry) thì quay lại màn hình đăng nhập
            while (true)
            {
                using (FrmDangNhap dn = new FrmDangNhap())
                    if (dn.ShowDialog() != DialogResult.OK) return 0;
                using (FrmMain main = new FrmMain())
                    if (main.ShowDialog() != DialogResult.Retry) return 0;
            }
        }

        private static int ChayNhacHan()
        {
            KetQuaXuLy kq = new NhacHanJob().Execute();
            string dong = string.Format("{0:yyyy-MM-dd HH:mm:ss}  {1}  {2}", DateTime.Now, kq.ThanhCong ? "OK " : "LOI", kq.ThongDiep);
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhachan.log"),
                               dong + Environment.NewLine, System.Text.Encoding.UTF8);
            return kq.ThanhCong ? 0 : 1;
        }
    }
}
