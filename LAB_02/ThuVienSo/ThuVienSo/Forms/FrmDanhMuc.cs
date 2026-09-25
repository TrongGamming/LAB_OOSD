using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>UC-QT-01 (phần danh mục): CRUD chủ đề, tác giả, nhà xuất bản dùng chung một bộ ô nhập.</summary>
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService _service = new DanhMucService();
        private LoaiDanhMuc _loai = LoaiDanhMuc.ChuDe;
        private bool _themMoi;
        private bool _dangNhap;   // đang ở chế độ Thêm/Sửa

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            DoiLoai();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNhap) CheDo(false);
            _loai = tabs.SelectedIndex == 0 ? LoaiDanhMuc.ChuDe
                  : tabs.SelectedIndex == 1 ? LoaiDanhMuc.TacGia : LoaiDanhMuc.NhaXuatBan;
            DoiLoai();
        }

        private void DoiLoai()
        {
            if (_loai == LoaiDanhMuc.ChuDe)
                DatNhan("Mã chủ đề", "Tên chủ đề *", "Mô tả", null);
            else if (_loai == LoaiDanhMuc.TacGia)
                DatNhan("Mã tác giả", "Tên tác giả *", "Ghi chú", null);
            else
                DatNhan("Mã NXB", "Tên NXB *", "Địa chỉ", "Điện thoại");
            NapLuoi();
        }

        private void DatNhan(string ma, string t1, string t2, string t3)
        {
            lblMa.Text = ma;
            lbl1.Text = t1;
            lbl2.Text = t2;
            lbl3.Visible = txt3.Visible = t3 != null;
            if (t3 != null) lbl3.Text = t3;
        }

        private void NapLuoi()
        {
            try
            {
                dgv.DataSource = _service.LayDanhSach(_loai);
                dgv.Columns[0].HeaderText = lblMa.Text;
                dgv.Columns[1].HeaderText = lbl1.Text.TrimEnd(' ', '*');
                dgv.Columns[2].HeaderText = lbl2.Text;
                if (dgv.Columns.Count > 3) dgv.Columns[3].HeaderText = lbl3.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(KetQuaXuLy.TuLoi(ex).ThongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNhap) return;
            DataRowView v = GridHelper.DongChon(dgv);
            if (v == null) return;
            txtMa.Text = Convert.ToString(v[0]);
            txt1.Text = Convert.ToString(v[1]);
            txt2.Text = Convert.ToString(v[2]);
            txt3.Text = v.Row.Table.Columns.Count > 3 ? Convert.ToString(v[3]) : "";
        }

        /// <summary>Bật/tắt chế độ nhập: điều khiển Enabled/ReadOnly để người dùng không hiểu nhầm.</summary>
        private void CheDo(bool nhap)
        {
            _dangNhap = nhap;
            txtMa.ReadOnly = !(nhap && _themMoi);   // mã chỉ được nhập khi thêm mới
            txt1.ReadOnly = txt2.ReadOnly = txt3.ReadOnly = !nhap;
            btnLuu.Enabled = btnHuy.Enabled = nhap;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = !nhap;
            dgv.Enabled = !nhap;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _themMoi = true;
            txtMa.Clear();
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            CheDo(true);
            txtMa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0) return;
            _themMoi = false;
            CheDo(true);
            txt1.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            KetQuaXuLy kq = _service.Luu(_loai, _themMoi, ma, new[] { txt1.Text, txt2.Text, txt3.Text });
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongDiep, "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);   // giữ nguyên dữ liệu đã nhập
                return;
            }
            CheDo(false);
            NapLuoi();
            ChonDong(ma);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            CheDo(false);
            dgv_SelectionChanged(null, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length == 0) return;
            if (MessageBox.Show("Xóa " + lblMa.Text.ToLower() + " " + txtMa.Text + "?", "Xác nhận",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            KetQuaXuLy kq = _service.Xoa(_loai, txtMa.Text);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongDiep, "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);   // BR14
                return;
            }
            NapLuoi();
        }

        private void ChonDong(string ma)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                if (Convert.ToString(row.Cells[0].Value) == ma)
                {
                    dgv.CurrentCell = row.Cells[0];
                    return;
                }
        }
    }
}
