-- =====================================================================
-- LAB 04 – Hệ thống cửa hàng online e-SHOPPING
-- Script Oracle 19c: 18 bảng, 7 sequence, 1 hàm, 1 trigger, 2 view và dữ liệu mẫu.
-- Chạy bằng user ESHOP (xem README.md):
--   set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
--   sqlplus ESHOP/<mật_khẩu>@localhost:1521/ORCL @EShopping.sql
-- Script chạy lại được nhiều lần (tự xóa đối tượng cũ trước khi tạo).
-- =====================================================================
SET DEFINE OFF
SET SERVEROUTPUT ON

-- ---------------------------------------------------------------- 0. Xóa đối tượng cũ
BEGIN
  FOR t IN (SELECT table_name FROM user_tables WHERE table_name IN (
              'NHATKYEMAIL','NHATKYTHANHTOAN','CHITIETDONHANG','DONDATHANG','THETINDUNG','LOAITHE',
              'BANGPHIGIAOHANG','TINHTHANH','KHUVUCGIAOHANG','LOAIPHIEUDATHANG','CHITIETGIOHANG','GIOHANG',
              'NHANVIEN','KHACHHANG','THONGSOKYTHUAT','HINHANHSANPHAM','SANPHAM','NHOMSANPHAM')) LOOP
    EXECUTE IMMEDIATE 'DROP TABLE ' || t.table_name || ' CASCADE CONSTRAINTS PURGE';
  END LOOP;
  FOR s IN (SELECT sequence_name FROM user_sequences WHERE sequence_name IN (
              'SEQ_KHACHHANG','SEQ_GIOHANG','SEQ_DONHANG','SEQ_THE','SEQ_NHATKYTT','SEQ_EMAIL','SEQ_HINHANH')) LOOP
    EXECUTE IMMEDIATE 'DROP SEQUENCE ' || s.sequence_name;
  END LOOP;
END;
/

-- ---------------------------------------------------------------- 1. Sản phẩm (bản sao từ Hệ thống quản lý sản phẩm)
CREATE TABLE NhomSanPham (
  MaNhom      VARCHAR2(10)   CONSTRAINT PK_NhomSanPham PRIMARY KEY,
  TenNhom     NVARCHAR2(100) NOT NULL CONSTRAINT UQ_NhomSanPham_Ten UNIQUE,
  MoTa        NVARCHAR2(300)
);

CREATE TABLE SanPham (
  MaSP        VARCHAR2(20)   CONSTRAINT PK_SanPham PRIMARY KEY,
  TenSP       NVARCHAR2(200) NOT NULL,
  MaNhom      VARCHAR2(10)   NOT NULL CONSTRAINT FK_SanPham_Nhom REFERENCES NhomSanPham(MaNhom),
  NhaSanXuat  NVARCHAR2(100) NOT NULL,
  MoTa        NVARCHAR2(2000),
  GiaBan      NUMBER(12)     NOT NULL CONSTRAINT CK_SanPham_Gia CHECK (GiaBan > 0),
  TinhTrang   NVARCHAR2(20)  DEFAULT N'Còn hàng' NOT NULL
              CONSTRAINT CK_SanPham_TinhTrang CHECK (TinhTrang IN (N'Còn hàng', N'Hết hàng')),
  NgayCapNhat DATE           DEFAULT SYSDATE NOT NULL
);

CREATE TABLE HinhAnhSanPham (
  MaHinh      NUMBER         CONSTRAINT PK_HinhAnhSanPham PRIMARY KEY,
  MaSP        VARCHAR2(20)   NOT NULL CONSTRAINT FK_HinhAnh_SanPham REFERENCES SanPham(MaSP) ON DELETE CASCADE,
  DuongDan    VARCHAR2(300)  NOT NULL,
  ThuTu       NUMBER(2)      DEFAULT 1 NOT NULL,
  CONSTRAINT UQ_HinhAnh_ThuTu UNIQUE (MaSP, ThuTu)
);

CREATE TABLE ThongSoKyThuat (
  MaSP        VARCHAR2(20)   CONSTRAINT FK_ThongSo_SanPham REFERENCES SanPham(MaSP) ON DELETE CASCADE,
  TenThongSo  NVARCHAR2(100),
  GiaTri      NVARCHAR2(300) NOT NULL,
  CONSTRAINT PK_ThongSoKyThuat PRIMARY KEY (MaSP, TenThongSo)
);

