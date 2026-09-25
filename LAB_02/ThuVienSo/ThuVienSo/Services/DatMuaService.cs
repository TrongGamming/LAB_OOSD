using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    /// <summary>Yêu cầu đặt mua tài liệu điện tử: gửi, theo dõi, xét duyệt.</summary>
    public class DatMuaService
    {
        /// <summary>UC-TK-03: gửi yêu cầu (BR10 kiểm tra trong sp_GuiYeuCauDatMua).</summary>
        public KetQuaXuLy GuiYeuCau(int maTaiKhoan, string tenSach, string tacGia, int namXuatBan, string nhaXuatBan, string lyDo)
        {
            if (string.IsNullOrWhiteSpace(tenSach) || string.IsNullOrWhiteSpace(tacGia) || namXuatBan <= 0)
                return KetQuaXuLy.Loi("Tên sách, tác giả và năm xuất bản là bắt buộc.");
            try
            {
                DataTable t = Db.ExecProcLast("sp_GuiYeuCauDatMua",
                    new OracleParameter("MaTaiKhoan", maTaiKhoan),
                    new OracleParameter("TenSach", tenSach.Trim()),
                    new OracleParameter("TacGia", tacGia.Trim()),
                    new OracleParameter("NamXuatBan", namXuatBan),
                    new OracleParameter("NhaXuatBan", string.IsNullOrWhiteSpace(nhaXuatBan) ? (object)DBNull.Value : nhaXuatBan.Trim()),
                    new OracleParameter("LyDo", string.IsNullOrWhiteSpace(lyDo) ? (object)DBNull.Value : lyDo.Trim()));
                string ma = Convert.ToString(t.Rows[0]["MaYeuCau"]);
                return KetQuaXuLy.Ok("Đã gửi yêu cầu " + ma + ". Thư viện sẽ xét duyệt trong thời gian sớm nhất.", ma);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>UC-TK-04: danh sách yêu cầu của chính độc giả và kết quả xét duyệt.</summary>
        public DataTable LayYeuCauCuaToi(int maTaiKhoan, string trangThai)
        {
            return Db.Query(@"SELECT MaYeuCau, TenSach, TacGia, NamXuatBan, NgayGui, TrangThai, KetQuaGhiChu, MaTaiLieuLienKet
                              FROM YeuCauDatMua
                              WHERE MaTaiKhoan = :MaTK AND (:TT IS NULL OR TrangThai = :TT)
                              ORDER BY NgayGui DESC",
                new OracleParameter("MaTK", maTaiKhoan),
                new OracleParameter("TT", (object)trangThai ?? DBNull.Value));
        }

        /// <summary>UC-QT-02: danh sách theo trạng thái và khoảng ngày gửi, kèm số người cùng đề nghị.</summary>
        public DataTable LayDanhSach(string trangThai, DateTime tu, DateTime den)
        {
            if (tu > den)
            {
                DateTime tmp = tu;
                tu = den;
                den = tmp;
            }
            return Db.Query(@"SELECT yc.Id, yc.MaYeuCau, yc.TenSach, yc.TacGia, yc.NamXuatBan, yc.NhaXuatBan, yc.LyDoDeNghi,
                                     COALESCE(dg.HoTen, TO_NCHAR(tk.TenDangNhap)) AS NguoiGui, yc.NgayGui, yc.TrangThai, yc.KetQuaGhiChu,
                                     (SELECT COUNT(*) FROM YeuCauDatMua x
                                      WHERE UPPER(x.TenSach) = UPPER(yc.TenSach) AND UPPER(x.TacGia) = UPPER(yc.TacGia)) AS SoNguoiDeNghi
                              FROM YeuCauDatMua yc
                              JOIN TaiKhoan tk ON tk.MaTaiKhoan = yc.MaTaiKhoan
                              LEFT JOIN DocGia dg ON dg.MaDocGia = tk.MaDocGia
                              WHERE (:TT IS NULL OR yc.TrangThai = :TT)
                                AND CAST(yc.NgayGui AS DATE) >= :Tu AND CAST(yc.NgayGui AS DATE) < :Den + 1
                              ORDER BY yc.NgayGui",
                new OracleParameter("TT", (object)trangThai ?? DBNull.Value),
                new OracleParameter("Tu", OracleDbType.Date) { Value = tu.Date },
                new OracleParameter("Den", OracleDbType.Date) { Value = den.Date });
        }

        /// <summary>Luồng 5.2: tài liệu đã có trong danh mục giống tên / tác giả của yêu cầu.</summary>
        public DataTable KiemTraTrungDanhMuc(string tenSach, string tacGia)
        {
            return Db.Query(@"SELECT DISTINCT tl.MaTaiLieu, tl.TenTaiLieu
                              FROM TaiLieu tl
                              LEFT JOIN TaiLieu_TacGia x ON x.MaTaiLieu = tl.MaTaiLieu
                              LEFT JOIN TacGia tg ON tg.MaTacGia = x.MaTacGia
                              WHERE UPPER(tl.TenTaiLieu) LIKE '%' || UPPER(:Ten) || '%'
                                 OR (UPPER(tg.TenTacGia) = UPPER(:TacGia) AND UPPER(tl.TenTaiLieu) LIKE '%' || UPPER(SUBSTR(:Ten, 1, 10)) || '%')
                              ORDER BY tl.MaTaiLieu",
                new OracleParameter("Ten", tenSach ?? ""), new OracleParameter("TacGia", tacGia ?? ""));
        }

        public DataTable LayTaiLieu()
        {
            return Db.Query("SELECT MaTaiLieu, TenTaiLieu FROM TaiLieu ORDER BY TenTaiLieu");
        }

        /// <summary>UC-QT-02: chấp nhận / từ chối; sp kiểm tra xử lý đồng thời (lỗi -20062).</summary>
        public KetQuaXuLy Duyet(int yeuCauId, string maThuThu, string quyetDinh, string ghiChu, string maTaiLieuLienKet)
        {
            if (quyetDinh == "TuChoi" && string.IsNullOrWhiteSpace(ghiChu))
                return KetQuaXuLy.Loi("Phải nhập lý do khi từ chối.");   // BR11
            try
            {
                Db.ExecProc("sp_DuyetYeuCauDatMua",
                    new OracleParameter("YeuCauId", yeuCauId),
                    new OracleParameter("MaThuThu", maThuThu),
                    new OracleParameter("QuyetDinh", quyetDinh),
                    new OracleParameter("GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim()),
                    new OracleParameter("MaTaiLieuLienKet", (object)maTaiLieuLienKet ?? DBNull.Value));
                return KetQuaXuLy.Ok(quyetDinh == "ChapNhan" ? "Đã chấp nhận yêu cầu." : "Đã từ chối yêu cầu.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }
    }
}
