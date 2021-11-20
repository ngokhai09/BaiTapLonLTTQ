--Create database BTLTTQ
USE [BTLTTQ]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Malop] [nvarchar] (5) NOT NULL,
	[Tenlop] [nvarchar] (5) NULL,
CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED
(
	[Malop] ASC 
)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [nvarchar] (5) NOT NULL,
	[TenHS] [nvarchar] (25) NULL,
	[Malop] [nvarchar]  (5)NULL,
	[Ngaysinh] [Datetime] NUll,
	[Gioitinh] [nvarchar] (3) NULL,
	[Diachi] [nvarchar] (100) Null,
	[Mask] [nvarchar] (5) null,
	[HTBo] [nvarchar] (25) not null,
	[HTMe] [nvarchar] (25) not null,
	[NNMe] [nvarchar] (15) not null,
	[NNBo] [nvarchar] (15) not null,
	[SDTBo] [int] not null,
	[SDTMe] [int] not null,
CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED
(
	[MaHS] ASC 
)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [nvarchar] (5) NOT NULL,
	[TenGV] [nvarchar] (25) NULL,
	[Mamon] [nvarchar] (15) NULL,
	[Diachi] [nvarchar] (100) Null,
	[Dienthoai] [int] null, 
	[Malop] [nvarchar] (5) null,
	[TenTaikhoan] [nvarchar] (10) not null,
	[MatKhau] [nvarchar] (15)
CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED
(
	[MaGV] ASC 
)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMon] [nvarchar] (5) NOT NULL,
	[TenMon] [nvarchar] (15) NULL,
CONSTRAINT [PK_MaHoc] PRIMARY KEY CLUSTERED
(
	[MaMon] ASC 
)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [nvarchar] (5) NOT NULL,
	[MaHS] [nvarchar] (5) NULL,
	[MaGV] [nvarchar] (5) NULL,
	[LoaiDanhGia] [nvarchar] (10) NULL,
	[NamHoc] [nvarchar] (10) Null,
	[KiDanhGia] [nvarchar] (15) NULL,
	[NoiDungDanhGia] [nvarchar] (100) Null,
	[MaMon] [nvarchar] (5) null,
	[MucDoDanhGia] [nvarchar] (5) not null,
CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED
(
	[MaDanhGia] ASC 
)
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoSucKhoe](
	[Mask] [nvarchar] (5)  not null,
	[Chieucao] int not null,
	[Cannang] float not null,
	[ChisoIBM] float not null,
	[Xeploaisuckhoe] [nvarchar] (5) null,
CONSTRAINT [PK_SoSucKhoe] PRIMARY KEY CLUSTERED
(
	[Mask] ASC
) 
)ON [PRIMARY]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_Lop] FOREIGN KEY([Malop])
REFERENCES [dbo].[Lop] ([Malop])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_Lop]
GO
ALTER TABLE [dbo].[GiaoVien] WITH CHECK ADD CONSTRAINT [FK_GiaoVien_Lop] FOREIGN KEY ([Malop])
REFERENCES [dbo].[Lop]([Malop])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_Lop]
GO
ALTER TABLE [dbo].[GiaoVien] WITH CHECK ADD CONSTRAINT [FK_GiaoVien_MonHoc] FOREIGN KEY ([MaMon])
REFERENCES [dbo].[MonHoc]([MaMon])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_MonHoc]
GO
ALTER TABLE [dbo].[DanhGia] WITH CHECK ADD CONSTRAINT [FK_DanhGia_Monhoc] FOREIGN KEY ([MaMon])
REFERENCES [dbo].[MonHoc]([MaMon])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_MonHoc]
GO
ALTER TABLE [dbo].[DanhGia] WITH CHECK ADD CONSTRAINT [FK_DanhGia_HocSinh] FOREIGN KEY ([MaHS])
REFERENCES [dbo].[HocSinh]([MaHS])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_HocSinh]
GO
ALTER TABLE [dbo].[DanhGia] WITH CHECK ADD CONSTRAINT [FK_DanhGia_GiaoVien] FOREIGN KEY ([MaGV])
REFERENCES [dbo].[GiaoVien]([MaGV])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_GiaoVien]
GO
ALTER TABLE [dbo].[HocSinh] WITH CHECK ADD CONSTRAINT [FK_HocSinh_SoSucKhoe] FOREIGN KEY ([Mask])
REFERENCES [dbo].[SoSucKhoe]([Mask])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_SoSucKhoe] 