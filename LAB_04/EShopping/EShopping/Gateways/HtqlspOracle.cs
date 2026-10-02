using System;
using System.Data;
using EShopping.Data;
using Oracle.ManagedDataAccess.Client;

namespace EShopping.Gateways
{
    /// <summary>
    /// Cài đặt cổng HTQLSP trong bài lab: đọc các bảng sản phẩm (bản sao do HTQLSP đồng bộ sang) trong schema ESHOP.
    /// Khi tích hợp thật chỉ cần thay lớp này bằng lớp gọi API của HTQLSP.
    /// </summary>
    public class HtqlspOracle : IHeThongQuanLySanPham
    {
        public DataTable LayNhom()
        {
            return Db.Query(@"SELECT n.MaNhom, n.TenNhom, COUNT(s.MaSP) AS SoSanPham
                              FROM NhomSanPham n LEFT JOIN SanPham s ON s.MaNhom = n.MaNhom
                              GROUP BY n.MaNhom, n.TenNhom ORDER BY n.TenNhom");
        }

        public DataTable LayDanhSach(string maNhom, string tuKhoa)
        {
            string tk = string.IsNullOrWhiteSpace(tuKhoa) ? null : "%" + tuKhoa.Trim().ToUpper() + "%";
            return Db.Query(@"SELECT MaSP, TenSP, MaNhom, TenNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang
                              FROM V_SanPham
                              WHERE (:nhom IS NULL OR MaNhom = :nhom)
                                AND (:tk IS NULL OR UPPER(TenSP) LIKE :tk OR UPPER(NhaSanXuat) LIKE :tk)
                              ORDER BY TinhTrang, TenSP",
                            new OracleParameter("nhom", (object)maNhom ?? DBNull.Value),
                            new OracleParameter("tk", (object)tk ?? DBNull.Value));
        }

        public DataRow LaySanPham(string maSP)
        {
            DataTable t = Db.Query(@"SELECT MaSP, TenSP, MaNhom, TenNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang
                                     FROM V_SanPham WHERE MaSP = :ma", new OracleParameter("ma", maSP ?? ""));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }

        public DataTable LayHinhAnh(string maSP)
        {
            return Db.Query("SELECT MaHinh, DuongDan, ThuTu FROM HinhAnhSanPham WHERE MaSP = :ma ORDER BY ThuTu",
                            new OracleParameter("ma", maSP ?? ""));
        }

        public DataTable LayThongSo(string maSP)
        {
            return Db.Query("SELECT TenThongSo, GiaTri FROM ThongSoKyThuat WHERE MaSP = :ma ORDER BY TenThongSo",
                            new OracleParameter("ma", maSP ?? ""));
        }
    }
}
