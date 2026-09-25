using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Oracle.ManagedDataAccess.Client;

namespace ThuVienSo.Data
{
    /// <summary>Lớp truy cập dữ liệu dùng chung (ADO.NET – Oracle ODP.NET Managed).</summary>
    public static class Db
    {
        // Dùng khi App.config chưa khai báo chuỗi kết nối; mật khẩu thật đặt trong App.config, không để trong mã nguồn.
        private const string MacDinh = "User Id=THUVIENSO;Password=;Data Source=localhost:1521/ORCL;";

        // Oracle trả tên cột IN HOA (MATAILIEU). Bảng tên chuẩn để đổi lại thành MaTaiLieu, TenTaiLieu…
        private const string TenCotChuan =
            "BanSao BatDau ChoPhepTai ChuDe ChucVu ConDangGiu DaNhac DangGiu DangKyId DangKyMuon DangLamViec DangMuon " +
            "DangQuaHan DiaChi DiaChiIP DiaChiNhan DinhDang DocGia DonVi DungLuongMB DuongDanTep Email EmailDaGui " +
            "EmailNhacHan GhiChu HanNhan HanSuDung HanTra HinhThuc HoTen Id KetQuaGhiChu KetThuc LanDangNhapCuoi " +
            "LoaiDocGia LoaiTaiLieu LoiGanNhat LuotMuon LuotTai LyDoDeNghi MaBanSao MaBanSaoGiu MaChuDe MaDangKy " +
            "MaDocGia MaEmail MaNXB MaPhieuMuon MaTacGia MaTaiKhoan MaTaiLieu MaTaiLieuLienKet MaThe MaThuThu " +
            "MaThuThuDuyet MaThuThuLap MaThuThuNhan MaYeuCau MatKhauHash MatKhauSalt MoTa NamXuatBan NgayCap " +
            "NgayCapNhat NgayDangKy NgayDuyet NgayGui NgayMuon NgayNhap NgaySinh NgayTao NgayTra NhaXuatBan NhatKyId " +
            "NhatKyLapLich NoiDung PhieuMuon PhieuMuonId QuaHan SoBanGhiQuet SoDangKyHuy SoDienThoai SoLanSaiLienTiep " +
            "SoLanThu SoLoi SoLuongTon SoNgayTre SoThanhCong SoYeuCau TacGia TaiKhoan TaiLieu TenChuDe TenCongViec " +
            "TenDangNhap TenNXB TenSach TenTacGia TenTaiLieu TepDienTu TheThuVien ThoiDiem ThoiDiemGui ThoiDiemTao " +
            "ThuThu ThuTu TieuDe TinhTrang TongBanSao TrangThai VaiTro ViTriKe YeuCauDatMua";

        private static readonly Regex _dinhDanh = new Regex(@"\b[A-Za-z_][A-Za-z0-9_]*\b", RegexOptions.Compiled);
        private static readonly Dictionary<string, string> _tenChuan = TaoTuDien(TenCotChuan);

        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["QuanLyThuVienSoDb"];
                    _connectionString = cs != null ? cs.ConnectionString : MacDinh;
                }
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        public static OracleConnection OpenConnection()
        {
            OracleConnection cn = new OracleConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        /// <summary>Câu lệnh SQL: tham số gắn theo tên (:Ma, :The… được dùng lại nhiều lần).</summary>
        private static OracleCommand TaoLenh(OracleConnection cn, string sql, OracleParameter[] parameters)
        {
            OracleCommand cmd = new OracleCommand(sql, cn) { BindByName = true };
            if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            return cmd;
        }

        public static DataTable Query(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection cn = OpenConnection())
            using (OracleCommand cmd = TaoLenh(cn, sql, parameters))
            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                da.Fill(table);
                ChuanHoaTenCot(table, sql);
                return table;
            }
        }

        public static int Execute(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection cn = OpenConnection())
            using (OracleCommand cmd = TaoLenh(cn, sql, parameters))
                return cmd.ExecuteNonQuery();
        }

        public static object Scalar(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection cn = OpenConnection())
            using (OracleCommand cmd = TaoLenh(cn, sql, parameters))
                return cmd.ExecuteScalar();
        }

        /// <summary>Chạy nhiều câu lệnh trong một transaction (vd. lưu tài liệu + tác giả + tệp + bản sao).</summary>
        public static void Transaction(Action<OracleConnection, OracleTransaction> congViec)
        {
            using (OracleConnection cn = OpenConnection())
            using (OracleTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    congViec(cn, tx);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>Câu lệnh chạy bên trong Transaction(...).</summary>
        public static int Execute(OracleConnection cn, OracleTransaction tx, string sql, params OracleParameter[] parameters)
        {
            using (OracleCommand cmd = TaoLenh(cn, sql, parameters))
            {
                cmd.Transaction = tx;
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gọi stored procedure. Procedure trả dữ liệu bằng DBMS_SQL.RETURN_RESULT (implicit result set);
        /// tham số truyền đúng thứ tự khai báo p_MaThe, p_MaTaiLieu…
        /// </summary>
        public static DataSet ExecProc(string name, params OracleParameter[] parameters)
        {
            using (OracleConnection cn = OpenConnection())
            using (OracleCommand cmd = new OracleCommand(name, cn))
            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = false;
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataTable t in ds.Tables) ChuanHoaTenCot(t, null);
                return ds;
            }
        }

        /// <summary>Result set cuối cùng của procedure.</summary>
        public static DataTable ExecProcLast(string name, params OracleParameter[] parameters)
        {
            DataSet ds = ExecProc(name, parameters);
            return ds.Tables.Count > 0 ? ds.Tables[ds.Tables.Count - 1] : new DataTable();
        }

        /// <summary>MATAILIEU -> MaTaiLieu: ưu tiên cách viết trong chính câu SQL, sau đó tới bảng tên chuẩn.</summary>
        private static void ChuanHoaTenCot(DataTable table, string sql)
        {
            Dictionary<string, string> trongCau = sql == null ? null : TaoTuDien(sql);
            foreach (DataColumn c in table.Columns)
            {
                string ten;
                if (trongCau != null && trongCau.TryGetValue(c.ColumnName, out ten))
                    c.ColumnName = ten;
                else if (_tenChuan.TryGetValue(c.ColumnName, out ten))
                    c.ColumnName = ten;
            }
        }

        private static Dictionary<string, string> TaoTuDien(string text)
        {
            Dictionary<string, string> d = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match m in _dinhDanh.Matches(text))
            {
                string w = m.Value;
                // chỉ nhận định danh viết kiểu PascalCase (có cả chữ hoa lẫn chữ thường)
                if (w.ToUpperInvariant() != w && w.ToLowerInvariant() != w && !d.ContainsKey(w)) d[w] = w;
            }
            return d;
        }
    }
}
