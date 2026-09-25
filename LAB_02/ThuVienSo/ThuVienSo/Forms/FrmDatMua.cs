using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.10 – UC-TK-03 gửi yêu cầu đặt mua, UC-TK-04 xem kết quả (bắt buộc đã đăng nhập).</summary>
    public partial class FrmDatMua : Form
    {
        private readonly DatMuaService _service = new DatMuaService();

        public FrmDatMua()
        {
            InitializeComponent();
        }

        private void FrmDatMua_Load(object sender, EventArgs e)
        {
            // UC-TK-03 «include» UC-TK-02: chỉ độc giả đã đăng nhập mới dùng được
            if (Phien.MaTaiKhoan == 0 || Phien.LaThuThu)
            {
                MessageBox.Show(this, "Chức năng đặt mua dành cho độc giả đã đăng nhập.", "Đặt mua",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            cboLocTrangThai.Items.AddRange(new object[]
            {
                new Muc(null, "Tất cả trạng thái"), new Muc("ChoDuyet", "Chờ duyệt"),
                new Muc("ChapNhan", "Chấp nhận"), new Muc("TuChoi", "Từ chối")
            });
            cboLocTrangThai.SelectedIndex = 0;   // kéo theo nạp danh sách
        }

        private void NapDanhSach()
        {
            try
            {
                DataTable t = _service.LayYeuCauCuaToi(Phien.MaTaiKhoan, GridHelper.MaChon(cboLocTrangThai));
                t.Columns.Add("TrangThaiHienThi", typeof(string));
                foreach (DataRow r in t.Rows)
                    r["TrangThaiHienThi"] = TenTrangThai(Convert.ToString(r["TrangThai"]));
                GridHelper.HienThi(dgvYeuCau, t,
                    "MaYeuCau", "Mã YC", "TenSach", "*Tên sách", "TacGia", "Tác giả", "NamXuatBan", "Năm",
                    "NgayGui", "Ngày gửi", "TrangThaiHienThi", "Trạng thái", "KetQuaGhiChu", "*Kết quả / lý do",
                    "MaTaiLieuLienKet", "Tài liệu liên kết");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        internal static string TenTrangThai(string tt)
        {
            return tt == "ChoDuyet" ? "Chờ duyệt" : tt == "ChapNhan" ? "Chấp nhận" : tt == "TuChoi" ? "Từ chối" : tt;
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            NapDanhSach();
        }

        private bool KiemTraNhap()
        {
            errProvider.Clear();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(txtTenSach.Text)) { errProvider.SetError(txtTenSach, "Bắt buộc nhập tên sách"); ok = false; }
            if (string.IsNullOrWhiteSpace(txtTacGia.Text)) { errProvider.SetError(txtTacGia, "Bắt buộc nhập tác giả"); ok = false; }
            return ok;   // năm XB là NumericUpDown nên luôn có giá trị hợp lệ
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            lblGuiKetQua.Text = "";
            if (!KiemTraNhap()) return;   // BR10
            KetQuaXuLy kq = _service.GuiYeuCau(Phien.MaTaiKhoan, txtTenSach.Text, txtTacGia.Text, (int)numNamXB.Value,
                                               txtNXB.Text, txtLyDo.Text);
            if (!kq.ThanhCong)
            {
                GridHelper.ThongBao(this, kq, "Gửi yêu cầu");
                return;
            }
            lblGuiKetQua.Text = kq.ThongDiep;
            btnNhapLai_Click(null, EventArgs.Empty);
            cboLocTrangThai.SelectedIndex = 0;
            NapDanhSach();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNXB.Clear();
            txtLyDo.Clear();
            numNamXB.Value = DateTime.Today.Year;
            errProvider.Clear();
            txtTenSach.Focus();
        }
    }
}
