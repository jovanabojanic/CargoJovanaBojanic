USE [master]
GO
/****** Object:  Database [ProductDB]    Script Date: 10/11/2024 1:35:31 PM ******/
CREATE DATABASE [ProductDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProductDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProductDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProductDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductDB', N'ON'
GO
ALTER DATABASE [ProductDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProductDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProductDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/11/2024 1:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[_FC_Categories]    Script Date: 10/11/2024 1:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_FC_Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK__FC_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[_FC_ProductCategories]    Script Date: 10/11/2024 1:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_FC_ProductCategories](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK__FC_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[_FC_Products]    Script Date: 10/11/2024 1:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_FC_Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK__FC_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241010100538_InitialCreate', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[_FC_Categories] ON 

INSERT [dbo].[_FC_Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (1, N'Tehnika', CAST(N'2024-10-10T12:51:07.7033333' AS DateTime2))
INSERT [dbo].[_FC_Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (2, N'Enterijer', CAST(N'2024-10-10T12:51:07.7033333' AS DateTime2))
INSERT [dbo].[_FC_Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (3, N'Moda', CAST(N'2024-10-10T12:51:07.7033333' AS DateTime2))
INSERT [dbo].[_FC_Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (4, N'Igracke', CAST(N'2024-10-10T12:51:07.7033333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[_FC_Categories] OFF
GO
INSERT [dbo].[_FC_ProductCategories] ([ProductId], [CategoryId]) VALUES (1, 1)
INSERT [dbo].[_FC_ProductCategories] ([ProductId], [CategoryId]) VALUES (2, 1)
INSERT [dbo].[_FC_ProductCategories] ([ProductId], [CategoryId]) VALUES (3, 2)
INSERT [dbo].[_FC_ProductCategories] ([ProductId], [CategoryId]) VALUES (4, 3)
INSERT [dbo].[_FC_ProductCategories] ([ProductId], [CategoryId]) VALUES (5, 4)
GO
SET IDENTITY_INSERT [dbo].[_FC_Products] ON 

INSERT [dbo].[_FC_Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (1, N'Samsung Galaxy S23', CAST(799.99 AS Decimal(18, 2)), N'Pametan telefon sa vrhunskim kamerama i performansama.', 120, CAST(N'2024-10-10T12:51:41.3566667' AS DateTime2))
INSERT [dbo].[_FC_Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (2, N'Dell XPS 13', CAST(1299.99 AS Decimal(18, 2)), N'Snažan laptop sa ekranom bez okvira, idealan za posao i zabavu.', 75, CAST(N'2024-10-10T12:51:41.3566667' AS DateTime2))
INSERT [dbo].[_FC_Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (3, N'Modularni kauc', CAST(349.99 AS Decimal(18, 2)), N'Savremeni kauc koji se lako prilagodava vašem prostoru.', 15, CAST(N'2024-10-10T12:51:41.3566667' AS DateTime2))
INSERT [dbo].[_FC_Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (4, N'Elegantna majica', CAST(24.99 AS Decimal(18, 2)), N'Klasicna majica od kvalitetnog pamuka, dostupna u raznim bojama.', 250, CAST(N'2024-10-10T12:51:41.3566667' AS DateTime2))
INSERT [dbo].[_FC_Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (5, N'Plasticni auto', CAST(29.99 AS Decimal(18, 2)), N'Igracka stvorna za malisane!', 100, CAST(N'2024-10-10T22:18:35.2691759' AS DateTime2))
SET IDENTITY_INSERT [dbo].[_FC_Products] OFF
GO
/****** Object:  Index [IX__FC_ProductCategories_CategoryId]    Script Date: 10/11/2024 1:35:31 PM ******/
CREATE NONCLUSTERED INDEX [IX__FC_ProductCategories_CategoryId] ON [dbo].[_FC_ProductCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[_FC_ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK__FC_ProductCategories__FC_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[_FC_Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[_FC_ProductCategories] CHECK CONSTRAINT [FK__FC_ProductCategories__FC_Categories_CategoryId]
GO
ALTER TABLE [dbo].[_FC_ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK__FC_ProductCategories__FC_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[_FC_Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[_FC_ProductCategories] CHECK CONSTRAINT [FK__FC_ProductCategories__FC_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [ProductDB] SET  READ_WRITE 
GO
