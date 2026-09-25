using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using ThuVienSo.Data;

namespace ThuVienSo.Services
{
    /// <summary>Mô tả một bảng danh mục để dùng chung CRUD (ChuDe, TacGia, NhaXuatBan).</summary>
    public class LoaiDanhMuc
    {
        public string Bang { get; set; }
        public string CotKhoa { get; set; }
        public string[] CotDuLieu { get; set; }   // theo thứ tự ô nhập trên form
        public string[] CotBatBuoc { get; set; }

        public static readonly LoaiDanhMuc ChuDe = new LoaiDanhMuc
        {
            Bang = "ChuDe", CotKhoa = "MaChuDe", CotDuLieu = new[] { "TenChuDe", "MoTa" }, CotBatBuoc = new[] { "TenChuDe" }
        };

        public static readonly LoaiDanhMuc TacGia = new LoaiDanhMuc
        {
            Bang = "TacGia", CotKhoa = "MaTacGia", CotDuLieu = new[] { "TenTacGia", "GhiChu" }, CotBatBuoc = new[] { "TenTacGia" }
        };

        public static readonly LoaiDanhMuc NhaXuatBan = new LoaiDanhMuc
        {
            Bang = "NhaXuatBan", CotKhoa = "MaNXB", CotDuLieu = new[] { "TenNXB", "DiaChi", "SoDienThoai" },
            CotBatBuoc = new[] { "TenNXB" }
        };
    }

    public class DanhMucService
    {
        // Tên bảng/cột chỉ lấy từ LoaiDanhMuc cố định ở trên, không lấy từ người dùng.
        public DataTable LayDanhSach(LoaiDanhMuc loai)
        {
            return Db.Query(string.Format("SELECT {0}, {1} FROM {2} ORDER BY {0}",
                loai.CotKhoa, string.Join(", ", loai.CotDuLieu), loai.Bang));
        }

        public KetQuaXuLy Luu(LoaiDanhMuc loai, bool themMoi, string ma, IList<string> giaTri)
        {
            if (string.IsNullOrWhiteSpace(ma)) return KetQuaXuLy.Loi("Vui lòng nhập mã.");
            for (int i = 0; i < loai.CotDuLieu.Length; i++)
                if (loai.CotBatBuoc.Contains(loai.CotDuLieu[i]) && string.IsNullOrWhiteSpace(giaTri[i]))
                    return KetQuaXuLy.Loi("Vui lòng nhập đầy đủ thông tin bắt buộc.");

            List<OracleParameter> ps = new List<OracleParameter> { new OracleParameter("Ma", ma.Trim()) };
            for (int i = 0; i < loai.CotDuLieu.Length; i++)
                ps.Add(new OracleParameter("v" + i,
                    string.IsNullOrWhiteSpace(giaTri[i]) ? (object)DBNull.Value : giaTri[i].Trim()));

            string sql;
            if (themMoi)
                sql = string.Format("INSERT INTO {0}({1}, {2}) VALUES (:Ma, {3})", loai.Bang, loai.CotKhoa,
                    string.Join(", ", loai.CotDuLieu),
                    string.Join(", ", loai.CotDuLieu.Select((c, i) => ":v" + i)));
            else
                sql = string.Format("UPDATE {0} SET {1} WHERE {2} = :Ma", loai.Bang,
                    string.Join(", ", loai.CotDuLieu.Select((c, i) => c + " = :v" + i)), loai.CotKhoa);
            try
            {
                int n = Db.Execute(sql, ps.ToArray());
                if (n == 0) return KetQuaXuLy.Loi("Không tìm thấy dữ liệu cần cập nhật.");
                return KetQuaXuLy.Ok(themMoi ? "Đã thêm." : "Đã cập nhật.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy Xoa(LoaiDanhMuc loai, string ma)
        {
            try
            {
                Db.Execute(string.Format("DELETE FROM {0} WHERE {1} = :Ma", loai.Bang, loai.CotKhoa),
                           new OracleParameter("Ma", ma));
                return KetQuaXuLy.Ok("Đã xóa.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);   // lỗi ORA-02292 -> "đang được sử dụng" (BR14)
            }
        }
    }
}
