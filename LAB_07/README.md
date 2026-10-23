# LAB 07 – Quản lý nhân sự công ty sơn Đông Á

Sinh viên: **Nguyễn Dương Trọng – 1250080213**. Đề: `template/Bai_7_Quan_ly_nhan_su.pdf`.

Bài làm dựa trên cách tổ chức và báo cáo kết quả của LAB_06: phân tích UML, ứng dụng WinForms C# .NET Framework 4.7.2, Oracle 19c, SQL tham số và giao dịch.

## Tệp nộp

| Tệp / thư mục | Nội dung |
|---|---|
| `BaoCao_LAB07_QuanLyNhanSu.docx` | Trả lời đủ 6 câu; thuộc tính, ID, phương thức, liên kết/bản số, use case tổng quát và chi tiết, activity, sequence khen thưởng; thiết kế dữ liệu, giao diện và kiểm thử. |
| `QuanLyNhanSu.sql` | 20 bảng Oracle, khóa/ràng buộc, sequence, danh mục và nhân viên mẫu. |
| `QuanLyNhanSu/QuanLyNhanSu.sln` | Solution Visual Studio; source trong thư mục `QuanLyNhanSu/QuanLyNhanSu/`. |
| `QuanLyNhanSu/UML/LAB07_QuanLyNhanSu.mdj` | Mô hình định dạng StarUML: 3 class diagram, 2 use case, 1 activity, 1 sequence. |
| `plantuml/*.puml` | Nguồn sơ đồ nhúng trong Word, có thể chỉnh sửa và dựng lại. |

Ảnh, file build, DLL, cấu hình mật khẩu và công cụ dựng báo cáo chỉ lưu cục bộ, được loại khỏi Git. Các ảnh cần nộp đã nhúng trong DOCX.

## Môi trường và cài đặt

Cần Visual Studio 2022 với workload **.NET desktop development**, .NET Framework 4.7.2 Developer Pack, Oracle Database 19c và SQL*Plus.

1. Tạo **schema mới, riêng cho bài lab** bằng tài khoản quản trị:

   ```sql
   CREATE USER NHANSU IDENTIFIED BY "MAT_KHAU_CUA_BAN"
     DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
   GRANT CREATE SESSION, CREATE TABLE, CREATE SEQUENCE TO NHANSU;
   ```

2. Trong `cmd`, bật Unicode và mở SQL*Plus; nhập mật khẩu khi được hỏi:

   ```bat
   set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
   sqlplus NHANSU@localhost:1521/ORCL
   ```

   Sau khi kết nối, chạy `@D:\WorkSpace\OOSD\LAB_07\QuanLyNhanSu.sql`.
   Script **không xóa dữ liệu hay đối tượng hiện có**; chạy một lần trong schema mới. Khi có lỗi, SQL*Plus thoát với mã lỗi. Oracle DDL tự commit, vì vậy muốn chạy lại toàn bộ hãy dùng schema mới, không coi script là migration hay thao tác rollback toàn bộ DDL.

3. Chép `QuanLyNhanSu/QuanLyNhanSu/App.config.example` thành `App.config`; sửa tên user, mật khẩu, service name. Có thể dùng biến môi trường `LAB07_CONNECTION` thay cấu hình file. Không đưa mật khẩu lên Git.

4. Đặt `Oracle.ManagedDataAccess.dll` và các dependency tương ứng vào `QuanLyNhanSu/lib/`. Trên máy làm bài đã tái sử dụng nguyên bộ DLL của `LAB_06/QuanLyBenhAn/lib/` (ODP.NET Managed, file version 4.122.23.1). Khi clone Git, tự lấy lại thư viện từ LAB_06 hoặc gói Oracle.ManagedDataAccess tương ứng; project dùng tham chiếu DLL giống LAB_06, không tự tải NuGet. Không dùng `Oracle.ManagedDataAccess.Core` cho project .NET Framework này.

5. Mở solution bằng Visual Studio, chọn **Release → Build → F5**. Có thể build bằng Developer Command Prompt:

   ```bat
   MSBuild QuanLyNhanSu\QuanLyNhanSu.sln /p:Configuration=Release
   ```

## Chạy thử từ dữ liệu mẫu

