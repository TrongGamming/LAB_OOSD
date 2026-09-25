using System;
using System.Data;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.11 – UC-QT-02: xét duyệt yêu cầu đặt mua (chấp nhận / từ chối / để sau).</summary>
    public partial class FrmDuyetDatMua : Form
    {
        private readonly DatMuaService _service = new DatMuaService();

        public FrmDuyetDatMua()
        {
            InitializeComponent();
        }

        private void FrmDuyetDatMua_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.AddRange(new object[]
            {
                new Muc("ChoDuyet", "Chờ duyệt"), new Muc("ChapNhan", "Chấp nhận"),
                new Muc("TuChoi", "Từ chối"), new Muc(null, "Tất cả")
            });
            cboTrangThai.SelectedIndex = 0;
            dtTu.Value = DateTime.Today.AddMonths(-3);
            dtDen.Value = DateTime.Today;
            try
            {
                cboTaiLieuLienKet.Items.Add(new Muc(null, "(Không liên kết)"));
                foreach (DataRow r in _service.LayTaiLieu().Rows)
                    cboTaiLieuLienKet.Items.Add(new Muc(Convert.ToString(r["MaTaiLieu"]),
                                                        r["MaTaiLieu"] + " – " + r["TenTaiLieu"]));
                cboTaiLieuLienKet.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
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
                DataTable t = _service.LayDanhSach(GridHelper.MaChon(cboTrangThai), dtTu.Value, dtDen.Value);
                t.Columns.Add("TrangThaiHienThi", typeof(string));
                foreach (DataRow r in t.Rows) r["TrangThaiHienThi"] = FrmDatMua.TenTrangThai(Convert.ToString(r["TrangThai"]));
                GridHelper.HienThi(dgvYeuCau, t,
                    "MaYeuCau", "Mã YC", "TenSach", "*Tên sách", "TacGia", "Tác giả", "NamXuatBan", "Năm",
                    "NguoiGui", "Người gửi", "NgayGui", "Ngày gửi", "SoNguoiDeNghi", "Số người đề nghị",
                    "TrangThaiHienThi", "Trạng thái");
                if (t.Rows.Count == 0) HienChiTiet(null);   // luồng 2.1: danh sách trống
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvYeuCau_SelectionChanged(object sender, EventArgs e)
        {
            HienChiTiet(GridHelper.DongChon(dgvYeuCau));
        }

        private void HienChiTiet(DataRowView v)
        {
            if (v == null)
            {
                lblChiTiet.Text = dgvYeuCau.Rows.Count == 0 ? "Không có yêu cầu nào phù hợp bộ lọc." : "Chọn một yêu cầu trong danh sách.";
                lblCanhBao.Text = "";
                btnLuu.Enabled = false;
                return;
            }
            lblChiTiet.Text = string.Format("{0}: \"{1}\" – {2} ({3}){4}. Lý do: {5}",
                v["MaYeuCau"], v["TenSach"], v["TacGia"], v["NamXuatBan"],
                v["NhaXuatBan"] == DBNull.Value ? "" : " – NXB " + v["NhaXuatBan"],
                v["LyDoDeNghi"] == DBNull.Value ? "(không ghi)" : v["LyDoDeNghi"]);
            bool choDuyet = Convert.ToString(v["TrangThai"]) == "ChoDuyet";
            btnLuu.Enabled = choDuyet;
            txtLyDo.Text = choDuyet ? "" : Convert.ToString(v["KetQuaGhiChu"]);
            try
            {
                // luồng 5.2: kiểm tra trùng danh mục, gợi ý liên kết tài liệu sẵn có
                DataTable trung = _service.KiemTraTrungDanhMuc(Convert.ToString(v["TenSach"]), Convert.ToString(v["TacGia"]));
                if (trung.Rows.Count == 0)
                {
                    lblCanhBao.Text = choDuyet ? "Không tìm thấy tài liệu tương tự trong danh mục." : "";
                    cboTaiLieuLienKet.SelectedIndex = 0;
                }
                else
                {
                    string ma = Convert.ToString(trung.Rows[0]["MaTaiLieu"]);
                    lblCanhBao.Text = "⚠ Danh mục đã có tài liệu tương tự: " + ma + " – " + trung.Rows[0]["TenTaiLieu"];
                    GridHelper.ChonTheoMa(cboTaiLieuLienKet, ma);
                }
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvYeuCau);
            if (v == null) return;
            if (rdoDeSau.Checked)   // luồng 5.3: giữ trạng thái Chờ duyệt
            {
                MessageBox.Show(this, "Yêu cầu vẫn ở trạng thái Chờ duyệt.", "Để lại xử lý sau", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdoTuChoi.Checked && string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show(this, "Phải nhập lý do khi từ chối.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);   // BR11
                txtLyDo.Focus();
                return;
            }
            KetQuaXuLy kq = _service.Duyet(Convert.ToInt32(v["Id"]), Phien.MaThuThu, rdoChapNhan.Checked ? "ChapNhan" : "TuChoi",
                                           txtLyDo.Text, GridHelper.MaChon(cboTaiLieuLienKet));
            GridHelper.ThongBao(this, kq, "Xét duyệt");
            txtLyDo.Clear();
            rdoChapNhan.Checked = true;
            NapDanhSach();   // thành công hoặc đã được thủ thư khác xử lý (luồng 6.1) đều làm mới danh sách
        }
    }
}
