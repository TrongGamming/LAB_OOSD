using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.14 – UC-TĐ-01: theo dõi email nhắc hạn do Bộ lập lịch gửi, gửi lại email lỗi.</summary>
    public partial class FrmNhatKyEmail : Form
    {
        private readonly NhacHanJob _job = new NhacHanJob();

        public FrmNhatKyEmail()
        {
            InitializeComponent();
        }

        private void FrmNhatKyEmail_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.AddRange(new object[]
            {
                new Muc(null, "Tất cả"), new Muc("ChoGui", "Chờ gửi"), new Muc("DaGui", "Đã gửi"), new Muc("Loi", "Lỗi")
            });
            cboTrangThai.SelectedIndex = 0;
            dtNgay.Checked = false;   // bỏ chọn = mọi ngày
            NapDanhSach();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            NapDanhSach();
        }

        private void NapDanhSach()
        {
            try
            {
                DataTable t = _job.LayEmail(dtNgay.Checked ? dtNgay.Value.Date : (DateTime?)null, GridHelper.MaChon(cboTrangThai));
                t.Columns.Add("TrangThaiHienThi", typeof(string));
                foreach (DataRow r in t.Rows)
                {
                    string tt = Convert.ToString(r["TrangThai"]);
                    r["TrangThaiHienThi"] = tt == "DaGui" ? "Đã gửi" : tt == "Loi" ? "Lỗi" : "Chờ gửi";
                }
                GridHelper.HienThi(dgvEmail, t,
                    "MaEmail", "Mã email", "MaPhieuMuon", "Mã phiếu", "DocGia", "*Độc giả", "DiaChiNhan", "*Email",
                    "HanTra", "Hạn trả", "ThoiDiemGui", "Gửi lúc", "TrangThaiHienThi", "Trạng thái", "SoLanThu", "Lần thử",
                    "LoiGanNhat", "*Lỗi gần nhất");
                lblLanChay.Text = _job.LanChayGanNhat() + "   |   Lịch chạy: 06:00 hằng ngày (Task Scheduler gọi ThuVienSo.exe /nhachan)";
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvEmail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataRowView v = dgvEmail.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToString(v["TrangThai"]) == "Loi") e.CellStyle.BackColor = Color.MistyRose;
        }

        /// <summary>Chạy ngay công việc nhắc hạn (giống Bộ lập lịch kích hoạt).</summary>
        private void btnChayNgay_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            KetQuaXuLy kq = _job.Execute();
            Cursor = Cursors.Default;
            lblKetQua.ForeColor = kq.ThanhCong ? Color.FromArgb(31, 78, 121) : Color.Firebrick;
            lblKetQua.Text = kq.ThongDiep;
            NapDanhSach();
        }

        private void btnGuiLai_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            foreach (DataGridViewRow row in dgvEmail.SelectedRows)
            {
                DataRowView v = row.DataBoundItem as DataRowView;
                if (v != null && Convert.ToString(v["TrangThai"]) == "Loi") ids.Add(Convert.ToInt32(v["Id"]));
            }
            if (ids.Count == 0)
            {
                lblKetQua.Text = "Chọn ít nhất một email đang ở trạng thái Lỗi.";
                return;
            }
            KetQuaXuLy kq = _job.GuiLaiLoi(ids);
            lblKetQua.Text = kq.ThongDiep;
            NapDanhSach();
        }
    }
}
