create database QuanLyKhachSan

create table Phong
(
    MaPhong nvarchar(10) primary key not null,
	TenPhong nvarchar(50),
	DonGia float
)

Insert into Phong(MaPhong, TenPhong, DonGia)
Values ('P01', 'Ph�ng 1', '1000000')
Insert into Phong(MaPhong, TenPhong, DonGia)
Values ('P02', 'Ph�ng 2', '500000')

select *from Phong


    