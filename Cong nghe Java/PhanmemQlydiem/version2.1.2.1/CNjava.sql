CREATE DATABASE QLSV
USE QLSV

CREATE TABLE KHOA
(
	MaKH char(10),
	TenKH nvarchar(50),
	CONSTRAINT PK_KHOA PRIMARY KEY(MaKH)
)

CREATE TABLE LOP
(
	MALOP CHAR(10),
	TENLOP NVARCHAR(50),
	SISO INT,
	MaKH char(10),
	CONSTRAINT PK_LOP PRIMARY KEY(MALOP),
	Constraint fk_lop_khoa Foreign KEY(MaKH) references KHOA(MaKH)
)

CREATE TABLE SINHVIEN
(
MASV CHAR(10),
HOTEN NVARCHAR(50),
NGSINH DATE,
GIOITINH NVARCHAR(5),
QUEQUAN NVARCHAR(50),
MALOP CHAR(10),
CONSTRAINT PK_SINHVIEN PRIMARY KEY(MASV),
CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY(MALOP) REFERENCES LOP(MALOP),
)
CREATE TABLE MONHOC
(
MAMH CHAR(10),
TENMH NVARCHAR(50),
SOTC INT,
CONSTRAINT PK_MONHOC PRIMARY KEY(MAMH),
)
insert into monhoc(mamh,tenmh) values('MH004','Mang')
--hocky phải liền mạch 123456 không được có 123568; viết bảng thêm xóa bớt phải lưu ý 
CREATE TABLE KETQUA
(
MASV CHAR(10),
MAMH CHAR(10),	
HOCKY INT,
DIEM_GK FLOAT,
DIEM_CK FLOAT,
DIEM_TK FLOAT,
XEPLOAI CHAR(10),
CONSTRAINT PK_KQ PRIMARY KEY(MASV,MAMH,HOCKY),
CONSTRAINT FK_KQ_SINHVIEN FOREIGN KEY(MASV) REFERENCES SINHVIEN(MASV),
CONSTRAINT FK_KQ_MH FOREIGN KEY(MAMH) REFERENCES MONHOC(MAMH),

)
	select (DIEM_CK+DIEM_GK)/2 as s from KETQUA

create trigger tg_tinhdiemTK_xepLoai on ketqua 
for insert,update
as
	begin 
		update ketqua set DIEM_TK = (select (ketqua.DIEM_CK+ ketqua.DIEM_GK)/ 2as s from KETQUA,inserted where KETQUA.MASV=inserted.MASV  and KETQUA.MAMH = inserted.MAMH and KETQUA.HOCKY=inserted.HOCKY)
		from inserted
		where KETQUA.MASV=inserted.MASV  and KETQUA.MAMH = inserted.MAMH and KETQUA.HOCKY=inserted.HOCKY

		declare @diemtk float = (select ketqua.diem_tk from inserted,KETQUA where KETQUA.MASV=inserted.MASV  and KETQUA.MAMH = inserted.MAMH and KETQUA.HOCKY=inserted.HOCKY  ) 
		if(@diemtk>=8)
			update KETQUA set XEPLOAI = 'A' where KETQUA.MASV=(select MASV from inserted) and KETQUA.HOCKY=(select HOCKY from inserted)
		else if(@diemtk>=7)
			update KETQUA set XEPLOAI = 'B' where KETQUA.MASV=(select MASV from inserted) and KETQUA.HOCKY=(select HOCKY from inserted)
		else if(@diemtk>=5)
			update KETQUA set XEPLOAI = 'C' where KETQUA.MASV=(select MASV from inserted) and KETQUA.HOCKY=(select HOCKY from inserted)
		else if(@diemtk>2)
			update KETQUA set XEPLOAI = 'D' where KETQUA.MASV=(select MASV from inserted) and KETQUA.HOCKY=(select HOCKY from inserted)
		else
			update KETQUA set XEPLOAI = 'F' where KETQUA.MASV=(select MASV from inserted) and KETQUA.HOCKY=(select HOCKY from inserted)
	end

insert into khoa values('CNTT',N'Công Nghệ Thông Tin')


INSERT INTO LOP(MALOP,TENLOP,SISO,MaKH)
VALUES('LOP A',N'08DHTH3',null,'CNTT'),
('LOP B',N'08DHTH1',null,'CNTT'),
('LOP C',N'07DHTP1',null,'CNTT')

