using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.12 – UC-QT-03: báo cáo thống kê theo khoảng thời gian (sp_ThongKeTongHop).</summary>
    public partial class FrmBaoCao : Form
    {
        private readonly BaoCaoService _service = new BaoCaoService();

        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDen.Value = DateTime.Today;
            btnXem_Click(null, EventArgs.Empty);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            if (dtTu.Value.Date > dtDen.Value.Date)
            {
                // kịch bản sai: nhập ngược khoảng -> tự đổi chỗ và báo cho người dùng
                DateTime tmp = dtTu.Value;
                dtTu.Value = dtDen.Value;
                dtDen.Value = tmp;
                lblThongBao.Text = "Đã tự đổi chỗ Từ ngày / Đến ngày.";
            }
            if ((dtDen.Value.Date - dtTu.Value.Date).TotalDays > 366)
            {
                lblThongBao.Text = "Khoảng thời gian tối đa 366 ngày.";
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                DataSet ds = _service.ThongKe(dtTu.Value, dtDen.Value);
                DataRow kpi = ds.Tables[0].Rows[0];
                lblLuotMuon.Text = Convert.ToString(kpi["LuotMuon"]);
                lblQuaHan.Text = Convert.ToString(kpi["DangQuaHan"]);
                lblLuotTai.Text = Convert.ToString(kpi["LuotTai"]);
                lblDatMua.Text = Convert.ToString(kpi["YeuCauDatMua"]);
                lblEmail.Text = Convert.ToString(kpi["EmailDaGui"]);

                GridHelper.HienThi(dgvTheoChuDe, ds.Tables[1], "TenChuDe", "*Chủ đề", "LuotMuon", "Lượt mượn");
                GridHelper.HienThi(dgvQuaHan, ds.Tables[2],
                    "MaPhieuMuon", "Mã phiếu", "HoTen", "*Độc giả", "Email", "*Email", "TenTaiLieu", "*Tài liệu",
                    "HanTra", "Hạn trả", "SoNgayTre", "Trễ (ngày)", "DaNhac", "Đã nhắc");
                GridHelper.HienThi(dgvTopTai, ds.Tables[3], "MaTaiLieu", "Mã TL", "TenTaiLieu", "*Tài liệu", "LuotTai", "Lượt tải");
                DataTable datMua = ds.Tables[4];
                datMua.Columns.Add("TrangThaiHienThi", typeof(string));
                foreach (DataRow r in datMua.Rows) r["TrangThaiHienThi"] = FrmDatMua.TenTrangThai(Convert.ToString(r["TrangThai"]));
                GridHelper.HienThi(dgvDatMua, datMua, "TrangThaiHienThi", "*Trạng thái", "SoYeuCau", "Số yêu cầu");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Xuất bảng của tab đang mở ra CSV (UTF-8 có BOM để Excel đọc đúng tiếng Việt).</summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)tabs.SelectedTab.Controls[0];
            if (dgv.Rows.Count == 0)
            {
                lblThongBao.Text = "Bảng đang trống, không có gì để xuất.";
                return;
            }
            using (SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "CSV (Excel)|*.csv",
                FileName = "BaoCao_" + tabs.SelectedTab.Name.Substring(3) + "_" + dtTu.Value.ToString("yyyyMMdd") + "_" + dtDen.Value.ToString("yyyyMMdd") + ".csv"
            })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Join(",", CotHienThi(dgv, c => Csv(c.HeaderText))));
                foreach (DataGridViewRow row in dgv.Rows)
                    sb.AppendLine(string.Join(",", CotHienThi(dgv, c => Csv(Convert.ToString(row.Cells[c.Index].FormattedValue)))));
                File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                lblThongBao.Text = "Đã xuất " + dgv.Rows.Count + " dòng.";
            }
        }

        private static System.Collections.Generic.IEnumerable<string> CotHienThi(DataGridView dgv, Func<DataGridViewColumn, string> lay)
        {
            System.Collections.Generic.List<DataGridViewColumn> cot = new System.Collections.Generic.List<DataGridViewColumn>();
            foreach (DataGridViewColumn c in dgv.Columns)
                if (c.Visible) cot.Add(c);
            cot.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));
            foreach (DataGridViewColumn c in cot) yield return lay(c);
        }

        private static string Csv(string s)
        {
            s = s ?? "";
            return s.IndexOfAny(new[] { ',', '"', '\n' }) >= 0 ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;
        }
    }
}
