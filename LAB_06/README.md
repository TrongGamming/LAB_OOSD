# LAB 06 – Quản lý hồ sơ bệnh án

Bài làm cho **Bài 5 – Quản lý hồ sơ bệnh án của bệnh nhân**, tham chiếu cách tổ chức sản phẩm của `LAB_05`.

Sinh viên: **Nguyễn Dương Trọng** – MSSV **1250080213**.

## Bộ tệp nộp

| Tệp / thư mục | Nội dung |
|---|---|
| `BaoCao_LAB06_QuanLyBenhAn.docx` | Báo cáo Word trả lời 6 câu, kèm đặc tả use case, state diagram, lớp chi tiết, ERD, ràng buộc, giao diện và bảng kiểm tra. |
| `QuanLyBenhAn.sql` | Oracle 19c: 16 bảng, khóa và ràng buộc, 12 sequence, trigger, dữ liệu mẫu. |
| `QuanLyBenhAn/` | Solution Visual Studio 2022, ứng dụng WinForms .NET Framework 4.7.2, ODP.NET Managed. |

Khi nộp qua Git, chỉ đưa lên **Word, SQL, README và mã nguồn project**. Các sơ đồ và ảnh đã nhúng trong Word; `plantuml/`, `screenshots/`, log kiểm thử và file build chỉ lưu ở máy làm bài.

## Cài đặt

Cần Oracle Database 19c, SQL*Plus, Visual Studio 2022 và .NET Framework 4.7.2 Developer Pack. Dùng tài khoản có quyền tạo bảng, sequence và trigger. Có thể tạo schema riêng:

```sql
CREATE USER BENHAN IDENTIFIED BY mat_khau_cua_ban DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CREATE SESSION, CREATE TABLE, CREATE SEQUENCE, CREATE TRIGGER TO BENHAN;
```

Trong **cmd**, đặt mã hóa tiếng Việt rồi nạp script (thay mật khẩu và service Oracle cho phù hợp):

```bat
set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
sqlplus BENHAN/mat_khau_cua_ban@localhost:1521/ORCL @QuanLyBenhAn.sql
```

Script **xóa rồi tạo lại** các bảng/sequence của bài trong schema đang đăng nhập. Không chạy trên schema đang có dữ liệu cần giữ. Nên dùng tài khoản `BENHAN` riêng.

Chép `QuanLyBenhAn/QuanLyBenhAn/App.config.example` thành `App.config`, thay `YOUR_PASSWORD` bằng mật khẩu của `BENHAN` và sửa `Data Source` nếu Oracle dùng service khác. Dự án tham chiếu `Oracle.ManagedDataAccess.dll` tại `QuanLyBenhAn/lib/`; thư viện nhị phân không được đưa lên Git, vì vậy sau khi clone cần lấy DLL từ gói Oracle.ManagedDataAccess hoặc bản LAB_05 và đặt vào thư mục đó. Mở `QuanLyBenhAn/QuanLyBenhAn.sln` bằng Visual Studio, chọn Build rồi F5.

## Dùng thử nhanh

1. Tab **Tra cứu hồ sơ**: tìm `HS0001`, xem bệnh nhân mẫu. Tab **Đăng ký & cấp hồ sơ**: nhập bệnh nhân mới và lệ phí năm; hệ thống thu phí, tạo phiếu và cấp mã hồ sơ trong một transaction. Với hồ sơ có từ năm trước, dùng ô **Thu lệ phí năm hiện tại** để gia hạn.
2. Tab **Đặt lịch hẹn**: nhập mã hồ sơ và chọn bác sĩ trong danh sách. Nếu đánh dấu định kỳ, hệ thống kiểm tra phí năm và giới hạn một lịch mỗi quý.
3. Tab **Khám bệnh**: tạo lượt khám; ghi mã lượt khám trả về, sau đó nhập triệu chứng/chẩn đoán.
4. Tab **Xét nghiệm**: tạo chỉ định khi cần, rồi dùng mã chỉ định để lưu kết quả.
5. Tab **Lập toa thuốc**: chọn thuốc, liều, số ngày và ký toa. Nếu còn xét nghiệm chưa có kết quả, ứng dụng từ chối kê toa.
6. Tab **Thanh toán & xuất viện**: nhập kết luận và viện phí; khám định kỳ phải để 0. Lịch sử lượt khám hiển thị ở tab tra cứu.
7. Tab **Phản ứng thuốc**: lưu phản ứng vào hồ sơ để bác sĩ theo dõi về sau.

Tab **Tra cứu hồ sơ** có cửa sổ lịch sử gồm bốn trang: lượt khám, toa thuốc, xét nghiệm và phản ứng thuốc.

Các ComboBox nạp danh mục từ Oracle khi mở danh sách. Các mã mẫu: `HS0001`, `BS01`, `XN01`, `T01`.

## Thiết kế và giới hạn

`MainForm.cs` chứa giao diện; `ClinicService.cs` kiểm tra nghiệp vụ và giao dịch; `Db.cs` quản lý kết nối và SQL tham số. Mỗi hồ sơ thuộc một bệnh nhân, nhiều lượt khám; mỗi lượt khám có thể có nhiều chỉ định xét nghiệm, tối đa một toa thuốc. Chi tiết và bản số thể hiện trong báo cáo.

Bản mẫu chưa có đăng nhập/phân quyền, chưa nhập nhiều thuốc trong cùng một toa qua giao diện và ảnh bệnh nhân hiện lưu dạng đường dẫn. Thu ngân xác nhận thanh toán trực tiếp trong ứng dụng; chưa có kết nối cổng thanh toán. Danh mục bác sĩ, khoa, thuốc và xét nghiệm được tạo bằng SQL, chưa có màn hình bảo trì danh mục.

## Kiểm tra đã thực hiện

Ứng dụng đã được biên dịch bằng MSBuild của Visual Studio 2022. Script đã chạy trên Oracle 19c trong schema kiểm thử riêng `L06VERIFY`; kịch bản `QuanLyBenhAn.exe /kiemthu ketqua.txt` đạt **18/18** ca. Bảng kết quả được ghi trong Word; log gốc lưu tại máy làm bài. Ảnh giao diện trong Word chụp khi kết nối schema kiểm thử; riêng các form nhập liệu chưa được bấm lưu thủ công trong lúc chụp.

Để chạy lại kịch bản kiểm thử trên schema của bạn, đặt biến môi trường `LAB06_CONNECTION` thành chuỗi kết nối Oracle rồi chạy bản Release với `/kiemthu <file_kết_quả>`. Kịch bản tạo dữ liệu thử và để lại trong schema, nên chỉ chạy trên schema dùng cho kiểm thử. Không sử dụng mật khẩu mẫu trong thư mục source khi nộp hoặc triển khai thật.
