using System;
using System.Windows.Forms;
namespace QuanLyNhanSu
{
    internal static class Program
    {
        [STAThread] static int Main(string[] args)
        {
            Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length>=2&&args[0]=="/kiemthu") return KiemThu.Run(args[1],true);
            if(args.Length>=2&&args[0]=="/kiemthu-congthuc") return KiemThu.Run(args[1],false);
            if(args.Length>=2&&args[0]=="/chupanh") { MainForm.CaptureScreens(args[1]); return 0; }
            Application.Run(new MainForm()); return 0;
        }
    }
}
