using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    /// <summary>
    /// UC-TĐ-01: Bộ lập lịch gọi Execute() mỗi ngày (Windows Task Scheduler chạy "ThuVienSo.exe /nhachan").
    /// </summary>
    public class NhacHanJob
    {
        private const int SoNgayTruocHan = 3;   // BR12
        private readonly EmailService _email = new EmailService();

        public KetQuaXuLy Execute()
        {
            try
            {
                int huy = new MuonTraService().HuyDangKyHetHan();                       // BR05
                DataTable ds = Db.ExecProcLast("sp_QuetNhacHanTra", new OracleParameter("SoNgayTruoc", SoNgayTruocHan));
                int thanhCong = 0, loi = 0;
                foreach (DataRow r in ds.Rows)
                {
                    if (GuiMot(r, r["NhatKyId"])) thanhCong++;
                    else loi++;
                }
                return KetQuaXuLy.Ok(string.Format("Đã hủy {0} đăng ký quá hạn nhận; gửi {1} email thành công, {2} lỗi.",
                                                   huy, thanhCong, loi));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Thủ thư gửi lại các email lỗi đã chọn (chỉ khi còn lượt thử, BR13).</summary>
        public KetQuaXuLy GuiLaiLoi(IEnumerable<int> emailIds)
        {
            int thanhCong = 0, loi = 0, boQua = 0;
            try
            {
                foreach (int id in emailIds)
                {
                    DataTable t = Db.Query(@"SELECT Id, DiaChiNhan, TieuDe, NoiDung FROM EmailNhacHan
                                             WHERE Id = :Id AND TrangThai = 'Loi' AND SoLanThu < 3",
                                           new OracleParameter("Id", id));
                    if (t.Rows.Count == 0)
                    {
                        boQua++;
                        continue;
                    }
                    if (GuiMot(t.Rows[0], DBNull.Value)) thanhCong++;
                    else loi++;
                }
                return KetQuaXuLy.Ok(string.Format("Gửi lại: {0} thành công, {1} lỗi, {2} bỏ qua (không ở trạng thái Lỗi hoặc đã hết 3 lượt).",
                                                   thanhCong, loi, boQua));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        private bool GuiMot(DataRow r, object nhatKyId)
        {
            string loi = _email.Gui(Convert.ToString(r["DiaChiNhan"]), Convert.ToString(r["TieuDe"]), Convert.ToString(r["NoiDung"]));
            Db.ExecProc("sp_CapNhatKetQuaEmail",
                new OracleParameter("EmailId", Convert.ToInt32(r["Id"])),
                new OracleParameter("ThanhCong", loi == null ? 1 : 0),
                new OracleParameter("Loi", loi == null ? (object)DBNull.Value : (loi.Length > 500 ? loi.Substring(0, 500) : loi)),
                new OracleParameter("NhatKyId", nhatKyId == null || nhatKyId == DBNull.Value ? DBNull.Value : (object)Convert.ToInt32(nhatKyId)));
            return loi == null;
        }

        // ------------------------- dữ liệu cho FrmNhatKyEmail -------------------------

        public DataTable LayEmail(DateTime? ngay, string trangThai)
        {
            return Db.Query(@"SELECT e.Id, e.MaEmail, pm.MaPhieuMuon, dg.HoTen AS DocGia, e.DiaChiNhan, pm.HanTra,
                                     e.ThoiDiemTao, e.ThoiDiemGui, e.TrangThai, e.SoLanThu, e.LoiGanNhat
                              FROM EmailNhacHan e
                              JOIN PhieuMuon pm ON pm.Id = e.PhieuMuonId
                              JOIN TheThuVien t ON t.MaThe = pm.MaThe
                              JOIN DocGia dg ON dg.MaDocGia = t.MaDocGia
                              WHERE (:Ngay IS NULL OR TRUNC(CAST(e.ThoiDiemTao AS DATE)) = :Ngay)
                                AND (:TT IS NULL OR e.TrangThai = :TT)
                              ORDER BY e.ThoiDiemTao DESC",
                new OracleParameter("Ngay", OracleDbType.Date) { Value = ngay.HasValue ? (object)ngay.Value.Date : DBNull.Value },
                new OracleParameter("TT", (object)trangThai ?? DBNull.Value));
        }

        public string LanChayGanNhat()
        {
            DataTable t = Db.Query(@"SELECT BatDau, SoBanGhiQuet, SoThanhCong, SoLoi FROM NhatKyLapLich
                                     ORDER BY BatDau DESC FETCH FIRST 1 ROWS ONLY");
            if (t.Rows.Count == 0) return "Bộ lập lịch chưa chạy lần nào.";
            DataRow r = t.Rows[0];
            return string.Format("Lần chạy gần nhất: {0:dd/MM/yyyy HH:mm} – quét {1}, gửi được {2}, lỗi {3}",
                                 r["BatDau"], r["SoBanGhiQuet"], r["SoThanhCong"], r["SoLoi"]);
        }
    }
}
