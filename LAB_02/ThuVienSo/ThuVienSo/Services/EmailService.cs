using System;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace ThuVienSo.Services
{
    /// <summary>
    /// Gửi thư qua Dịch vụ email của trường. Cấu hình SMTP đặt trong App.config (system.net/mailSettings):
    /// chế độ Network cho máy chủ thật, hoặc SpecifiedPickupDirectory để lưu thư thành file .eml khi chạy thử.
    /// </summary>
    public class EmailService
    {
        /// <summary>Trả về null nếu gửi thành công, ngược lại là thông điệp lỗi.</summary>
        public string Gui(string den, string tieuDe, string noiDung)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                using (MailMessage mail = new MailMessage())
                {
                    if (smtp.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
                    {
                        if (string.IsNullOrEmpty(smtp.PickupDirectoryLocation))
                            smtp.PickupDirectoryLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MailPickup");
                        Directory.CreateDirectory(smtp.PickupDirectoryLocation);
                    }

                    if (mail.From == null) mail.From = new MailAddress("thuvien@hutech.edu.vn", "Thư viện số");
                    mail.To.Add(den);
                    mail.Subject = tieuDe;
                    mail.Body = noiDung;
                    mail.SubjectEncoding = mail.BodyEncoding = Encoding.UTF8;
                    smtp.Send(mail);
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.Message + " – " + ex.InnerException.Message : ex.Message;
            }
        }
    }
}
