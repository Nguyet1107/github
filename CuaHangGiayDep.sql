Create database CuaHangGiayDep;

create table TheLoai
(
   MaLoai nvarchar(10) primary key,
   TenLoai nvarchar(20),
)
create table Co
(
   MaCo nvarchar(10) primary key,
   TenCo nvarchar(50),
)
create table ChatLieu
(
   MaCL nvarchar(10) primary key,
   TenCL nvarchar(50),
)
create table Mau
(
   MaMau nvarchar(10) primary key,
   TenMau nvarchar(50),
)
create table DoiTuong
(
   MaDT nvarchar(10) primary key,
   TenDT nvarchar(50),
)
create table Mua
(
   MaMua nvarchar(10) primary key,
   TenMua nvarchar(50),
)
create table NuocSX
(
   MaNSX nvarchar(10) primary key,
   TenNSX nvarchar(50),
)
create table SanPham
(
   MaGD nvarchar(10) primary key,
   TenGD nvarchar(50),
   MaLoai nvarchar(10),
   MaCo nvarchar(10),
   MaCL nvarchar(10),
   MaMau nvarchar(10),
   MaDT nvarchar(10),
   MaMua nvarchar(10),
   MaNSX nvarchar (10),
   SoLuong int,
   Anh nvarchar(100),
   DonGiaNhap float,
   DonGiaBan float,
)
create table CongViec
(
   MaCV nvarchar(10) primary key,
   TenCV nvarchar(50),
)
create table NhanVien
(
   MaNV nvarchar(10) primary key,
   TenNV nvarchar(50),
   GioiTinh nvarchar(50),
   NgaySinh datetime,
   DienThoai nvarchar(15),
   DiaChi nvarchar(100),
   MaCV nvarchar(10),
)
create table Khach
(
   MaKhach nvarchar(10) primary key,
   TenKhach nvarchar(50),
   DiaChi nvarchar(70),
   DienThoai nvarchar(15),
)
create table HoaDonBan
(
   SoHDB nvarchar(10) primary key,
   MaNV nvarchar(10),
   NgayBan datetime,
   MaKhach nvarchar(10),
   TongTien float,
)
create table NhaCungCap
(
   MaNCC nvarchar(10) primary key,
   TenNCC nvarchar(50),
   DiaChi nvarchar(70),
   DienThoai nvarchar(15),
)
create table HoaDonNhap
(
   SoHDN nvarchar(10)primary key,
   MaNV nvarchar(10),
   NgayNhap datetime,
   MaNCC nvarchar(10),
   TongTien float,
)
create table ChiTietHDB
(
   SoHDB nvarchar(10) ,
   MaGD nvarchar(10) ,
   SoLuong int,
   GiamGia float,
   ThanhTien float,
   PRIMARY KEY( SoHDB, MaGD),
)
create table ChiTietHDN
(
   SoHDN nvarchar(10),
   MaGD nvarchar(10),
   SoLuong int,
   DonGia float,
   GiamGia float,
   ThanhTien float,
   PRIMARY KEY(SoHDN, MaGD),
)

insert into TheLoai(MaLoai,TenLoai) values('L01','giay')
insert into TheLoai(MaLoai,TenLoai) values('L02','giay')

insert into Co(MaCo,TenCo) values ('C01','39')
insert into Co(MaCo,TenCo) values ('C02','37')

insert into ChatLieu(MaCL,TenCL) values('CL01','vai')
insert into ChatLieu(MaCL,TenCL) values('CL02','vai')

insert into Mau(MaMau,TenMau) values('M01','trang')
insert into Mau(MaMau,TenMau) values('M02','den')

insert into DoiTuong(MaDT,TenDT) values('DT01','nu')
insert into DoiTuong(MaDT,TenDT) values('DT02','nam')

insert into Mua(MaMua,TenMua) values('MU01','mua xuan')
insert into Mua(MaMua,TenMua) values('MU02','mua he')

insert into CongViec(MaCV,TenCV) values('CV01','banhang')
insert into CongViec(MaCV,TenCV) values('CV02','nhan vien kho')

insert into NuocSX(MaNSX,TenNSX) values ('N01','korea')
insert into NuocSX(MaNSX,TenNSX) values ('N02','germany')
insert into NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,DienThoai,DiaChi,MaCV)
values('NV01','loan','nu','04/04/1997','0986783654','ninh binh','CV01')
insert into NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,DienThoai,DiaChi,MaCV)
values('NV02','chinh','nam','03/04/2000','0986783751','hung yen','CV02')
insert into Khach(MaKhach,TenKhach,DiaChi,DienThoai)
values('K01','linh','ha noi','064957318')
insert into Khach(MaKhach,TenKhach,DiaChi,DienThoai)
values('K02','nam','khanh hoa','06387318')
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,DienThoai)
values('NCC01','cong ty hai dang','hung yen','034975647')
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,DienThoai)
values('NCC02','cong ty thanh cong','ha noi','034976477')
insert into HoaDonBan(SoHDB,MaNV,NgayBan,MaKhach,TongTien)
values('001','NV01','03/04/2020','K01','8200000')
insert into HoaDonBan(SoHDB,MaNV,NgayBan,MaKhach,TongTien)
values('002','NV02','11/12/2019','K02','8250000')
insert into HoaDonNhap(SoHDN,MaNV,NgayNhap,MaNCC,TongTien)
values('110','NV01','06/03/2019','NCC01','5000000')
insert into HoaDonNhap(SoHDN,MaNV,NgayNhap,MaNCC,TongTien)
values('111','NV02','05/12/2019','NCC02','7500000')
insert SanPham(MaGD,TenGD,MaLoai,MaCo,MaCL,MaMau,MaMua,MaNSX,Anh,MaDT)
values('GD01','giay the thao','L01','C01','CL01','M01','MU01','N01','giayEQT','DT01')
insert SanPham(MaGD,TenGD,MaLoai,MaCo,MaCL,MaMau,MaMua,MaNSX,Anh,MaDT)
values('GD02','giay nike air max','L02','C02','CL02','M02','MU02','N02','giaynike','DT02')
insert into ChiTietHDB(SoHDB,MaGD,SoLuong,GiamGia,ThanhTien)
values('001','GD01','1','0.1','800000')
insert into ChiTietHDB(SoHDB,MaGD,SoLuong,GiamGia,ThanhTien)
values('002','GD02','2','0','950000')
insert into ChiTietHDN(SoHDN,MaGD,SoLuong,DonGia,GiamGia,ThanhTien)
values('110','GD01','8','820000','0.1','59040000')
insert into ChiTietHDN(SoHDN,MaGD,SoLuong,DonGia,GiamGia,ThanhTien)
values('111','GD02','7','1050000','0','7350000')
select *from SanPham;

Delete from Mau;
