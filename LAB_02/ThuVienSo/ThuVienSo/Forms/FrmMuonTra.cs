using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>UC-MT-02 Lập phiếu mượn, UC-MT-03 Ghi nhận trả sách.</summary>
    public partial class FrmMuonTra : Form
    {
        private readonly MuonTraService _service = new MuonTraService();
        private readonly TheService _the = new TheService();
        private string _maThe;   // thẻ đã kiểm tra hợp lệ ở tab Lập phiếu

        public FrmMuonTra()
        {
            InitializeComponent();
        }

        // ============================== TAB LẬP PHIẾU ==============================
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            _maThe = null;
            grpBanSao.Enabled = false;
            dgvBanSaoChon.Rows.Clear();
            cboDangKy.Items.Clear();
            lblHanMuc.Text = "";

            KetQuaXuLy kq = _the.XacThucMaThe(txtMaThe.Text);   // UC-XT-01
            lblDocGia.ForeColor = kq.ThanhCong ? Color.FromArgb(31, 78, 121) : Color.Firebrick;
            lblDocGia.Text = kq.ThongDiep;
            if (!kq.ThanhCong) return;

            try
            {
                _maThe = txtMaThe.Text.Trim();
                lblHanMuc.Text = _service.TomTatHanMuc(_maThe);
                foreach (DataRow r in _service.LayDangKyChoNhan(_maThe).Rows)
                    cboDangKy.Items.Add(new DangKyMuc(r));
                if (cboDangKy.Items.Count > 0) cboDangKy.SelectedIndex = 0;
                btnLayDangKy.Enabled = cboDangKy.Items.Count > 0;
                grpBanSao.Enabled = true;
                txtMaBanSao.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaBanSao_KeyDown(object sender, KeyEventArgs e)
        {
            // máy quét mã vạch gửi Enter sau mỗi mã
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            btnThem_Click(sender, EventArgs.Empty);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaBanSao.Text.Trim();
            if (ma.Length == 0) return;
            try
            {
                DataRow bs = _service.LayBanSao(ma);
                if (bs == null)
                {
                    MessageBox.Show("Không tìm thấy bản sao " + ma + ".", "Thêm bản sao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // bản sao đang được giữ cho chính thẻ này thì tự gắn đăng ký tương ứng
                DangKyMuc dk = null;
                foreach (DangKyMuc m in cboDangKy.Items)
                    if (m.MaBanSao == ma) dk = m;
                ThemDong(ma, Convert.ToString(bs["TenTaiLieu"]), dk);
                txtMaBanSao.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLayDangKy_Click(object sender, EventArgs e)
        {
            DangKyMuc dk = cboDangKy.SelectedItem as DangKyMuc;
            if (dk != null) ThemDong(dk.MaBanSao, dk.TenTaiLieu, dk);
        }

        private void ThemDong(string maBanSao, string tenTaiLieu, DangKyMuc dk)
        {
            foreach (DataGridViewRow row in dgvBanSaoChon.Rows)
                if (Convert.ToString(row.Cells[colMaBanSao.Index].Value) == maBanSao)
                {
                    MessageBox.Show("Bản sao này đã có trong danh sách.", "Thêm bản sao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            dgvBanSaoChon.Rows.Add(maBanSao, tenTaiLieu, dk == null ? "" : dk.MaDangKy,
                                   dk == null ? (object)null : dk.Id, "");
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvBanSaoChon.CurrentRow != null) dgvBanSaoChon.Rows.Remove(dgvBanSaoChon.CurrentRow);
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (_maThe == null || dgvBanSaoChon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có bản sao nào để lập phiếu.", "Lập phiếu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int thanhCong = 0;
            foreach (DataGridViewRow row in dgvBanSaoChon.Rows)
            {
                if (row.Tag as string == "OK") continue;   // dòng đã lập ở lần bấm trước
                object id = row.Cells[colDangKyId.Index].Value;
                KetQuaXuLy kq = _service.LapPhieuMuon(_maThe, Convert.ToString(row.Cells[colMaBanSao.Index].Value),
                                                      Phien.MaThuThu, id == null ? (int?)null : Convert.ToInt32(id));
                row.Cells[colKetQua.Index].Value = kq.ThongDiep;
                row.DefaultCellStyle.BackColor = kq.ThanhCong ? Color.Honeydew : Color.MistyRose;
                if (kq.ThanhCong)
                {
                    row.Tag = "OK";
                    thanhCong++;
                }
            }
            lblHanMuc.Text = _service.TomTatHanMuc(_maThe);
            MessageBox.Show("Đã lập " + thanhCong + " phiếu mượn.", "Lập phiếu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ============================== TAB TRẢ SÁCH ==============================
        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            TaiPhieuDangMo();
            if (dgvPhieuDangMo.Rows.Count == 0)
                lblKetQuaTra.Text = "Bản sao không nằm trong danh sách đang cho mượn.";
        }

        private void TaiPhieuDangMo()
        {
            lblKetQuaTra.ForeColor = Color.Firebrick;
            lblKetQuaTra.Text = "";
            try
            {
                GridHelper.HienThi(dgvPhieuDangMo, _service.TimPhieuDangMo(txtMaBanSaoTra.Text.Trim(), txtMaTheTra.Text.Trim()),
                    "MaPhieuMuon", "Mã phiếu", "MaBanSao", "Mã bản sao", "TenTaiLieu", "*Tên tài liệu",
                    "DocGia", "Độc giả", "NgayMuon", "Ngày mượn", "HanTra", "Hạn trả", "SoNgayTre", "Trễ (ngày)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhieuDangMo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // luồng 4.2 UC-MT-03: tô nổi phiếu quá hạn
            DataRowView v = dgvPhieuDangMo.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToInt32(v["SoNgayTre"]) > 0)
            {
                e.CellStyle.BackColor = Color.MistyRose;
                if (dgvPhieuDangMo.Columns[e.ColumnIndex].Name == "SoNgayTre")
                    e.CellStyle.Font = new Font(dgvPhieuDangMo.Font, FontStyle.Bold);
            }
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvPhieuDangMo);
            if (v == null)
            {
                lblKetQuaTra.Text = "Chọn phiếu cần trả trong danh sách.";
                return;
            }
            string tinhTrang = rdoHuHong.Checked ? "HuHong" : rdoMat.Checked ? "Mat" : "NguyenVen";
            if (tinhTrang != "NguyenVen" && string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                lblKetQuaTra.Text = "Phải nhập ghi chú khi sách hư hỏng hoặc mất.";
                txtGhiChu.Focus();
                return;
            }
            KetQuaXuLy kq = _service.GhiNhanTra(Convert.ToString(v["MaBanSao"]), Phien.MaThuThu, tinhTrang, txtGhiChu.Text);
            string thongDiep = kq.ThongDiep;
            if (kq.ThanhCong)
            {
                txtGhiChu.Clear();
                rdoNguyenVen.Checked = true;
                TaiPhieuDangMo();
            }
            lblKetQuaTra.ForeColor = kq.ThanhCong ? Color.FromArgb(31, 78, 121) : Color.Firebrick;
            lblKetQuaTra.Text = thongDiep;
        }

        // ============================== TAB ĐĂNG KÝ CHỜ NHẬN ==============================
        private void FrmMuonTra_Load(object sender, EventArgs e)
        {
            TaiDangKy();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabDangKy) TaiDangKy();
            else if (tabs.SelectedTab == tabTinhTrang) TaiTinhTrang();
            else if (tabs.SelectedTab == tabLapPhieu) txtMaThe.Focus();
            else if (tabs.SelectedTab == tabTraSach) txtMaBanSaoTra.Focus();
        }

        private void btnTaiDangKy_Click(object sender, EventArgs e)
        {
            TaiDangKy();
        }

        private void TaiDangKy()
        {
            try
            {
                GridHelper.HienThi(dgvDangKy, _service.LayTatCaDangKyChoNhan(),
                    "MaDangKy", "Mã đăng ký", "MaThe", "Mã thẻ", "DocGia", "*Độc giả", "TenTaiLieu", "*Tài liệu",
                    "MaBanSaoGiu", "Bản sao giữ", "NgayDangKy", "Ngày đăng ký", "HanNhan", "Hạn nhận");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvDangKy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataRowView v = dgvDangKy.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToInt32(v["QuaHan"]) == 1) e.CellStyle.BackColor = Color.MistyRose;   // BR05
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvDangKy);
            if (v == null || !GridHelper.XacNhan(this, "Hủy đăng ký " + v["MaDangKy"] + " và trả bản sao về kho?")) return;
            KetQuaXuLy kq = _service.HuyDangKy(Convert.ToInt32(v["Id"]));
            GridHelper.ThongBao(this, kq, "Hủy đăng ký");
            TaiDangKy();
        }

        /// <summary>Chuyển sang tab Lập phiếu, kiểm tra thẻ và đưa sẵn bản sao đang giữ vào danh sách.</summary>
        private void btnChuyenLapPhieu_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvDangKy);
            if (v == null) return;
            string maDangKy = Convert.ToString(v["MaDangKy"]);
            tabs.SelectedTab = tabLapPhieu;
            txtMaThe.Text = Convert.ToString(v["MaThe"]);
            btnKiemTra_Click(null, EventArgs.Empty);
            if (_maThe == null) return;
            foreach (DangKyMuc m in cboDangKy.Items)
                if (m.MaDangKy == maDangKy)
                {
                    cboDangKy.SelectedItem = m;
                    btnLayDangKy_Click(null, EventArgs.Empty);
                    break;
                }
        }

        // ============================== TAB TÌNH TRẠNG MƯỢN (UC-MT-04) ==============================
        private void btnTimTT_Click(object sender, EventArgs e)
        {
            TaiTinhTrang();
        }

        private void TaiTinhTrang()
        {
            try
            {
                GridHelper.HienThi(dgvTinhTrang, _service.TinhTrangMuon(txtTimTT.Text, chkChiQuaHan.Checked),
                    "MaTaiLieu", "Mã TL", "TenTaiLieu", "*Tài liệu", "MaBanSao", "Bản sao", "MaPhieuMuon", "Mã phiếu",
                    "DocGia", "*Độc giả đang giữ", "NgayMuon", "Ngày mượn", "HanTra", "Hạn trả", "SoNgayTre", "Trễ (ngày)");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvTinhTrang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataRowView v = dgvTinhTrang.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToInt32(v["QuaHan"]) == 1)
            {
                e.CellStyle.BackColor = Color.MistyRose;
                if (dgvTinhTrang.Columns[e.ColumnIndex].Name == "SoNgayTre")
                    e.CellStyle.Font = new Font(dgvTinhTrang.Font, FontStyle.Bold);
            }
        }

        /// <summary>Một đăng ký chờ nhận hiển thị trong ComboBox.</summary>
        private class DangKyMuc
        {
            public DangKyMuc(DataRow r)
            {
                Id = Convert.ToInt32(r["Id"]);
                MaDangKy = Convert.ToString(r["MaDangKy"]);
                MaBanSao = Convert.ToString(r["MaBanSaoGiu"]);
                TenTaiLieu = Convert.ToString(r["TenTaiLieu"]);
            }

            public int Id { get; private set; }
            public string MaDangKy { get; private set; }
            public string MaBanSao { get; private set; }
            public string TenTaiLieu { get; private set; }

            public override string ToString()
            {
                return MaDangKy + " – " + MaBanSao + " – " + TenTaiLieu;
            }
        }
    }
}
