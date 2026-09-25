using System;
using System.Windows.Forms;
using ThuVienSo.Services;

namespace ThuVienSo.Forms
{
    /// <summary>6.3 – Trang chủ: điều hướng theo vai trò, không thao tác nghiệp vụ trực tiếp.</summary>
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bool thuThu = Phien.LaThuThu;
            lblXinChao.Text = string.Format("Xin chào: {0}  –  Vai trò: {1}", Phien.HoTen, thuThu ? "Thủ thư" : "Độc giả");
            // BR15: chức năng quản trị chỉ dành cho thủ thư; độc giả có thêm Đặt mua
            foreach (Button b in new[] { btnDanhMuc, btnTaiLieu, btnDocGia, btnMuonTra, btnDuyetDatMua, btnBaoCao, btnNhatKyEmail })
                b.Visible = thuThu;
            btnDatMua.Visible = !thuThu;
            lblTrangThai.Text = string.Format("Đăng nhập lúc {0:HH:mm dd/MM/yyyy}  |  Tài khoản: {1}", DateTime.Now, Phien.TenDangNhap);
        }

        private void Mo(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        private void btnTraCuu_Click(object sender, EventArgs e) { Mo(new FrmTraCuu()); }
        private void btnDanhMuc_Click(object sender, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnTaiLieu_Click(object sender, EventArgs e) { Mo(new FrmTaiLieu()); }
        private void btnDocGia_Click(object sender, EventArgs e) { Mo(new FrmDocGia()); }
        private void btnMuonTra_Click(object sender, EventArgs e) { Mo(new FrmMuonTra()); }
        private void btnDuyetDatMua_Click(object sender, EventArgs e) { Mo(new FrmDuyetDatMua()); }
        private void btnBaoCao_Click(object sender, EventArgs e) { Mo(new FrmBaoCao()); }
        private void btnNhatKyEmail_Click(object sender, EventArgs e) { Mo(new FrmNhatKyEmail()); }
        private void btnDatMua_Click(object sender, EventArgs e) { Mo(new FrmDatMua()); }
        private void btnDoiMatKhau_Click(object sender, EventArgs e) { Mo(new FrmDoiMatKhau()); }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (!GridHelper.XacNhan(this, "Bạn muốn đăng xuất?")) return;
            Phien.DangXuat();
            DialogResult = DialogResult.Retry;   // Program hiển thị lại FrmDangNhap
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (GridHelper.XacNhan(this, "Thoát chương trình?")) DialogResult = DialogResult.Cancel;
        }
    }
}
