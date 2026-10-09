<h1 align="center">Quản Lý Công Ty Du Lịch Văn Hóa Việt<br/>Lab 05 – Phân tích thiết kế hướng đối tượng</h1>

<p align="center">
  <img src="./screenshots/FrmMain.png" width="560">
</p>

## Mục lục
- [Giới thiệu](#giới-thiệu)
- [Trong repo có gì](#trong-repo-có-gì)
- [Cài đặt và chạy](#cài-đặt-và-chạy)
- [Mấy lỗi mình đã gặp](#mấy-lỗi-mình-đã-gặp)
- [Hình ảnh](#hình-ảnh)
- [Tự kiểm tra](#tự-kiểm-tra)
- [Lời cuối](#lời-cuối)

## Giới thiệu

Chào mọi người, mình là Trọng (MSSV 1250080213). Đây là bài Lab 05 môn Phân tích thiết kế hướng đối tượng, đề số 6:
**Quản lý công ty du lịch**. Đề cho một công ty lữ hành ở TP.HCM, khách đi theo đoàn (trên 12 người) thì lập phiếu
và đặt cọc, khách lẻ thì mua vé theo chuyến. Ngoài ra còn phải xếp hướng dẫn viên sao cho không trùng lịch, tính lương
và gửi phiếu khảo sát sau tour.

Bài làm gồm 2 phần:
1. **Phân tích thiết kế**: use case, đặc tả, class diagram, state, activity, sequence, ERD, ràng buộc. Nằm hết trong file Word.
2. **Cài đặt**: CSDL Oracle + app WinForms C# kết nối vào CSDL đó, có chạy được thật chứ không phải chỉ vẽ.

Nếu bạn cũng đang làm đề này thì cứ tham khảo, nhưng nhớ tự vẽ lại sơ đồ theo cách hiểu của mình nha 😄

## Trong repo có gì

```
LAB_05/
├── BaoCao_LAB05_QuanLyDuLich.docx   # báo cáo chính
├── PhienBan2/                       # bản báo cáo thứ 2, sơ đồ vẽ kiểu khác
├── PhienBan3/                       # bản báo cáo thứ 3, trả lời theo từng câu của đề
├── QuanLyDuLich.sql                 # script tạo CSDL + dữ liệu mẫu
├── QuanLyDuLich/                    # source code WinForms (3 bản báo cáo dùng chung)
└── screenshots/                     # ảnh để xem nhanh trên GitHub
```

Code chia 3 lớp cho dễ đọc:
- `Forms/` – giao diện, chỉ lo đọc/ghi control
- `Services/` – kiểm tra nghiệp vụ (số người, tiền cọc, còn chỗ, trùng lịch…)
- `Data/Db.cs` – kết nối Oracle bằng ODP.NET Managed, mọi câu SQL đều dùng tham số

## Cài đặt và chạy

Cần có: Visual Studio 2022, Oracle 19c (mình dùng bản cài trên máy, service `ORCL`).

**Bước 1.** Bật 2 service `OracleServiceORCL` và `OracleOraDB19Home1TNSListener` (máy mình để Manual nên lần nào cũng phải bật tay).

**Bước 2.** Vào sqlplus bằng sysdba tạo user:

```sql
CREATE USER DULICH IDENTIFIED BY matkhau_cua_ban DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE, CREATE VIEW, CREATE TRIGGER, CREATE SEQUENCE TO DULICH;
```

**Bước 3.** Chạy script. Nhớ set `NLS_LANG` trước, không là tiếng Việt thành dấu `?` hết:

```bat
set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
sqlplus DULICH/matkhau_cua_ban@localhost:1521/ORCL @QuanLyDuLich.sql
```

**Bước 4.** Copy `QuanLyDuLich/QuanLyDuLich/App.config.example` thành `App.config`, sửa lại mật khẩu cho đúng máy bạn.

**Bước 5.** Mở `QuanLyDuLich/QuanLyDuLich.sln`, F5. Thanh trạng thái dưới màn hình chính hiện
*"Đã kết nối Oracle – user DULICH – 6 tour"* là ok.

> Project tham chiếu thẳng `Oracle.ManagedDataAccess.dll` trong thư mục `lib/` (không xài NuGet). Thư mục này mình không
> đưa lên git, nếu build báo thiếu thì cài gói NuGet `Oracle.ManagedDataAccess` vào là được.

## Mấy lỗi mình đã gặp

Ghi lại để ai làm sau đỡ mất thời gian:

- **UNIQUE (MaNV, SoPhieu) chặn nhầm.** Oracle coi 2 dòng `(NV03, NULL)` là trùng nhau, nên một hướng dẫn viên không nhận
  được chuyến khách lẻ thứ 2. Mình đổi sang unique index trên biểu thức
  `CASE WHEN SoPhieu IS NOT NULL THEN MaNV END, SoPhieu`.
- **ORA-12704: character set mismatch.** Lỗi này hiện khi `UNION` một cột `NVARCHAR2` với chuỗi `'Khách lẻ'`. Viết thành `N'Khách lẻ'` là hết.
- **Trigger kiểm tra trùng lịch bị mutating table.** Trigger `FOR EACH ROW` không được đọc lại chính bảng đó, nên mình
  viết trigger mức câu lệnh (bỏ `FOR EACH ROW`) cho `TRG_PhanCong_ChongCheo` và `TRG_Ve_SoCho`.
- **Control trong TabPage bị tràn** khi đặt Anchor. Bỏ Anchor cho mấy control trong tab là được.

## Hình ảnh

| Lập phiếu theo đoàn | Bán vé khách lẻ |
|---|---|
| ![](./screenshots/FrmPhieuDoan.png) | ![](./screenshots/FrmBanVe.png) |

| Phân công hướng dẫn viên | Bảng lương |
|---|---|
| ![](./screenshots/FrmPhanCong.png) | ![](./screenshots/FrmLuong.png) |

Use case tổng quát và ERD:

<p align="center">
  <img src="./screenshots/usecase.png" width="380">
  <img src="./screenshots/erd.png" width="620">
</p>

## Tự kiểm tra

Mình có viết sẵn một chế độ test chạy thẳng trên CSDL, khỏi phải bấm tay từng form:

```bat
QuanLyDuLich.exe /kiemthu ketqua.txt
```

Nó chạy 30 tình huống (phiếu đoàn 12 người, cọc dưới 30%, bán quá chỗ, phân công trùng lịch, sai thứ tự trạng thái…),
ghi kết quả ra file rồi tự xoá dữ liệu test. Lần chạy cuối: **30/30 đạt**.

Lưu ý: chạy lệnh này trong cmd hoặc PowerShell. Git Bash tự đổi `/kiemthu` thành đường dẫn nên app mở giao diện bình thường.

## Lời cuối

Bài này mình làm trong khoảng một buổi nên chắc còn chỗ chưa ổn: chưa có đăng nhập, phần gửi mail khảo sát với
bảo hiểm mới dừng ở mức thiết kế. Bạn nào thấy sai chỗ nào cứ mở issue nhé. Thấy có ích thì cho mình xin một ⭐ nha!
