CREATE DATABASE QL_INTERNET1
USE QL_INTERNET1
GO


CREATE TABLE KHACHHANG
 (
	MaKH char(5) NOT NULL,
	TenKH nvarchar(50) NULL,
	DiaChi nvarchar (50) NULL,
	SDT char(10) NULL,
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (MAKH)
 )
 create table ChucVu(
	MaCV char(5) NOT NULL,
	TenCV Nvarchar(20) null,
	CONSTRAINT PK_CHUCVU primary key (MaCV)
 )
 CREATE TABLE NHANVIEN
(
	MaNV char(5) NOT NULL,
	TenNV nvarchar(50) NULL,
	GioiTinh nvarchar(5) NULL,
    LUONG INTEGER,
    MaCV char(5) NULL,
	DiaChiNV nvarchar(50) NULL,
	SDTNV char(20) NULL,
	NgaySinh date NULL,
	CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV),
	CONSTRAINT FK_ChucVu FOREIGN KEY (MaCV) REFERENCES ChucVu(MaCV)
 )
 Create table GoiCuoc(
	MaGC Char(5) not null,
	TenGC NvarChar(50)  null,
	GiaCuoc int null,
	CONSTRAINT PK_GOICUOC PRIMARY KEY (MaGC)
 )
 CREATE TABLE HOADON
 (
	MaHD char(5) NOT NULL,
	MaNV char(5) not NULL,
	NgayLapHD date not NULL,
	MaKH char(5) not NULL,
	trangthai char(20),	
	CONSTRAINT PK_HD PRIMARY KEY (MAHD),
	CONSTRAINT FK_HD_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
	CONSTRAINT FK_HD_KHACHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)
	
 )
 CREATE TABLE CTHD
(
	MaHD char(5) NOT NULL,
	MaGC char(5) NOT NULL,
    DonGia integer NULL,
	GiamGia integer NULL,
	ThanhTien integer NULL,
	CONSTRAINT PK_CTHD PRIMARY KEY (MAHD, MAGC),
	CONSTRAINT FK_CTHDB_HOADON FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CTHDB_HANG FOREIGN KEY (MAGC) REFERENCES GoiCuoc(MAGC)
 )
 create table taikhoan
 (
	taikhoan char(50) not null,
	matkhau	char(50) not null,
	MaNV char(5) null,
	MaKH char(5) null,
  CONSTRAINT PK_taikhoan PRIMARY KEY (taikhoan, matkhau),
  CONSTRAINT FK_taikhoan_nhanvien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
  CONSTRAINT FK_taikhoan_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
 )
 create table wifi(
	taikhoanwifi char(50)  not null,
	matkhauwifi char(50) not null,
	MaKH char(5) null,
	CONSTRAINT PK_wifi PRIMARY KEY (taikhoanwifi, matkhauwifi),
	CONSTRAINT FK_taikhoanwifi_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
 )
 Create table HoTro(

	MaNV char(5) not null,
	MaKH char(5) not null,
	NgayHen date not null ,
	TrangThai	NVarchar(max),
	YeuCau NVarchar(max),
	CONSTRAINT PK_HoTro PRIMARY KEY (MaNV, MaKH,NgayHen),
	CONSTRAINT FK_HoTro_nhanvien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_HoTro_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
 )
 

 ---bảng khách hàng
 INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH001',N'Nguyễn Thị Mai',N'Tân Phú, HCM','0935682663');
INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH002',N'Trần Văn Cảnh',N'Tân Bình, HCM','0965182618');
INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH003',N'Hoàng Thị A',N'Bình Tân, HCM','0935634563');
INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH004',N'Trần Văn B',N'Tân Bình, HCM','0965182619');
INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH005',N'Nguyễn Thị C',N'Tân Phú, HCM','0935686363');
INSERT INTO KHACHHANG(MAKH, TENKH, DiaChi, SDT) VALUES ('KH006',N'Trần Văn D',N'Tân Bình, HCM','0965182620');
SELECT *FROM KHACHHANG;
--update KHACHHANG set TenKH='',DiaChi='',SDT='' where MaKH = ''



