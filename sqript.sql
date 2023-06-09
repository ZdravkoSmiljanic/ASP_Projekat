USE [master]
GO
/****** Object:  Database [projekat_blog]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE DATABASE [projekat_blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projekat_blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\projekat_blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projekat_blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\projekat_blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [projekat_blog] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projekat_blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projekat_blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projekat_blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projekat_blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projekat_blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projekat_blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [projekat_blog] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [projekat_blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projekat_blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projekat_blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projekat_blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projekat_blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projekat_blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projekat_blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projekat_blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projekat_blog] SET  ENABLE_BROKER 
GO
ALTER DATABASE [projekat_blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projekat_blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projekat_blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projekat_blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projekat_blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projekat_blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projekat_blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projekat_blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [projekat_blog] SET  MULTI_USER 
GO
ALTER DATABASE [projekat_blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projekat_blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projekat_blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projekat_blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projekat_blog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [projekat_blog] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [projekat_blog] SET QUERY_STORE = OFF
GO
USE [projekat_blog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8.6.2023. 15:24:03 ******/
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
/****** Object:  Table [dbo].[BlogImages]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogImages](
	[BlogId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_BlogImages] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogReactions]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogReactions](
	[BlogId] [int] NOT NULL,
	[ReactionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[ReactedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_BlogReactions] PRIMARY KEY CLUSTERED 
(
	[ReactionId] ASC,
	[BlogId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogText] [nvarchar](1024) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTags]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTags](
	[BlogId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_BlogTags] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TextComment] [nvarchar](1024) NOT NULL,
	[BlogId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[CommentedAt] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[ImageSize] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEntries]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Actor] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
	[UseCaseName] [nvarchar](max) NOT NULL,
	[UseCaseData] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reactions]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReactionName] [nvarchar](40) NOT NULL,
	[ImageID] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUseCases]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUseCases](
	[RoleId] [int] NOT NULL,
	[UseacaseId] [int] NOT NULL,
 CONSTRAINT [PK_RoleUseCases] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UseacaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagText] [nvarchar](30) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8.6.2023. 15:24:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Surname] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[ProfileImgId] [int] NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230530140853_initial migration', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230530195501_new migration', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230530195728_new blog lenght', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230530200057_new fk blog comments', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230602203203_between images and users', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230603151020_updata table blogReactions', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604112303_new log enrty table', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604112433_new log enrty table', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604113219_role use cases table', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230604133650_new length of password', N'6.0.16')
GO
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (11, 43)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (15, 43)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (12, 44)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (15, 44)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (13, 45)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (15, 45)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (7, 47)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (8, 48)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (9, 49)
INSERT [dbo].[BlogImages] ([BlogId], [ImageId]) VALUES (10, 50)
GO
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (7, 17, 21, CAST(N'2023-06-03T15:20:34.8043705' AS DateTime2), 0, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (7, 17, 22, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (8, 17, 23, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (10, 17, 21, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (8, 18, 24, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (9, 18, 20, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (7, 19, 20, NULL, NULL, NULL)
INSERT [dbo].[BlogReactions] ([BlogId], [ReactionId], [UserId], [DeletedAt], [IsActive], [ReactedAt]) VALUES (10, 19, 22, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (7, N'Otkako su se zagrebačka Cedevita i ljubljanska Olimpija spojili u Cedevita Olimpiju, 8. jula 2019, Partizan nije uspeo da savlada taj novonastali hrvatsko-slovenački klub u gostima, odnosno u Ljubljani. Danas (18 časova) u tom gradu „crno-beli” igraju drugi meč polufinala plej-ofa ABA lige, a ukoliko pobede, plasiraće se u finale u kojem je već Crvena zvezda. Preksinoć, u „Štark areni”, pobedili su sa 85:70 i poveli sa 1:0 (igra se na dve dobijene utakmice, finale na tri)', 22, CAST(N'2023-05-30T22:01:51.8033333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (8, N'Zato su malo vremena „ukrali“ od sna, revanš malo pripremali i u autobusu. Mada – ovo će biti pet meč dva tima ove sezone. Teško da je ostala neka nepoznanica, pa i da je moguće bilo kakvo iznenađenje.- Analiza utakmice je napravljena. Video sa igračima odrađen, kako bismo se dobro pripremili. Želimo da probamo da igramo dobru utakmicu i da prođemo u finale – poručio je Obradović.', 23, CAST(N'2023-05-30T22:01:51.8033333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (9, N'Srpski stručnjak se dovodio u vezu sa Partizanom kao trener koji bi mogao da počne narednu sezonu na klupi crno-belih, ali je Nikolić odlučio da se oproba u Dubaiju.On će potpisati ugovor na godinu dana sa Al Ahli Šababom iz Dubaija, potvrđeno je Sport klubu. ', 22, CAST(N'2023-05-30T22:01:51.8033333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (10, N'Đoković je nakon dva i po sata igre savladao Aleksandra Kovačevića u tri seta i tako lako prošao u narednu rundu drugog Grend slema u sezoni.Posle pobede je prema tradiciji ispisao poruku na kameri koja je snimala prenost tog meča, ali je ovaj put poruka imala snažnije značenje nego u nekim drugim navratima.''Kosovo je srce Srbije! Stop nasilju'', napisao je treći nosilac na Rolan Garosu.Đokovićev naredni rival će biti mađarski teniser Marton Fučovič.', 21, CAST(N'2023-05-30T22:01:51.8033333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (11, N'blog kroz swagger', 19, CAST(N'2023-06-02T23:01:19.3724564' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (12, N'izmena bloga', 19, CAST(N'2023-06-03T09:32:53.7160366' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (13, N'probaaaaa', 19, CAST(N'2023-06-03T15:49:55.2862591' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (14, N'probaaaaa', 19, CAST(N'2023-06-03T15:52:01.0705302' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Blogs] ([Id], [BlogText], [UserId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (15, N'probaaaaaqqqq', 19, CAST(N'2023-06-03T15:52:39.2802770' AS DateTime2), NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (9, 28)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (10, 28)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (11, 28)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (12, 28)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (7, 29)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (8, 29)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (10, 29)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (8, 30)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (8, 31)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (15, 33)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (15, 34)
INSERT [dbo].[BlogTags] ([BlogId], [TagId]) VALUES (13, 37)
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (4, 20, N'ova objava je bas zanimljivog karaktera', 8, NULL, CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (5, 23, N'Tezak je to put bio.', 9, NULL, CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (6, 22, N'Bravo Nole svaka cast!!!', 10, NULL, CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), CAST(N'2023-05-30T22:01:53.0500000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (7, 22, N'totalno se slazem', 8, 4, CAST(N'2023-05-30T22:01:53.4166667' AS DateTime2), CAST(N'2023-05-30T22:01:53.4166667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (8, 21, N'Bilo je mnogo teskihh', 8, 4, CAST(N'2023-05-30T22:01:53.4300000' AS DateTime2), CAST(N'2023-05-30T22:01:53.4300000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (9, 20, N'update komentara', 10, 6, CAST(N'2023-05-30T22:01:53.4333333' AS DateTime2), CAST(N'2023-05-30T22:01:53.4333333' AS DateTime2), CAST(N'2023-06-03T16:00:32.6278169' AS DateTime2), NULL, 0, CAST(N'2023-06-03T19:26:02.0024618' AS DateTime2), NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (10, 19, N'text za promenu kroz postman', 8, NULL, CAST(N'2023-06-03T16:19:39.2372439' AS DateTime2), CAST(N'2023-06-03T18:19:39.6433333' AS DateTime2), NULL, NULL, 1, CAST(N'2023-06-07T13:48:01.4448584' AS DateTime2), NULL)
INSERT [dbo].[Comments] ([Id], [UserId], [TextComment], [BlogId], [ParentId], [CommentedAt], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (11, 21, N'Odgovor na komentar sa id-em 4', 8, 4, CAST(N'2023-06-03T16:20:13.5865815' AS DateTime2), CAST(N'2023-06-03T18:20:13.5800000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (43, N'putanja2', 12, CAST(N'2023-05-30T20:01:39.5453751' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (44, N'putanja3', 14, CAST(N'2023-05-30T20:01:39.5453752' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (45, N'putanja4', 10, CAST(N'2023-05-30T20:01:39.5453754' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (46, N'putanja1', 10, CAST(N'2023-05-30T20:01:39.5453734' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (47, N'putanja5', 16, CAST(N'2023-05-30T20:01:39.5453755' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (48, N'putanja6', 20, CAST(N'2023-05-30T20:01:39.5453758' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (49, N'putanja7', 19, CAST(N'2023-05-30T20:01:39.5453760' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (50, N'putanja8', 18, CAST(N'2023-05-30T20:01:39.5453761' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (51, N'putanja9', 11, CAST(N'2023-05-30T20:01:39.5453762' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (52, N'reakcijaimg1', 11, CAST(N'2023-05-30T20:01:39.5453764' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (53, N'reakcijaimg2', 11, CAST(N'2023-05-30T20:01:39.5453765' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (54, N'reakcijaimg3', 11, CAST(N'2023-05-30T20:01:39.5453766' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (55, N'reakcijaimg4', 11, CAST(N'2023-05-30T20:01:39.5453767' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (56, N'reakcijaimg5', 11, CAST(N'2023-05-30T20:01:39.5453768' AS DateTime2), NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (57, N'nova putanja', 63, CAST(N'2023-06-02T21:06:24.0466667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (58, N'putanjaKrozPostman', 50, CAST(N'2023-06-05T17:45:56.8400000' AS DateTime2), CAST(N'2023-06-05T15:46:21.1981686' AS DateTime2), NULL, 0, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (59, N'6fd6ed41-fad2-4994-a4d6-0a3964433e98.png', 0, CAST(N'2023-06-07T15:20:09.8300000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Images] ([Id], [ImagePath], [ImageSize], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (60, N'a3531398-5947-49ea-bcb8-a4a2b85bb210.jpg', 50, CAST(N'2023-06-08T14:56:43.2966667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[LogEntries] ON 

INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (1, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:28:20.9521399' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (2, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:28:35.0521451' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (3, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:29:35.8082052' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (4, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:34:08.2341452' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (5, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:39:36.5529269' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (6, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:42:08.7062039' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (7, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag"}', CAST(N'2023-06-05T13:46:15.9368706' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (8, N'kevinPanter7', 19, N'Kreiranje taga', N'{"Name":"najnoviji tag as"}', CAST(N'2023-06-05T13:46:38.6529031' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (9, N'kevinPanter7', 19, N'Brisanje taga', N'1', CAST(N'2023-06-05T14:11:56.3076111' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (10, N'kevinPanter7', 19, N'Brisanje taga', N'45', CAST(N'2023-06-05T14:38:23.7646743' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (11, N'kevinPanter7', 19, N'Brisanje taga', N'45', CAST(N'2023-06-05T14:38:31.0725054' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (12, N'kevinPanter7', 19, N'Brisanje taga', N'1', CAST(N'2023-06-05T14:48:34.7589829' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (13, N'kevinPanter7', 19, N'Brisanje taga', N'1', CAST(N'2023-06-05T14:49:23.0593067' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (14, N'kevinPanter7', 19, N'Brisanje taga', N'45', CAST(N'2023-06-05T14:49:42.5236335' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (15, N'kevinPanter7', 19, N'Brisanje taga', N'40', CAST(N'2023-06-05T14:49:59.1986680' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (16, N'kevinPanter7', 19, N'Kreiranje uloge', N'{"Name":"rola kroz postman"}', CAST(N'2023-06-05T15:17:17.8952666' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (17, N'kevinPanter7', 19, N'Brisanje uloge', N'10', CAST(N'2023-06-05T15:17:38.9834026' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (18, N'kevinPanter7', 19, N'Brisanje uloge', N'10', CAST(N'2023-06-05T15:18:52.1080677' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (19, N'kevinPanter7', 19, N'Brisanje uloge', N'10', CAST(N'2023-06-05T15:19:21.5462331' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (20, N'kevinPanter7', 19, N'Kreiranje slike', N'{"ImagePath":"putanjaKrozPostman","ImageSize":50}', CAST(N'2023-06-05T15:45:56.2348794' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (21, N'kevinPanter7', 19, N'Brisanje slike', N'58', CAST(N'2023-06-05T15:46:20.9595123' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (22, N'kevinPanter7', 19, N'Kreiranje reakcije', N'{"ReactionName":"reackija kroz postman","ImageId":52}', CAST(N'2023-06-05T17:15:13.7530073' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (23, N'kevinPanter7', 19, N'Brisanje reakcije', N'22', CAST(N'2023-06-05T17:15:57.7872995' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (24, N'kevinPanter7', 19, N'Brisanje reakcije', N'22', CAST(N'2023-06-05T17:19:33.7014113' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (25, N'Anonymous', 0, N'Registracija usera', N'{"Email":"riki@gmail.com","Password":"sifra12312","Name":"Ricardo","Surname":"Gomes","UserName":"riki123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-07T13:16:32.9254842' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (26, N'Anonymous', 0, N'Registracija usera', N'{"Email":"mitar@gmail.com","Password":"mitara","Name":"MItar","Surname":"Miric","UserName":"micko13","ImageId":{"ContentDisposition":"form-data; name=\"ImageId\"; filename=\"baza.png\"","ContentType":"image/png","Headers":{"Content-Disposition":["form-data; name=\"ImageId\"; filename=\"baza.png\""],"Content-Type":["image/png"]},"Length":86824,"Name":"ImageId","FileName":"baza.png"},"ImageFileName":"0ae280f3-db05-4386-b220-1033db6e2cd8.png"}', CAST(N'2023-06-07T13:18:33.9685831' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (27, N'Anonymous', 0, N'Registracija usera', N'{"Email":"mitar@gmail.com","Password":"mitara","Name":"MItar","Surname":"Miric","UserName":"micko13","ImageId":{"ContentDisposition":"form-data; name=\"ImageId\"; filename=\"baza.png\"","ContentType":"image/png","Headers":{"Content-Disposition":["form-data; name=\"ImageId\"; filename=\"baza.png\""],"Content-Type":["image/png"]},"Length":86824,"Name":"ImageId","FileName":"baza.png"},"ImageFileName":"6fd6ed41-fad2-4994-a4d6-0a3964433e98.png"}', CAST(N'2023-06-07T13:20:06.8244765' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (28, N'Anonymous', 0, N'Registracija usera', N'{"Email":"lepa@gmail.com","Password":"LukicLepa","Name":"Lepa","Surname":"Lukic","UserName":"Lepa123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-07T13:24:52.6038342' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (29, N'Anonymous', 0, N'Registracija usera', N'{"Email":"lepa@gmail.com","Password":"LukicLepa","Name":"Lepa","Surname":"Lukic","UserName":"Lepa123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-07T13:26:07.9937092' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (30, N'Anonymous', 0, N'Registracija usera', N'{"Email":"lepa@gmail.com","Password":"LukicLepa","Name":"Lepa","Surname":"Lukic","UserName":"Lepa123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-07T13:26:42.3784154' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (31, N'Anonymous', 0, N'Registracija usera', N'{"Email":"lepa@gmail.com","Password":"LukicLepa","Name":"Lepa","Surname":"Lukic","UserName":"Lepa123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-07T13:27:15.8589329' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (32, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"mitarNovimejl@gmail.com","Password":"mitarizdubica","Username":"mitarNoviUserName","ProfileImageId":0}', CAST(N'2023-06-07T13:31:55.5319660' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (33, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"mitarNovimejl@gmail.com","Password":"mitarizdubica","Username":"mitarNoviUserName","ProfileImageId":null}', CAST(N'2023-06-07T13:33:39.0051380' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (34, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"riki@gmail.com","Password":"sifra11111","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:35:10.5427559' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (35, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"riki@gmail.com","Password":"sifra11111","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:35:52.6421631' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (36, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"RicardoRiki@gmail.com","Password":"novaSifra","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:37:25.3655664' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (37, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"RicardoRiki@gmail.com","Password":"novaSifra","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:38:12.0866383' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (38, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"RicardoRiki@gmail.com","Password":"novaSifra","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:40:42.6431077' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (39, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"RicardoRiki@gmail.com","Password":"novaSifra","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:41:25.1971895' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (40, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"RicardoRiki@gmail.com","Password":"novaSifra","Username":"rikardoooo123","ProfileImageId":null}', CAST(N'2023-06-07T13:42:38.9958799' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (41, N'Anonymous', 0, N'Izmena korisnika', N'{"Id":45,"Email":"mitarNoviProrilf@gmail.com","Password":"micaizdubica","Username":"mitar","ProfileImageId":null}', CAST(N'2023-06-07T13:43:44.4545987' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (42, N'Anonymous', 0, N'Izmena teksta komentara', N'{"Id":19,"CommentText":"text za promenu kroz postman"}', CAST(N'2023-06-07T13:45:49.9662594' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (43, N'Anonymous', 0, N'Izmena teksta komentara', N'{"Id":10,"CommentText":"text za promenu kroz postman"}', CAST(N'2023-06-07T13:46:14.2301652' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (44, N'Anonymous', 0, N'Izmena teksta komentara', N'{"Id":10,"CommentText":"text za promenu kroz postman"}', CAST(N'2023-06-07T13:47:59.5455424' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (45, N'Anonymous', 0, N'Pretraga blogova', N'{"Keyword":"a","HasReactions":null,"PerPage":5,"Page":1}', CAST(N'2023-06-07T14:15:14.7456565' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (46, N'kevinPanter7', 19, N'Pretraga blogova', N'{"Keyword":"a","HasReactions":null,"PerPage":5,"Page":1}', CAST(N'2023-06-07T14:43:42.0262419' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (47, N'kevinPanter7', 19, N'Pretraga blogova', N'{"Keyword":"minamina","HasReactions":null,"PerPage":5,"Page":1}', CAST(N'2023-06-07T14:44:00.3095838' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (48, N'zachhh222', 21, N'Dohvatanje user po id', N'28', CAST(N'2023-06-07T15:02:52.5057286' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (49, N'zachhh222', 21, N'Dohvatanje taga po id', N'28', CAST(N'2023-06-07T15:05:34.6935696' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (50, N'kevinPanter7', 19, N'Dohvatanje taga po id', N'28', CAST(N'2023-06-07T15:14:32.3729317' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (51, N'Anonymous', 0, N'Registracija usera', N'{"Email":"proba@gmail.com","Password":"sifra1","Name":"Proba","Surname":"Probic","UserName":"Proba123!","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-08T12:09:22.2673153' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (52, N'Anonymous', 0, N'Registracija usera', N'{"Email":"proba@gmail.com","Password":"sifra1","Name":"Proba","Surname":"Probic","UserName":"Proba123!","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-08T12:10:52.4093287' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (53, N'Anonymous', 0, N'Registracija usera', N'{"Email":"proba@gmail.com","Password":"sifra1","Name":"Proba","Surname":"Probic","UserName":"Proba123!","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-08T12:41:40.5972533' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (54, N'Anonymous', 0, N'Registracija usera', N'{"Email":"proba123@gmail.com","Password":"sifra1123","Name":"Proba123","Surname":"Probic123","UserName":"Proba123123!","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-08T12:43:10.1136371' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (55, N'Anonymous', 0, N'Registracija usera', N'{"Email":"proba121231233@gmail.com","Password":"sifra1123123123","Name":"Proba12312312","Surname":"Probic1231231","UserName":"Proba123123!123123","ImageId":null,"ImageFileName":null}', CAST(N'2023-06-08T12:49:15.3691081' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (56, N'Anonymous', 0, N'Registracija usera', N'{"Email":"urosdjurdjevic@gmail.com","Password":"sifra123!","Name":"Uros","Surname":"Djurdjevic","UserName":"UkiGolgeter","ImageId":{"ContentDisposition":"form-data; name=\"ImageId\"; filename=\"3D_Funny_Bear_1600 x 1200.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"ImageId\"; filename=\"3D_Funny_Bear_1600 x 1200.jpg\""],"Content-Type":["image/jpeg"]},"Length":265062,"Name":"ImageId","FileName":"3D_Funny_Bear_1600 x 1200.jpg"},"ImageFileName":"a3531398-5947-49ea-bcb8-a4a2b85bb210.jpg"}', CAST(N'2023-06-08T12:56:38.0151923' AS DateTime2), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LogEntries] OFF
GO
SET IDENTITY_INSERT [dbo].[Reactions] ON 

INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (16, N'Wow', 52, CAST(N'2023-05-30T20:01:39.5456271' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (17, N'Thumb Down', 53, CAST(N'2023-05-30T20:01:39.5456304' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (18, N'Thumb Up', 54, CAST(N'2023-05-30T20:01:39.5456307' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (19, N'Smily', 55, CAST(N'2023-05-30T20:01:39.5456309' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (20, N'Hearth', 56, CAST(N'2023-05-30T20:01:39.5456311' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (21, N'nova reakcija', 52, CAST(N'2023-06-02T20:47:16.4533333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Reactions] ([Id], [ReactionName], [ImageID], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (22, N'reackija kroz postman', 52, CAST(N'2023-06-05T19:15:15.4433333' AS DateTime2), CAST(N'2023-06-05T17:19:36.8285089' AS DateTime2), NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Reactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (7, N'admin', CAST(N'2023-05-30T20:01:39.5449816' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Role] ([Id], [RoleName], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (8, N'user', CAST(N'2023-05-30T20:01:39.5450362' AS DateTime2), NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Role] ([Id], [RoleName], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (9, N'nova Rola', CAST(N'2023-06-02T20:08:57.9866667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Role] ([Id], [RoleName], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (10, N'rola kroz postman', CAST(N'2023-06-05T17:17:19.5900000' AS DateTime2), CAST(N'2023-06-05T15:19:21.6386964' AS DateTime2), NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 2)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 3)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 4)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 5)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 6)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 7)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 8)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 9)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 12)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 14)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 29)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (7, 32)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 29)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 30)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseacaseId]) VALUES (8, 31)
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (28, N'#th7', CAST(N'2023-05-30T20:01:39.5451790' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (29, N'#grobari', CAST(N'2023-05-30T20:01:39.5451806' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (30, N'#lol', CAST(N'2023-05-30T20:01:39.5451808' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (31, N'#lmao', CAST(N'2023-05-30T20:01:39.5451809' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (32, N'#basket', CAST(N'2023-05-30T20:01:39.5451810' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (33, N'#3x3', CAST(N'2023-05-30T20:01:39.5451818' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (34, N'#nuggets', CAST(N'2023-05-30T20:01:39.5451819' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (35, N'#nba', CAST(N'2023-05-30T20:01:39.5451820' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (36, N'#joker', CAST(N'2023-05-30T20:01:39.5451820' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (37, N'#noviTag', CAST(N'2023-06-02T20:26:41.6533333' AS DateTime2), NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (38, N'novi tagaasasd', CAST(N'2023-06-05T14:24:06.2666667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (40, N'najnoviji tag', CAST(N'2023-06-05T15:28:24.3833333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Tags] ([Id], [TagText], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (45, N'najnoviji tag as', CAST(N'2023-06-05T15:46:40.3266667' AS DateTime2), CAST(N'2023-06-05T14:38:31.2775951' AS DateTime2), NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (19, N'Kevin', N'Panter', N'kevinpan@gmail.com', N'sifra1', N'kevinPanter7', 43, 7, CAST(N'2023-05-30T20:01:39.5461490' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (20, N'Zdravko', N'Smiljanic', N'smiljanic2620@ict.edu.rs', N'sifra1', N'zsmiljanic', 44, 7, CAST(N'2023-05-30T20:01:39.5461519' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (21, N'Zach', N'Ledey', N'zach@outlook.com', N'sifra1', N'zachhh222', NULL, 8, CAST(N'2023-05-30T20:01:39.5461567' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (22, N'Mina', N'Pasesnik', N'minaaaaa@gmail.com', N'sifra1', N'minamina', 45, 8, CAST(N'2023-05-30T20:01:39.5461572' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (23, N'Zeljko', N'Obradovic', N'zeljko.obr@gmail.com', N'sifra1', N'zoc9', NULL, 8, CAST(N'2023-05-30T20:01:39.5461575' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (24, N'Isidora', N'Smiljanic', N'isidora98@gmail.com', N'sifra1', N'isidoraSmiljaniccc', NULL, 7, CAST(N'2023-05-30T20:01:39.5461582' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (34, N'Vesna', N'Smiljanic', N'vesn@gmail.com', N'novaSifra', N'vesna1971', NULL, 7, CAST(N'2023-06-02T22:36:37.8766667' AS DateTime2), NULL, NULL, 0, CAST(N'2023-06-03T19:43:17.4071219' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (41, N'Zdravko', N'Smiljanic', N'zdravce@gmail.com', N'$2a$11$D6QdPzs07SdAZ1mbKdP.aOeWIHvLEY2KjDIVOWlW8A6MADZ2HkHlq', N'usreeerere', NULL, 7, CAST(N'2023-06-04T15:37:21.8166667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (42, N'Milos', N'Smiljanic', N'smiljanic070201@gmail.com', N'$2a$11$4Gp1Ou1nkcGN4Zo5C4o3COtZZzLTu7d20WH1UcwG2wLtmMZUQsXNu', N'isidavko', NULL, 7, CAST(N'2023-06-04T18:04:33.9333333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (43, N'Ricardo', N'Gomes', N'riki@gmail.com', N'$2a$11$TgUHjpd.yFZ9YDY/fBCX0uTb3BZJSFVLv4dIyAalbwwtoXoBSsP6G', N'riki123', NULL, 7, CAST(N'2023-06-07T15:16:35.1533333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (45, N'MItar', N'Miric', N'mitarNoviProrilf@gmail.com', N'$2a$11$yPGN/9TLii5gh7Ggaw0N1egj7CzsHfOLCsBPHwJc6TGA.8X1UijB6', N'mitar', NULL, 7, CAST(N'2023-06-07T15:20:09.9400000' AS DateTime2), NULL, NULL, 1, CAST(N'2023-06-07T13:43:46.3627086' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (46, N'Lepa', N'Lukic', N'lepa@gmail.com', N'$2a$11$ro1y4bkU3k43c3QpZoTXM.Y53jD0uJufztHpepqK4VPQ38ZUjn3tS', N'Lepa123', NULL, 7, CAST(N'2023-06-07T15:27:17.4900000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (47, N'Proba', N'Probic', N'proba@gmail.com', N'$2b$10$OlUg5RAtkO6hhp/cQFGWEeN1j4kb6ELQmTKy7olhs7MYFw3pPGCg.', N'Proba123!', NULL, 7, CAST(N'2023-06-08T14:10:57.3233333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (48, N'Proba123', N'Probic123', N'proba123@gmail.com', N'$2b$10$g0eMZxtkzKzqo1uvRlWhV.V32W8.8yJvTfkrRM7od2GiSrxtcPGHC', N'Proba123123!', NULL, 7, CAST(N'2023-06-08T14:43:11.8366667' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (49, N'Proba12312312', N'Probic1231231', N'proba121231233@gmail.com', N'$2b$10$7YRkkGM8XtIcKy3zmSN87O35lrQZiKpQxDOwag5N0z2zR7QrpJP9a', N'Proba123123!123123', NULL, 7, CAST(N'2023-06-08T14:49:19.5500000' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [UserName], [ProfileImgId], [RoleId], [CreatedAt], [DeletedAt], [DeletedBy], [IsActive], [ModifiedAt], [ModifiedBy]) VALUES (50, N'Uros', N'Djurdjevic', N'urosdjurdjevic@gmail.com', N'$2b$10$b6iwzrJPrECU.LaHdDunLuAmLww8JNzyqxb0GIrlFwUtQHWbQbAz6', N'UkiGolgeter', 60, 7, CAST(N'2023-06-08T14:56:43.3833333' AS DateTime2), NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_BlogImages_ImageId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_BlogImages_ImageId] ON [dbo].[BlogImages]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogReactions_BlogId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_BlogReactions_BlogId] ON [dbo].[BlogReactions]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogReactions_UserId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_BlogReactions_UserId] ON [dbo].[BlogReactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Blogs_BlogText]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_BlogText] ON [dbo].[Blogs]
(
	[BlogText] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Blogs_UserId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_UserId] ON [dbo].[Blogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogTags_TagId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_BlogTags_TagId] ON [dbo].[BlogTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_BlogId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_BlogId] ON [dbo].[Comments]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_ParentId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_ParentId] ON [dbo].[Comments]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comments_TextComment]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_TextComment] ON [dbo].[Comments]
(
	[TextComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Images_ImagePath]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Images_ImagePath] ON [dbo].[Images]
(
	[ImagePath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reactions_ImageID]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Reactions_ImageID] ON [dbo].[Reactions]
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reactions_ReactionName]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Reactions_ReactionName] ON [dbo].[Reactions]
(
	[ReactionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Role_RoleName]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Role_RoleName] ON [dbo].[Role]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tags_TagText]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tags_TagText] ON [dbo].[Tags]
(
	[TagText] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_ProfileImgId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Users_ProfileImgId] ON [dbo].[Users]
(
	[ProfileImgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_UserName]    Script Date: 8.6.2023. 15:24:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blogs] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Blogs] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CommentedAt]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Images] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Images] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Reactions] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Reactions] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Tags] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Tags] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[BlogImages]  WITH CHECK ADD  CONSTRAINT [FK_BlogImages_Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogImages] CHECK CONSTRAINT [FK_BlogImages_Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogImages]  WITH CHECK ADD  CONSTRAINT [FK_BlogImages_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[BlogImages] CHECK CONSTRAINT [FK_BlogImages_Images_ImageId]
GO
ALTER TABLE [dbo].[BlogReactions]  WITH CHECK ADD  CONSTRAINT [FK_BlogReactions_Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogReactions] CHECK CONSTRAINT [FK_BlogReactions_Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogReactions]  WITH CHECK ADD  CONSTRAINT [FK_BlogReactions_Reactions_ReactionId] FOREIGN KEY([ReactionId])
REFERENCES [dbo].[Reactions] ([Id])
GO
ALTER TABLE [dbo].[BlogReactions] CHECK CONSTRAINT [FK_BlogReactions_Reactions_ReactionId]
GO
ALTER TABLE [dbo].[BlogReactions]  WITH CHECK ADD  CONSTRAINT [FK_BlogReactions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BlogReactions] CHECK CONSTRAINT [FK_BlogReactions_Users_UserId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Users_UserId]
GO
ALTER TABLE [dbo].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogTags] CHECK CONSTRAINT [FK_BlogTags_Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[BlogTags] CHECK CONSTRAINT [FK_BlogTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Blogs_BlogId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Comments_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Comments_ParentId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Reactions]  WITH CHECK ADD  CONSTRAINT [FK_Reactions_Images_ImageID] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reactions] CHECK CONSTRAINT [FK_Reactions_Images_ImageID]
GO
ALTER TABLE [dbo].[RoleUseCases]  WITH CHECK ADD  CONSTRAINT [FK_RoleUseCases_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUseCases] CHECK CONSTRAINT [FK_RoleUseCases_Role_RoleId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Images_ProfileImgId] FOREIGN KEY([ProfileImgId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Images_ProfileImgId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role_RoleId]
GO
USE [master]
GO
ALTER DATABASE [projekat_blog] SET  READ_WRITE 
GO