-- ---------------------------------------------------------------- 2. Tài khoản
CREATE TABLE KhachHang (
  MaKH        VARCHAR2(10)   CONSTRAINT PK_KhachHang PRIMARY KEY,
  HoTen       NVARCHAR2(100) NOT NULL,
  NgaySinh    DATE           NOT NULL,
  SoGiayTo    VARCHAR2(20)   NOT NULL CONSTRAINT UQ_KhachHang_GiayTo UNIQUE,
  DiaChi      NVARCHAR2(250) NOT NULL,
  DienThoai   VARCHAR2(15)   NOT NULL CONSTRAINT CK_KhachHang_DT CHECK (REGEXP_LIKE(DienThoai, '^[0-9+]{9,15}$')),
  TenDangNhap VARCHAR2(50)   NOT NULL CONSTRAINT UQ_KhachHang_TenDN UNIQUE,
  MatKhauHash VARCHAR2(64)   NOT NULL,
  Salt        VARCHAR2(32)   NOT NULL,
  Email       VARCHAR2(100)  CONSTRAINT CK_KhachHang_Email CHECK (Email IS NULL OR REGEXP_LIKE(Email, '^[^@ ]+@[^@ ]+\.[^@ ]+$')),
  NgayDangKy  DATE           DEFAULT SYSDATE NOT NULL,
  TrangThai   NVARCHAR2(20)  DEFAULT N'Hoạt động' NOT NULL
              CONSTRAINT CK_KhachHang_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);

CREATE TABLE NhanVien (
  MaNV        VARCHAR2(10)   CONSTRAINT PK_NhanVien PRIMARY KEY,
  HoTen       NVARCHAR2(100) NOT NULL,
  TenDangNhap VARCHAR2(50)   NOT NULL CONSTRAINT UQ_NhanVien_TenDN UNIQUE,
  MatKhauHash VARCHAR2(64)   NOT NULL,
  Salt        VARCHAR2(32)   NOT NULL,
  VaiTro      NVARCHAR2(30)  DEFAULT N'Nhân viên bán hàng' NOT NULL
);

-- ---------------------------------------------------------------- 3. Giỏ hàng
CREATE TABLE GioHang (
  MaGioHang   NUMBER         CONSTRAINT PK_GioHang PRIMARY KEY,
  MaKH        VARCHAR2(10)   CONSTRAINT FK_GioHang_KhachHang REFERENCES KhachHang(MaKH),
  NgayTao     DATE           DEFAULT SYSDATE NOT NULL,
  TrangThai   NVARCHAR2(30)  DEFAULT N'Đang mua' NOT NULL
              CONSTRAINT CK_GioHang_TrangThai CHECK (TrangThai IN (N'Đang mua', N'Đã chuyển thành đơn'))
);
-- Mỗi khách chỉ có một giỏ đang mua (index duy nhất theo hàm, bỏ qua các giỏ đã chốt đơn)
CREATE UNIQUE INDEX UX_GioHang_DangMua ON GioHang (CASE WHEN TrangThai = N'Đang mua' THEN MaKH END);

CREATE TABLE ChiTietGioHang (
  MaGioHang   NUMBER         CONSTRAINT FK_CTGH_GioHang REFERENCES GioHang(MaGioHang) ON DELETE CASCADE,
  MaSP        VARCHAR2(20)   CONSTRAINT FK_CTGH_SanPham REFERENCES SanPham(MaSP),
  SoLuong     NUMBER(5)      NOT NULL CONSTRAINT CK_CTGH_SoLuong CHECK (SoLuong BETWEEN 1 AND 99),
  NgayThem    DATE           DEFAULT SYSDATE NOT NULL,
  CONSTRAINT PK_ChiTietGioHang PRIMARY KEY (MaGioHang, MaSP)
);

-- ---------------------------------------------------------------- 4. Giao hàng
CREATE TABLE LoaiPhieuDatHang (
  MaLoaiPhieu   VARCHAR2(10)   CONSTRAINT PK_LoaiPhieuDatHang PRIMARY KEY,
  TenLoai       NVARCHAR2(60)  NOT NULL,
  SoGioXuLy     NUMBER(4)      NOT NULL CONSTRAINT CK_LoaiPhieu_Gio CHECK (SoGioXuLy > 0),
  NguongMienPhi NUMBER(12)     CONSTRAINT CK_LoaiPhieu_Nguong CHECK (NguongMienPhi IS NULL OR NguongMienPhi >= 0)
);

CREATE TABLE KhuVucGiaoHang (
  MaKhuVuc    VARCHAR2(10)   CONSTRAINT PK_KhuVucGiaoHang PRIMARY KEY,
  TenKhuVuc   NVARCHAR2(100) NOT NULL
);

