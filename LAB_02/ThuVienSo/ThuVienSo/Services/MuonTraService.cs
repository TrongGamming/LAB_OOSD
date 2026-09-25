using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    public class MuonTraService
    {
        /// <summary>UC-MT-01: đăng ký mượn (giữ chỗ một bản sao).</summary>
        public KetQuaXuLy DangKyMuon(string maThe, string maTaiLieu)
        {
            try
            {
                DataTable t = Db.ExecProcLast("sp_DangKyMuon",
                    new OracleParameter("MaThe", maThe), new OracleParameter("MaTaiLieu", maTaiLieu));
                DataRow r = t.Rows[0];
                return KetQuaXuLy.Ok(string.Format("Đăng ký thành công, mã {0}. Bản sao {1} được giữ đến hết ngày {2:dd/MM/yyyy}.",
                                                   r["MaDangKy"], r["MaBanSaoGiu"], r["HanNhan"]), r);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Thông tin mượn của một thẻ: số đang mượn, quá hạn, danh sách đăng ký chờ nhận.</summary>
        public DataTable LayDangKyChoNhan(string maThe)
        {
            return Db.Query(@"SELECT dk.Id, dk.MaDangKy, dk.MaBanSaoGiu, tl.TenTaiLieu, dk.HanNhan
                              FROM DangKyMuon dk JOIN TaiLieu tl ON tl.MaTaiLieu = dk.MaTaiLieu
                              WHERE dk.MaThe = :The AND dk.TrangThai = 'ChoNhan'
                              ORDER BY dk.NgayDangKy", new OracleParameter("The", maThe));
        }

        public string TomTatHanMuc(string maThe)
        {
            DataTable t = Db.Query(@"SELECT
                    (SELECT COUNT(*) FROM PhieuMuon WHERE MaThe = :The AND TrangThai = 'DangMuon') AS DangMuon,
                    (SELECT COUNT(*) FROM PhieuMuon WHERE MaThe = :The AND TrangThai = 'DangMuon'
                        AND HanTra < TRUNC(SYSDATE)) AS QuaHan,
                    (SELECT COUNT(*) FROM DangKyMuon WHERE MaThe = :The AND TrangThai = 'ChoNhan') AS DangGiu
                    FROM DUAL",
                new OracleParameter("The", maThe));
            DataRow r = t.Rows[0];
            return string.Format("Đang mượn: {0}/5    Quá hạn: {1}    Đang giữ chỗ: {2}", r["DangMuon"], r["QuaHan"], r["DangGiu"]);
        }

        /// <summary>Tra bản sao: trả về tên tài liệu nếu tồn tại.</summary>
        public DataRow LayBanSao(string maBanSao)
        {
            DataTable t = Db.Query(@"SELECT bs.MaBanSao, bs.MaTaiLieu, tl.TenTaiLieu, bs.TinhTrang
                                     FROM BanSao bs JOIN TaiLieu tl ON tl.MaTaiLieu = bs.MaTaiLieu
                                     WHERE bs.MaBanSao = :Ma", new OracleParameter("Ma", maBanSao));
            return t.Rows.Count > 0 ? t.Rows[0] : null;
        }

        /// <summary>UC-MT-02: lập phiếu mượn cho một bản sao.</summary>
        public KetQuaXuLy LapPhieuMuon(string maThe, string maBanSao, string maThuThu, int? dangKyId)
        {
            try
            {
                DataTable t = Db.ExecProcLast("sp_LapPhieuMuon",
                    new OracleParameter("MaThe", maThe), new OracleParameter("MaBanSao", maBanSao),
                    new OracleParameter("MaThuThu", maThuThu),
                    new OracleParameter("DangKyId", (object)dangKyId ?? DBNull.Value));
                DataRow r = t.Rows[0];
                return KetQuaXuLy.Ok(string.Format("{0} – hạn trả {1:dd/MM/yyyy}", r["MaPhieuMuon"], r["HanTra"]), r);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Phiếu đang mở theo mã bản sao hoặc mã thẻ (UC-MT-03 bước 4 / luồng 3.1).</summary>
        public DataTable TimPhieuDangMo(string maBanSao, string maThe)
        {
            return Db.Query(@"SELECT pm.MaPhieuMuon, bs.MaBanSao, tl.TenTaiLieu, dg.HoTen AS DocGia,
                                     pm.NgayMuon, pm.HanTra,
                                     CASE WHEN pm.HanTra < TRUNC(SYSDATE)
                                          THEN (TRUNC(SYSDATE) - pm.HanTra) ELSE 0 END AS SoNgayTre
                              FROM PhieuMuon pm
                              JOIN BanSao bs ON bs.MaBanSao = pm.MaBanSao
                              JOIN TaiLieu tl ON tl.MaTaiLieu = bs.MaTaiLieu
                              JOIN TheThuVien t ON t.MaThe = pm.MaThe
                              JOIN DocGia dg ON dg.MaDocGia = t.MaDocGia
                              WHERE pm.TrangThai = 'DangMuon'
                                AND ((:BS IS NOT NULL AND pm.MaBanSao = :BS) OR (:The IS NOT NULL AND pm.MaThe = :The))
                              ORDER BY pm.HanTra",
                new OracleParameter("BS", (object)maBanSao ?? DBNull.Value),
                new OracleParameter("The", (object)maThe ?? DBNull.Value));
        }

        /// <summary>UC-MT-03: ghi nhận trả sách. tinhTrang: NguyenVen | HuHong | Mat.</summary>
        public KetQuaXuLy GhiNhanTra(string maBanSao, string maThuThu, string tinhTrang, string ghiChu)
        {
            try
            {
                DataTable t = Db.ExecProcLast("sp_GhiNhanTraSach",
                    new OracleParameter("MaBanSao", maBanSao), new OracleParameter("MaThuThu", maThuThu),
                    new OracleParameter("TinhTrang", tinhTrang),
                    new OracleParameter("GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim()));
                DataRow r = t.Rows[0];
                int tre = Convert.ToInt32(r["SoNgayTre"]);
                return KetQuaXuLy.Ok(string.Format("Đã ghi nhận trả phiếu {0}{1}. Độc giả còn giữ {2} cuốn.",
                    r["MaPhieuMuon"], tre > 0 ? " (trễ " + tre + " ngày)" : "", r["ConDangGiu"]));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Tab "Đăng ký chờ nhận": toàn bộ đăng ký đang giữ chỗ, đánh dấu cái sắp/đã quá hạn nhận.</summary>
        public DataTable LayTatCaDangKyChoNhan()
        {
            return Db.Query(@"SELECT dk.Id, dk.MaDangKy, dk.MaThe, dg.HoTen AS DocGia, tl.TenTaiLieu, dk.MaBanSaoGiu,
                                     dk.NgayDangKy, dk.HanNhan,
                                     CASE WHEN dk.HanNhan < TRUNC(SYSDATE) THEN 1 ELSE 0 END AS QuaHan
                              FROM DangKyMuon dk
                              JOIN TaiLieu tl ON tl.MaTaiLieu = dk.MaTaiLieu
                              JOIN TheThuVien t ON t.MaThe = dk.MaThe
                              JOIN DocGia dg ON dg.MaDocGia = t.MaDocGia
                              WHERE dk.TrangThai = 'ChoNhan'
                              ORDER BY dk.HanNhan, dk.NgayDangKy");
        }

        /// <summary>Hủy một đăng ký chờ nhận, trả bản sao đang giữ về Sẵn sàng.</summary>
        public KetQuaXuLy HuyDangKy(int dangKyId)
        {
            try
            {
                int n = 0;
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, @"UPDATE BanSao SET TinhTrang = 'SanSang'
                                         WHERE TinhTrang = 'DangGiu'
                                           AND MaBanSao = (SELECT MaBanSaoGiu FROM DangKyMuon WHERE Id = :Id AND TrangThai = 'ChoNhan')",
                               new OracleParameter("Id", dangKyId));
                    n = Db.Execute(cn, tx, "UPDATE DangKyMuon SET TrangThai = 'DaHuy' WHERE Id = :Id AND TrangThai = 'ChoNhan'",
                                   new OracleParameter("Id", dangKyId));
                });
                return n > 0 ? KetQuaXuLy.Ok("Đã hủy đăng ký.") : KetQuaXuLy.Loi("Đăng ký không còn ở trạng thái chờ nhận.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Công việc nền: hủy các đăng ký quá hạn nhận (BR05). Trả về số đăng ký đã hủy.</summary>
        public int HuyDangKyHetHan()
        {
            DataTable t = Db.ExecProcLast("sp_HuyDangKyHetHan");
            return t.Rows.Count > 0 ? Convert.ToInt32(t.Rows[0][0]) : 0;
        }

        /// <summary>UC-MT-04: tài liệu đang do ai mượn, hạn trả, có quá hạn không.</summary>
        public DataTable TinhTrangMuon(string tuKhoa, bool chiQuaHan)
        {
            return Db.Query(@"SELECT MaTaiLieu, TenTaiLieu, MaBanSao, MaPhieuMuon, DocGia, NgayMuon, HanTra, QuaHan, SoNgayTre
                              FROM vw_TinhTrangMuon
                              WHERE (:Tim IS NULL OR UPPER(MaTaiLieu) LIKE '%' || UPPER(:Tim) || '%'
                                                  OR UPPER(TenTaiLieu) LIKE '%' || UPPER(:Tim) || '%'
                                                  OR UPPER(MaBanSao) LIKE '%' || UPPER(:Tim) || '%'
                                                  OR UPPER(DocGia) LIKE '%' || UPPER(:Tim) || '%')
                                AND (:ChiQuaHan = 0 OR QuaHan = 1)
                              ORDER BY QuaHan DESC, HanTra",
                new OracleParameter("Tim", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()),
                new OracleParameter("ChiQuaHan", chiQuaHan ? 1 : 0));
        }
    }
}
