namespace EShopping.Gateways
{
    /// <summary>Cổng gửi email (Hệ thống Email của cửa hàng).</summary>
    public interface IEmailSender
    {
        /// <summary>Gửi email; trả về true nếu hệ thống mail đã nhận.</summary>
        bool Gui(string den, string tieuDe, string noiDung);
    }
}