CREATE TABLE TinhThanh (
  MaTinh      VARCHAR2(10)   CONSTRAINT PK_TinhThanh PRIMARY KEY,
  TenTinh     NVARCHAR2(100) NOT NULL CONSTRAINT UQ_TinhThanh_Ten UNIQUE,
  MaKhuVuc    VARCHAR2(10)   NOT NULL CONSTRAINT FK_TinhThanh_KhuVuc REFERENCES KhuVucGiaoHang(MaKhuVuc)
);

CREATE TABLE BangPhiGiaoHang (
  MaKhuVuc    VARCHAR2(10)   CONSTRAINT FK_BangPhi_KhuVuc REFERENCES KhuVucGiaoHang(MaKhuVuc),
  MaLoaiPhieu VARCHAR2(10)   CONSTRAINT FK_BangPhi_LoaiPhieu REFERENCES LoaiPhieuDatHang(MaLoaiPhieu),
  PhiGiao     NUMBER(12)     NOT NULL CONSTRAINT CK_BangPhi_Phi CHECK (PhiGiao >= 0),
  CONSTRAINT PK_BangPhiGiaoHang PRIMARY KEY (MaKhuVuc, MaLoaiPhieu)
);

-- ---------------------------------------------------------------- 5. Thanh toán
CREATE TABLE LoaiThe (
  MaLoaiThe     VARCHAR2(10)   CONSTRAINT PK_LoaiThe PRIMARY KEY,
  TenLoaiThe    NVARCHAR2(50)  NOT NULL,
  DoDaiSoThe    NUMBER(2)      NOT NULL CONSTRAINT CK_LoaiThe_DoDai CHECK (DoDaiSoThe IN (15, 16)),
  DoDaiCSV      NUMBER(1)      NOT NULL CONSTRAINT CK_LoaiThe_CSV CHECK (DoDaiCSV IN (3, 4)),
  LePhiGiaoDich NUMBER(12)     DEFAULT 0 NOT NULL CONSTRAINT CK_LoaiThe_LePhi CHECK (LePhiGiaoDich >= 0)
);

-- Không lưu số thẻ đầy đủ và mã CSV (chuẩn PCI-DSS): chỉ lưu số đã che và token do cổng thanh toán cấp.
CREATE TABLE TheTinDung (
  MaThe          NUMBER         CONSTRAINT PK_TheTinDung PRIMARY KEY,
  MaKH           VARCHAR2(10)   NOT NULL CONSTRAINT FK_The_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiThe      VARCHAR2(10)   NOT NULL CONSTRAINT FK_The_LoaiThe REFERENCES LoaiThe(MaLoaiThe),
  SoTheAn        VARCHAR2(25)   NOT NULL,
  ThangHetHan    NUMBER(2)      NOT NULL CONSTRAINT CK_The_Thang CHECK (ThangHetHan BETWEEN 1 AND 12),
  NamHetHan      NUMBER(4)      NOT NULL,
  TenChuThe      NVARCHAR2(100) NOT NULL,
  TokenThanhToan VARCHAR2(64)   NOT NULL CONSTRAINT UQ_The_Token UNIQUE
);

-- ---------------------------------------------------------------- 6. Đơn đặt hàng
CREATE TABLE DonDatHang (
  SoDonHang     VARCHAR2(12)   CONSTRAINT PK_DonDatHang PRIMARY KEY,
  MaKH          VARCHAR2(10)   NOT NULL CONSTRAINT FK_Don_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiPhieu   VARCHAR2(10)   NOT NULL CONSTRAINT FK_Don_LoaiPhieu REFERENCES LoaiPhieuDatHang(MaLoaiPhieu),
  ThoiDiemDat   DATE           DEFAULT SYSDATE NOT NULL,
  TenNguoiNhan  NVARCHAR2(100) NOT NULL,
  DiaChiNhan    NVARCHAR2(250) NOT NULL,
  MaTinh        VARCHAR2(10)   NOT NULL CONSTRAINT FK_Don_TinhThanh REFERENCES TinhThanh(MaTinh),
  DienThoaiNhan VARCHAR2(15)   NOT NULL,
  TongTienHang  NUMBER(14)     NOT NULL CONSTRAINT CK_Don_TienHang CHECK (TongTienHang > 0),
  PhiGiaoHang   NUMBER(12)     DEFAULT 0 NOT NULL CONSTRAINT CK_Don_PhiGiao CHECK (PhiGiaoHang >= 0),
  LePhiThe      NUMBER(12)     DEFAULT 0 NOT NULL CONSTRAINT CK_Don_LePhi CHECK (LePhiThe >= 0),
  TongTriGia    NUMBER(14)     GENERATED ALWAYS AS (TongTienHang + PhiGiaoHang + LePhiThe) VIRTUAL,
  MaThe         NUMBER         NOT NULL CONSTRAINT FK_Don_The REFERENCES TheTinDung(MaThe),
  MaGiaoDich    VARCHAR2(40)   NOT NULL CONSTRAINT UQ_Don_GiaoDich UNIQUE,
  TrangThai     NVARCHAR2(20)  DEFAULT N'Chờ xử lý' NOT NULL
                CONSTRAINT CK_Don_TrangThai CHECK (TrangThai IN (N'Chờ xử lý', N'Đang xử lý', N'Đang giao', N'Đã giao', N'Đã hủy')),
  DaGuiEmail    CHAR(1)        DEFAULT 'N' NOT NULL CONSTRAINT CK_Don_Email CHECK (DaGuiEmail IN ('Y', 'N'))
);

