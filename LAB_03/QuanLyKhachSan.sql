SET DEFINE OFF;

PROMPT [1/4] XOA OBJECT CU...

BEGIN
  FOR r IN (SELECT table_name FROM user_tables WHERE table_name IN (
      'THANHTOAN','HOADON','CHITIETPHIEUDENBU','PHIEUDENBU','QUYDINHDENBU',
      'CHITIETPHIEUSUDUNGDV','PHIEUSUDUNGDV','DICHVU','NGUOILUUTRU',
      'CHITIETDATPHONG','PHIEUDATPHONG','KHACHHANG','PHIEULAPDAT','TIENNGHI',
      'LOAITIENNGHI','PHONG','KHUVUC','NHANVIEN'))
  LOOP
    EXECUTE IMMEDIATE 'DROP TABLE ' || r.table_name || ' CASCADE CONSTRAINTS PURGE';
  END LOOP;
  FOR s IN (SELECT sequence_name FROM user_sequences WHERE sequence_name LIKE 'SEQ_%')
  LOOP
    EXECUTE IMMEDIATE 'DROP SEQUENCE ' || s.sequence_name;
  END LOOP;
END;
/

PROMPT [2/4] TAO BANG...

CREATE TABLE NhanVien (
    MaNV        VARCHAR2(20)   NOT NULL,
    HoTen       NVARCHAR2(120) NOT NULL,
    VaiTro      NVARCHAR2(50)  NOT NULL,
    SoDienThoai VARCHAR2(20),
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
);

CREATE TABLE KhuVuc (
    MaKhuVuc  VARCHAR2(20)   NOT NULL,
    TenKhuVuc NVARCHAR2(100) NOT NULL,
    CONSTRAINT PK_KhuVuc PRIMARY KEY (MaKhuVuc),
    CONSTRAINT UQ_KhuVuc_Ten UNIQUE (TenKhuVuc)
);

CREATE TABLE Phong (
    SoPhong      VARCHAR2(20)  NOT NULL,
    MaKhuVuc     VARCHAR2(20)  NOT NULL,
    SoNguoiToiDa NUMBER(10)    NOT NULL,
    DonGiaNgay   NUMBER(18,2)  NOT NULL,
    TrangThai    NVARCHAR2(30) DEFAULT N'Trống' NOT NULL,
    CONSTRAINT PK_Phong PRIMARY KEY (SoPhong),
    CONSTRAINT FK_Phong_KhuVuc FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc),
    CONSTRAINT CK_Phong_SucChua CHECK (SoNguoiToiDa > 0),
    CONSTRAINT CK_Phong_DonGia CHECK (DonGiaNgay >= 0),
    CONSTRAINT CK_Phong_TrangThai CHECK (TrangThai IN (N'Trống', N'Đã đặt', N'Đang ở', N'Bảo trì'))
);

CREATE TABLE LoaiTienNghi (
    MaLoaiTN  VARCHAR2(20)   NOT NULL,
    TenLoaiTN NVARCHAR2(100) NOT NULL,
    CONSTRAINT PK_LoaiTienNghi PRIMARY KEY (MaLoaiTN),
    CONSTRAINT UQ_LoaiTN_Ten UNIQUE (TenLoaiTN)
);

CREATE TABLE TienNghi (
    MaTienNghi       VARCHAR2(30)   NOT NULL,
    MaLoaiTN         VARCHAR2(20)   NOT NULL,
    SoThuTu          NUMBER(10)     NOT NULL,
    TinhTrangHienTai NVARCHAR2(100),
    CONSTRAINT PK_TienNghi PRIMARY KEY (MaTienNghi),
    CONSTRAINT UQ_TienNghi_Loai_STT UNIQUE (MaLoaiTN, SoThuTu),
    CONSTRAINT FK_TienNghi_Loai FOREIGN KEY (MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN),
    CONSTRAINT CK_TienNghi_STT CHECK (SoThuTu > 0)
);

