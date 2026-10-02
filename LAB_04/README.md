# LAB 04 – Hệ thống cửa hàng online e-SHOPPING

Phân tích, thiết kế hướng đối tượng đề `Bai_9_GOC` (cửa hàng ABC bán hàng online mùa Giáng Sinh), xây dựng
CSDL Oracle và ứng dụng WinForms kết nối trực tiếp vào CSDL đó.

| File / thư mục | Nội dung |
|---|---|
| `BaoCao_LAB04_EShopping.docx` | Báo cáo: tóm tắt (chức năng, yêu cầu, tác nhân, quy tắc nghiệp vụ, quyết định triển khai, FR/NFR), use case + phân rã + đặc tả, lớp phân tích, trạng thái, tuần tự, lớp chi tiết, ERD, SQL, giao diện và kết quả kiểm thử |
| `EShopping.sql` | Script Oracle: 18 bảng, 7 sequence, hàm `FN_TinhPhiGiao`, trigger, 2 view, dữ liệu mẫu |
| `EShopping/` | Ứng dụng WinForms (.NET Framework 4.7.2, ODP.NET Managed) – 8 form, tầng Forms / Services / Gateways / Data |
| `plantuml/` | Mã `.puml` và ảnh PNG của 13 sơ đồ (không đưa lên git) |
| `_build/` | Script sinh sơ đồ, form, project và báo cáo (không đưa lên git) |

## Chạy ứng dụng

1. Bật dịch vụ `OracleServiceORCL` và `OracleOraDB19Home1TNSListener`.
2. Tạo user (bằng tài khoản DBA):

   ```sql
   CREATE USER ESHOP IDENTIFIED BY <mật_khẩu> DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
   GRANT CONNECT, RESOURCE, CREATE VIEW, CREATE PROCEDURE, CREATE TRIGGER, CREATE SEQUENCE TO ESHOP;
   ```

3. Chạy script (đặt `NLS_LANG` để tiếng Việt không lỗi):

   ```bash
   set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
   sqlplus ESHOP/<mật_khẩu>@localhost:1521/ORCL @EShopping.sql
   ```

4. Chép `EShopping/EShopping/App.config.example` thành `App.config` rồi điền mật khẩu user `ESHOP`
   (`App.config` không đưa lên git).
5. Mở `EShopping/EShopping.sln` bằng Visual Studio 2022 và nhấn F5.

Tài khoản mẫu (mật khẩu `Eshop@123`): khách hàng `an.nv`, `binh.tt`; nhân viên `admin`, `banhang`.

Thẻ thử với cổng thanh toán giả lập: VISA `4111 1111 1111 1111` được chấp thuận, VISA `4000 0000 0000 0002`
bị từ chối (không đủ khả năng thanh toán), AmEx `3782 822463 10005`. Email xác nhận được ghi thành file `.eml`
trong `bin\Debug\MailPickup`.

Chế độ dòng lệnh: `EShopping.exe /kiemthu ketqua.txt` chạy 26 ca kiểm thử end-to-end trên CSDL rồi tự dọn dữ liệu thử;
`EShopping.exe /chupanh <thư_mục>` chụp ảnh các form dùng cho báo cáo.