CREATE TABLE ChiTietDonHang (
  SoDonHang   VARCHAR2(12)   CONSTRAINT FK_CTDH_Don REFERENCES DonDatHang(SoDonHang) ON DELETE CASCADE,
  MaSP        VARCHAR2(20)   CONSTRAINT FK_CTDH_SanPham REFERENCES SanPham(MaSP),
  SoLuong     NUMBER(5)      NOT NULL CONSTRAINT CK_CTDH_SoLuong CHECK (SoLuong > 0),
  DonGia      NUMBER(12)     NOT NULL CONSTRAINT CK_CTDH_DonGia CHECK (DonGia > 0),
  ThanhTien   NUMBER(14)     GENERATED ALWAYS AS (SoLuong * DonGia) VIRTUAL,
  CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (SoDonHang, MaSP)
);

CREATE TABLE NhatKyThanhToan (
  MaNhatKy    NUMBER         CONSTRAINT PK_NhatKyThanhToan PRIMARY KEY,
  MaKH        VARCHAR2(10)   NOT NULL CONSTRAINT FK_NKTT_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiThe   VARCHAR2(10)   NOT NULL CONSTRAINT FK_NKTT_LoaiThe REFERENCES LoaiThe(MaLoaiThe),
  SoTheAn     VARCHAR2(25)   NOT NULL,
  SoTien      NUMBER(14)     NOT NULL,
  KetQua      NVARCHAR2(20)  NOT NULL CONSTRAINT CK_NKTT_KetQua CHECK (KetQua IN (N'Chấp thuận', N'Từ chối', N'Hoàn tiền')),
  MaGiaoDich  VARCHAR2(40),
  LyDo        NVARCHAR2(200),
  ThoiDiem    DATE           DEFAULT SYSDATE NOT NULL
);

CREATE TABLE NhatKyEmail (
  MaEmail     NUMBER         CONSTRAINT PK_NhatKyEmail PRIMARY KEY,
  SoDonHang   VARCHAR2(12)   NOT NULL CONSTRAINT FK_Email_Don REFERENCES DonDatHang(SoDonHang) ON DELETE CASCADE,
  DiaChiEmail VARCHAR2(100)  NOT NULL,
  TieuDe      NVARCHAR2(200) NOT NULL,
  NoiDung     NCLOB,
  ThoiDiemGui DATE           DEFAULT SYSDATE NOT NULL
);

CREATE INDEX IX_SanPham_Nhom ON SanPham(MaNhom);
CREATE INDEX IX_Don_KhachHang ON DonDatHang(MaKH, ThoiDiemDat);
CREATE INDEX IX_Don_TrangThai ON DonDatHang(TrangThai);

-- ---------------------------------------------------------------- 7. Sequence
CREATE SEQUENCE SEQ_KhachHang START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_GioHang   START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_DonHang   START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_The       START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_NhatKyTT  START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_Email     START WITH 100 NOCACHE;
CREATE SEQUENCE SEQ_HinhAnh   START WITH 100 NOCACHE;

-- ---------------------------------------------------------------- 8. Hàm, trigger, view
-- BR06 + BR07: phí giao theo khu vực của tỉnh nhận và loại phiếu; miễn phí khi tổng tiền hàng đạt ngưỡng.
CREATE OR REPLACE FUNCTION FN_TinhPhiGiao (
  p_MaTinh       IN VARCHAR2,
  p_MaLoaiPhieu  IN VARCHAR2,
  p_TongTienHang IN NUMBER
) RETURN NUMBER
IS
  v_Phi    NUMBER;
  v_Nguong NUMBER;