SQL tạo `NV01` Nguyễn An, thử việc tại `PB02` từ 01/09/2026 đến 30/09/2026, chưa đánh giá. Các danh mục: `PB01..PB03`, `CV01..CV02`, `CA01..CA02`.

1. Tab **Tuyển dụng**: đánh giá `NV01` đạt, ngày đánh giá 01/10/2026 hoặc sau đó. Có thể tiếp nhận nhân viên mới và cấp quyết định thử việc trong cùng giao dịch.
2. Tab **Hợp đồng & BH**: nhập `NV01`, hiệu lực 01/10/2026, lương 8.000.000, phụ cấp 500.000, chức vụ Nhân viên. Dài hạn phải có số BHXH và BHYT; tỷ lệ mẫu 0,08 và 0,015 chỉ là giả định của bài. Ngắn hạn bắt buộc chọn ngày hết hạn. Nút ký tạo hợp đồng, quyết định lương/chức vụ và BH nếu cần trong một giao dịch.
3. Tab **Lương & chức vụ**: lập quyết định mới hiệu lực đầu tháng sau, giữ nguyên lịch sử cũ.
4. Tab **Công & phụ trội**: lập phân công `NV01`, ngày 05/10/2026, ca `CA01`, dự kiến 2 giờ phụ trội; hệ thống trả mã phân công và tự gắn kế hoạch tuần. Dùng mã vừa trả để chấm 8 giờ, sau đó lập phiếu phụ trội 2 giờ. Có thể nhập nhiều mã NV cách nhau bằng dấu phẩy; mỗi người phải có kế hoạch tương ứng.
5. Tab **Thưởng & kỷ luật**: chọn cá nhân (`NV01`) hoặc phòng ban (`PB02`), số tiền, cách xử lý; lưu dự thảo, sau đó nhập mã quyết định và giám đốc xác nhận ký. Với tập thể, số tiền là **tổng tiền của phòng**, chia đều cho các nhân viên còn làm việc tại lúc ký; phần dư ở dòng cuối. Chọn `TRUC_TIEP` thì xác nhận thu/chi; chọn `QUA_LUONG` thì chuyển sang bước lập lương.
6. Tab **Bảng lương**: chọn tháng 10/2026, công chuẩn 26, lập và khóa kỳ. Mỗi ca đã phân công phải được chấm công. Xem kết quả và xuất CSV UTF-8. Bảng lương lưu cả mức lương/phụ cấp, giờ công/PT, BH, thưởng/phạt và thực lĩnh.
7. Tab **Tra cứu & danh mục**: tìm tên/mã, xem lịch sử; danh mục phòng ban, chức vụ và ca làm được xem trên giao diện và bảo trì bằng SQL.

## Quy tắc tính lương và phạm vi

- Công chuẩn mặc định 26 ngày × 8 giờ; có thể chọn 1–31 ngày mỗi kỳ. Giờ công thực tế không vượt tổng giờ chuẩn.
- Lương công = `(lương cơ bản + phụ cấp lương + độc hại + chức vụ) × giờ công / (công chuẩn × 8)`.
- Tiền phụ trội = `lương cơ bản / (công chuẩn × 8) × giờ phụ trội × 1,5`. Theo đề, dùng cùng hệ số **1,5 cho tăng ca, ngày lễ và ngày nghỉ**.
- BHXH/BHYT = lương cơ bản × tỷ lệ trong hồ sơ BH của hợp đồng dài hạn. Các tỷ lệ 0,08 và 0,015 là dữ liệu minh họa, không khẳng định chính sách bảo hiểm thực tế. Bài không tính thuế TNCN, BHTN hoặc phần đóng của doanh nghiệp.
- Thực lĩnh = lương công + phụ trội + thưởng qua lương − phạt qua lương − BHXH − BHYT. Làm tròn từng khoản lương công/PT/BH về đồng; phân bổ thưởng/phạt giữ tối đa 2 chữ số thập phân để bảo toàn tổng tiền. Có thể có thực lĩnh âm khi công ít nhưng vẫn trích BH/phạt; bản mẫu hiển thị số dư âm, chưa quản lý công nợ kỳ sau.
- Lương/chức vụ lấy quyết định mới nhất có hiệu lực tại đầu tháng. Hợp đồng và quyết định lương/chức vụ chỉ nhận hiệu lực đầu tháng. Tháng có thử việc hoặc hợp đồng **không phủ trọn tháng** bị từ chối toàn bộ, tránh tự áp dụng công thức cho tháng chuyển tiếp chưa đặc tả.
- Lập lương lưu ảnh chụp các khoản và gắn phân bổ vào kỳ, mỗi tháng một bảng. Khoản đã trả trực tiếp không đi vào lương; phân bổ đã tính lương không tính lại tháng sau. Thưởng cuối năm, tháng 13, ngày lễ dùng quyết định khen thưởng và số tiền do người lập nhập, không tự tính tháng 13.
- Các thao tác ghi của `HrService` cùng khóa bảng kỳ lương trước khi xử lý, bảo đảm việc chấm công và chốt lương không đua tranh qua ứng dụng. Đây là lựa chọn cho lab nội bộ nhỏ; người có quyền SQL ghi trực tiếp phải tự tuân thủ quy tắc nhiều bảng.
- Chưa có đăng nhập, phân quyền, chữ ký số, giao dịch ngân hàng, thay đổi phòng ban, hủy/chỉnh quyết định đã ký hoặc mở lại kỳ lương. Tên người ký/người chấm do người dùng nhập. Các actor trong UML là vai trò nghiệp vụ, không phải tài khoản đã được xác thực. Màn hình minh họa thao tác ghi nhận sau khi các bên đã ký thực tế.

