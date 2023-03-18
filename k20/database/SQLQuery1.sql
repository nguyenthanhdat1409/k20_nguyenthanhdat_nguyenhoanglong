CREATE DATABASE DienThoai_k20
GO
USE DienThoai_k20
GO

CREATE TABLE KHACHHANG
(
	MAKH INT IDENTITY(1, 1) PRIMARY KEY,
	HOTEN NVARCHAR(100) NOT NULL,
	TAIKHOAN VARCHAR(50) NOT NULL,
	MATKHAU VARCHAR(50) NOT NULL,
	EMAIL VARCHAR(100) NOT NULL,
	DIACHI NVARCHAR(200) NOT NULL,
	DIENTHOAI VARCHAR(10) NOT NULL
)

CREATE TABLE DONDATHANG
(
	MADONHANG INT IDENTITY(1, 1) PRIMARY KEY,
	DATHANHTOAN BIT CHECK(DATHANHTOAN IN (0, 1)),
	TINHTRANGGIAOHANG NVARCHAR(100),
	NGAYDAT DATETIME,
	NGAYGIAO DATETIME,
	MAKH INT FOREIGN KEY REFERENCES KHACHHANG(MAKH),
)
CREATE TABLE nhasanxuat
(
	manhasanxuat INT IDENTITY(1, 1) PRIMARY KEY,
	tennhasanxuat NVARCHAR(200) NOT NULL
)

CREATE TABLE dienthoai
(
	MAdienthoai INT IDENTITY(1, 1) PRIMARY KEY,
	TENdienthoai NVARCHAR(200) NOT NULL,
	GIABAN DECIMAL(18,0) NOT NULL,
	MOTA NVARCHAR(MAX) NOT NULL,
	ANHBIA VARCHAR(200) NOT NULL,
	NGAYCAPNHAT DATETIME DEFAULT CURRENT_TIMESTAMP,
	SOLUONGTON INT NOT NULL,
	manhasanxuat INT FOREIGN KEY REFERENCES nhasanxuat(manhasanxuat),
	SALE FLOAT,
	TRONGLUONG INT,
	
)

CREATE TABLE CHITIETDONHANG
(
	MADONHANG INT FOREIGN KEY REFERENCES DONDATHANG(MADONHANG),
	madienthoai INT FOREIGN KEY REFERENCES dienthoai(madienthoai),
	SOLUONG INT NOT NULL,
	PRIMARY KEY (MADONHANG,madienthoai)
)

CREATE TABLE ADMIN
(
	TAIKHOAN VARCHAR(50) PRIMARY KEY,
	MATKHAU  VARCHAR(50) NOT NULL,
	HOTEN NVARCHAR(50)
)


INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Sam Sung')
INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Nokia')
INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Apple')
INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Xiamo')
INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Oppo')
INSERT INTO nhasanxuat
	(tennhasanxuat)
VALUES(N'Vivo')



insert into dienthoai(TENdienthoai,GIABAN,MOTA,ANHBIA,NGAYCAPNHAT,SOLUONGTON,manhasanxuat,SALE,TRONGLUONG)
values(N'iPhone 12 64GB',14000000,N'Mạnh mẽ, siêu nhanh với chip A14, RAM 4GB, mạng 5G tốc độ cao
Rực rỡ, sắc nét, độ sáng cao - Màn hình OLED cao cấp, Super Retina XDR hỗ trợ HDR10, Dolby Vision
Chụp đêm ấn tượng - Night Mode cho 2 camera, thuật toán Deep Fusion, Smart HDR 3
Bền bỉ vượt trội - Kháng nước, kháng bụi IP68, mặt lưng Ceramic Shield',   ''   , 12/02/2023,1000,1,10,3 );

insert into dienthoai(TENdienthoai,GIABAN,MOTA,ANHBIA,NGAYCAPNHAT,SOLUONGTON,manhasanxuat,SALE,TRONGLUONG)
values(N'iPhone 12 128GB',16500000,N'Mạnh mẽ, Vip pro, siêu nhanh với chip A14, RAM 4GB, mạng 5G tốc độ cao
Rực rỡ, sắc nét, độ sáng cao - Màn hình OLED cao cấp, Super Retina XDR hỗ trợ HDR10, Dolby Vision
Chụp đêm ấn tượng - Night Mode cho 2 camera, thuật toán Deep Fusion, Smart HDR 3
Bền bỉ vượt trội - Kháng nước, kháng bụi IP68, mặt lưng Ceramic Shield', ' ', 15/02/2023,100,2,5,4 );

insert into dienthoai(TENdienthoai,GIABAN,MOTA,ANHBIA,NGAYCAPNHAT,SOLUONGTON,manhasanxuat,SALE,TRONGLUONG)
values(N'iPhone 13 128GB',2500000,N'Mạnh m, Vip pro x2, siêu nhanh với chip A14, RAM 4GB, mạng 5G tốc độ cao
Rực rỡ, sắc nét, độ sáng cao - Màn hình OLED cao cấp, Super Retina XDR hỗ trợ HDR10, Dolby Vision
Chụp đêm ấn tượng - Night Mode cho 2 camera, thuật toán Deep Fusion, Smart HDR 3
Bền bỉ vượt trội - Kháng nước, kháng bụi IP68, mặt lưng Ceramic Shield', ' ' , 20/02/2023,10,3,6,5 );