BEGIN
  SELECT b.PhiGiao, l.NguongMienPhi
    INTO v_Phi, v_Nguong
    FROM TinhThanh t
    JOIN BangPhiGiaoHang b ON b.MaKhuVuc = t.MaKhuVuc
    JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = b.MaLoaiPhieu
   WHERE t.MaTinh = p_MaTinh AND b.MaLoaiPhieu = p_MaLoaiPhieu;
  IF v_Nguong IS NOT NULL AND p_TongTienHang >= v_Nguong THEN
    RETURN 0;
  END IF;
  RETURN v_Phi;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    RAISE_APPLICATION_ERROR(-20001, 'Chua co bieu phi giao hang cho tinh/thanh va loai phieu nay.');
END;
/

-- Giá bán / tình trạng do HTQLSP đồng bộ sang: ghi lại thời điểm cập nhật.
CREATE OR REPLACE TRIGGER TRG_SanPham_CapNhat
BEFORE UPDATE OF GiaBan, TinhTrang, TenSP, MoTa ON SanPham
FOR EACH ROW
BEGIN
  :NEW.NgayCapNhat := SYSDATE;
END;
/

CREATE OR REPLACE VIEW V_SanPham AS
SELECT s.MaSP, s.TenSP, s.MaNhom, n.TenNhom, s.NhaSanXuat, s.MoTa, s.GiaBan, s.TinhTrang, s.NgayCapNhat
  FROM SanPham s JOIN NhomSanPham n ON n.MaNhom = s.MaNhom;

CREATE OR REPLACE VIEW V_DonHang AS
SELECT d.SoDonHang, d.ThoiDiemDat, d.MaKH, k.HoTen, l.TenLoai, d.TenNguoiNhan, d.DiaChiNhan, t.TenTinh,
       d.DienThoaiNhan, d.TongTienHang, d.PhiGiaoHang, d.LePhiThe, d.TongTriGia, th.SoTheAn, d.MaGiaoDich,
       d.TrangThai, d.DaGuiEmail
  FROM DonDatHang d
  JOIN KhachHang k ON k.MaKH = d.MaKH
  JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = d.MaLoaiPhieu
  JOIN TinhThanh t ON t.MaTinh = d.MaTinh
  JOIN TheTinDung th ON th.MaThe = d.MaThe;

-- ---------------------------------------------------------------- 9. Dữ liệu mẫu
INSERT INTO NhomSanPham VALUES ('MCH',  N'Máy chụp hình kỹ thuật số', N'Máy ảnh compact, mirrorless, DSLR');
INSERT INTO NhomSanPham VALUES ('DOCHOI', N'Đồ chơi', N'Đồ chơi trẻ em, mô hình, xếp hình');
INSERT INTO NhomSanPham VALUES ('GIADUNG', N'Thiết bị điện gia dụng', N'Nồi cơm, máy xay, máy lọc không khí');
INSERT INTO NhomSanPham VALUES ('MAYTINH', N'Thiết bị máy tính', N'Laptop, chuột, bàn phím, màn hình');
INSERT INTO NhomSanPham VALUES ('QUATANG', N'Quà tặng Giáng Sinh', N'Hộp quà, thiệp, đồ trang trí Noel');

INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP001', N'Máy ảnh Canon EOS R50 kèm lens 18-45', 'MCH', N'Canon', N'Máy ảnh mirrorless nhỏ gọn cho người mới, quay 4K, lấy nét Dual Pixel.', 18990000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP002', N'Máy ảnh Sony ZV-1 II', 'MCH', N'Sony', N'Máy ảnh compact dành cho vlog, ống kính góc rộng 18-50mm.', 19490000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP003', N'Máy ảnh Fujifilm Instax Mini 12', 'MCH', N'Fujifilm', N'Máy chụp lấy liền, nhiều màu pastel, quà tặng phổ biến.', 1890000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP004', N'Máy ảnh Nikon Z fc', 'MCH', N'Nikon', N'Thiết kế cổ điển, cảm biến APS-C 20.9MP.', 21990000, N'Hết hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP005', N'Bộ xếp hình LEGO Ngôi nhà Giáng Sinh', 'DOCHOI', N'LEGO', N'Bộ 1.200 chi tiết, phù hợp từ 12 tuổi.', 2490000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP006', N'Gấu bông Teddy 80cm', 'DOCHOI', N'Teddy Home', N'Gấu bông lông mịn, an toàn cho trẻ nhỏ.', 450000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP007', N'Xe điều khiển địa hình 1:16', 'DOCHOI', N'Hot Wheels', N'Pin sạc, tốc độ 25 km/h, điều khiển 2.4GHz.', 890000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP008', N'Nồi cơm điện tử Cuckoo 1.8L', 'GIADUNG', N'Cuckoo', N'Lòng nồi chống dính, 12 chế độ nấu.', 2790000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP009', N'Máy lọc không khí Xiaomi 4 Lite', 'GIADUNG', N'Xiaomi', N'Lọc HEPA H13, phòng 43 m2, điều khiển qua app.', 2990000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP010', N'Máy xay sinh tố Philips HR2223', 'GIADUNG', N'Philips', N'Công suất 700W, cối 1.5L, lưỡi dao ProBlend.', 1290000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP011', N'Laptop ASUS Vivobook 15 OLED', 'MAYTINH', N'ASUS', N'Core i5-13500H, RAM 16GB, SSD 512GB, màn OLED 15.6".', 17490000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP012', N'Chuột không dây Logitech MX Master 3S', 'MAYTINH', N'Logitech', N'Cảm biến 8K DPI, sạc USB-C, kết nối 3 thiết bị.', 2290000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP013', N'Bàn phím cơ Keychron K2 V2', 'MAYTINH', N'Keychron', N'Layout 75%, switch Gateron Brown, Bluetooth.', 1890000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP014', N'Màn hình Dell UltraSharp U2424H', 'MAYTINH', N'Dell', N'24 inch IPS, 120Hz, chuẩn màu sRGB 100%.', 5590000, N'Hết hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP015', N'Hộp quà Giáng Sinh cao cấp', 'QUATANG', N'ABC Gift', N'Hộp gỗ kèm rượu vang, socola và thiệp Noel.', 1150000, N'Còn hàng');
INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP016', N'Cây thông Noel 1m8 kèm đèn LED', 'QUATANG', N'ABC Gift', N'Cây thông nhựa cao cấp, 300 bóng LED nhiều chế độ.', 990000, N'Còn hàng');

-- Mỗi sản phẩm hai ảnh minh họa (thư mục Images đi kèm ứng dụng)
BEGIN
  FOR r IN (SELECT MaSP FROM SanPham) LOOP
    INSERT INTO HinhAnhSanPham VALUES (SEQ_HinhAnh.NEXTVAL, r.MaSP, 'Images/' || r.MaSP || '_1.png', 1);
    INSERT INTO HinhAnhSanPham VALUES (SEQ_HinhAnh.NEXTVAL, r.MaSP, 'Images/' || r.MaSP || '_2.png', 2);
  END LOOP;
END;
/

INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Cảm biến', N'APS-C 24.2MP');
INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Quay phim', N'4K 30p');
INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Trọng lượng', N'375 g');
INSERT INTO ThongSoKyThuat VALUES ('SP002', N'Cảm biến', N'1 inch 20.1MP');
INSERT INTO ThongSoKyThuat VALUES ('SP002', N'Ống kính', N'18-50mm f/1.8-4');
INSERT INTO ThongSoKyThuat VALUES ('SP003', N'Loại phim', N'Instax Mini');
INSERT INTO ThongSoKyThuat VALUES ('SP003', N'Pin', N'2 pin AA');
INSERT INTO ThongSoKyThuat VALUES ('SP004', N'Cảm biến', N'APS-C 20.9MP');
INSERT INTO ThongSoKyThuat VALUES ('SP005', N'Số chi tiết', N'1.200');
INSERT INTO ThongSoKyThuat VALUES ('SP005', N'Độ tuổi', N'12+');
INSERT INTO ThongSoKyThuat VALUES ('SP006', N'Kích thước', N'80 cm');
INSERT INTO ThongSoKyThuat VALUES ('SP007', N'Tỉ lệ', N'1:16');
INSERT INTO ThongSoKyThuat VALUES ('SP007', N'Thời gian chơi', N'25 phút / lần sạc');
INSERT INTO ThongSoKyThuat VALUES ('SP008', N'Dung tích', N'1.8 lít');
INSERT INTO ThongSoKyThuat VALUES ('SP008', N'Công suất', N'860 W');
INSERT INTO ThongSoKyThuat VALUES ('SP009', N'Màng lọc', N'HEPA H13');
INSERT INTO ThongSoKyThuat VALUES ('SP009', N'Diện tích', N'43 m2');
INSERT INTO ThongSoKyThuat VALUES ('SP010', N'Công suất', N'700 W');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'CPU', N'Intel Core i5-13500H');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'RAM', N'16 GB DDR4');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'Màn hình', N'15.6 inch OLED 2.8K');
INSERT INTO ThongSoKyThuat VALUES ('SP012', N'DPI', N'200 - 8000');
INSERT INTO ThongSoKyThuat VALUES ('SP013', N'Switch', N'Gateron Brown');
INSERT INTO ThongSoKyThuat VALUES ('SP014', N'Tần số quét', N'120 Hz');
INSERT INTO ThongSoKyThuat VALUES ('SP015', N'Gồm', N'Rượu vang, socola, thiệp');
INSERT INTO ThongSoKyThuat VALUES ('SP016', N'Chiều cao', N'1,8 m');

