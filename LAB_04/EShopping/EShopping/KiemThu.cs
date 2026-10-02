using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EShopping.Data;
using EShopping.Forms;
using EShopping.Services;
using Oracle.ManagedDataAccess.Client;

namespace EShopping
{
    /// <summary>
    /// Kịch bản kiểm thử chạy trên CSDL Oracle thật (EShopping.exe /kiemthu ketqua.txt) và
    /// chế độ chụp ảnh các form cho báo cáo (EShopping.exe /chupanh thu_muc).
    /// </summary>
    internal static class KiemThu
    {
        private static readonly StringBuilder _log = new StringBuilder();
        private static int _dat, _truot;

        private static void Ghi(string s)
        {
            _log.AppendLine(s);
        }

        private static void Kiem(string ma, string moTa, bool ok, string chiTiet)
        {
            if (ok) _dat++; else _truot++;
            Ghi(string.Format("[{0}] {1,-6} {2} -> {3}", ok ? "PASS" : "FAIL", ma, moTa, chiTiet));
        }

        public static int ChayKichBan(string fileKetQua)
        {
            string maKH = null;
            try
            {
                Ghi("KIỂM THỬ END-TO-END e-SHOPPING – " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                Ghi("Chuỗi kết nối: " + Db.ConnectionString.Replace("Password=eshop123", "Password=***"));
                Ghi("");
                string kn = HeThong.KiemTraKetNoi();
                Kiem("KT01", "Kết nối Oracle", kn.StartsWith("ESHOP@"), kn);

                // ---- UC04 Đăng ký
                string ten = "kt" + DateTime.Now.ToString("HHmmssfff");
                string cmnd = "0" + DateTime.Now.ToString("yyMMddHHmmss").Substring(1);
                KhachHangDto kh = new KhachHangDto
                {
                    HoTen = "Khách Kiểm Thử", NgaySinh = new DateTime(1999, 1, 1), SoGiayTo = cmnd,
                    DiaChi = "1 Võ Văn Ngân, Thủ Đức", DienThoai = "0909000111", Email = ten + "@example.com", TenDangNhap = ten
                };
                KetQuaXuLy kq = HeThong.TaiKhoan.DangKy(kh, "Abc@123", "Abc@999");
                Kiem("KT02", "Đăng ký: mật khẩu nhập lại không khớp", !kq.ThanhCong, kq.ThongBao);
                kq = HeThong.TaiKhoan.DangKy(kh, "Abc@123", "Abc@123");
                Kiem("KT03", "Đăng ký hợp lệ", kq.ThanhCong, kq.ThongBao);
                maKH = kq.DuLieu as string;
                kq = HeThong.TaiKhoan.DangKy(kh, "Abc@123", "Abc@123");
                Kiem("KT04", "Đăng ký trùng tên đăng nhập/CMND", !kq.ThanhCong, kq.ThongBao);

                // ---- UC03 Giỏ hàng của khách vãng lai
                PhienLamViec.DangXuat();
                kq = HeThong.GioHang.ThemVaoGio(0, null, "SP004", 1);
                Kiem("KT05", "Thêm sản phẩm HẾT HÀNG vào giỏ", !kq.ThanhCong, kq.ThongBao);
                kq = HeThong.GioHang.ThemVaoGio(0, null, "SP003", 1);
                Kiem("KT06", "Khách vãng lai thêm SP003 (tạo giỏ mới)", kq.ThanhCong, kq.ThongBao);
                PhienLamViec.MaGioHang = (long)kq.DuLieu;
                kq = HeThong.GioHang.ThemVaoGio(PhienLamViec.MaGioHang, null, "SP006", 1);
                HeThong.GioHang.ThemVaoGio(PhienLamViec.MaGioHang, null, "SP006", 1);
                int sl = HeThong.GioHang.DemSoLuong(PhienLamViec.MaGioHang);
                Kiem("KT07", "Thêm SP006 hai lần → cộng dồn", sl == 3, "tổng số lượng trong giỏ = " + sl);
                kq = HeThong.GioHang.CapNhatSoLuong(PhienLamViec.MaGioHang, "SP006", 0);
                Kiem("KT08", "Cập nhật số lượng = 0", !kq.ThanhCong, kq.ThongBao);

                // ---- UC05 Đăng nhập + gộp giỏ
                kq = HeThong.TaiKhoan.DangNhap(ten, "sai-mat-khau");
                Kiem("KT09", "Đăng nhập sai mật khẩu", !kq.ThanhCong, kq.ThongBao);
                long gioTam = PhienLamViec.MaGioHang;
                kq = HeThong.TaiKhoan.DangNhap(ten, "Abc@123");
                Kiem("KT10", "Đăng nhập đúng, giỏ tạm gán cho khách", kq.ThanhCong && PhienLamViec.MaGioHang == gioTam
                     && PhienLamViec.MaNguoiDung == maKH, kq.ThongBao + " (giỏ " + PhienLamViec.MaGioHang + ")");

                // ---- UC07 Tính tiền: 1.890.000 + 2 x 450.000 = 2.790.000
                BangTinhTien b = HeThong.DatHang.TinhTien(PhienLamViec.MaGioHang, "CPN", "HN", "VISA");
                Kiem("KT11", "Tiền hàng theo giá hiện hành", b.TongTienHang == 2790000m, b.TongTienHang.ToString("#,##0"));
                Kiem("KT12", "CPN, tiền hàng >= 1 triệu → miễn phí giao", b.PhiGiaoHang == 0 && b.DuocMienPhi,
                     "phí gốc " + b.PhiGiaoGoc.ToString("#,##0") + ", phí áp dụng " + b.PhiGiaoHang.ToString("#,##0"));
                b = HeThong.DatHang.TinhTien(PhienLamViec.MaGioHang, "CPN_NGAY", "HN", "AMEX");
                Kiem("KT13", "CPN trong ngày, tiền hàng < 5 triệu → tính phí miền Bắc", b.PhiGiaoHang == 180000m && b.LePhiThe == 12000m,
                     "phí " + b.PhiGiaoHang.ToString("#,##0") + ", lệ phí AmEx " + b.LePhiThe.ToString("#,##0"));

                YeuCauDatHang yc = new YeuCauDatHang
                {
                    MaKH = PhienLamViec.MaNguoiDung, MaGioHang = PhienLamViec.MaGioHang, MaLoaiPhieu = "CPN",
                    NguoiNhan = "Nguyễn Thị Hoa", DienThoai = "0987654321", DiaChi = "88 Nguyễn Huệ", MaTinh = "HN",
                    MaLoaiThe = "AMEX", SoThe = "4111 1111 1111 1111", Csv = "123", ThangHetHan = 12, NamHetHan = DateTime.Today.Year + 2,
                    TenChuThe = "KHACH KIEM THU"
                };
                kq = HeThong.DatHang.DatHang(yc);
                Kiem("KT14", "Thẻ AmEx nhập 16 chữ số", !kq.ThanhCong, kq.ThongBao);
                yc.MaLoaiThe = "VISA";
                yc.SoThe = "4111 1111 1111 1112";
                kq = HeThong.DatHang.DatHang(yc);
                Kiem("KT15", "Số thẻ sai chữ số kiểm tra (Luhn)", !kq.ThanhCong, kq.ThongBao);
                yc.SoThe = "4111111111111111";
                yc.ThangHetHan = 1;
                yc.NamHetHan = DateTime.Today.Year - 1;
                kq = HeThong.DatHang.DatHang(yc);
                Kiem("KT16", "Thẻ đã hết hạn", !kq.ThanhCong, kq.ThongBao);
                yc.ThangHetHan = 12;
                yc.NamHetHan = DateTime.Today.Year + 2;
                yc.SoThe = "4000000000000002";
                kq = HeThong.DatHang.DatHang(yc);
                object tuChoi = Db.Scalar("SELECT COUNT(*) FROM NhatKyThanhToan WHERE MaKH = :kh AND KetQua = N'Từ chối'",
                                          new OracleParameter("kh", maKH));
                Kiem("KT17", "Hệ thống thanh toán từ chối (không đủ khả năng)", !kq.ThanhCong && Convert.ToInt32(tuChoi) == 1,
                     kq.ThongBao + " | nhật ký từ chối = " + tuChoi);

                yc.SoThe = "4111 1111 1111 1111";
                kq = HeThong.DatHang.DatHang(yc);
                string soDon = kq.DuLieu as string;
                Kiem("KT18", "Đặt hàng thành công bằng thẻ VISA hợp lệ", kq.ThanhCong, kq.ThongBao);
                if (soDon != null)
                {
                    DataTable d = Db.Query(@"SELECT d.TongTienHang, d.PhiGiaoHang, d.LePhiThe, d.TongTriGia, d.TrangThai, d.DaGuiEmail,
                                                    t.SoTheAn, t.TokenThanhToan
                                             FROM DonDatHang d JOIN TheTinDung t ON t.MaThe = d.MaThe WHERE d.SoDonHang = :so",
                                           new OracleParameter("so", soDon));
                    DataRow r = d.Rows[0];
                    Kiem("KT19", "Đơn lưu đúng tổng trị giá (2.790.000 + 0 + 5.000)", Convert.ToDecimal(r["TongTriGia"]) == 2795000m
                         && Convert.ToString(r["TrangThai"]) == "Chờ xử lý",
                         "TongTriGia = " + Convert.ToDecimal(r["TongTriGia"]).ToString("#,##0") + ", " + r["TrangThai"]);
                    Kiem("KT20", "Không lưu số thẻ đầy đủ / CSV", Convert.ToString(r["SoTheAn"]) == "**** **** **** 1111",
                         r["SoTheAn"] + " | " + r["TokenThanhToan"]);
                    object ct = Db.Scalar("SELECT COUNT(*) FROM ChiTietDonHang WHERE SoDonHang = :so", new OracleParameter("so", soDon));
                    object gio = Db.Scalar("SELECT TrangThai FROM GioHang WHERE MaGioHang = :g", new OracleParameter("g", yc.MaGioHang));
                    Kiem("KT21", "Chi tiết đơn + giỏ chuyển trạng thái", Convert.ToInt32(ct) == 2 && Convert.ToString(gio) == "Đã chuyển thành đơn",
                         ct + " dòng chi tiết, giỏ: " + gio);
                    string noiDung = Convert.ToString(Db.Scalar("SELECT NoiDung FROM NhatKyEmail WHERE SoDonHang = :so",
                                                                new OracleParameter("so", soDon)));
                    Kiem("KT22", "Gửi email xác nhận KHÔNG chứa thông tin thẻ", Convert.ToString(r["DaGuiEmail"]) == "Y"
                         && noiDung.Length > 0 && !noiDung.Contains("1111") && !noiDung.Contains("VISA"),
                         "DaGuiEmail = " + r["DaGuiEmail"] + ", file: " + ((Gateways.EmailFileSender)HeThong.Email).FileCuoi);

                    // ---- UC09 Xử lý đơn / UC08 Hủy đơn
                    kq = HeThong.DonHang.ChuyenTrangThai(soDon, DonHangService.DaGiao);
                    Kiem("KT23", "Chuyển Chờ xử lý → Đã giao (không hợp lệ)", !kq.ThanhCong, kq.ThongBao);
                    kq = HeThong.DonHang.ChuyenTrangThai(soDon, DonHangService.DangXuLy);
                    Kiem("KT24", "Chuyển Chờ xử lý → Đang xử lý", kq.ThanhCong, kq.ThongBao);
                    kq = HeThong.DonHang.HuyDon(soDon, maKH);
                    Kiem("KT25", "Khách hủy đơn đang xử lý", !kq.ThanhCong, kq.ThongBao);
                    kq = HeThong.DonHang.ChuyenTrangThai(soDon, DonHangService.DaHuy);
                    object hoan = Db.Scalar("SELECT COUNT(*) FROM NhatKyThanhToan WHERE MaKH = :kh AND KetQua = N'Hoàn tiền'",
                                            new OracleParameter("kh", maKH));
                    Kiem("KT26", "Nhân viên hủy đơn → hoàn tiền", kq.ThanhCong && Convert.ToInt32(hoan) == 1, kq.ThongBao);
                }
            }
            catch (Exception ex)
            {
                Kiem("LOI", "Ngoại lệ không mong đợi", false, ex.ToString());
            }
            finally
            {
                DonDep(maKH);
                PhienLamViec.DangXuat();
            }
            Ghi("");
            Ghi(string.Format("KẾT QUẢ: {0} đạt, {1} không đạt (dữ liệu thử đã được dọn khỏi CSDL).", _dat, _truot));
            File.WriteAllText(fileKetQua, _log.ToString(), new UTF8Encoding(true));
            return _truot;
        }

        /// <summary>Xóa khách hàng thử và mọi dữ liệu liên quan để CSDL giữ nguyên dữ liệu mẫu.</summary>
        private static void DonDep(string maKH)
        {
            if (maKH == null) return;
            Db.Transaction((cn, tx) =>
            {
                OracleParameter p() => new OracleParameter("kh", maKH);
                Db.Execute(cn, tx, "DELETE FROM DonDatHang WHERE MaKH = :kh", p());
                Db.Execute(cn, tx, "DELETE FROM NhatKyThanhToan WHERE MaKH = :kh", p());
                Db.Execute(cn, tx, "DELETE FROM TheTinDung WHERE MaKH = :kh", p());
                Db.Execute(cn, tx, "DELETE FROM GioHang WHERE MaKH = :kh", p());
                Db.Execute(cn, tx, "DELETE FROM KhachHang WHERE MaKH = :kh", p());
            });
        }

        // ================================================================ chụp ảnh form
        public static int ChupAnh(string thuMuc)
        {
            Directory.CreateDirectory(thuMuc);
            List<string> loi = new List<string>();
            Action<string, Func<Form>, Action<Form>> chup = (ten, tao, chuanBi) =>
            {
                try
                {
                    using (Form f = tao())
                    {
                        f.StartPosition = FormStartPosition.Manual;
                        f.Location = new Point(40, 40);
                        f.WindowState = FormWindowState.Normal;
                        f.ShowInTaskbar = false;
                        f.Show();
                        Application.DoEvents();
                        if (chuanBi != null) chuanBi(f);
                        Application.DoEvents();
                        using (Bitmap bmp = new Bitmap(f.Width, f.Height))
                        {
                            f.DrawToBitmap(bmp, new Rectangle(0, 0, f.Width, f.Height));
                            bmp.Save(Path.Combine(thuMuc, ten + ".png"), ImageFormat.Png);
                        }
                        f.Close();
                    }
                }
                catch (Exception ex)
                {
                    loi.Add(ten + ": " + ex.Message);
                }
            };

            // Khách vãng lai
            PhienLamViec.DangXuat();
            chup("FrmMain_KhachVangLai", () => new FrmMain(), null);
            chup("FrmDangNhap", () => new FrmDangNhap(), f => ((TextBox)f.Controls["txtTen"]).Text = "an.nv");
            chup("FrmDangKy", () => new FrmDangKy(), f =>
            {
                f.Controls["txtHoTen"].Text = "Lê Minh Châu";
                f.Controls["txtSoGiayTo"].Text = "079201001122";
                f.Controls["txtDiaChi"].Text = "25 Nguyễn Trãi, Quận 5";
                f.Controls["txtDienThoai"].Text = "0938111222";
                f.Controls["txtEmail"].Text = "chau.lm@example.com";
                f.Controls["txtTenDN"].Text = "chau.lm";
                f.Controls["txtMatKhau"].Text = "Abc@123";
                f.Controls["txtNhapLai"].Text = "Abc@123";
            });

            // Khách hàng an.nv (giỏ mẫu có 2 mặt hàng)
            HeThong.TaiKhoan.DangNhap("an.nv", "Eshop@123");
            chup("FrmMain_KhachHang", () => new FrmMain(), null);
            chup("FrmSanPham", () => new FrmSanPham(), f =>
            {
                FrmSanPham sp = (FrmSanPham)f;
                sp.ChonNhom(1);
                Application.DoEvents();
                sp.ChonSanPham("SP001");
            });
            chup("FrmGioHang", () => new FrmGioHang(), null);
            chup("FrmDatHang", () => new FrmDatHang(), f =>
                ((FrmDatHang)f).DienMau("HUE", true, "VISA", "4111 1111 1111 1111", "123", "NGUYEN VAN AN"));
            chup("FrmDonHang_KhachHang", () => new FrmDonHang(), null);

            // Nhân viên quản trị
            HeThong.TaiKhoan.DangNhap("admin", "Eshop@123");
            chup("FrmMain_NhanVien", () => new FrmMain(), null);
            chup("FrmDonHang_NhanVien", () => new FrmDonHang(), null);
            for (int i = 0; i < 4; i++)
            {
                int tab = i;
                chup("FrmQuanTri_tab" + (i + 1), () => new FrmQuanTri(), f => ((FrmQuanTri)f).ChonTab(tab));
            }
            PhienLamViec.DangXuat();
            File.WriteAllText(Path.Combine(thuMuc, "_loi.txt"), string.Join(Environment.NewLine, loi), Encoding.UTF8);
            return loi.Count;
        }
    }
}
