using System;

namespace QuanLyNhanSu
{
    internal sealed class PayrollResult
    {
        public decimal LuongCong, TienPT, BHXH, BHYT, ThucLinh;
    }
    internal static class Payroll
    {
        // Quy uoc bai lab: luong theo gio, ca 8h; BH tinh tren luong co ban.
        internal static PayrollResult Calculate(decimal salary, decimal allowance, decimal hours,
            decimal overtime, int standardDays, decimal rateXH, decimal rateYT, decimal bonus, decimal fine)
        {
            if (salary <= 0 || allowance < 0 || hours < 0 || overtime < 0 || standardDays < 1 || standardDays > 31 ||
                hours > standardDays * 8 || rateXH < 0 || rateYT < 0 || rateXH + rateYT >= 1 || bonus < 0 || fine < 0)
                throw new ArgumentException("Dữ liệu tính lương không hợp lệ; công thực tế không vượt công chuẩn.");
            var r = new PayrollResult();
            r.LuongCong = Round((salary + allowance) * hours / (standardDays * 8));
            r.TienPT = Round(salary / (standardDays * 8) * overtime * 1.5m);
            r.BHXH = Round(salary * rateXH); r.BHYT = Round(salary * rateYT);
            r.ThucLinh = r.LuongCong + r.TienPT + bonus - fine - r.BHXH - r.BHYT;
            return r;
        }
        internal static decimal Round(decimal value) { return Math.Round(value, 0, MidpointRounding.AwayFromZero); }
    }
}