SET DATEFORMAT DMY
INSERT INTO SINHVIEN(MASV,HOTEN,NGSINH,GIOITINH,QUEQUAN,MALOP)
VALUES('SV001',N'Thân Anh Tuấn','1999-04-26',N'Nam',N'Bình Định','LOP A'),
('SV002',N'Trần Van Cao','1999-05-26',N'Nam',N'HCM','LOP A'),
('SV003',N'Thái Thị Hà','1998-03-12',N'Nữ',N'Vũng Tàu','LOP B'),
('SV004',N'Trần An','1994-06-04',N'Nữ',N'Tây Ninh','LOP C'),
('SV005',N'Mai Văn Cao','1999-04-11',N'Nam',N'Phú Yên','LOP A'),
('SV006',N'Bùi Công ','1999-04-13',N'Nam',N'Hà Nội','LOP C'),
('SV007',N'Nguyễn Nhạc','1912-11-30',N'Nam',N'Bình Định','LOP A'),
('SV008',N'Nguyễn Huệ','1913-05-21',N'Nam',N'Bình Định','LOP B'),
('SV009',N'Nguyện Lữ','1914-04-22',N'Nam',N'Bình Định','LOP A')

INSERT INTO MONHOC(MAMH,TENMH,SOTC) VALUES('MH001',N'CSDL',3)
INSERT INTO MONHOC(MAMH,TENMH,SOTC) VALUES ('MH002',N'Cấu trúc',3)
INSERT INTO MONHOC(MAMH,TENMH,SOTC) VALUES ('MH003',N'Toán',3)
select * from monhoc
select * from KETQUA
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH003',2,5,6,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH001',3,8,3,null,null)
 INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH001',10,3,8,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH002',1,3,5,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH003',1,9,4,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH001',4,4,6,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH001',5,2,9,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH003',6,4,5,null,null)
INSERT INTO KETQUA(MASV,MAMH,HOCKY,DIEM_GK,DIEM_CK ,DIEM_TK ,XEPLOAI )VALUES ('SV001','MH001',7,4,3,null,null)

--drop trigger tg_tinhdiemTK_xepLoai


--tạo bảng học kỳ không trùng
create view tbhocky
as 
		select distinct hocky,masv from ketqua 
		delete from KETQUA
		select * from tbhocky
		select count(*) from tbhocky where masv='SV001'
--lấy số học kỳ 
select count(*) from tbhocky
select * from sinhvien
delete from KETQUA
Select * from sinhvien,ketqua where  sinhvien.masv=ketqua.masv and sinhvien.masv='SV001'  and hocky=1
create view showSVKQ
as 
select sinhvien.MASV ,
HOTEN,
NGSINH ,
GIOITINH ,
QUEQUAN ,
MALOP , 
MAMH ,	
HOCKY ,
DIEM_GK ,
DIEM_CK ,
DIEM_TK ,
drop table lop
drop table khoa
drop table sinhvien
drop table monhoc
drop table ketqua
XEPLOAI from sinhvien,ketqua where sinhvien.masv=ketqua.masv
delete  from showSVKQ where masv='SV001' and  hocky=2
delete from  sinhvien where MASV=''
INSERT INTO KETQUA VALUES('SV001','null',1,3,8,4,'B')





insert into sinhvien  values('SV010',N'Thân Anh Tuấn','26/04/1999',N'Nam',N'Bình Định','LOP A')
insert into ketqua  values('SV001',null,2,null,null,null,null)
select * from sinhvien
update sinhvien set  malop='LOP A' , hoten=N'fháiuvgài' where masv='SV001'
select ketqua.MAMH,TENMH,DIEM_GK,DIEM_CK,DIEMTK,XEPLOAI from ketqua,monhoc where ketqua.mamh=monhoc.mamh and masv='SV001'  and hocky=1
select ketqua.mamh,tenmh,diem_gk,diem_CK,diem_TK,xeploai from ketqua,monhoc where ketqua.mamh=monhoc.mamh and masv='SV001'  and hocky=1

	select * from monhoc,ketqua where monhoc.mamh=ketqua.mamh and monhoc.mamh='MH001' and hocky=1

select * from monhoc
select tenmh from monhoc where mamh = 'MH002'

select sum(diem_tk)/count(*) as s from ketqua where masv='sv001'  and hocky= 1