---bảng chức vụ
INSERT INTO ChucVu(MaCV,TenCV) values ('CV01',N'Kỹ Thuật')
INSERT INTO ChucVu(MaCV,TenCV) values ('CV02',N'Tổng Đài')
INSERT INTO ChucVu(MaCV,TenCV) values ('CV03',N'Thu Ngân')
INSERT INTO ChucVu(MaCV,TenCV) values ('CV04',N'Admin')
SELECT *FROM ChucVu;
--Select nv.Manv, Tennv, gioitinh, luong, tencv, DiaChiNV, SDTNV, ngaysinh from Nhanvien nv, Chucvu cv where SDTNV = '0927352718' and nv.Macv = cv.Macv
---bảng nhân viên
SET DATEFORMAT DMY  
INSERT INTO NHANVIEN  VALUES ('NV001',N'Nguyễn Hoàng Anh Thư',N'Nữ',5500000,'CV01',N'Tân Phú, TPHCM','0927352718','12-09-1998');
INSERT INTO NHANVIEN  VALUES ('NV002',N'Nguyễn Hoàng Nam',N'Nam',1500000,'CV02',N'Tân Bình, TPHCM','0856218771','19-12-1997');
INSERT INTO NHANVIEN  VALUES ('NV003',N'Lê Ngọc Mai',N'Nữ',7500000,'CV03',N'Thủ Đức, TPHCM','0919395758','22-08-1997');
INSERT INTO NHANVIEN  VALUES ('NV004',N'Đào Hữu Minh',N'Nam',10000000,'CV04',N'Bình Dương','0985497213','22-08-1996');
SELECT *FROM NHANVIEN;
--update NHANVIEN set MaNV='',TenNV='',GioiTinh='',LUONG=,MaCV='',DiaChiNV='',SDTNV='',NgaySinh='' where MaNV=''
--delete NHANVIEN where MaNV = 'NV004'
--select * from NHANVIEN where macv = 'CV03'
---bảng Gói Cước
INSERT INTO GoiCuoc(MaGC,TenGC,GiaCuoc) values ('GC01',N'Băng Thông 45mb/s',200000)
INSERT INTO GoiCuoc(MaGC,TenGC,GiaCuoc) values ('GC02',N'Băng Thông 35mb/s',180000)
INSERT INTO GoiCuoc(MaGC,TenGC,GiaCuoc) values ('GC03',N'Băng Thông 30mb/s',150000)
SELECT *FROM GoiCuoc
---bảng hóa đơn
SET DATEFORMAT DMY
INSERT INTO HOADON VALUES ('HDB01','NV003','18-02-2019','KH001',N'Chưa thanh toán');
INSERT INTO HOADON VALUES('HDB02','NV003','23-6-2019','KH002',N'Đã thanh toán');
INSERT INTO HOADON VALUES('HDB03','NV003','29-08-2019','KH003',N'Chưa thanh toán');
INSERT INTO HOADON VALUES('HDB04','NV003','15-06-2019','KH004',N'Chưa thanh toán');
INSERT INTO HOADON VALUES('HDB05','NV003','1-10-2019','KH005',N'Chưa thanh toán');
INSERT INTO HOADON VALUES('HDB06','NV003','9-5-2019','KH006',N'Đã thanh toán');
SELECT *FROM HOADON
--delete HOADON
--INSERT INTO HOADON VALUES('HDB08','NV003','9-5-2019','KH006',N'Đã thanh toán');INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES ('HDB08','GC01',200000, 0, NULL)
--update HOADON set MaNV='',NgayLapHD='',MaKH='',trangthai=N'Chưa thanh toán' update CTHD set MaGC='',DonGia=0,GiamGia=0 update CTHD set thanhtien = (dongia - dongia*(giamgia/100))
--select MAKH, TENKH, DiaChi, SDT from khachhang
select GoiCuoc.TenGC,GoiCuoc.MaGC from HOADON ,CTHD,GoiCuoc where HOADON.mahd= CTHD.mahd and GoiCuoc.MAGC=CTHD.MAGC and HOADON.makh = (select makh from KHACHHANG where sdt='0935682663')
select HOADON.MaHD, MaGC,  DonGia, GiamGia, ThanhTien,HOADON.NgayLapHD,trangthai from HOADON ,CTHD where HOADON.mahd= CTHD.mahd and mahd=N'HDB01' and   HOADON.makh = (select makh from KHACHHANG where sdt='0935682663')
select trangthai from hoadon where makh=(select makh from KHACHHANG where sdt='0935682663')
select trangthai from hoadon where trangthai='Đã thanh toán' and makh=(select makh from KHACHHANG where sdt='0965182618')
---Bảng chi tiết hóa đơn
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES ('HDB01','GC01',200000, 10000, NULL);
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES  ('HDB02','GC02',180000, 10000, NULL);
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES  ('HDB03','GC03',150000, 10000, NULL);
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES  ('HDB04','GC03',150000, 10000, NULL);
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES  ('HDB05','GC01',200000, 10000, NULL);
INSERT INTO CTHD(MaHD, MaGC,  DonGia, GiamGia, ThanhTien) VALUES  ('HDB06','GC02',180000, 10000, NULL);
SELECT *FROM CTHD
--delete CTHD
update CTHD set thanhtien = (dongia - GiamGia)
SELECT *FROM CTHD
---Bảng Tài Khoản tạo bằng SĐT
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0935682663','123',NULL,'KH001');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0965182618','123',NULL,'KH002');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0935634563','123',NULL,'KH003');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0965182619','123',NULL,'KH004');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0935686363','123',NULL,'KH005');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0965182620','123',NULL,'KH006');
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0927352718','123','NV001',NULL);
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0856218771','123','NV002',NULL);
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0919395758','123','NV003',NULL);
INSERT INTO taikhoan(taikhoan,matkhau,MaNV,MaKH) values ('0985497213','123','NV004',NULL);
SELECT *FROM taikhoan
select taikhoan from taikhoan,khachhang where khachhang.makh= taikhoan.makh and taikhoan = '0935682663' and matkhau ='123'


