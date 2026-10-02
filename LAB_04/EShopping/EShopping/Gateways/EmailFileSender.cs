using System;
using System.IO;
using System.Text;

namespace EShopping.Gateways
{
    /// <summary>
    /// Khi chưa cấu hình SMTP thật, email được ghi thành file .eml trong thư mục MailPickup cạnh file chạy
    /// (mở được bằng Outlook / Thunderbird) – tương tự chế độ SpecifiedPickupDirectory của SmtpClient.
    /// </summary>
    public class EmailFileSender : IEmailSender
    {
        public static string ThuMuc
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MailPickup"); }
        }

        public string FileCuoi { get; private set; }

        public bool Gui(string den, string tieuDe, string noiDung)
        {
            Directory.CreateDirectory(ThuMuc);
            string ten = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + Guid.NewGuid().ToString("N").Substring(0, 6) + ".eml";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("From: e-SHOPPING <no-reply@eshopping.abc.vn>");
            sb.AppendLine("To: " + den);
            sb.AppendLine("Subject: =?utf-8?B?" + Convert.ToBase64String(Encoding.UTF8.GetBytes(tieuDe)) + "?=");
            sb.AppendLine("Date: " + DateTime.Now.ToString("R"));
            sb.AppendLine("MIME-Version: 1.0");
            sb.AppendLine("Content-Type: text/plain; charset=utf-8");
            sb.AppendLine("Content-Transfer-Encoding: 8bit");
            sb.AppendLine();
            sb.AppendLine(noiDung);
            FileCuoi = Path.Combine(ThuMuc, ten);
            File.WriteAllText(FileCuoi, sb.ToString(), new UTF8Encoding(false));
            return true;
        }
    }
}
