using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>Tiện ích dùng chung cho các form: hiển thị lưới, lấy dòng chọn, thông báo kết quả.</summary>
    internal static class GridHelper
    {
        // cột thời điểm (có giờ phút); các cột ngày khác chỉ hiện dd/MM/yyyy
        private static readonly string[] CotCoGio = { "NgayGui", "NgayDangKy", "NgayDuyet", "ThoiDiem", "ThoiDiemTao", "ThoiDiemGui" };

        // mã lưu trong CSDL -> chữ hiển thị (chỉ đổi lúc vẽ ô, giá trị gốc giữ nguyên cho nghiệp vụ)
        private static readonly System.Collections.Generic.Dictionary<string, string> TenHienThi =
            new System.Collections.Generic.Dictionary<string, string>
            {
                { "BanIn", "Bản in" }, { "DienTu", "Điện tử" }, { "CaHai", "Bản in + điện tử" },
                { "Sach", "Sách" }, { "Bao", "Báo" }, { "TapChi", "Tạp chí" }, { "NgheNhin", "Nghe nhìn" },
                { "SanSang", "Sẵn sàng" }, { "DangGiu", "Đang giữ" }, { "DangMuon", "Đang mượn" },
                { "CanKiemTra", "Cần kiểm tra" }, { "Mat", "Mất" }, { "ThanhLy", "Thanh lý" },
                { "DaTra", "Đã trả" }, { "TraHuHong", "Trả hư hỏng" },
                { "HoatDong", "Hoạt động" }, { "HetHan", "Hết hạn" }, { "Khoa", "Bị khóa" },
                { "ChoNhan", "Chờ nhận" }, { "DaNhan", "Đã nhận" }, { "DaHuy", "Đã hủy" },
                { "ChoDuyet", "Chờ duyệt" }, { "ChapNhan", "Chấp nhận" }, { "TuChoi", "Từ chối" },
                { "ChoGui", "Chờ gửi" }, { "DaGui", "Đã gửi" }, { "Loi", "Lỗi" },
                { "SinhVien", "Sinh viên" }, { "GiangVien", "Giảng viên" }, { "NhanVien", "Nhân viên" }
            };

        private static readonly string[] CotMa = { "HinhThuc", "LoaiTaiLieu", "TinhTrang", "TrangThai", "LoaiDocGia" };

        private static void DichMa(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string ten;
            if (e.Value is string && Array.IndexOf(CotMa, dgv.Columns[e.ColumnIndex].DataPropertyName) >= 0
                && TenHienThi.TryGetValue((string)e.Value, out ten))
            {
                e.Value = ten;
                e.FormattingApplied = true;
            }
        }

        /// <summary>
        /// cot: các cặp "TenCot", "Tiêu đề"; cột không liệt kê sẽ bị ẩn. Tiêu đề bắt đầu bằng "*" là cột rộng.
        /// </summary>
        public static void HienThi(DataGridView dgv, DataTable data, params string[] cot)
        {
            if (!"DichMa".Equals(dgv.Tag))
            {
                dgv.CellFormatting += DichMa;
                dgv.Tag = "DichMa";
            }
            dgv.DataSource = data;
            foreach (DataGridViewColumn c in dgv.Columns) c.Visible = false;
            for (int i = 0; i + 1 < cot.Length; i += 2)
            {
                if (!dgv.Columns.Contains(cot[i])) continue;
                DataGridViewColumn c = dgv.Columns[cot[i]];
                c.HeaderText = cot[i + 1].TrimStart('*');
                c.FillWeight = cot[i + 1].StartsWith("*") ? 220 : 100;
                c.DisplayIndex = i / 2;
                c.Visible = true;
                if (data.Columns[cot[i]].DataType == typeof(DateTime))
                    c.DefaultCellStyle.Format = Array.IndexOf(CotCoGio, cot[i]) >= 0 ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy";
            }
        }

        /// <summary>
        /// Dòng đang chọn. Ưu tiên SelectedRows vì trong SelectionChanged, CurrentRow có thể chưa kịp cập nhật
        /// (khi chọn bằng bàn phím hoặc bằng code).
        /// </summary>
        public static DataRowView DongChon(DataGridView dgv)
        {
            DataGridViewRow row = dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0] : dgv.CurrentRow;
            return row == null ? null : row.DataBoundItem as DataRowView;
        }

        public static void ThongBao(IWin32Window owner, KetQuaXuLy kq, string tieuDe = "Thông báo")
        {
            MessageBox.Show(owner, kq.ThongDiep, tieuDe, MessageBoxButtons.OK,
                            kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        public static void LoiHeThong(IWin32Window owner, Exception ex)
        {
            MessageBox.Show(owner, KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool XacNhan(IWin32Window owner, string cauHoi)
        {
            return MessageBox.Show(owner, cauHoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>Chọn mục trong ComboBox (chứa Muc) theo mã.</summary>
        public static void ChonTheoMa(ComboBox cbo, string ma)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                Muc m = cbo.Items[i] as Muc;
                if (m != null && m.Ma == ma)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
            cbo.SelectedIndex = cbo.Items.Count > 0 ? 0 : -1;
        }

        public static string MaChon(ComboBox cbo)
        {
            Muc m = cbo.SelectedItem as Muc;
            return m == null ? null : m.Ma;
        }
    }
}
