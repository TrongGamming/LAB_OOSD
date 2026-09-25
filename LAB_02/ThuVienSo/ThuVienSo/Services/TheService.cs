using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    /// <summary>Thông tin độc giả nhập trên FrmDocGia.</summary>
    public class DocGiaInfo
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string LoaiDocGia { get; set; }
        public string DonVi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
    }

    /// <summary>Độc giả và thẻ thư viện (UC-XT-01, FrmDocGia).</summary>
    public class TheService
    {
        /// <summary>UC-XT-01: xác thực mã thẻ; DuLieu = DataRow (MaThe, HanSuDung, MaDocGia, HoTen, LoaiDocGia, Email).</summary>
        public KetQuaXuLy XacThucMaThe(string maThe)
        {
            if (string.IsNullOrWhiteSpace(maThe)) return KetQuaXuLy.Loi("Vui lòng nhập mã thẻ.");
            try
            {
                DataTable t = Db.ExecProcLast("sp_XacThucMaThe", new OracleParameter("MaThe", maThe.Trim().ToUpperInvariant()));
                DataRow r = t.Rows[0];
                return KetQuaXuLy.Ok(string.Format("{0} – thẻ còn hạn đến {1:dd/MM/yyyy}", r["HoTen"], r["HanSuDung"]), r);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public DataTable LayDanhSachDocGia(string tuKhoa)
        {
            return Db.Query(@"
                SELECT dg.MaDocGia, dg.HoTen, dg.LoaiDocGia, dg.DonVi, dg.Email, dg.SoDienThoai, dg.NgaySinh,
                       t.MaThe, t.NgayCap, t.HanSuDung, t.TrangThai,
                       (SELECT COUNT(*) FROM PhieuMuon pm JOIN TheThuVien x ON x.MaThe = pm.MaThe
                        WHERE x.MaDocGia = dg.MaDocGia AND pm.TrangThai = 'DangMuon') AS DangMuon
                FROM DocGia dg
                LEFT JOIN (SELECT th.*, ROW_NUMBER() OVER (PARTITION BY th.MaDocGia
                               ORDER BY CASE th.TrangThai WHEN 'HoatDong' THEN 0 ELSE 1 END, th.HanSuDung DESC) AS rn
                           FROM TheThuVien th) t ON t.MaDocGia = dg.MaDocGia AND t.rn = 1
                WHERE :Tim IS NULL
                   OR UPPER(dg.MaDocGia) LIKE '%' || UPPER(:Tim) || '%'
                   OR UPPER(dg.HoTen) LIKE '%' || UPPER(:Tim) || '%'
                   OR UPPER(dg.Email) LIKE '%' || UPPER(:Tim) || '%'
                   OR UPPER(t.MaThe) LIKE '%' || UPPER(:Tim) || '%'
                ORDER BY dg.MaDocGia",
                new OracleParameter("Tim", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()));
        }

        public string MaDocGiaMoi()
        {
            object o = Db.Scalar("SELECT NVL(MAX(TO_NUMBER(SUBSTR(MaDocGia, 3))), 0) + 1 FROM DocGia WHERE REGEXP_LIKE(MaDocGia, '^DG[0-9]+$')");
            return "DG" + Convert.ToInt32(o).ToString("0000");
        }

        public KetQuaXuLy LuuDocGia(bool themMoi, DocGiaInfo dg)
        {
            if (string.IsNullOrWhiteSpace(dg.MaDocGia) || string.IsNullOrWhiteSpace(dg.HoTen) || string.IsNullOrWhiteSpace(dg.Email))
                return KetQuaXuLy.Loi("Vui lòng nhập mã, họ tên và email.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(dg.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return KetQuaXuLy.Loi("Email không đúng định dạng.");
            OracleParameter[] ps =
            {
                new OracleParameter("Ma", dg.MaDocGia.Trim()),
                new OracleParameter("HoTen", dg.HoTen.Trim()),
                new OracleParameter("Loai", dg.LoaiDocGia),
                new OracleParameter("DonVi", string.IsNullOrWhiteSpace(dg.DonVi) ? (object)DBNull.Value : dg.DonVi.Trim()),
                new OracleParameter("NgaySinh", OracleDbType.Date) { Value = dg.NgaySinh.HasValue ? (object)dg.NgaySinh.Value.Date : DBNull.Value },
                new OracleParameter("Email", dg.Email.Trim()),
                new OracleParameter("SDT", string.IsNullOrWhiteSpace(dg.SoDienThoai) ? (object)DBNull.Value : dg.SoDienThoai.Trim())
            };
            try
            {
                int n = themMoi
                    ? Db.Execute(@"INSERT INTO DocGia(MaDocGia, HoTen, LoaiDocGia, DonVi, NgaySinh, Email, SoDienThoai)
                                   VALUES (:Ma, :HoTen, :Loai, :DonVi, :NgaySinh, :Email, :SDT)", ps)
                    : Db.Execute(@"UPDATE DocGia SET HoTen = :HoTen, LoaiDocGia = :Loai, DonVi = :DonVi, NgaySinh = :NgaySinh,
                                          Email = :Email, SoDienThoai = :SDT
                                   WHERE MaDocGia = :Ma", ps);
                return n > 0 ? KetQuaXuLy.Ok(themMoi ? "Đã thêm độc giả." : "Đã cập nhật độc giả.")
                             : KetQuaXuLy.Loi("Không tìm thấy độc giả.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy XoaDocGia(string maDocGia)
        {
            try
            {
                Db.Execute("DELETE FROM DocGia WHERE MaDocGia = :Ma", new OracleParameter("Ma", maDocGia));
                return KetQuaXuLy.Ok("Đã xóa độc giả.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // còn thẻ/tài khoản -> ORA-02292
            }
        }

        /// <summary>Cấp thẻ mới: BR02 – không cấp khi độc giả còn thẻ Hoạt động.</summary>
        public KetQuaXuLy CapThe(string maDocGia, DateTime ngayCap, DateTime hanSuDung)
        {
            if (hanSuDung.Date <= ngayCap.Date) return KetQuaXuLy.Loi("Hạn sử dụng phải sau ngày cấp.");
            try
            {
                object dangCo = Db.Scalar("SELECT COUNT(*) FROM TheThuVien WHERE MaDocGia = :Ma AND TrangThai = 'HoatDong'",
                                          new OracleParameter("Ma", maDocGia));
                if (Convert.ToInt32(dangCo) > 0)
                    return KetQuaXuLy.Loi("Độc giả đang có thẻ hoạt động. Hãy gia hạn thay vì cấp thẻ mới.");
                string tienTo = "TV" + ngayCap.Year;
                object so = Db.Scalar("SELECT NVL(MAX(TO_NUMBER(SUBSTR(MaThe, 7))), 0) + 1 FROM TheThuVien WHERE MaThe LIKE :P || '%'",
                                      new OracleParameter("P", tienTo));
                string maThe = tienTo + Convert.ToInt32(so).ToString("000000");
                Db.Execute(@"INSERT INTO TheThuVien(MaThe, MaDocGia, NgayCap, HanSuDung, TrangThai)
                             VALUES (:MaThe, :MaDG, :NgayCap, :Han, 'HoatDong')",
                           new OracleParameter("MaThe", maThe), new OracleParameter("MaDG", maDocGia),
                           new OracleParameter("NgayCap", OracleDbType.Date) { Value = ngayCap.Date },
                           new OracleParameter("Han", OracleDbType.Date) { Value = hanSuDung.Date });
                return KetQuaXuLy.Ok("Đã cấp thẻ " + maThe + ".", maThe);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy GiaHan(string maThe, DateTime hanMoi)
        {
            try
            {
                int n = Db.Execute(@"UPDATE TheThuVien SET HanSuDung = :Han, TrangThai = 'HoatDong'
                                     WHERE MaThe = :MaThe AND TrangThai IN ('HoatDong','HetHan') AND :Han > NgayCap",
                                   new OracleParameter("Han", OracleDbType.Date) { Value = hanMoi.Date },
                                   new OracleParameter("MaThe", maThe));
                return n > 0 ? KetQuaXuLy.Ok("Đã gia hạn thẻ đến " + hanMoi.ToString("dd/MM/yyyy") + ".")
                             : KetQuaXuLy.Loi("Không gia hạn được: thẻ bị khóa/mất hoặc hạn mới không hợp lệ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // độc giả đã có thẻ hoạt động khác -> ORA-00001
            }
        }

        /// <summary>Đổi trạng thái thẻ: Khoa (khóa), HoatDong (mở khóa), Mat (báo mất).</summary>
        public KetQuaXuLy DoiTrangThai(string maThe, string trangThai)
        {
            try
            {
                int n = Db.Execute("UPDATE TheThuVien SET TrangThai = :TT WHERE MaThe = :MaThe",
                                   new OracleParameter("TT", trangThai), new OracleParameter("MaThe", maThe));
                return n > 0 ? KetQuaXuLy.Ok("Đã cập nhật trạng thái thẻ.") : KetQuaXuLy.Loi("Không tìm thấy thẻ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }
    }
}