CREATE TABLE PhieuLapDat (
    SoPhieuLapDat VARCHAR2(30)   NOT NULL,
    MaTienNghi    VARCHAR2(30)   NOT NULL,
    SoPhong       VARCHAR2(20)   NOT NULL,
    NgayLap       DATE           NOT NULL,
    TinhTrang     NVARCHAR2(100) NOT NULL,
    MaNV          VARCHAR2(20)   NOT NULL,
    GhiChu        NVARCHAR2(250),
    CONSTRAINT PK_PhieuLapDat PRIMARY KEY (SoPhieuLapDat),
    CONSTRAINT UQ_PhieuLapDat_ThietBi_Ngay UNIQUE (MaTienNghi, NgayLap),
    CONSTRAINT FK_PhieuLapDat_TienNghi FOREIGN KEY (MaTienNghi) REFERENCES TienNghi(MaTienNghi),
    CONSTRAINT FK_PhieuLapDat_Phong FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong),
    CONSTRAINT FK_PhieuLapDat_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE DichVu (
    MaDV      VARCHAR2(20)   NOT NULL,
    TenDV     NVARCHAR2(120) NOT NULL,
    DonViTinh NVARCHAR2(40)  NOT NULL,
    DonGia    NUMBER(18,2)   NOT NULL,
    CONSTRAINT PK_DichVu PRIMARY KEY (MaDV),
    CONSTRAINT CK_DichVu_DonGia CHECK (DonGia >= 0)
);

CREATE TABLE KhachHang (
    MaKhach     VARCHAR2(20)   NOT NULL,
    HoTen       NVARCHAR2(120) NOT NULL,
    SoCMND      VARCHAR2(30)   NOT NULL,
    QuocTich    NVARCHAR2(80)  NOT NULL,
    SoDienThoai VARCHAR2(20),
    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKhach),
    CONSTRAINT UQ_KhachHang_CMND UNIQUE (SoCMND)
);

CREATE TABLE PhieuDatPhong (
    SoPhieuDat      VARCHAR2(30)  NOT NULL,
    MaKhach         VARCHAR2(20)  NOT NULL,
    MaNVLeTan       VARCHAR2(20)  NOT NULL,
    NgayLap         DATE          NOT NULL,
    NgayNhan        DATE          NOT NULL,
    NgayTraDuKien   DATE          NOT NULL,
    TienCoc         NUMBER(18,2)  DEFAULT 0 NOT NULL,
    KenhDat         NVARCHAR2(20) NOT NULL,
    TrangThai       NVARCHAR2(30) DEFAULT N'Đã đặt' NOT NULL,
    NgayNhanThucTe  DATE,
    NgayTraThucTe   DATE,
    CONSTRAINT PK_PhieuDatPhong PRIMARY KEY (SoPhieuDat),
    CONSTRAINT FK_PhieuDat_Khach FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
    CONSTRAINT FK_PhieuDat_NV FOREIGN KEY (MaNVLeTan) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_PhieuDat_Coc CHECK (TienCoc >= 0),
    CONSTRAINT CK_PhieuDat_Ngay CHECK (NgayTraDuKien >= NgayNhan),
    CONSTRAINT CK_PhieuDat_Kenh CHECK (KenhDat IN (N'Điện thoại', N'Website', N'Trực tiếp')),
    CONSTRAINT CK_PhieuDat_TrangThai CHECK (TrangThai IN (N'Đã đặt', N'Đang ở', N'Đã trả', N'No-show', N'Hủy'))
);

