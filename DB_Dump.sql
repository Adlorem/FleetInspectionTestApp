USE [master]
GO
/****** Object:  Database [Fleet]    Script Date: 23.06.2022 23:53:29 ******/
CREATE DATABASE [Fleet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fleet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Fleet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fleet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Fleet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Fleet] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fleet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fleet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fleet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fleet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fleet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fleet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fleet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fleet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fleet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fleet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fleet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fleet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fleet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fleet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fleet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fleet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fleet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fleet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fleet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fleet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fleet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fleet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fleet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fleet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fleet] SET  MULTI_USER 
GO
ALTER DATABASE [Fleet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fleet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fleet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fleet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fleet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fleet] SET QUERY_STORE = OFF
GO
USE [Fleet]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [nvarchar](9) NOT NULL,
	[MakeId] [int] NOT NULL,
	[ModelId] [int] NOT NULL,
	[Image] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleInspections]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleInspections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[CheckDate] [date] NULL,
	[NextCheckDate] [date] NULL,
	[IsCheckPassed] [bit] NOT NULL,
 CONSTRAINT [PK_VehicleInspections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleMakes]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleMakes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MakeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VehicleMakes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModels]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MakeId] [int] NOT NULL,
	[ModelName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VehicleModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 
GO
INSERT [dbo].[Vehicle] ([Id], [Identifier], [MakeId], [ModelId], [Image]) VALUES (1, N'SK835PG', 1, 1, N'https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Ford_Focus_RS_Mk_III_2015_001.jpg/640px-Ford_Focus_RS_Mk_III_2015_001.jpg')
GO
INSERT [dbo].[Vehicle] ([Id], [Identifier], [MakeId], [ModelId], [Image]) VALUES (2, N'WW456WN', 1, 2, N'https://bonpic.com/download_img.php?dimg=7866&raz=640x480')
GO
INSERT [dbo].[Vehicle] ([Id], [Identifier], [MakeId], [ModelId], [Image]) VALUES (3, N'PO5674T', 1, 3, N'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/2012_Ford_Mondeo_Titanium_sedan_%282012-10-26%29_01.jpg/640px-2012_Ford_Mondeo_Titanium_sedan_%282012-10-26%29_01.jpg')
GO
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleMakes] ON 
GO
INSERT [dbo].[VehicleMakes] ([Id], [MakeName]) VALUES (1, N'Ford')
GO
INSERT [dbo].[VehicleMakes] ([Id], [MakeName]) VALUES (2, N'Fiat')
GO
INSERT [dbo].[VehicleMakes] ([Id], [MakeName]) VALUES (3, N'Mercedes')
GO
SET IDENTITY_INSERT [dbo].[VehicleMakes] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleModels] ON 
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (1, 1, N'Focus')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (2, 1, N'Mustang')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (3, 1, N'Mondeo')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (4, 2, N'500')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (6, 2, N'Panda')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (8, 2, N'Tipo')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (9, 3, N'AMG GT')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (10, 3, N'CLA')
GO
INSERT [dbo].[VehicleModels] ([Id], [MakeId], [ModelName]) VALUES (11, 3, N'CLS')
GO
SET IDENTITY_INSERT [dbo].[VehicleModels] OFF
GO
/****** Object:  Index [IX_VehicleInspections]    Script Date: 23.06.2022 23:53:29 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleInspections] ON [dbo].[VehicleInspections]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Vehicle] FOREIGN KEY([Id])
REFERENCES [dbo].[Vehicle] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Vehicle]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleMakes] FOREIGN KEY([MakeId])
REFERENCES [dbo].[VehicleMakes] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleMakes]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleModels] FOREIGN KEY([ModelId])
REFERENCES [dbo].[VehicleModels] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleModels]
GO
ALTER TABLE [dbo].[VehicleInspections]  WITH CHECK ADD  CONSTRAINT [FK_VehicleInspections_Vehicle] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
ALTER TABLE [dbo].[VehicleInspections] CHECK CONSTRAINT [FK_VehicleInspections_Vehicle]
GO
ALTER TABLE [dbo].[VehicleModels]  WITH CHECK ADD  CONSTRAINT [FK_VehicleModels_VehicleMakes] FOREIGN KEY([MakeId])
REFERENCES [dbo].[VehicleMakes] ([Id])
GO
ALTER TABLE [dbo].[VehicleModels] CHECK CONSTRAINT [FK_VehicleModels_VehicleMakes]
GO
/****** Object:  StoredProcedure [dbo].[spVehicle_GetAll]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVehicle_GetAll]
@Search nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	veh.* 
	,make.[MakeName]
    ,model.[ModelName]
	,finsp.CheckDate AS [FirstCheckDate]
	,linsp.[CheckDate]
	,linsp.[NextCheckDate]
	,linsp.[IsCheckPassed]
	FROM [dbo].Vehicle veh
	JOIN [dbo].VehicleMakes make on make.[Id] = veh.[MakeId]
	JOIN [dbo].VehicleModels model on model.[Id] = veh.ModelId
	OUTER APPLY 
    (SELECT TOP 1 *
     FROM [dbo].VehicleInspections ins (NOLOCK)
     WHERE ins.VehicleId = veh.Id 
     ORDER BY ins.CheckDate DESC
    ) AS linsp
	OUTER APPLY 
    (SELECT TOP 1 *
     FROM [dbo].VehicleInspections ins (NOLOCK)
     WHERE ins.VehicleId = veh.Id 
     ORDER BY ins.CheckDate
    ) AS finsp
	WHERE   veh.[Identifier] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE veh.[Identifier]
			END
		OR  make.[MakeName] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE make.[MakeName]
			END
		OR model.[ModelName] LIKE CASE 
			WHEN @Search IS NOT NULL
				THEN '%' + @Search + '%'
			ELSE model.[ModelName]
			END

END
GO
/****** Object:  StoredProcedure [dbo].[spVehicleInspections_Insert]    Script Date: 23.06.2022 23:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spVehicleInspections_Insert]
  @VehicleId int
 ,@CheckDate date
 ,@NextCheckDate date
 ,@IsCheckPassed bit
AS
BEGIN
	SET NOCOUNT ON;

	insert into [dbo].VehicleInspections 
	(
        VehicleId
	   ,CheckDate
	   ,NextCheckDate
	   ,IsCheckPassed
	)
	values
	(
	    @VehicleId
	   ,@CheckDate
	   ,@NextCheckDate
	   ,@IsCheckPassed
	)

END
GO
USE [master]
GO
ALTER DATABASE [Fleet] SET  READ_WRITE 
GO