-- Mật khẩu mẫu của mọi tài khoản: Eshop@123  (SHA-256 của Salt || MatKhau)
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, SoGiayTo, DiaChi, DienThoai, TenDangNhap, MatKhauHash, Salt, Email, NgayDangKy)
VALUES ('KH001', N'Nguyễn Văn An', DATE '1998-05-12', '079098001234', N'12 Lê Lợi, Quận 1', '0901234567', 'an.nv',
        'E96812255D4E348BA5BCF24BA1E07D4230B61AF2B23467415C510754C06F1184', 'A1B2C3D4E5F60718', 'an.nv@example.com', DATE '2026-09-01');
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, SoGiayTo, DiaChi, DienThoai, TenDangNhap, MatKhauHash, Salt, Email, NgayDangKy)
VALUES ('KH002', N'Trần Thị Bình', DATE '2000-11-20', 'C1234567', N'45 Trần Phú, Hải Châu', '0912345678', 'binh.tt',
        'AFBE3E31325C00EF0D6F0A96046EF44C267473A79635390D52765F58CB9C602B', '9F8E7D6C5B4A3921', NULL, DATE '2026-09-15');

INSERT INTO NhanVien VALUES ('NV001', N'Lê Quản Trị', 'admin',
        'E52ABE9028138C8630B6219257167D39A793C7935B84DC32B83331AA94131446', '0A1B2C3D4E5F6071', N'Quản trị');
INSERT INTO NhanVien VALUES ('NV002', N'Phạm Bán Hàng', 'banhang',
        'A7206C3BD79FA862689836B929D4CFE288B97B5B1AC2A716480B2AA216510CF9', '7766554433221100', N'Nhân viên bán hàng');

INSERT INTO LoaiPhieuDatHang VALUES ('THUONG',   N'Phiếu đặt hàng thường', 72, 1000000);
INSERT INTO LoaiPhieuDatHang VALUES ('CPN',      N'Chuyển phát nhanh', 24, 1000000);
INSERT INTO LoaiPhieuDatHang VALUES ('CPN_NGAY', N'Chuyển phát nhanh trong ngày', 6, 5000000);

INSERT INTO KhuVucGiaoHang VALUES ('NOITHANH', N'Nội thành TP.HCM');
INSERT INTO KhuVucGiaoHang VALUES ('MIENNAM', N'Các tỉnh miền Nam');
INSERT INTO KhuVucGiaoHang VALUES ('MIENTRUNG', N'Các tỉnh miền Trung');
INSERT INTO KhuVucGiaoHang VALUES ('MIENBAC', N'Các tỉnh miền Bắc');

INSERT INTO TinhThanh VALUES ('HCM', N'TP. Hồ Chí Minh', 'NOITHANH');
INSERT INTO TinhThanh VALUES ('BD',  N'Bình Dương', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('DN',  N'Đồng Nai', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('CT',  N'Cần Thơ', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('DNG', N'Đà Nẵng', 'MIENTRUNG');
INSERT INTO TinhThanh VALUES ('HUE', N'Huế', 'MIENTRUNG');
INSERT INTO TinhThanh VALUES ('HN',  N'Hà Nội', 'MIENBAC');
INSERT INTO TinhThanh VALUES ('HP',  N'Hải Phòng', 'MIENBAC');

INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'THUONG',    20000);
INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'CPN',       35000);
INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'CPN_NGAY',  60000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'THUONG',    30000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'CPN',       50000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'CPN_NGAY',  90000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'THUONG',    40000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'CPN',       70000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'CPN_NGAY', 150000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'THUONG',    45000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'CPN',       80000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'CPN_NGAY', 180000);

INSERT INTO LoaiThe VALUES ('VISA',     N'VISA', 16, 3, 5000);
INSERT INTO LoaiThe VALUES ('MASTER',   N'MasterCard', 16, 3, 5000);
INSERT INTO LoaiThe VALUES ('DISCOVER', N'Discover', 16, 3, 8000);
INSERT INTO LoaiThe VALUES ('AMEX',     N'American Express', 15, 4, 12000);