CREATE TABLE ChiTietDatPhong (
    SoPhieuDat   VARCHAR2(30) NOT NULL,
    SoPhong      VARCHAR2(20) NOT NULL,
    SoNguoi      NUMBER(10)   NOT NULL,
    DonGiaApDung NUMBER(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietDatPhong PRIMARY KEY (SoPhieuDat, SoPhong),
    CONSTRAINT FK_CTDat_Phieu FOREIGN KEY (SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
    CONSTRAINT FK_CTDat_Phong FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong),
    CONSTRAINT CK_CTDat_SoNguoi CHECK (SoNguoi > 0),
    CONSTRAINT CK_CTDat_DonGia CHECK (DonGiaApDung >= 0)
);

CREATE TABLE NguoiLuuTru (
    MaNguoiLT  NUMBER(10) GENERATED BY DEFAULT AS IDENTITY,
    SoPhieuDat VARCHAR2(30)   NOT NULL,
    SoPhong    VARCHAR2(20)   NOT NULL,
    HoTen      NVARCHAR2(120) NOT NULL,
    SoCMND     VARCHAR2(30)   NOT NULL,
    QuocTich   NVARCHAR2(80)  NOT NULL,
    CONSTRAINT PK_NguoiLuuTru PRIMARY KEY (MaNguoiLT),
    CONSTRAINT FK_NguoiLT_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong)
);

CREATE TABLE PhieuSuDungDV (
    SoPhieuSDDV VARCHAR2(30) NOT NULL,
    SoPhieuDat  VARCHAR2(30) NOT NULL,
    SoPhong     VARCHAR2(20) NOT NULL,
    NgaySuDung  DATE         NOT NULL,
    MaNV        VARCHAR2(20) NOT NULL,
    CONSTRAINT PK_PhieuSuDungDV PRIMARY KEY (SoPhieuSDDV),
    CONSTRAINT UQ_PhieuSDDV_PhongNgay UNIQUE (SoPhieuDat, SoPhong, NgaySuDung),
    CONSTRAINT FK_PhieuSDDV_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
    CONSTRAINT FK_PhieuSDDV_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuSuDungDV (
    SoPhieuSDDV VARCHAR2(30) NOT NULL,
    MaDV        VARCHAR2(20) NOT NULL,
    SoLuong     NUMBER(10)   NOT NULL,
    DonGia      NUMBER(18,2) NOT NULL,
    ThanhTien   NUMBER(18,2) GENERATED ALWAYS AS (SoLuong * DonGia) VIRTUAL,
    CONSTRAINT PK_CTSDDV PRIMARY KEY (SoPhieuSDDV, MaDV),
    CONSTRAINT FK_CTSDDV_Phieu FOREIGN KEY (SoPhieuSDDV) REFERENCES PhieuSuDungDV(SoPhieuSDDV),
    CONSTRAINT FK_CTSDDV_DV FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV),
    CONSTRAINT CK_CTSDDV_SoLuong CHECK (SoLuong > 0),
    CONSTRAINT CK_CTSDDV_DonGia CHECK (DonGia >= 0)
);

CREATE TABLE QuyDinhDenBu (
    MaQuyDinh     VARCHAR2(30)  NOT NULL,
    MaLoaiTN      VARCHAR2(20)  NOT NULL,
    MucDoThietHai NVARCHAR2(80) NOT NULL,
    MucDenBu      NUMBER(18,2)  NOT NULL,
    CONSTRAINT PK_QuyDinhDenBu PRIMARY KEY (MaQuyDinh),
    CONSTRAINT UQ_QDDB_Loai_MucDo UNIQUE (MaLoaiTN, MucDoThietHai),
    CONSTRAINT FK_QDDB_Loai FOREIGN KEY (MaLoaiTN) REFERENCES LoaiTienNghi(MaLoaiTN),
    CONSTRAINT CK_QDDB_Muc CHECK (MucDenBu >= 0)
);

CREATE TABLE PhieuDenBu (
    SoPhieuDenBu VARCHAR2(30) NOT NULL,
    SoPhieuDat   VARCHAR2(30) NOT NULL,
    SoPhong      VARCHAR2(20) NOT NULL,
    NgayLap      DATE         NOT NULL,
    MaNV         VARCHAR2(20) NOT NULL,
    TongTien     NUMBER(18,2) DEFAULT 0 NOT NULL,
    CONSTRAINT PK_PhieuDenBu PRIMARY KEY (SoPhieuDenBu),
    CONSTRAINT FK_PhieuDB_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),
    CONSTRAINT FK_PhieuDB_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_PhieuDB_Tong CHECK (TongTien >= 0)
);

