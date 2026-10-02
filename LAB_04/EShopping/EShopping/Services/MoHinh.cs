using System;

namespace EShopping.Services
{
    /// <summary>Thông tin khách hàng nhập trên form đăng ký.</summary>
    public class KhachHangDto
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoGiayTo { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
    }

    /// <summary>Quy cách của một loại thẻ (độ dài số thẻ, CSV và lệ phí giao dịch).</summary>
    public class LoaiTheDto
    {
        public string MaLoaiThe { get; set; }
        public string TenLoaiThe { get; set; }
        public int DoDaiSoThe { get; set; }
        public int DoDaiCSV { get; set; }
        public decimal LePhiGiaoDich { get; set; }
    }

    /// <summary>Bảng tính tiền hiển thị trên form đặt hàng trước khi khách xác nhận.</summary>
    public class BangTinhTien
    {
        public decimal TongTienHang { get; set; }
        public decimal PhiGiaoGoc { get; set; }
        public decimal PhiGiaoHang { get; set; }
        public decimal LePhiThe { get; set; }
        public decimal? NguongMienPhi { get; set; }
        public int SoGioXuLy { get; set; }
        public int SoMatHang { get; set; }
        public int SoMatHangHetHang { get; set; }
        public bool DuocMienPhi { get { return PhiGiaoGoc > 0 && PhiGiaoHang == 0; } }
        public decimal TongTriGia { get { return TongTienHang + PhiGiaoHang + LePhiThe; } }
    }

    /// <summary>Toàn bộ dữ liệu khách nhập để đặt một đơn hàng.</summary>
    public class YeuCauDatHang
    {
        public string MaKH { get; set; }
        public long MaGioHang { get; set; }
        public string MaLoaiPhieu { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string MaTinh { get; set; }
        public string MaLoaiThe { get; set; }
        public string SoThe { get; set; }
        public string Csv { get; set; }
        public int ThangHetHan { get; set; }
        public int NamHetHan { get; set; }
        public string TenChuThe { get; set; }
    }
}
