USE [master]
GO
/****** Object:  Database [Seguridad]    Script Date: 16/11/2014 16:09:35 ******/
CREATE DATABASE [Seguridad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Seguridad', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.CJZILMAN\MSSQL\DATA\Seguridad.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Seguridad_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.CJZILMAN\MSSQL\DATA\Seguridad_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Seguridad] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Seguridad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Seguridad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Seguridad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Seguridad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Seguridad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Seguridad] SET ARITHABORT OFF 
GO
ALTER DATABASE [Seguridad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Seguridad] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Seguridad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Seguridad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Seguridad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Seguridad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Seguridad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Seguridad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Seguridad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Seguridad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Seguridad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Seguridad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Seguridad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Seguridad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Seguridad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Seguridad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Seguridad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Seguridad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Seguridad] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Seguridad] SET  MULTI_USER 
GO
ALTER DATABASE [Seguridad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Seguridad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Seguridad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Seguridad] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Seguridad]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 16/11/2014 16:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
	[Name] [varchar](150) NULL,
	[Surname] [varchar](150) NULL,
	[Age] [int] NULL,
	[Birthday] [datetime] NULL,
	[Email] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 16/11/2014 16:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 16/11/2014 16:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 16/11/2014 16:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 16/11/2014 16:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__webpages__AF2760ADF3C6C9A8] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (1, N'zilman', NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (2, N'julio', N'Julio ', N'Julio', 12, CAST(0x0000A363000B63A0 AS DateTime), N'name@gmail.com')
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (3, N'koki', N'koki', N'koki', 0, CAST(0x0000A3630186C3F0 AS DateTime), N'name@gmail.com')
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (4, N'emanual', N'emanual', N'ASS', 12, CAST(0x0000A3710158C9A0 AS DateTime), N'testemanual@gmail.com')
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (5, N'super', N'super', N'super', 16, CAST(0x0000A3710159EB14 AS DateTime), N'name@gmail.com')
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (6, N'adminconstanciadelvalle', N'admin', N'admin', 13, CAST(0x0000A39301719480 AS DateTime), N'name@gmail.com')
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (7, N'mauri', NULL, NULL, 0, CAST(0x0000000000000000 AS DateTime), NULL)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (8, N'mauri2', NULL, NULL, 0, CAST(0x0000000000000000 AS DateTime), NULL)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [Name], [Surname], [Age], [Birthday], [Email]) VALUES (9, N'juliozilman', N'juliozilman', N'julio', 12, CAST(0x0000A3E50102B808 AS DateTime), N'name@gmail.com')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A363003C8DC2 AS DateTime), NULL, 1, NULL, 0, N'AN8U4Qd6Yphiiiz+3oDTtCxQPgeWaUnnU9BddVeVOAsxHz7BiFpoWUDJqGyeXOKKAw==', CAST(0x0000A363003C8DC2 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(0x0000A363003D59DF AS DateTime), NULL, 1, NULL, 0, N'AJ/6Olvhctv5v9CtR/scvTlKmRU1gihcqLJHUtZXmmswXucFjI0M2CRd+ZPUh1Hijg==', CAST(0x0000A363003D59DF AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(0x0000A364002CC6C7 AS DateTime), NULL, 1, CAST(0x0000A37501889278 AS DateTime), 0, N'AEUgnPCqohj/T22R7qUaZc6TD8U5KEylFBAa6Lu6NAfo39tMFN+mbQnoJ5VVRavHGw==', CAST(0x0000A364002CC6C7 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (4, CAST(0x0000A371018A8AEE AS DateTime), NULL, 1, NULL, 0, N'AKYwTdeB9QO/DElrHi8HErcADlmluDcB3/hu1BJBGBfIUyil/QGLblOfhLMprJ+rqQ==', CAST(0x0000A371018A8AEE AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (5, CAST(0x0000A37200000B77 AS DateTime), NULL, 1, NULL, 0, N'ABrq5DkZoIXILwcFa6EWfLt/g6L1P1+p0eE7wnoRGHo6VaPuKuShAMBzXfqsLomhBA==', CAST(0x0000A37200000B77 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (6, CAST(0x0000A3940017F813 AS DateTime), NULL, 1, NULL, 0, N'AJF7BVJapkbLbzLYA4TD0enFBpAh9wz4zVBQyXmh+6BB+tfXuEkiDIp0BqU2hhiu/A==', CAST(0x0000A3940017F813 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (7, CAST(0x0000A3E501329134 AS DateTime), NULL, 1, NULL, 0, N'AEmFQ3D3Q7mwTnMbgpMIAKSSePjjb5ieiTll3/KREarU8nGL4BZgAzEW1R/U9HULnw==', CAST(0x0000A3E501329134 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (8, CAST(0x0000A3E5013350A2 AS DateTime), NULL, 1, NULL, 0, N'AAfcHcKTd01g/dYphwWw+e49fm8hJX4ZRJ9d6H8A7Op8+V7EvDtwh/dk4mr9G//kHg==', CAST(0x0000A3E5013350A2 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (9, CAST(0x0000A3E5013469CE AS DateTime), NULL, 1, NULL, 0, N'AONIr3cXZW+wsdodAI+d3jLaHjPQt1n/SRsRYL3p6LnEqSSNQfAB18ky4FB7xvOjkA==', CAST(0x0000A3E5013469CE AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'administrador')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'empleado')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'negocio')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'visitante')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
SET IDENTITY_INSERT [dbo].[webpages_UsersInRoles] ON 

INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (2, 2, 1)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (3, 1, 2)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (4, 2, 3)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (5, 2, 4)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (6, 1, 5)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId], [UserRoleId]) VALUES (9, 1, 8)
SET IDENTITY_INSERT [dbo].[webpages_UsersInRoles] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F284564CA394FD]    Script Date: 16/11/2014 16:09:36 ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B61605CA6BB0F]    Script Date: 16/11/2014 16:09:36 ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_Age]  DEFAULT ((0)) FOR [Age]
GO
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_Birthday]  DEFAULT (((1)/(1))/(2001)) FOR [Birthday]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
USE [master]
GO
ALTER DATABASE [Seguridad] SET  READ_WRITE 
GO
