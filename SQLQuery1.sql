USE [master]
GO
/****** Object:  Database [QLHSCap1]    Script Date: 11/26/2021 7:16:38 AM ******/
CREATE DATABASE [QLHSCap1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLHSCap1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLHSCap1.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLHSCap1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLHSCap1_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLHSCap1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLHSCap1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLHSCap1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLHSCap1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLHSCap1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLHSCap1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLHSCap1] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLHSCap1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLHSCap1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLHSCap1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLHSCap1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLHSCap1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLHSCap1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLHSCap1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLHSCap1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLHSCap1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLHSCap1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLHSCap1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLHSCap1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLHSCap1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLHSCap1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLHSCap1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLHSCap1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLHSCap1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLHSCap1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLHSCap1] SET  MULTI_USER 
GO
ALTER DATABASE [QLHSCap1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLHSCap1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLHSCap1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLHSCap1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLHSCap1] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLHSCap1]
GO
/****** Object:  Table [dbo].[ChucVU]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVU](
	[MaCV] [nvarchar](2) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChucVU] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [nvarchar](5) NOT NULL,
	[MaHS] [nvarchar](50) NULL,
	[MaGV] [nvarchar](5) NULL,
	[LoaiDanhGia] [nvarchar](10) NULL,
	[NamHoc] [nvarchar](10) NULL,
	[KiDanhGia] [nvarchar](15) NULL,
	[NoiDungDanhGia] [nvarchar](100) NULL,
	[MaMon] [nvarchar](5) NULL,
	[MucDoDanhGia] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhGiaTX]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaTX](
	[MaDanhGia] [nvarchar](5) NOT NULL,
	[MaHS] [nvarchar](50) NULL,
	[MaGV] [nvarchar](5) NULL,
	[NamHoc] [nvarchar](10) NULL,
	[KiDanhGia] [nvarchar](15) NULL,
	[Thang] [nvarchar](2) NULL,
	[NhanXetNangLuc] [nvarchar](100) NULL,
	[MaMon] [nvarchar](5) NULL,
	[NhanXetPhamChat] [nvarchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [nvarchar](5) NOT NULL,
	[TenGV] [nvarchar](25) NULL,
	[Mamon] [nvarchar](5) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Dienthoai] [nvarchar](25) NULL,
	[Malop] [nvarchar](5) NULL,
	[MaCV] [nvarchar](2) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](25) NULL,
	[Malop] [nvarchar](5) NULL,
	[Ngaysinh] [datetime] NULL,
	[Gioitinh] [nvarchar](3) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Mask] [nvarchar](5) NULL,
	[HoTenCha] [nvarchar](25) NOT NULL,
	[HoTenMe] [nvarchar](25) NOT NULL,
	[NgheNghiepMe] [nvarchar](15) NOT NULL,
	[NgheNghiepCha] [nvarchar](15) NOT NULL,
	[SDTCha] [nvarchar](50) NOT NULL,
	[SDTMe] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Malop] [nvarchar](5) NOT NULL,
	[Tenlop] [nvarchar](5) NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[Malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMon] [nvarchar](5) NOT NULL,
	[TenMon] [nvarchar](15) NULL,
 CONSTRAINT [PK_MaHoc] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SoSucKhoe]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoSucKhoe](
	[Mask] [nvarchar](30) NOT NULL,
	[Chieucao] [nvarchar](30) NOT NULL,
	[Cannang] [nvarchar](30) NOT NULL,
	[ChisoIBM] [nvarchar](30) NOT NULL,
	[Xeploaisuckhoe] [nvarchar](30) NULL,
 CONSTRAINT [PK_SoSucKhoe] PRIMARY KEY CLUSTERED 
(
	[Mask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Tentaikhoan] [nvarchar](50) NOT NULL,
	[Matkhau] [nvarchar](50) NULL,
	[MaGV] [nvarchar](5) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Tentaikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[DG]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[DG] as
	select LoaiDanhGia, TenLop ,HocSinh.MaHS, HoTen, MaGV, NamHoc, KiDanhGia, TenMon, MucDoDanhGia, NoiDungDanhGia   from DanhGia inner join HocSinh on DanhGia.MaHS = HocSinh.MaHS join MonHoc on MonHoc.MaMon = DanhGia.MaMon join Lop on HocSinh.Malop = Lop.Malop

GO
/****** Object:  View [dbo].[HS]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HS]
AS
SELECT dbo.HocSinh.MaHS, dbo.Lop.Tenlop, dbo.HocSinh.Ngaysinh, dbo.HocSinh.Gioitinh, dbo.HocSinh.Diachi, dbo.HocSinh.SDTMe, dbo.HocSinh.HoTenCha, dbo.HocSinh.HoTenMe, dbo.HocSinh.NgheNghiepMe, dbo.HocSinh.NgheNghiepCha, 
                  dbo.HocSinh.SDTCha, dbo.HocSinh.HoTen
FROM     dbo.HocSinh INNER JOIN
                  dbo.Lop ON dbo.HocSinh.Malop = dbo.Lop.Malop


GO
/****** Object:  View [dbo].[SK]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[SK] as
	select MaHS, HoTen, ChieuCao, CanNang, ChiSoIBM, XepLoaiSucKhoe, TenLop from HocSinh join SoSucKhoe on HocSinh.Mask = SoSucKhoe.Mask join Lop on HocSinh.Malop = Lop.Malop

GO
/****** Object:  View [dbo].[tblChucVu]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[tblChucVu] as
	Select GiaoVien.MaGV, TenGV, Tentaikhoan, Matkhau, TenCV from GiaoVien inner join ChucVU on GiaoVien.MaCV = ChucVu.MaCV inner join TaiKhoan on GiaoVien.MaGV = TaiKhoan.MaGV

GO
/****** Object:  View [dbo].[tblinfo]    Script Date: 11/26/2021 7:16:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[tblinfo] as
	select GiaoVien.MaGV, TenGV, isnull(TenMon, '') as TenMon, Diachi, Dienthoai, isnull(Tenlop,'') as TenLop, TenCV, isnull(Tentaikhoan,'') as TenTaiKhoan, isnull(Matkhau,'') as Matkhau
	from GiaoVien inner join ChucVU on GiaoVien.MaCV = ChucVU.MaCV left join TaiKhoan on GiaoVien.MaGV = TaiKhoan.MaGV left join MonHoc on GiaoVien.Mamon = MonHoc.MaMon left join Lop on GiaoVien.Malop = Lop.Malop


GO
/****** Object:  View [dbo].[TX]    Script Date: 11/26/2021 7:16:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[TX] as
	select HocSinh.MaHS, HoTen, MaGV, NamHoc, KiDanhGia, TenMon, NhanXetNangLuc, NhanXetPhamChat
	from DanhGiaTX join HocSinh on DanhGiaTX.MaHS = HocSinh.MaHS join MonHoc on MonHoc.MaMon = DanhGiaTX.MaMon

GO
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'BM', N'Bộ Môn')
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'CN', N'Chủ Nhiệm')
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'QL', N'Quản Lý')
INSERT [dbo].[DanhGia] ([MaDanhGia], [MaHS], [MaGV], [LoaiDanhGia], [NamHoc], [KiDanhGia], [NoiDungDanhGia], [MaMon], [MucDoDanhGia]) VALUES (N'DG01', N'HS01', N'GV01', N'Định Kỳ', N'2020-2021', N'1', N'Hoàn thành tốt môn học', N'M01', N'HT')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV01', N'Ngô Văn Khải', NULL, N'Đông Anh', N'22133215', NULL, N'QL')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV02', N'Vũ Thị Thùy Trang', N'M01', N'Hòa Bình', 13221321, N'2A', N'BM')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV03', N'Nguyễn Chí Thịnh', N'M01', N'Đông Anh', 13213215, N'1A', N'CN')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0131156399', N'Hoàng Quốc Cường', N'L02', CAST(N'2015-02-21 00:00:00.000' AS DateTime), N'Nam', N'Xã Uy Nỗ', NULL, N'Hoàng Văn Vạn', N'Nguyễn Thị Hằng', N'Công nhân', N'công nhân', N'0123456789', N'0123456789')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0140416396', N'Phạm Thùy Dung', N'L02', CAST(N'2015-01-05 00:00:00.000' AS DateTime), N'Nữ', N'Xã Liên Hà', NULL, N'Phạm Huy Chiến', N'Hoàng Thị Hạnh', N'Giáo viên', N'công nhân', N'0123456791', N'0123456791')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0140416400', N'Nguyễn Ngọc Hà', N'L02', CAST(N'2015-01-30 00:00:00.000' AS DateTime), N'Nữ', N'Xã Việt Hùng', NULL, N'Nguyễn Minh Điệp', N'Trần Thị Thanh Hương', N'Công nhân', N'Công nhân', N'0123456797', N'0123456797')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700251', N'Ngô Bích Diệp', N'L02', CAST(N'2015-07-26 00:00:00.000' AS DateTime), N'Nữ', N'Xã Việt Hùng', NULL, N'Ngô Đăng Có', N'Nguyễn Thị Hồng Vân', N'Công nhân', N'Công nhân', N'0123456790', N'0123456790')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700252', N'Đào Thùy Dương', N'L02', CAST(N'2015-01-02 00:00:00.000' AS DateTime), N'Nữ', N'Tổ 39 TT Đông Anh', NULL, N'Đào Việt Cường', N'Nguyễn Ngọc Hà', N'Kỹ Sư', N'Kỹ Sư', N'0123456793', N'0123456793')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700253', N'Ngô Văn Đức', N'L02', CAST(N'2015-03-10 00:00:00.000' AS DateTime), N'Nam', N'Xã Việt Hùng', NULL, N'Ngô Văn Dũng', N'Đức Thị Hoa', N'Nhân viên', N'Công nhân', N'0123456794', N'0123456794')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700254', N'Nguyễn Hương Giang', N'L02', CAST(N'2015-10-12 00:00:00.000' AS DateTime), N'Nữ', N'Tổ 37 TT Đông Anh', NULL, N'Nguyễn Công Thực', N'Nguyễn Thị Vân Anh', N'Công nhân', N'Công an', N'0123456795', N'0123456795')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700263', N'Nguyễn Thu Giang', N'L02', CAST(N'2015-05-23 00:00:00.000' AS DateTime), N'Nữ', N'Xã Việt Hùng', NULL, N'Nguyễn Đức Huấn', N'Nguyễn Thị Dậu', N'Làm ruộng', N'Làm ruộng', N'0123456796', N'0123456796')
INSERT [dbo].[HocSinh] ([MaHS], [HoTen], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HoTenCha], [HoTenMe], [NgheNghiepMe], [NgheNghiepCha], [SDTCha], [SDTMe]) VALUES (N'0150700284', N'Nguyễn Ngọc Duyên', N'L02', CAST(N'2015-03-15 00:00:00.000' AS DateTime), N'Nữ', N'Xã Việt Hùng', NULL, N'Nguyễn Công Tam', N'Nguyễn Thị Thúy', N'Công nhân', N'Tự do', N'0123456792', N'0123456792')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L01', N'1A')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L02', N'1B')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L03', N'2A')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L04', N'2B')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L05', N'3A')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L06', N'4A')
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L07', N'5A')
INSERT [dbo].[MonHoc] ([MaMon], [TenMon]) VALUES (N'M01', N'Tin học')
INSERT [dbo].[SoSucKhoe] ([Mask], [Chieucao], [Cannang], [ChisoIBM], [Xeploaisuckhoe]) VALUES (N'SK01', 120, 31, 21.53, N'Tốt')
INSERT [dbo].[TaiKhoan] ([Tentaikhoan], [Matkhau], [MaGV]) VALUES (N'ngokhai', N'123', N'GV01')
INSERT [dbo].[TaiKhoan] ([Tentaikhoan], [Matkhau], [MaGV]) VALUES (N'thinhnguyen', N'123', N'GV03')
INSERT [dbo].[TaiKhoan] ([Tentaikhoan], [Matkhau], [MaGV]) VALUES (N'trangthuy', N'123', N'GV02')
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Lop"
            Begin Extent = 
               Top = 60
               Left = 218
               Bottom = 179
               Right = 412
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HocSinh"
            Begin Extent = 
               Top = 62
               Left = 607
               Bottom = 225
               Right = 801
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'HS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'HS'
GO
USE [master]
GO
ALTER DATABASE [QLHSCap1] SET  READ_WRITE 
GO
