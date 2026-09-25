using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyKhachSan.Data
{
    /// <summary>Lớp truy cập dữ liệu dùng chung cho hệ thống khách sạn (ADO.NET – Oracle ODP.NET Managed).</summary>
    public static class Db
    {
        // Dùng khi App.config chưa khai báo chuỗi kết nối; mật khẩu thật đặt trong App.config, không để trong mã nguồn.
        private const string MacDinh = "User Id=KHACHSAN;Password=;Data Source=localhost:1521/ORCL;";

        // Oracle trả tên cột IN HOA (SOPHIEUDAT). Bảng tên chuẩn để đổi lại thành SoPhieuDat, TenKhuVuc…
        private const string TenCotChuan =
            "ChiTietDatPhong ChiTietPhieuDenBu ChiTietPhieuSuDungDV ConLai DichVu DoanhThu DonGia DonGiaApDung " +
            "DonGiaNgay DonViTinh GhiChu HinhThuc HoTen HoaDon KenhDat KhachHang KhuVuc LoaiTienNghi MaDV MaKhach " +
            "MaKhuVuc MaLoaiTN MaNV MaNVLeTan MaNguoiLT MaQuyDinh MaThanhToan MaTienNghi MucDenBu MucDoThietHai NgayLap " +
            "NgayNhan NgayNhanThucTe NgaySuDung NgayThanhToan NgayTraDuKien NgayTraThucTe NguoiLuuTru NhanVien " +
            "PhieuDatPhong PhieuDenBu PhieuLapDat PhieuSuDungDV QuocTich QuyDinhDenBu SoBang SoCMND SoDienThoai SoHoaDon " +
            "SoLuong SoLuot SoNgayTinhTien SoNguoi SoNguoiToiDa SoPhieuDat SoPhieuDenBu SoPhieuLapDat SoPhieuSDDV " +
            "SoPhong SoThuTu SoTien TenDV TenKhuVuc TenLoaiTN ThanhTien ThanhToan TienCoc TienDichVu TienNghi TienPhong " +
            "TinhTrang TinhTrangHienTai TongDaThanhToan TongTien TrangThai VaiTro";

        private static readonly Regex _dinhDanh = new Regex(@"\b[A-Za-z_][A-Za-z0-9_]*\b", RegexOptions.Compiled);
        private static readonly Dictionary<string, string> _tenChuan = TaoTuDien(TenCotChuan);

        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["QuanLyKhachSanDb"];
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

        /// <summary>Sinh mã phiếu từ sequence, ví dụ SinhMa("SEQ_PhieuDat", "DP", 5) -> DP00123.</summary>
        public static string SinhMa(string sequence, string tienTo, int soChuSo)
        {
            object o = Scalar("SELECT " + sequence + ".NEXTVAL FROM dual");
            return tienTo + Convert.ToInt64(o).ToString(new string('0', soChuSo));
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

        /// <summary>Truy vấn một giá trị bên trong Transaction(...).</summary>
        public static object Scalar(OracleConnection cn, OracleTransaction tx, string sql, params OracleParameter[] parameters)
        {
            using (OracleCommand cmd = TaoLenh(cn, sql, parameters))
            {
                cmd.Transaction = tx;
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Gọi stored procedure. Procedure trả dữ liệu bằng DBMS_SQL.RETURN_RESULT (implicit result set);
        /// tham số truyền đúng thứ tự khai báo.
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
