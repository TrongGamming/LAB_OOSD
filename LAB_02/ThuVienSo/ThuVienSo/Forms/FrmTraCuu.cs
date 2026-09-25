using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>UC-TC-01..04 + UC-MT-01: tra cứu, xem chi tiết, đọc, tải về, đăng ký mượn.</summary>
    public partial class FrmTraCuu : Form
    {
        private readonly TaiLieuService _taiLieu = new TaiLieuService();
        private readonly MuonTraService _muonTra = new MuonTraService();
        private DataRow _chiTiet;

        public FrmTraCuu()
        {
            InitializeComponent();
        }

        private void FrmTraCuu_Load(object sender, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[]
            {
                new Muc(null, "Tất cả"), new Muc("Sach", "Sách"), new Muc("Bao", "Báo"),
                new Muc("TapChi", "Tạp chí"), new Muc("NgheNhin", "Nghe nhìn")
            });
            cboLoai.SelectedIndex = 0;
            try
            {
                cboChuDe.Items.Add(new Muc(null, "Tất cả"));
                foreach (DataRow r in _taiLieu.LayChuDe().Rows)
                    cboChuDe.Items.Add(new Muc(Convert.ToString(r["MaChuDe"]), Convert.ToString(r["TenChuDe"])));
                cboChuDe.SelectedIndex = 0;
                TimKiem(true);   // hiển thị toàn bộ danh mục khi mở form
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimKiem(false);
        }

        private void TimKiem(bool choPhepRong)
        {
            TieuChiTimKiem tc = new TieuChiTimKiem
            {
                TuKhoa = txtTuKhoa.Text,
                TacGia = txtTacGia.Text,
                NamXuatBan = (int)numNamXB.Value,
                LoaiTaiLieu = ((Muc)cboLoai.SelectedItem).Ma,
                MaChuDe = ((Muc)cboChuDe.SelectedItem).Ma,
                HinhThuc = rdoBanIn.Checked ? "BanIn" : rdoDienTu.Checked ? "DienTu" : null
            };
            if (tc.Rong && !choPhepRong)
            {
                MessageBox.Show("Nhập ít nhất một tiêu chí tìm kiếm.", "Tra cứu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                DataTable t = _taiLieu.TimKiem(tc);
                GridHelper.HienThi(dgvKetQua, t,
                    "MaTaiLieu", "Mã TL", "TenTaiLieu", "*Tên tài liệu", "TacGia", "Tác giả", "NamXuatBan", "Năm",
                    "LoaiTaiLieu", "Loại", "HinhThuc", "Hình thức", "SoLuongTon", "Còn");
                lblKetQua.Text = t.Rows.Count == 0 ? "Không tìm thấy tài liệu phù hợp." : "Kết quả: " + t.Rows.Count + " tài liệu";
                if (t.Rows.Count == 0) HienChiTiet(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLoc_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            txtTacGia.Clear();
            numNamXB.Value = 0;
            cboLoai.SelectedIndex = 0;
            cboChuDe.SelectedIndex = 0;
            rdoTatCa.Checked = true;
            TimKiem(true);
        }

        private void dgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvKetQua);
            if (v == null) return;
            try
            {
                HienChiTiet(_taiLieu.LayChiTiet(Convert.ToString(v["MaTaiLieu"])));
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienChiTiet(DataRow r)
        {
            _chiTiet = r;
            if (r == null)
            {
                lblChiTiet.Text = "Chọn một tài liệu trong danh sách.";
                txtMoTa.Clear();
                btnDocTrucTuyen.Enabled = btnTaiVe.Enabled = btnDangKyMuon.Enabled = false;
                return;
            }
            string hinhThuc = Convert.ToString(r["HinhThuc"]);
            bool coBanIn = hinhThuc != "DienTu";
            bool coDienTu = r["DinhDang"] != DBNull.Value;
            lblChiTiet.Text =
                "Mã: " + r["MaTaiLieu"] + Environment.NewLine +
                "Tên: " + r["TenTaiLieu"] + Environment.NewLine +
                "Tác giả: " + r["TacGia"] + Environment.NewLine +
                "NXB: " + (r["TenNXB"] == DBNull.Value ? "—" : r["TenNXB"]) + Environment.NewLine +
                "Năm XB: " + r["NamXuatBan"] + Environment.NewLine +
                "Chủ đề: " + r["TenChuDe"] + Environment.NewLine +
                "Hình thức: " + (hinhThuc == "BanIn" ? "Bản in" : hinhThuc == "DienTu" ? "Điện tử" : "Bản in + điện tử") + Environment.NewLine +
                (coBanIn ? "Tồn bản in: " + r["SoLuongTon"] + " / " + r["TongBanSao"] + Environment.NewLine : "") +
                (coDienTu ? "Tệp: " + r["DinhDang"] + " " + r["DungLuongMB"] + " MB" : "");
            txtMoTa.Text = Convert.ToString(r["MoTa"]);
            btnDocTrucTuyen.Enabled = coDienTu;                                             // BR01
            btnTaiVe.Enabled = coDienTu && Convert.ToBoolean(r["ChoPhepTai"]);
            btnDangKyMuon.Enabled = coBanIn && Convert.ToInt32(r["SoLuongTon"]) > 0;        // BR04
        }

        private void btnDocTrucTuyen_Click(object sender, EventArgs e)
        {
            string duongDan = Convert.ToString(_chiTiet["DuongDanTep"]);
            if (File.Exists(duongDan))
                Process.Start(duongDan);
            else
                MessageBox.Show("Mở trình xem trực tuyến cho tệp:" + Environment.NewLine + duongDan +
                                Environment.NewLine + "(tệp nằm trên file server của thư viện)",
                                "Đọc trực tuyến", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            string maThe = HoiMaThe();
            if (maThe == null) return;
            KetQuaXuLy kq = _taiLieu.TaiVe(maThe, Convert.ToString(_chiTiet["MaTaiLieu"]));
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongDiep, "Tải về", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nguon = (string)kq.DuLieu;
            if (!File.Exists(nguon))
            {
                MessageBox.Show(kq.ThongDiep + Environment.NewLine + "Tệp nguồn: " + nguon, "Tải về",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog dlg = new SaveFileDialog { FileName = Path.GetFileName(nguon) })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                File.Copy(nguon, dlg.FileName, true);
                MessageBox.Show("Tải về thành công.", "Tải về", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDangKyMuon_Click(object sender, EventArgs e)
        {
            string maThe = HoiMaThe();
            if (maThe == null) return;
            KetQuaXuLy kq = _muonTra.DangKyMuon(maThe, Convert.ToString(_chiTiet["MaTaiLieu"]));
            MessageBox.Show(kq.ThongDiep, "Đăng ký mượn", MessageBoxButtons.OK,
                            kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) dgvKetQua_SelectionChanged(null, EventArgs.Empty);   // cập nhật số tồn
        }

        /// <summary>UC-XT-01 (include): trả về mã thẻ hợp lệ hoặc null nếu người dùng hủy.</summary>
        private string HoiMaThe()
        {
            using (FrmNhapMaThe f = new FrmNhapMaThe())
                return f.ShowDialog(this) == DialogResult.OK ? f.MaThe : null;
        }
    }
}