CREATE TABLE ChiTietPhieuDenBu (
    SoPhieuDenBu  VARCHAR2(30)  NOT NULL,
    MaTienNghi    VARCHAR2(30)  NOT NULL,
    MucDoThietHai NVARCHAR2(80) NOT NULL,
    SoTien        NUMBER(18,2)  NOT NULL,
    CONSTRAINT PK_CTDenBu PRIMARY KEY (SoPhieuDenBu, MaTienNghi),
    CONSTRAINT FK_CTDB_Phieu FOREIGN KEY (SoPhieuDenBu) REFERENCES PhieuDenBu(SoPhieuDenBu),
    CONSTRAINT FK_CTDB_TienNghi FOREIGN KEY (MaTienNghi) REFERENCES TienNghi(MaTienNghi),
    CONSTRAINT CK_CTDB_SoTien CHECK (SoTien >= 0)
);

CREATE TABLE HoaDon (
    SoHoaDon       VARCHAR2(30)  NOT NULL,
    SoPhieuDat     VARCHAR2(30)  NOT NULL,
    NgayLap        DATE          NOT NULL,
    MaNV           VARCHAR2(20)  NOT NULL,
    SoNgayTinhTien NUMBER(10)    NOT NULL,
    TienPhong      NUMBER(18,2)  NOT NULL,
    TienDichVu     NUMBER(18,2)  NOT NULL,
    TongTien       NUMBER(18,2)  GENERATED ALWAYS AS (TienPhong + TienDichVu) VIRTUAL,
    TrangThai      NVARCHAR2(30) DEFAULT N'Chưa thanh toán' NOT NULL,
    CONSTRAINT PK_HoaDon PRIMARY KEY (SoHoaDon),
    CONSTRAINT UQ_HoaDon_PhieuDat UNIQUE (SoPhieuDat),
    CONSTRAINT FK_HoaDon_PhieuDat FOREIGN KEY (SoPhieuDat) REFERENCES PhieuDatPhong(SoPhieuDat),
    CONSTRAINT FK_HoaDon_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT CK_HoaDon_SoNgay CHECK (SoNgayTinhTien > 0),
    CONSTRAINT CK_HoaDon_TienPhong CHECK (TienPhong >= 0),
    CONSTRAINT CK_HoaDon_TienDV CHECK (TienDichVu >= 0),
    CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán'))
);

CREATE TABLE ThanhToan (
    MaThanhToan   VARCHAR2(30)  NOT NULL,
    SoHoaDon      VARCHAR2(30)  NOT NULL,
    NgayThanhToan DATE          NOT NULL,
    HinhThuc      NVARCHAR2(30) NOT NULL,
    SoTien        NUMBER(18,2)  NOT NULL,
    CONSTRAINT PK_ThanhToan PRIMARY KEY (MaThanhToan),
    CONSTRAINT FK_ThanhToan_HoaDon FOREIGN KEY (SoHoaDon) REFERENCES HoaDon(SoHoaDon),
    CONSTRAINT CK_ThanhToan_SoTien CHECK (SoTien > 0),
    CONSTRAINT CK_ThanhToan_HinhThuc CHECK (HinhThuc IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử'))
);

CREATE INDEX IX_PhieuDatPhong_Ngay ON PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);
CREATE INDEX IX_CTDat_Phong ON ChiTietDatPhong(SoPhong, SoPhieuDat);
CREATE INDEX IX_PhieuLapDat_Phong ON PhieuLapDat(SoPhong, NgayLap);
CREATE INDEX IX_ThanhToan_HoaDon ON ThanhToan(SoHoaDon);

CREATE SEQUENCE SEQ_KhachHang   START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_PhieuLapDat START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_PhieuDat    START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_PhieuSDDV   START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_PhieuDenBu  START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_HoaDon      START WITH 100 INCREMENT BY 1 NOCACHE;
CREATE SEQUENCE SEQ_ThanhToan   START WITH 100 INCREMENT BY 1 NOCACHE;

PROMPT [3/4] DU LIEU MAU...

INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV01', N'Nguyễn Thu Hà', N'Lễ tân', '0901000001');
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV02', N'Trần Minh An', N'Phục vụ phòng', '0901000002');
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV03', N'Lê Hoàng Nam', N'Thanh toán', '0901000003');
INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV04', N'Phạm Quỳnh Chi', N'Quản lý', '0901000004');

INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('A', N'Khu A');
INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('B', N'Khu B');

INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A101', 'A', 2, 600000, N'Trống');
INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A102', 'A', 3, 800000, N'Trống');
INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('B201', 'B', 4, 1200000, N'Trống');

INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TV', N'Ti vi');
INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TL', N'Tủ lạnh');
INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('DT', N'Điện thoại');

INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV01', 'TV', 1, N'Tốt');
INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV02', 'TV', 2, N'Tốt');
INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TL01', 'TL', 1, N'Tốt');
INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('DT01', 'DT', 1, N'Tốt');

INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV01', N'Ăn sáng', N'Suất', 120000);
INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV02', N'Tắm hơi', N'Lượt', 250000);
INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV03', N'Karaoke', N'Giờ', 300000);

INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD01', 'TV', N'Hư hỏng nhẹ', 500000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD02', 'TV', N'Mất', 5000000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD03', 'TL', N'Hư hỏng nhẹ', 400000);
INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD04', 'TL', N'Mất', 4000000);

INSERT INTO KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai)
VALUES ('KH001', N'Nguyễn Văn A', '079201000111', N'Việt Nam', '0912000001');
INSERT INTO KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai)
VALUES ('KH002', N'Trần Thị B', '079201000222', N'Việt Nam', '0912000002');

INSERT INTO PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)
VALUES ('LD001', 'TV01', 'A101', TRUNC(SYSDATE) - 30, N'Tốt', 'NV02', NULL);
INSERT INTO PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)
VALUES ('LD002', 'TL01', 'A101', TRUNC(SYSDATE) - 30, N'Tốt', 'NV02', NULL);
INSERT INTO PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)
VALUES ('LD003', 'TV02', 'B201', TRUNC(SYSDATE) - 20, N'Tốt', 'NV02', NULL);

INSERT INTO PhieuDatPhong(SoPhieuDat, MaKhach, MaNVLeTan, NgayLap, NgayNhan, NgayTraDuKien,
                          TienCoc, KenhDat, TrangThai, NgayNhanThucTe)
VALUES ('DP001', 'KH001', 'NV01', SYSDATE - 2, TRUNC(SYSDATE) - 2, TRUNC(SYSDATE) + 1,
        500000, N'Website', N'Đang ở', SYSDATE - 2);
INSERT INTO ChiTietDatPhong(SoPhieuDat, SoPhong, SoNguoi, DonGiaApDung) VALUES ('DP001', 'A101', 2, 600000);
INSERT INTO NguoiLuuTru(SoPhieuDat, SoPhong, HoTen, SoCMND, QuocTich)
VALUES ('DP001', 'A101', N'Nguyễn Văn A', '079201000111', N'Việt Nam');
UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = 'A101';

INSERT INTO PhieuSuDungDV(SoPhieuSDDV, SoPhieuDat, SoPhong, NgaySuDung, MaNV)
VALUES ('SD001', 'DP001', 'A101', TRUNC(SYSDATE) - 1, 'NV02');
INSERT INTO ChiTietPhieuSuDungDV(SoPhieuSDDV, MaDV, SoLuong, DonGia) VALUES ('SD001', 'DV01', 2, 120000);

COMMIT;

PROMPT [4/4] KIEM TRA...

SELECT table_name FROM user_tables ORDER BY table_name;
SELECT COUNT(*) AS SoBang FROM user_tables;
SELECT SoPhong, TrangThai FROM Phong ORDER BY SoPhong;
SELECT SoPhieuDat, TrangThai FROM PhieuDatPhong;

PROMPT HOAN TAT SCRIPT CHINH.
