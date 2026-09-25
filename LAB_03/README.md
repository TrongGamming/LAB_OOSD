# LAB 03 – Hệ thống quản lý khách sạn

Bài thực hành số 3: phân tích đề `Bai_3_He_thong_quan_ly_khach_san`, xây dựng cơ sở dữ liệu Oracle và
ứng dụng WinForms kết nối trực tiếp vào cơ sở dữ liệu đó.

## Nội dung thư mục

| Đường dẫn | Mô tả |
|---|---|
| `QuanLyKhachSan.sql` | Script chính: 18 bảng, 10 sequence, ràng buộc và dữ liệu mẫu |
| `QuanLyKhachSan_MoRong.sql` | 5 bảng "dư" tách riêng để phát triển module về sau |
| `QuanLyKhachSan/` | Ứng dụng WinForms (.NET Framework 4.7.2, ODP.NET Managed) |

## Cơ sở dữ liệu

Phần lõi bám theo mô hình trong đề, có bổ sung những bảng/cột mà đề còn thiếu:

- `NhanVien`, `KhuVuc`, `Phong`, `LoaiTienNghi`, `TienNghi`, `PhieuLapDat`
- `KhachHang`, `PhieuDatPhong`, `ChiTietDatPhong`, `NguoiLuuTru`
- `DichVu`, `PhieuSuDungDV`, `ChiTietPhieuSuDungDV`
- `QuyDinhDenBu`, `PhieuDenBu`, `ChiTietPhieuDenBu`
- `HoaDon`, `ThanhToan`

Bổ sung đáng chú ý: cột `DonGiaApDung` trong `ChiTietDatPhong` để chốt đơn giá tại thời điểm đặt
(đổi giá phòng về sau không làm sai hóa đơn cũ), cột tính sẵn `ThanhTien`, `TongTien`, và bảng
`ThanhToan` tách khỏi `HoaDon` để một hóa đơn trả được nhiều lần bằng nhiều hình thức.

Những bảng vượt ngoài phạm vi đề được để riêng trong `QuanLyKhachSan_MoRong.sql`:
`TaiKhoan`, `LichSuGiaPhong`, `GiaoDichCoc`, `PhieuKiemTraTienNghi`, `ChiTietKiemTraTienNghi`.

## Các màn hình

| Form | Chức năng |
|---|---|
| `FrmMain` | Màn hình chính, kiểm tra kết nối Oracle ngay khi mở |
| `FrmDanhMuc` | Khu vực, nhân viên, loại tiện nghi, dịch vụ, quy định đền bù |
| `FrmPhongTienNghi` | Phòng, tiện nghi, phiếu lắp đặt / luân chuyển thiết bị |
| `FrmDatPhong` | Khách hàng, lập phiếu đặt, nhận phòng, ghi người lưu trú |
| `FrmDichVu` | Ghi nhận dịch vụ khách sử dụng (cộng dồn theo ngày) |
| `FrmTraPhong` | Kiểm tra tiện nghi, phiếu đền bù, hóa đơn, thanh toán, trả phòng |
| `FrmThongKe` | Thống kê theo khoảng thời gian, xuất CSV |

## Cách chạy

1. Tạo user Oracle (chạy bằng tài khoản có quyền DBA):

   ```sql
   CREATE USER KHACHSAN IDENTIFIED BY <mật_khẩu> DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
   GRANT CONNECT, RESOURCE TO KHACHSAN;
   ```

2. Chạy script tạo cơ sở dữ liệu (đặt `NLS_LANG` để tiếng Việt không bị lỗi font):

   ```bash
   set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
   sqlplus KHACHSAN/<mật_khẩu>@localhost:1521/ORCL @QuanLyKhachSan.sql
   sqlplus KHACHSAN/<mật_khẩu>@localhost:1521/ORCL @QuanLyKhachSan_MoRong.sql
   ```

3. Chép `QuanLyKhachSan/QuanLyKhachSan/App.config.example` thành `App.config` rồi điền mật khẩu
   của user `KHACHSAN` (file `App.config` không được đưa lên git).

4. Mở `QuanLyKhachSan/QuanLyKhachSan.sln` bằng Visual Studio 2022 và chạy (F5).
