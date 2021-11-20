USE [master]
GO
/****** Object:  Database [QLHSCap1]    Script Date: 11/20/2021 9:10:30 PM ******/
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
/****** Object:  Table [dbo].[ChucVU]    Script Date: 11/20/2021 9:10:30 PM ******/
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
/****** Object:  Table [dbo].[DanhGia]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [nvarchar](5) NOT NULL,
	[MaHS] [nvarchar](5) NULL,
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
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [nvarchar](5) NOT NULL,
	[TenGV] [nvarchar](25) NULL,
	[Mamon] [nvarchar](5) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Dienthoai] [int] NULL,
	[Malop] [nvarchar](5) NULL,
	[MaCV] [nvarchar](2) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [nvarchar](5) NOT NULL,
	[TenHS] [nvarchar](25) NULL,
	[Malop] [nvarchar](5) NULL,
	[Ngaysinh] [datetime] NULL,
	[Gioitinh] [nvarchar](3) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Mask] [nvarchar](5) NULL,
	[HTBo] [nvarchar](25) NOT NULL,
	[HTMe] [nvarchar](25) NOT NULL,
	[NNMe] [nvarchar](15) NOT NULL,
	[NNBo] [nvarchar](15) NOT NULL,
	[SDTBo] [int] NOT NULL,
	[SDTMe] [int] NOT NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 11/20/2021 9:10:30 PM ******/
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
/****** Object:  Table [dbo].[MonHoc]    Script Date: 11/20/2021 9:10:30 PM ******/
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
/****** Object:  Table [dbo].[SoSucKhoe]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoSucKhoe](
	[Mask] [nvarchar](5) NOT NULL,
	[Chieucao] [int] NOT NULL,
	[Cannang] [float] NOT NULL,
	[ChisoIBM] [float] NOT NULL,
	[Xeploaisuckhoe] [nvarchar](5) NULL,
 CONSTRAINT [PK_SoSucKhoe] PRIMARY KEY CLUSTERED 
(
	[Mask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/20/2021 9:10:30 PM ******/
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
/****** Object:  View [dbo].[HS]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[HS] as
	select MaHS, TenHS, TenLop, Ngaysinh, Gioitinh, Diachi, HTBo,  NNBo, SDTBo,HTMe, NNMe, SDTMe from HocSinh join Lop on HocSinh.Malop = Lop.Malop
GO
/****** Object:  View [dbo].[tblChucVu]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[tblChucVu] as
	Select GiaoVien.MaGV, TenGV, Tentaikhoan, Matkhau, TenCV from GiaoVien inner join ChucVU on GiaoVien.MaCV = ChucVu.MaCV inner join TaiKhoan on GiaoVien.MaGV = TaiKhoan.MaGV
GO
/****** Object:  View [dbo].[tblinfo]    Script Date: 11/20/2021 9:10:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[tblinfo] as
	select GiaoVien.MaGV, TenGV, isnull(TenMon, '') as TenMon, Diachi, Dienthoai, isnull(Tenlop,'') as TenLop, TenCV, isnull(Tentaikhoan,'') as TenTaiKhoan, isnull(Matkhau,'') as Matkhau
	from GiaoVien inner join ChucVU on GiaoVien.MaCV = ChucVU.MaCV left join TaiKhoan on GiaoVien.MaGV = TaiKhoan.MaGV left join MonHoc on GiaoVien.Mamon = MonHoc.MaMon left join Lop on GiaoVien.Malop = Lop.Malop

GO
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'BM', N'Bộ Môn')
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'CN', N'Chủ Nhiệm')
INSERT [dbo].[ChucVU] ([MaCV], [TenCV]) VALUES (N'QL', N'Quản Lý')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV01', N'Ngô Văn Khải', N'M01', N'Đông Anh', 394229171, N'L01', N'QL')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV02', N'Nguyễn Thị Ngũ', N'M01', N'Ba Vì', 123456, N'L01', N'BM')
INSERT [dbo].[GiaoVien] ([MaGV], [TenGV], [Mamon], [Diachi], [Dienthoai], [Malop], [MaCV]) VALUES (N'GV03', N'Nguyễn Thị Lý', NULL, N'Đông Anh', 12344567, NULL, N'QL')
INSERT [dbo].[HocSinh] ([MaHS], [TenHS], [Malop], [Ngaysinh], [Gioitinh], [Diachi], [Mask], [HTBo], [HTMe], [NNMe], [NNBo], [SDTBo], [SDTMe]) VALUES (N'HS01', N'Ngô Văn Thái', N'L01', CAST(N'1990-10-08 00:00:00.000' AS DateTime), N'Nam', N'Đông Anh', NULL, N'Ngô', N'sdfsdf', N'sdfsdf', N'sdfsdf', 898356276, 394229171)
INSERT [dbo].[Lop] ([Malop], [Tenlop]) VALUES (N'L01', N'1A')
INSERT [dbo].[MonHoc] ([MaMon], [TenMon]) VALUES (N'M01', N'Tin học')
INSERT [dbo].[TaiKhoan] ([Tentaikhoan], [Matkhau], [MaGV]) VALUES (N'ngokhai', N'123', N'GV01')
INSERT [dbo].[TaiKhoan] ([Tentaikhoan], [Matkhau], [MaGV]) VALUES (N'nguyenngu', N'123', N'GV02')
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_GiaoVien] FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_GiaoVien]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_HocSinh] FOREIGN KEY([MaHS])
REFERENCES [dbo].[HocSinh] ([MaHS])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_HocSinh]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_Monhoc] FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonHoc] ([MaMon])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_Monhoc]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_Lop] FOREIGN KEY([Malop])
REFERENCES [dbo].[Lop] ([Malop])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_Lop]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_MonHoc] FOREIGN KEY([Mamon])
REFERENCES [dbo].[MonHoc] ([MaMon])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_MonHoc]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_Lop] FOREIGN KEY([Malop])
REFERENCES [dbo].[Lop] ([Malop])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_Lop]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_SoSucKhoe] FOREIGN KEY([Mask])
REFERENCES [dbo].[SoSucKhoe] ([Mask])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_SoSucKhoe]
GO
USE [master]
GO
ALTER DATABASE [QLHSCap1] SET  READ_WRITE 
GO
