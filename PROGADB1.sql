USE [master]
GO
/****** Object:  Database [PROGADB1]    Script Date: 27.04.2023 6:09:54 ******/
CREATE DATABASE [PROGADB1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROGADB1', FILENAME = N'D:\SQLSERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\PROGADB1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROGADB1_log', FILENAME = N'D:\SQLSERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\PROGADB1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PROGADB1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROGADB1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROGADB1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROGADB1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROGADB1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROGADB1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROGADB1] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROGADB1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PROGADB1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROGADB1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROGADB1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROGADB1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROGADB1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROGADB1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROGADB1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROGADB1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROGADB1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PROGADB1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROGADB1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROGADB1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROGADB1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROGADB1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROGADB1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROGADB1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROGADB1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PROGADB1] SET  MULTI_USER 
GO
ALTER DATABASE [PROGADB1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROGADB1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROGADB1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROGADB1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROGADB1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROGADB1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PROGADB1] SET QUERY_STORE = OFF
GO
USE [PROGADB1]
GO
/****** Object:  Table [dbo].[reports]    Script Date: 27.04.2023 6:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reports](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[priceForHour] [nvarchar](50) NOT NULL,
	[hours] [nvarchar](50) NOT NULL,
	[zarplata] [nvarchar](50) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 27.04.2023 6:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[priceForHour] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 27.04.2023 6:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[phonenumber] [nvarchar](50) NOT NULL,
	[adress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[reports] ON 

INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (1, N'Администратор', N'500', N'250', N'125000', N'Elian Ángel Valenzuela')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (2, N'Admin', N'500', N'228', N'114000', N'fkjg')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (3, N'Admin', N'500', N'34', N'17000', N'fkjg')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (4, N'Admin', N'500', N'567', N'283500', N'fkjg')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (5, N'Admin', N'500', N'228', N'114000', N'fkjg')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (6, N'Admin', N'500', N'999', N'499500', N'fkjg')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (7, N'Polz', N'200', N'666', N'133200', N'sdkfsd')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (8, N'Admin', N'200', N'120', N'24000', N'sdkfsd')
INSERT [dbo].[reports] ([id], [role], [priceForHour], [hours], [zarplata], [fullName]) VALUES (9, N'Инженер', N'250', N'170', N'42500', N'Василий')
SET IDENTITY_INSERT [dbo].[reports] OFF
GO
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'1', N'Администратор', N'500')
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'2', N'Бухгалтер', N'400')
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'3', N'Бригадир', N'300')
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'4', N'Инженер', N'250')
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'5', N'Слесарь', N'200')
INSERT [dbo].[role] ([id], [title], [priceForHour]) VALUES (N'6', N'Стекольщик', N'100')
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [login], [password], [role], [fullName], [dateOfBirth], [phonenumber], [adress]) VALUES (1, N'elian228', N'12345678', N'Администратор', N'Elian Ángel Valenzuela', CAST(N'2000-01-01' AS Date), N'+79803892816', N'General Rodríguez, Buenos Aires Province')
INSERT [dbo].[user] ([id], [login], [password], [role], [fullName], [dateOfBirth], [phonenumber], [adress]) VALUES (4, N'0', N'0', N'Администратор', N'Василий', CAST(N'1985-07-04' AS Date), N'+79002054926', N'Ясная 21')
INSERT [dbo].[user] ([id], [login], [password], [role], [fullName], [dateOfBirth], [phonenumber], [adress]) VALUES (5, N'1', N'1', N'Бухгалтер', N'Корпатый', CAST(N'1973-09-09' AS Date), N'+35003911963', N'Майдан')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
USE [master]
GO
ALTER DATABASE [PROGADB1] SET  READ_WRITE 
GO
