using System.Data;

namespace EShopping.Gateways
{
    /// <summary>
    /// Cổng kết nối tới Hệ thống quản lý sản phẩm có sẵn của cửa hàng (hệ thống ngoài).
    /// e-SHOPPING chỉ đọc thông tin sản phẩm qua giao diện này, không tự sửa sản phẩm.
    /// </summary>
    public interface IHeThongQuanLySanPham
    {
        DataTable LayNhom();
        DataTable LayDanhSach(string maNhom, string tuKhoa);
        DataRow LaySanPham(string maSP);
        DataTable LayHinhAnh(string maSP);
        DataTable LayThongSo(string maSP);
    }
}
