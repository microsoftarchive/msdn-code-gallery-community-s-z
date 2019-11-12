USE [master]
GO
/****** Object:  Database [MockedEmail]    Script Date: 6/15/2017 4:31:47 PM ******/
CREATE DATABASE [MockedEmail]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MockedEmail', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MockedEmail.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MockedEmail_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MockedEmail_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MockedEmail] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MockedEmail].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MockedEmail] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MockedEmail] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MockedEmail] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MockedEmail] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MockedEmail] SET ARITHABORT OFF 
GO
ALTER DATABASE [MockedEmail] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MockedEmail] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MockedEmail] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MockedEmail] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MockedEmail] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MockedEmail] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MockedEmail] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MockedEmail] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MockedEmail] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MockedEmail] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MockedEmail] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MockedEmail] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MockedEmail] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MockedEmail] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MockedEmail] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MockedEmail] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MockedEmail] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MockedEmail] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MockedEmail] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MockedEmail] SET  MULTI_USER 
GO
ALTER DATABASE [MockedEmail] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MockedEmail] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MockedEmail] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MockedEmail] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MockedEmail]
GO
/****** Object:  Table [dbo].[Body]    Script Date: 6/15/2017 4:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Body](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayText] [nvarchar](max) NULL,
	[HtmlText] [nvarchar](max) NULL,
 CONSTRAINT [PK_Body] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FakeAddresses]    Script Date: 6/15/2017 4:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FakeAddresses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_FakeAddresses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Body] ON 

GO
INSERT [dbo].[Body] ([id], [DisplayText], [HtmlText]) VALUES (1, N'Two paragraphs', N'<p>Paragraph one </p><p>Paragraph two</p>')
GO
INSERT [dbo].[Body] ([id], [DisplayText], [HtmlText]) VALUES (2, N'One paragraph UL five elements', N'<p>Paragraph one</p><ul><li>Meat</li><li>Fish</li><li>Chicken</li><li>Fruit</li><li>Candy</li></ul>')
GO
SET IDENTITY_INSERT [dbo].[Body] OFF
GO
SET IDENTITY_INSERT [dbo].[FakeAddresses] ON 

GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (1, N'azxhezkm.dfmfr@dsbohvn.ogmgqd.org')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (2, N'coiugkn.dffloia@tymqtdkx.sweerx.net')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (3, N'rjkdtec629@mull.xludji.net')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (4, N'cgyn1@aaztjn.com')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (5, N'cyotkk.pzxweauyj@fczj.gutiko.com')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (6, N'fqhk681@qivma.-ijrkk.org')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (7, N'smqrlv.yqotjsi@bvftnmhsc.ecguec.net')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (8, N'obesmt19@iabq.pxvd-h.net')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (9, N'kuhrwip.uhwiimpei@ebfcplp.-jnsej.org')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (10, N'wrip.eguuahlg@zndhoe.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (11, N'tjnugo.gmsm@suxzhv.com
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (12, N'tujvtrf.rpxwiwkz@caznnsfuj.pwf-kp.net
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (13, N'kuysnbb.wkymzcrihu@dnxw.uuiwks.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (14, N'pkejmxmp.kkyquosd@mfgawe.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (15, N'oglsulk.yuxuhoe@jeaueix.mhcbmg.com
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (16, N'bjyrqmg739@sbojvb.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (17, N'bducy4@gpffgu.wyxskz.net
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (18, N'hqancloy88@enqhvq.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (19, N'nwtozdia.vbrlnwicsq@kxhhtj.org
')
GO
INSERT [dbo].[FakeAddresses] ([id], [Address]) VALUES (20, N'ehyhceto62@alxt-t.net')
GO
SET IDENTITY_INSERT [dbo].[FakeAddresses] OFF
GO
USE [master]
GO
ALTER DATABASE [MockedEmail] SET  READ_WRITE 
GO
