using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    public class TieuChiTimKiem
    {
        public string TuKhoa { get; set; }
        public string TacGia { get; set; }
        public int NamXuatBan { get; set; }      // 0 = bỏ qua
        public string LoaiTaiLieu { get; set; }  // null = tất cả
        public string MaChuDe { get; set; }      // null = tất cả
        public string HinhThuc { get; set; }     // null / BanIn / DienTu

        public bool Rong
        {
            get
            {
                return string.IsNullOrWhiteSpace(TuKhoa) && string.IsNullOrWhiteSpace(TacGia) && NamXuatBan == 0
                       && LoaiTaiLieu == null && MaChuDe == null && HinhThuc == null;
            }
        }
    }

    /// <summary>Dữ liệu một tài liệu nhập trên FrmTaiLieu.</summary>
    public class TaiLieuInfo
    {
        public string MaTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public string LoaiTaiLieu { get; set; }
        public string HinhThuc { get; set; }
        public string MaChuDe { get; set; }
        public string MaNXB { get; set; }
        public int NamXuatBan { get; set; }
        public string MoTa { get; set; }
        public List<string> MaTacGia { get; set; }
        // phần điện tử (khi HinhThuc = DienTu / CaHai)
        public string DuongDanTep { get; set; }
        public string DinhDang { get; set; }
        public decimal DungLuongMB { get; set; }
        public bool ChoPhepTai { get; set; }

        public bool CoDienTu
        {
            get { return HinhThuc == "DienTu" || HinhThuc == "CaHai"; }
        }
    }

    public class TaiLieuService
    {
        public DataTable LayChuDe()
        {
            return Db.Query("SELECT MaChuDe, TenChuDe FROM ChuDe ORDER BY TenChuDe");
        }

        /// <summary>UC-TC-01: tìm kiếm theo nhiều tiêu chí (tham số hóa, không nối chuỗi giá trị).</summary>
        public DataTable TimKiem(TieuChiTimKiem tc)
        {
            StringBuilder sql = new StringBuilder(@"
                SELECT tl.MaTaiLieu, tl.TenTaiLieu,
                       (SELECT LISTAGG(tg.TenTacGia, ', ') WITHIN GROUP (ORDER BY x.ThuTu)
                        FROM TaiLieu_TacGia x JOIN TacGia tg ON tg.MaTacGia = x.MaTacGia
                        WHERE x.MaTaiLieu = tl.MaTaiLieu) AS TacGia,
                       tl.NamXuatBan, tl.LoaiTaiLieu, tl.HinhThuc,
                       CASE WHEN tl.HinhThuc = 'DienTu' THEN NULL ELSE tk.SoLuongTon END AS SoLuongTon
                FROM TaiLieu tl
                JOIN vw_TonKho tk ON tk.MaTaiLieu = tl.MaTaiLieu
                WHERE 1 = 1");
            OracleCommandBuilderHelper p = new OracleCommandBuilderHelper();
            if (!string.IsNullOrWhiteSpace(tc.TuKhoa))
                sql.Append(" AND UPPER(tl.TenTaiLieu) LIKE UPPER(").Append(p.Add("%" + tc.TuKhoa.Trim() + "%")).Append(")");
            if (!string.IsNullOrWhiteSpace(tc.TacGia))
                sql.Append(@" AND EXISTS (SELECT 1 FROM TaiLieu_TacGia x JOIN TacGia tg ON tg.MaTacGia = x.MaTacGia
                                         WHERE x.MaTaiLieu = tl.MaTaiLieu AND UPPER(tg.TenTacGia) LIKE UPPER(")
                   .Append(p.Add("%" + tc.TacGia.Trim() + "%")).Append("))");
            if (tc.NamXuatBan > 0) sql.Append(" AND tl.NamXuatBan = ").Append(p.Add(tc.NamXuatBan));
            if (tc.LoaiTaiLieu != null) sql.Append(" AND tl.LoaiTaiLieu = ").Append(p.Add(tc.LoaiTaiLieu));
            if (tc.MaChuDe != null) sql.Append(" AND tl.MaChuDe = ").Append(p.Add(tc.MaChuDe));
            if (tc.HinhThuc == "BanIn") sql.Append(" AND tl.HinhThuc IN ('BanIn','CaHai')");
            if (tc.HinhThuc == "DienTu") sql.Append(" AND tl.HinhThuc IN ('DienTu','CaHai')");
            sql.Append(" ORDER BY tl.TenTaiLieu");
            return Db.Query(sql.ToString(), p.ToArray());
        }

        /// <summary>UC-TC-02: chi tiết một tài liệu.</summary>
        public DataRow LayChiTiet(string maTaiLieu)
        {
            DataTable t = Db.Query(@"
                SELECT tl.*, cd.TenChuDe, nxb.TenNXB, tk.SoLuongTon, tk.TongBanSao,
                       tep.DinhDang, tep.DungLuongMB, tep.ChoPhepTai, tep.DuongDanTep,
                       (SELECT LISTAGG(tg.TenTacGia, ', ') WITHIN GROUP (ORDER BY x.ThuTu)
                        FROM TaiLieu_TacGia x JOIN TacGia tg ON tg.MaTacGia = x.MaTacGia
                        WHERE x.MaTaiLieu = tl.MaTaiLieu) AS TacGia
                FROM TaiLieu tl
                JOIN ChuDe cd ON cd.MaChuDe = tl.MaChuDe
                LEFT JOIN NhaXuatBan nxb ON nxb.MaNXB = tl.MaNXB
                LEFT JOIN TepDienTu tep ON tep.MaTaiLieu = tl.MaTaiLieu
                JOIN vw_TonKho tk ON tk.MaTaiLieu = tl.MaTaiLieu
                WHERE tl.MaTaiLieu = :Ma", new OracleParameter("Ma", maTaiLieu));
            return t.Rows.Count > 0 ? t.Rows[0] : null;
        }

        /// <summary>UC-TC-04: ghi lượt tải, trả về đường dẫn tệp trong DuLieu.</summary>
        public KetQuaXuLy TaiVe(string maThe, string maTaiLieu)
        {
            try
            {
                DataTable t = Db.ExecProcLast("sp_GhiLuotTai",
                    new OracleParameter("MaThe", maThe), new OracleParameter("MaTaiLieu", maTaiLieu),
                    new OracleParameter("DiaChiIP", Environment.MachineName));
                return KetQuaXuLy.Ok("Đã ghi nhận lượt tải.", Convert.ToString(t.Rows[0]["DuongDanTep"]));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        // ======================= UC-QT-01: cập nhật danh mục tài liệu =======================

        public DataTable LayTacGia()
        {
            return Db.Query("SELECT MaTacGia, TenTacGia FROM TacGia ORDER BY TenTacGia");
        }

        public DataTable LayNXB()
        {
            return Db.Query("SELECT MaNXB, TenNXB FROM NhaXuatBan ORDER BY TenNXB");
        }

        public DataTable LayDanhSach(string tuKhoa)
        {
            return Db.Query(@"
                SELECT tl.MaTaiLieu, tl.TenTaiLieu, cd.TenChuDe, nxb.TenNXB, tl.NamXuatBan, tl.HinhThuc,
                       tk.SoLuongTon, tk.TongBanSao
                FROM TaiLieu tl
                JOIN ChuDe cd ON cd.MaChuDe = tl.MaChuDe
                LEFT JOIN NhaXuatBan nxb ON nxb.MaNXB = tl.MaNXB
                JOIN vw_TonKho tk ON tk.MaTaiLieu = tl.MaTaiLieu
                WHERE :Tim IS NULL OR UPPER(tl.MaTaiLieu) LIKE '%' || UPPER(:Tim) || '%'
                                   OR UPPER(tl.TenTaiLieu) LIKE '%' || UPPER(:Tim) || '%'
                ORDER BY tl.MaTaiLieu",
                new OracleParameter("Tim", string.IsNullOrWhiteSpace(tuKhoa) ? (object)DBNull.Value : tuKhoa.Trim()));
        }

        public List<string> LayMaTacGiaCua(string maTaiLieu)
        {
            List<string> ds = new List<string>();
            foreach (DataRow r in Db.Query("SELECT MaTacGia FROM TaiLieu_TacGia WHERE MaTaiLieu = :Ma ORDER BY ThuTu",
                                           new OracleParameter("Ma", maTaiLieu)).Rows)
                ds.Add(Convert.ToString(r["MaTacGia"]));
            return ds;
        }

        public string MaTaiLieuMoi()
        {
            object o = Db.Scalar("SELECT NVL(MAX(TO_NUMBER(SUBSTR(MaTaiLieu, 3))), 0) + 1 FROM TaiLieu WHERE REGEXP_LIKE(MaTaiLieu, '^TL[0-9]+$')");
            return "TL" + Convert.ToInt32(o).ToString("0000");
        }

        /// <summary>Lưu tài liệu + tác giả + tệp điện tử trong một transaction.</summary>
        public KetQuaXuLy Luu(bool themMoi, TaiLieuInfo tl)
        {
            if (string.IsNullOrWhiteSpace(tl.MaTaiLieu) || string.IsNullOrWhiteSpace(tl.TenTaiLieu) || tl.MaChuDe == null)
                return KetQuaXuLy.Loi("Vui lòng nhập mã, tên tài liệu và chọn chủ đề.");
            if (tl.MaTacGia == null || tl.MaTacGia.Count == 0) return KetQuaXuLy.Loi("Chọn ít nhất một tác giả.");
            if (tl.CoDienTu && (string.IsNullOrWhiteSpace(tl.DuongDanTep) || tl.DungLuongMB <= 0))
                return KetQuaXuLy.Loi("Tài liệu điện tử phải có đường dẫn tệp và dung lượng > 0.");
            string ma = tl.MaTaiLieu.Trim().ToUpperInvariant();
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    OracleParameter[] ps =
                    {
                        new OracleParameter("Ma", ma), new OracleParameter("Ten", tl.TenTaiLieu.Trim()),
                        new OracleParameter("Loai", tl.LoaiTaiLieu), new OracleParameter("HT", tl.HinhThuc),
                        new OracleParameter("CD", tl.MaChuDe), new OracleParameter("NXB", (object)tl.MaNXB ?? DBNull.Value),
                        new OracleParameter("Nam", tl.NamXuatBan),
                        new OracleParameter("MoTa", string.IsNullOrWhiteSpace(tl.MoTa) ? (object)DBNull.Value : tl.MoTa.Trim())
                    };
                    int n = themMoi
                        ? Db.Execute(cn, tx, @"INSERT INTO TaiLieu(MaTaiLieu, TenTaiLieu, LoaiTaiLieu, HinhThuc, MaChuDe, MaNXB, NamXuatBan, MoTa)
                                               VALUES (:Ma, :Ten, :Loai, :HT, :CD, :NXB, :Nam, :MoTa)", ps)
                        : Db.Execute(cn, tx, @"UPDATE TaiLieu SET TenTaiLieu = :Ten, LoaiTaiLieu = :Loai, HinhThuc = :HT, MaChuDe = :CD,
                                                   MaNXB = :NXB, NamXuatBan = :Nam, MoTa = :MoTa, NgayCapNhat = SYSTIMESTAMP
                                               WHERE MaTaiLieu = :Ma", ps);
                    if (n == 0) throw new InvalidOperationException("Không tìm thấy tài liệu cần cập nhật.");

                    Db.Execute(cn, tx, "DELETE FROM TaiLieu_TacGia WHERE MaTaiLieu = :Ma", new OracleParameter("Ma", ma));
                    for (int i = 0; i < tl.MaTacGia.Count; i++)
                        Db.Execute(cn, tx, "INSERT INTO TaiLieu_TacGia(MaTaiLieu, MaTacGia, ThuTu) VALUES (:Ma, :TG, :TT)",
                                   new OracleParameter("Ma", ma), new OracleParameter("TG", tl.MaTacGia[i]),
                                   new OracleParameter("TT", i + 1));

                    if (tl.CoDienTu)
                    {
                        OracleParameter[] tep =
                        {
                            new OracleParameter("Ma", ma), new OracleParameter("DD", tl.DuongDanTep.Trim()),
                            new OracleParameter("DinhDang", tl.DinhDang), new OracleParameter("MB", tl.DungLuongMB),
                            new OracleParameter("Tai", tl.ChoPhepTai ? 1 : 0)
                        };
                        if (Db.Execute(cn, tx, @"UPDATE TepDienTu SET DuongDanTep = :DD, DinhDang = :DinhDang, DungLuongMB = :MB,
                                                        ChoPhepTai = :Tai WHERE MaTaiLieu = :Ma", tep) == 0)
                            Db.Execute(cn, tx, @"INSERT INTO TepDienTu(MaTaiLieu, DuongDanTep, DinhDang, DungLuongMB, ChoPhepTai)
                                                 VALUES (:Ma, :DD, :DinhDang, :MB, :Tai)", tep);
                    }
                    else
                    {
                        // bỏ phần điện tử; nếu đã có lượt tải thì FK chặn và báo lỗi
                        Db.Execute(cn, tx, "DELETE FROM TepDienTu WHERE MaTaiLieu = :Ma", new OracleParameter("Ma", ma));
                    }
                });
                return KetQuaXuLy.Ok(themMoi ? "Đã thêm tài liệu " + ma + "." : "Đã cập nhật tài liệu " + ma + ".");
            }
            catch (InvalidOperationException ex)
            {
                return KetQuaXuLy.Loi(ex.Message);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>BR14: không xóa tài liệu còn bản sao Đang mượn / Đang giữ.</summary>
        public KetQuaXuLy Xoa(string maTaiLieu)
        {
            try
            {
                object dangDung = Db.Scalar(@"SELECT COUNT(*) FROM BanSao WHERE MaTaiLieu = :Ma AND TinhTrang IN ('DangMuon','DangGiu')",
                                            new OracleParameter("Ma", maTaiLieu));
                if (Convert.ToInt32(dangDung) > 0)
                    return KetQuaXuLy.Loi("Tài liệu còn bản sao đang được mượn hoặc giữ chỗ nên không thể xóa.");
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, "DELETE FROM BanSao WHERE MaTaiLieu = :Ma", new OracleParameter("Ma", maTaiLieu));
                    Db.Execute(cn, tx, "DELETE FROM TaiLieu WHERE MaTaiLieu = :Ma", new OracleParameter("Ma", maTaiLieu));
                });
                return KetQuaXuLy.Ok("Đã xóa tài liệu " + maTaiLieu + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // có lịch sử mượn / tải / đặt mua -> ORA-02292
            }
        }

        public DataTable LayBanSao(string maTaiLieu)
        {
            return Db.Query("SELECT MaBanSao, ViTriKe, TinhTrang, NgayNhap, GhiChu FROM BanSao WHERE MaTaiLieu = :Ma ORDER BY MaBanSao",
                            new OracleParameter("Ma", maTaiLieu));
        }

        /// <summary>Sinh thêm n bản sao (mã BS + 6 chữ số) ở trạng thái Sẵn sàng.</summary>
        public KetQuaXuLy ThemBanSao(string maTaiLieu, int soBan, string viTriKe)
        {
            if (soBan < 1 || soBan > 50) return KetQuaXuLy.Loi("Số bản phải từ 1 đến 50.");
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    for (int i = 0; i < soBan; i++)
                        Db.Execute(cn, tx, @"INSERT INTO BanSao(MaBanSao, MaTaiLieu, ViTriKe, TinhTrang)
                                             SELECT 'BS' || LPAD(NVL(MAX(TO_NUMBER(SUBSTR(MaBanSao, 3))), 0) + 1, 6, '0'), :Ma, :Ke, 'SanSang'
                                             FROM BanSao WHERE REGEXP_LIKE(MaBanSao, '^BS[0-9]+$')",
                                   new OracleParameter("Ma", maTaiLieu),
                                   new OracleParameter("Ke", string.IsNullOrWhiteSpace(viTriKe) ? (object)DBNull.Value : viTriKe.Trim()));
                });
                return KetQuaXuLy.Ok("Đã thêm " + soBan + " bản sao.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Thủ thư chỉ được đổi giữa các tình trạng kho; Đang mượn / Đang giữ do nghiệp vụ mượn-trả quản lý.</summary>
        public KetQuaXuLy DoiTinhTrangBanSao(string maBanSao, string tinhTrang)
        {
            try
            {
                int n = Db.Execute(@"UPDATE BanSao SET TinhTrang = :TT
                                     WHERE MaBanSao = :Ma AND TinhTrang NOT IN ('DangMuon','DangGiu')",
                                   new OracleParameter("TT", tinhTrang), new OracleParameter("Ma", maBanSao));
                return n > 0 ? KetQuaXuLy.Ok("Đã cập nhật tình trạng bản sao.")
                             : KetQuaXuLy.Loi("Bản sao đang được mượn hoặc giữ chỗ, không đổi tình trạng tại đây.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy XoaBanSao(string maBanSao)
        {
            try
            {
                int n = Db.Execute("DELETE FROM BanSao WHERE MaBanSao = :Ma AND TinhTrang NOT IN ('DangMuon','DangGiu')",
                                   new OracleParameter("Ma", maBanSao));
                return n > 0 ? KetQuaXuLy.Ok("Đã xóa bản sao.")
                             : KetQuaXuLy.Loi("Bản sao đang được mượn hoặc giữ chỗ nên không thể xóa.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // có lịch sử phiếu mượn -> gợi ý đổi sang Thanh lý
            }
        }
    }

    /// <summary>Sinh tên tham số :p0, :p1… cho câu truy vấn động (Oracle bind variable).</summary>
    internal class OracleCommandBuilderHelper
    {
        private readonly System.Collections.Generic.List<OracleParameter> _ps = new System.Collections.Generic.List<OracleParameter>();

        public string Add(object value)
        {
            string name = "p" + _ps.Count;
            _ps.Add(new OracleParameter(name, value));
            return ":" + name;
        }

        public OracleParameter[] ToArray()
        {
            return _ps.ToArray();
        }
    }
}
