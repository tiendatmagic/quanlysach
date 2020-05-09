create database Quanlysach

use Quanlysach

create table Sach (
MaSach nchar(10) not null,
Tieude nvarchar(30),
NamXB int,
MaTG nchar(10) not null,
primary key(MaSach,MaTG),
)

insert into Sach values ('S01',N'Mạng máy tính','2020','T01')
insert into Sach values ('S02',N'Office 2019','2020','T02')
insert into Sach values ('S03',N'Phần mềm máy tính','2019','T03')
insert into Sach values ('S04',N'Kỹ năng làm việc nhóm','2020','T01')
insert into Sach values ('S05',N'Điện toán đám mây','2020','T03')
insert into Sach values ('S06',N'Phần cứng máy tính','2019','T02')
insert into Sach values ('S07',N'Quản trị Linux','2019','T02')
insert into Sach values ('S08',N'Code dạo ký sự','2018','T03')
insert into Sach values ('S09',N'Quản trị Windows Server','2019','T03')
insert into Sach values ('S10',N'An ninh mạng','2018','T01')

create table TacGia (
MaTG nchar(10) not null,
TenTG nvarchar(30),
SoLuongSach int,
primary key(MaTG),
)

insert into TacGia values ('T01',N'Nguyễn Quốc Việt','2')
insert into TacGia values ('T02',N'Phan Cư Chánh','4')
insert into TacGia values ('T03',N'Cao Tiến Đạt','5')

alter table Sach
add constraint fk_mtg
foreign key (MaTG)
references TacGia (MaTG);