using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.7 – UC-QT-01: quản lý tài liệu, tệp sách điện tử và bản sao bản in.</summary>
    public partial class FrmTaiLieu : Form
    {
        private readonly TaiLieuService _service = new TaiLieuService();
        private bool _themMoi;
        private bool _dangNhap;   // đang ở chế độ Thêm/Sửa

        public FrmTaiLieu()
        {
            InitializeComponent();
        }

        private void FrmTaiLieu_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { new Muc("Sach", "Sách"), new Muc("Bao", "Báo"), new Muc("TapChi", "Tạp chí"), new Muc("NgheNhin", "Nghe nhìn") });
            cboHinhThuc.Items.AddRange(new object[] { new Muc("BanIn", "Bản in"), new Muc("DienTu", "Điện tử"), new Muc("CaHai", "Cả hai") });
            cboDinhDang.Items.AddRange(new object[] { new Muc("PDF", "PDF"), new Muc("EPUB", "EPUB"), new Muc("MP3", "MP3"), new Muc("MP4", "MP4") });
            cboTinhTrangBS.Items.AddRange(new object[] { new Muc("SanSang", "Sẵn sàng"), new Muc("CanKiemTra", "Cần kiểm tra"), new Muc("Mat", "Mất"), new Muc("ThanhLy", "Thanh lý") });
            cboLoai.SelectedIndex = cboHinhThuc.SelectedIndex = cboDinhDang.SelectedIndex = cboTinhTrangBS.SelectedIndex = 0;
            try
            {
                foreach (DataRow r in _service.LayChuDe().Rows)
                    cboChuDe.Items.Add(new Muc(Convert.ToString(r["MaChuDe"]), Convert.ToString(r["TenChuDe"])));
                cboNXB.Items.Add(new Muc(null, "(Không có)"));
                foreach (DataRow r in _service.LayNXB().Rows)
                    cboNXB.Items.Add(new Muc(Convert.ToString(r["MaNXB"]), Convert.ToString(r["TenNXB"])));
                foreach (DataRow r in _service.LayTacGia().Rows)
                    clbTacGia.Items.Add(new Muc(Convert.ToString(r["MaTacGia"]), Convert.ToString(r["TenTacGia"])));
                CheDo(false);
                NapLuoi(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapLuoi(string chonMa)
        {
            GridHelper.HienThi(dgvTaiLieu, _service.LayDanhSach(txtTim.Text),
                "MaTaiLieu", "Mã", "TenTaiLieu", "*Tên tài liệu", "TenChuDe", "Chủ đề", "TenNXB", "NXB",
                "NamXuatBan", "Năm", "HinhThuc", "Hình thức", "SoLuongTon", "Còn", "TongBanSao", "Tổng bản");
            if (chonMa == null) return;
            foreach (DataGridViewRow row in dgvTaiLieu.Rows)
                if (Convert.ToString(row.Cells["MaTaiLieu"].Value) == chonMa)
                {
                    dgvTaiLieu.CurrentCell = row.Cells["MaTaiLieu"];
                    break;
                }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (_dangNhap) return;
            try { NapLuoi(null); }
            catch (Exception ex) { GridHelper.LoiHeThong(this, ex); }
        }

        private void dgvTaiLieu_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNhap) return;
            DataRowView v = GridHelper.DongChon(dgvTaiLieu);
            if (v == null) return;
            try
            {
                DataRow r = _service.LayChiTiet(Convert.ToString(v["MaTaiLieu"]));
                if (r == null) return;
                txtMa.Text = Convert.ToString(r["MaTaiLieu"]);
                txtTen.Text = Convert.ToString(r["TenTaiLieu"]);
                txtMoTa.Text = Convert.ToString(r["MoTa"]);
                GridHelper.ChonTheoMa(cboLoai, Convert.ToString(r["LoaiTaiLieu"]));
                GridHelper.ChonTheoMa(cboHinhThuc, Convert.ToString(r["HinhThuc"]));
                GridHelper.ChonTheoMa(cboChuDe, Convert.ToString(r["MaChuDe"]));
                GridHelper.ChonTheoMa(cboNXB, r["MaNXB"] == DBNull.Value ? null : Convert.ToString(r["MaNXB"]));
                numNam.Value = Convert.ToDecimal(r["NamXuatBan"]);
                bool coTep = r["DinhDang"] != DBNull.Value;
                txtDuongDanTep.Text = coTep ? Convert.ToString(r["DuongDanTep"]) : "";
                GridHelper.ChonTheoMa(cboDinhDang, coTep ? Convert.ToString(r["DinhDang"]) : "PDF");
                numDungLuong.Value = coTep ? Convert.ToDecimal(r["DungLuongMB"]) : 0;
                chkChoPhepTai.Checked = !coTep || Convert.ToInt32(r["ChoPhepTai"]) == 1;
                List<string> tacGia = _service.LayMaTacGiaCua(txtMa.Text);
                for (int i = 0; i < clbTacGia.Items.Count; i++)
                    clbTacGia.SetItemChecked(i, tacGia.Contains(((Muc)clbTacGia.Items[i]).Ma));
                NapBanSao();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapBanSao()
        {
            GridHelper.HienThi(dgvBanSao, _service.LayBanSao(txtMa.Text),
                "MaBanSao", "Mã bản sao", "ViTriKe", "Kệ", "TinhTrang", "Tình trạng");
            grpBanSao.Enabled = !_dangNhap && GridHelper.MaChon(cboHinhThuc) != "DienTu" && txtMa.Text.Length > 0;
        }

        private void cboHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ht = GridHelper.MaChon(cboHinhThuc);
            grpDienTu.Enabled = _dangNhap && ht != "BanIn";
        }

        /// <summary>Bật/tắt chế độ nhập; mã tài liệu chỉ sửa được khi thêm mới (ReadOnly khi Sửa).</summary>
        private void CheDo(bool nhap)
        {
            _dangNhap = nhap;
            txtMa.ReadOnly = !(nhap && _themMoi);
            txtTen.ReadOnly = txtMoTa.ReadOnly = !nhap;
            cboLoai.Enabled = cboHinhThuc.Enabled = cboChuDe.Enabled = cboNXB.Enabled = numNam.Enabled = clbTacGia.Enabled = nhap;
            grpDienTu.Enabled = nhap && GridHelper.MaChon(cboHinhThuc) != "BanIn";
            btnLuu.Enabled = btnHuy.Enabled = nhap;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = txtTim.Enabled = dgvTaiLieu.Enabled = !nhap;
            grpBanSao.Enabled = !nhap && txtMa.Text.Length > 0 && GridHelper.MaChon(cboHinhThuc) != "DienTu";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _themMoi = true;
            try { txtMa.Text = _service.MaTaiLieuMoi(); }
            catch (Exception ex) { GridHelper.LoiHeThong(this, ex); return; }
            txtTen.Clear();
            txtMoTa.Clear();
            txtDuongDanTep.Clear();
            numDungLuong.Value = 0;
            chkChoPhepTai.Checked = true;
            cboLoai.SelectedIndex = cboHinhThuc.SelectedIndex = cboDinhDang.SelectedIndex = 0;
            cboNXB.SelectedIndex = 0;
            if (cboChuDe.Items.Count > 0) cboChuDe.SelectedIndex = 0;
            numNam.Value = DateTime.Today.Year;
            for (int i = 0; i < clbTacGia.Items.Count; i++) clbTacGia.SetItemChecked(i, false);
            dgvBanSao.DataSource = null;
            CheDo(true);
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0) return;
            _themMoi = false;
            CheDo(true);
            txtTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<string> tacGia = new List<string>();
            foreach (Muc m in clbTacGia.CheckedItems) tacGia.Add(m.Ma);
            TaiLieuInfo tl = new TaiLieuInfo
            {
                MaTaiLieu = txtMa.Text,
                TenTaiLieu = txtTen.Text,
                LoaiTaiLieu = GridHelper.MaChon(cboLoai),
                HinhThuc = GridHelper.MaChon(cboHinhThuc),
                MaChuDe = GridHelper.MaChon(cboChuDe),
                MaNXB = GridHelper.MaChon(cboNXB),
                NamXuatBan = (int)numNam.Value,
                MoTa = txtMoTa.Text,
                MaTacGia = tacGia,
                DuongDanTep = txtDuongDanTep.Text,
                DinhDang = GridHelper.MaChon(cboDinhDang),
                DungLuongMB = numDungLuong.Value,
                ChoPhepTai = chkChoPhepTai.Checked
            };
            KetQuaXuLy kq = _service.Luu(_themMoi, tl);
            if (!kq.ThanhCong)
            {
                GridHelper.ThongBao(this, kq, "Lưu tài liệu");   // giữ nguyên dữ liệu đã nhập
                return;
            }
            CheDo(false);
            NapLuoi(txtMa.Text.Trim().ToUpperInvariant());
            if (_themMoi && tl.HinhThuc != "DienTu")
                MessageBox.Show(this, kq.ThongDiep + Environment.NewLine + "Hãy thêm bản sao cho tài liệu bản in ở khung bên phải.",
                                "Lưu tài liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            CheDo(false);
            dgvTaiLieu_SelectionChanged(null, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0 || !GridHelper.XacNhan(this, "Xóa tài liệu " + txtMa.Text + " cùng toàn bộ bản sao?")) return;
            KetQuaXuLy kq = _service.Xoa(txtMa.Text);
            GridHelper.ThongBao(this, kq, "Xóa tài liệu");
            if (kq.ThanhCong) NapLuoi(null);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            try { NapLuoi(txtMa.Text); }
            catch (Exception ex) { GridHelper.LoiHeThong(this, ex); }
        }

        private void btnChonTep_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog { Filter = "Tài liệu số|*.pdf;*.epub;*.mp3;*.mp4|Tất cả|*.*" })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                txtDuongDanTep.Text = dlg.FileName;
                string duoi = Path.GetExtension(dlg.FileName).TrimStart('.').ToUpperInvariant();
                GridHelper.ChonTheoMa(cboDinhDang, duoi);
                numDungLuong.Value = Math.Max(0.01m, Math.Round(new FileInfo(dlg.FileName).Length / 1048576m, 2));
            }
        }

        // ------------------------------------------------------------ bản sao
        private void btnThemBanSao_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _service.ThemBanSao(txtMa.Text, (int)numSoBan.Value, txtViTriKe.Text);
            if (!kq.ThanhCong) { GridHelper.ThongBao(this, kq, "Thêm bản sao"); return; }
            NapBanSao();
            NapLuoi(txtMa.Text);
        }

        private void btnDoiTinhTrang_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvBanSao);
            if (v == null) return;
            KetQuaXuLy kq = _service.DoiTinhTrangBanSao(Convert.ToString(v["MaBanSao"]), GridHelper.MaChon(cboTinhTrangBS));
            if (!kq.ThanhCong) { GridHelper.ThongBao(this, kq, "Đổi tình trạng"); return; }
            NapBanSao();
            NapLuoi(txtMa.Text);
        }

        private void btnXoaBanSao_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvBanSao);
            if (v == null || !GridHelper.XacNhan(this, "Xóa bản sao " + v["MaBanSao"] + "?")) return;
            KetQuaXuLy kq = _service.XoaBanSao(Convert.ToString(v["MaBanSao"]));
            if (!kq.ThanhCong)
            {
                MessageBox.Show(this, kq.ThongDiep + Environment.NewLine + "Bản sao đã có lịch sử mượn: hãy đổi tình trạng sang Thanh lý.",
                                "Xóa bản sao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NapBanSao();
            NapLuoi(txtMa.Text);
        }
    }
}