## Mô hình UML

Mở `QuanLyNhanSu/UML/LAB07_QuanLyNhanSu.mdj` bằng **File → Open** trong StarUML. Mô hình gồm lớp với thuộc tính/phương thức, liên kết/bản số, actor, use case, luồng hoạt động và thông điệp tuần tự. `.mdj` được sinh theo cấu trúc mẫu chính thức [staruml/staruml-samples](https://github.com/staruml/staruml-samples/blob/main/UMLExample.mdj); đã kiểm tra JSON, tính duy nhất ID và toàn bộ tham chiếu nội bộ. Máy làm bài không cài StarUML, nên chưa xác nhận bố cục khi mở bằng ứng dụng này. Hình UML trong Word được render từ nguồn PlantUML; đây không phải ảnh chụp StarUML. Dùng `.puml` để dựng lại đúng ảnh trong báo cáo.

## Xác minh

Đã nạp SQL thành công trên Oracle 19c trong schema riêng `L07VERIFY`, build **Release** và chạy **41/41 ca đạt** qua source `KiemThu.cs`. Các ca kiểm tra công thức, luồng thử việc/hợp đồng/BH, lịch sử lương/chức vụ, công/phụ trội, cá nhân/tập thể, phiếu thu/chi, rollback, chống trả trùng, khóa kỳ và không cộng thưởng lại tháng sau. Chi tiết từng ca nằm trong báo cáo Word. Ảnh giao diện lấy từ ứng dụng kết nối dữ liệu kiểm thử, không thay thế kiểm thử bấm tay toàn bộ form.

Chạy công thức độc lập, không cần Oracle:

```bat
QuanLyNhanSu\QuanLyNhanSu\bin\Release\QuanLyNhanSu.exe /kiemthu-congthuc ketqua-congthuc.txt
```

Chạy kiểm thử đầy đủ trên **schema mới chỉ vừa nạp SQL mẫu**:

```bat
QuanLyNhanSu\QuanLyNhanSu\bin\Release\QuanLyNhanSu.exe /kiemthu ketqua-kiemthu.txt
```

Mã thoát 0 khi mọi ca đạt, 1 khi có ca lỗi. Kiểm thử đầy đủ để lại dữ liệu; chạy lại cần schema mới. Thử việc mẫu ở 09/2026; kỳ hợp đồng/lương của kiểm thử tự lấy tháng hiện tại và tháng kế tiếp theo đồng hồ máy (từ 10/2026 trở đi). Đồng hồ máy và Oracle cần thống nhất để quyết định ký trong tháng được tính đúng kỳ.

`.gitignore` đã bổ sung LAB_07: giữ DOCX, README, SQL, `.cs/.csproj/.sln`, cấu hình mẫu, `.mdj` và `.puml`; bỏ `App.config`, DLL, `bin`, `obj`, ảnh và `_build`.
