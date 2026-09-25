# LAB 02 – Hệ thống quản lý thư viện số

Làm tiếp đề tài thư viện số ở [LAB 01](../LAB_01/README.md): từ Activity Diagram, Sequence Diagram đến thiết kế giao diện, cơ sở dữ liệu và ứng dụng chạy thật.

| File / thư mục | Nội dung |
|---|---|
| `baocaolab02.docx` | Báo cáo chính: mục 4.4 Activity Diagram, 4.5 Sequence Diagram, 5 Thiết kế CSDL, 6 Thiết kế giao diện (14 form), 7 Kịch bản đúng – sai, 8 Test case, 9 Cài đặt CSDL. |
| `QuanLyThuVienSo.sql` | Script Oracle: 17 bảng, 3 view, 11 stored procedure và dữ liệu mẫu. |
| `ThuVienSo/` | Ứng dụng Windows Forms (C#, .NET Framework 4.7.2) theo 3 tầng Forms – Services – Data. |
| `GiaoDien_QuanLyThuVienSo.xlsx` | Bản phác thảo giao diện ban đầu, mỗi form một sheet (không đưa lên git). |
| `plantuml/` | Mã nguồn `.puml` và ảnh của các sơ đồ trong báo cáo (không đưa lên git). |

## Chạy ứng dụng

1. Bật dịch vụ `OracleServiceORCL` và listener `OracleOraDB19Home1TNSListener`.
2. Tạo user `THUVIENSO` (quyền CONNECT, RESOURCE, CREATE VIEW, CREATE PROCEDURE), đăng nhập bằng user này rồi chạy `QuanLyThuVienSo.sql`. Nếu chạy bằng SQL*Plus thì đặt `NLS_LANG=AMERICAN_AMERICA.AL32UTF8` để không lỗi tiếng Việt.
3. Chép `ThuVienSo/ThuVienSo/App.config.example` thành `App.config` rồi điền mật khẩu Oracle của máy bạn (`App.config` không đưa lên git vì chứa mật khẩu).
4. Mở `ThuVienSo/ThuVienSo.sln` bằng Visual Studio 2022, phục hồi NuGet (`Oracle.ManagedDataAccess`) rồi nhấn F5.

Tài khoản mẫu: `hoa.lt`, `khoa.vm` (thủ thư) và `an.nv`, `binh.tt` (độc giả) — mật khẩu `Thuvien@123`.

Tác vụ nhắc hạn trả sách chạy bằng lệnh `ThuVienSo.exe /nhachan` (đặt lịch trong Task Scheduler). Khi chưa có SMTP thật, email được lưu thành file `.eml` trong `bin\Debug\MailPickup`.