-- Thẻ đã dùng của khách mẫu (chỉ lưu số đã che + token)
INSERT INTO TheTinDung VALUES (1, 'KH001', 'VISA', '**** **** **** 1111', 12, 2028, N'NGUYEN VAN AN', 'TOK-VISA-KH001-0001');
INSERT INTO TheTinDung VALUES (2, 'KH002', 'AMEX', '**** ****** *0005', 6, 2029, N'TRAN THI BINH', 'TOK-AMEX-KH002-0001');

-- Hai đơn hàng mẫu ở các trạng thái khác nhau
INSERT INTO DonDatHang (SoDonHang, MaKH, MaLoaiPhieu, ThoiDiemDat, TenNguoiNhan, DiaChiNhan, MaTinh, DienThoaiNhan,
                        TongTienHang, PhiGiaoHang, LePhiThe, MaThe, MaGiaoDich, TrangThai, DaGuiEmail)
VALUES ('DH000001', 'KH001', 'CPN', TIMESTAMP '2026-09-20 10:15:00', N'Nguyễn Thị Hoa', N'88 Nguyễn Huệ, Phú Hội', 'HUE', '0987654321',
        2940000, 0, 5000, 1, 'GD20260920101500A1', N'Đã giao', 'Y');
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP003', 1, 1890000);
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP006', 1, 450000);
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP016', 1, 600000);

INSERT INTO DonDatHang (SoDonHang, MaKH, MaLoaiPhieu, ThoiDiemDat, TenNguoiNhan, DiaChiNhan, MaTinh, DienThoaiNhan,
                        TongTienHang, PhiGiaoHang, LePhiThe, MaThe, MaGiaoDich, TrangThai, DaGuiEmail)
VALUES ('DH000002', 'KH002', 'THUONG', TIMESTAMP '2026-09-28 20:40:00', N'Trần Thị Bình', N'45 Trần Phú, Hải Châu', 'DNG', '0912345678',
        890000, 40000, 12000, 2, 'GD20260928204000B2', N'Chờ xử lý', 'N');
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000002', 'SP007', 1, 890000);

INSERT INTO NhatKyThanhToan VALUES (1, 'KH001', 'VISA', '**** **** **** 1111', 2945000, N'Chấp thuận', 'GD20260920101500A1', NULL, TIMESTAMP '2026-09-20 10:15:00');
INSERT INTO NhatKyThanhToan VALUES (2, 'KH002', 'VISA', '**** **** **** 0002', 942000, N'Từ chối', NULL, N'Thẻ không đủ khả năng thanh toán', TIMESTAMP '2026-09-28 20:38:00');
INSERT INTO NhatKyThanhToan VALUES (3, 'KH002', 'AMEX', '**** ****** *0005', 942000, N'Chấp thuận', 'GD20260928204000B2', NULL, TIMESTAMP '2026-09-28 20:40:00');

INSERT INTO NhatKyEmail VALUES (1, 'DH000001', 'an.nv@example.com', N'[e-SHOPPING] Xác nhận đơn hàng DH000001',
        N'Cảm ơn quý khách đã đặt hàng tại e-SHOPPING. Đơn hàng DH000001 gồm 3 sản phẩm, tổng trị giá 2.945.000 đ.', TIMESTAMP '2026-09-20 10:15:05');

-- Giỏ hàng đang mua của khách KH001
INSERT INTO GioHang (MaGioHang, MaKH, NgayTao) VALUES (1, 'KH001', SYSDATE - 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES (1, 'SP012', 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES (1, 'SP015', 2);

COMMIT;

-- ---------------------------------------------------------------- 10. Kiểm tra nhanh
SELECT 'NhomSanPham' AS Bang, COUNT(*) AS SoDong FROM NhomSanPham
UNION ALL SELECT 'SanPham', COUNT(*) FROM SanPham
UNION ALL SELECT 'HinhAnhSanPham', COUNT(*) FROM HinhAnhSanPham
UNION ALL SELECT 'KhachHang', COUNT(*) FROM KhachHang
UNION ALL SELECT 'DonDatHang', COUNT(*) FROM DonDatHang
UNION ALL SELECT 'BangPhiGiaoHang', COUNT(*) FROM BangPhiGiaoHang;

SELECT FN_TinhPhiGiao('HN', 'CPN', 800000)  AS Phi_HN_CPN_800k,
       FN_TinhPhiGiao('HN', 'CPN', 1200000) AS Phi_HN_CPN_1tr2,
       FN_TinhPhiGiao('HN', 'CPN_NGAY', 1200000) AS Phi_HN_NGAY_1tr2,
       FN_TinhPhiGiao('HN', 'CPN_NGAY', 5000000) AS Phi_HN_NGAY_5tr
  FROM dual;
