USE [master]
GO
/****** Object:  Database [ApiDemo]    Script Date: 5/29/2022 10:18:03 PM ******/
CREATE DATABASE [ApiDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApiDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.WSL024\MSSQL\DATA\ApiDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApiDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.WSL024\MSSQL\DATA\ApiDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApiDemo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApiDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApiDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApiDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApiDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApiDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApiDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApiDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApiDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApiDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApiDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApiDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApiDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApiDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApiDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApiDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApiDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApiDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApiDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApiDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApiDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApiDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApiDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApiDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApiDemo] SET RECOVERY FULL 
GO
ALTER DATABASE [ApiDemo] SET  MULTI_USER 
GO
ALTER DATABASE [ApiDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApiDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApiDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApiDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApiDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApiDemo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ApiDemo] SET QUERY_STORE = OFF
GO
USE [ApiDemo]
GO
/****** Object:  Table [dbo].[Tbl_Account]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[IdCreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IdUpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Customer]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](800) NOT NULL,
	[IdCreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IdUpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Transaction]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Transaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdAccount] [int] NULL,
	[IdCreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IdUpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Amount] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](800) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IdCreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IdUpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Account] ON 

INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (4, 3, NULL, CAST(N'2022-05-29T13:06:43.183' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (5, 3, NULL, CAST(N'2022-05-29T13:08:08.793' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (6, 4, NULL, CAST(N'2022-05-29T13:08:40.637' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (7, 3, NULL, CAST(N'2022-05-29T13:08:53.183' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (8, 3, NULL, CAST(N'2022-05-29T13:48:00.540' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (9, 3, NULL, CAST(N'2022-05-29T13:51:15.860' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (10, 3, NULL, CAST(N'2022-05-29T13:51:34.830' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (11, 3, NULL, CAST(N'2022-05-29T13:52:33.200' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (12, 3, NULL, CAST(N'2022-05-29T15:28:08.470' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (13, 3, NULL, CAST(N'2022-05-29T19:54:51.130' AS DateTime), NULL, NULL)
INSERT [dbo].[Tbl_Account] ([ID], [IdCustomer], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (14, 3, NULL, CAST(N'2022-05-29T20:00:56.163' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Customer] ON 

INSERT [dbo].[Tbl_Customer] ([ID], [Name], [Surname], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (3, N'MHMD ', N'Itani', 1, CAST(N'2022-05-29T11:40:13.937' AS DateTime), NULL, CAST(N'2021-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Tbl_Customer] ([ID], [Name], [Surname], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (4, N'Tarek', N'Itani', 1, CAST(N'2020-09-30T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Transaction] ON 

INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (1, 10, NULL, CAST(N'2022-05-29T13:51:57.730' AS DateTime), NULL, NULL, CAST(0.000000 AS Decimal(18, 6)))
INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (2, 11, NULL, CAST(N'2022-05-29T13:54:16.117' AS DateTime), NULL, NULL, CAST(100.000000 AS Decimal(18, 6)))
INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (3, 11, NULL, CAST(N'2022-05-29T13:54:35.250' AS DateTime), NULL, NULL, CAST(100.000000 AS Decimal(18, 6)))
INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (4, 11, NULL, CAST(N'2022-05-29T14:16:51.630' AS DateTime), NULL, NULL, CAST(100.000000 AS Decimal(18, 6)))
INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (5, 12, NULL, CAST(N'2022-05-29T15:28:13.037' AS DateTime), NULL, NULL, CAST(100.000000 AS Decimal(18, 6)))
INSERT [dbo].[Tbl_Transaction] ([ID], [IdAccount], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate], [Amount]) VALUES (6, 14, NULL, CAST(N'2022-05-29T20:00:56.370' AS DateTime), NULL, NULL, CAST(100.000000 AS Decimal(18, 6)))
SET IDENTITY_INSERT [dbo].[Tbl_Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([ID], [Username], [Password], [Name], [IdCreatedBy], [CreatedDate], [IdUpdatedBy], [UpdatedDate]) VALUES (1, N'admin', N'9ca694a90285c034432c9550421b7b9dbd5c0f4b6673f05f6dbce58052ba20e4248041956ee8c9a2ec9f10290cdc0782', N'MHMD ITANI', NULL, CAST(N'2022-05-29T10:22:53.660' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
GO
ALTER TABLE [dbo].[Tbl_Account] ADD  CONSTRAINT [DF_Account_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Tbl_Customer] ADD  CONSTRAINT [DF_Customer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Tbl_Transaction] ADD  CONSTRAINT [DF_Transaction_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Tbl_User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Tbl_Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Tbl_Customer] ([ID])
GO
ALTER TABLE [dbo].[Tbl_Account] CHECK CONSTRAINT [FK_Account_Customer]
GO
ALTER TABLE [dbo].[Tbl_Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Transaction_Account] FOREIGN KEY([IdAccount])
REFERENCES [dbo].[Tbl_Account] ([ID])
GO
ALTER TABLE [dbo].[Tbl_Transaction] CHECK CONSTRAINT [FK_Tbl_Transaction_Account]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Account_Add]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Account_Add] --3
@IdCustomer int

as

begin


Insert Into Tbl_Account(IdCustomer) Values(@IdCustomer)

Select @@IDENTITY

End
GO
/****** Object:  StoredProcedure [dbo].[Sp_CustomerDetails_Get]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Sp_CustomerDetails_Get]

as


Begin

Select 

c.ID,c.Name,c.Surname,Sum(trans.Amount) Balance

From

Tbl_Customer c

Left Join Tbl_Account acc on acc.IdCustomer = c.ID
Left Join Tbl_Transaction trans on trans.IdAccount = acc.ID
Group By c.ID, c.Name,c.Surname


End


GO
/****** Object:  StoredProcedure [dbo].[Sp_Transaction_Add]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Transaction_Add] 
@IdAccount int,
@InitialCredit Decimal(18,6)

as

begin


Insert Into Tbl_Transaction(IdAccount,Amount) Values(@IdAccount,@InitialCredit)

Select  @@IDENTITY

End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Transactions_Get]    Script Date: 5/29/2022 10:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Transactions_Get]
as

Begin
Select 

tr.ID,
tr.IdAccount,
tr.Amount,
c.ID IdCustomer

From

Tbl_Transaction tr
Inner Join Tbl_Account acc on acc.ID = tr.IdAccount
Inner Join Tbl_Customer c on c.ID = acc.IdCustomer

End
GO
USE [master]
GO
ALTER DATABASE [ApiDemo] SET  READ_WRITE 
GO