--- bảng wifi 
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0935682663','123','KH001');
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0965182618','123','KH002');
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0935634563','123','KH003');
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0965182619','123','KH004');
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0935686363','123','KH005');
INSERT INTO wifi(taikhoanwifi,matkhauwifi,MaKH) values ('0965182620','123','KH006');
select *from wifi 
----bảng hỗ trợ
SET DATEFORMAT DMY
INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV003','KH001','01-01-2020',N'Chưa hỗ trợ',N'YÊU CẦU ĐẾN SỬA WIFI');
INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV001','KH001','02-01-2020',N'Đã hỗ trợ',N'YÊU CẦU ĐẾN SỬA WIFI');
INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV003','KH002','01-01-2020',N'Đã hỗ trợ',N'YÊU CẦU ĐẾN THU TIỀN WIFI');
INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV003','KH003','01-01-2020',N'Chưa hỗ trợ',N'YÊU CẦU ĐẾN THU TIỀN WIFI');
INSERT INTO HoTro(MaNV,MaKH,NgayHen,TrangThai,YeuCau) values ('NV003','KH004','01-01-2020',N'Chưa hỗ trợ',N'YÊU CẦU ĐẾN THU TIỀN WIFI');
select *from HoTro;
select MaKH from HoTro where MaKH='KH001' and TrangThai=N'Chưa hỗ trợ'
delete HoTro where MaKH = 'kh001' and YeuCau=N'YÊU CẦU ĐẾN THU TIỀN WIFI'and TrangThai=N'Chưa hỗ trợ'
select MaNV,MaKH,NgayHen,TrangThai,YeuCau from HoTro where makh = 'kh002' and YeuCau=N'YÊU CẦU ĐẾN THU TIỀN WIFI';
delete hotro