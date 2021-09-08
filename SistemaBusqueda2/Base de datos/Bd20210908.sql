USE [sistemaBusqueda2]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 08-09-2021 11:02:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([id], [nombreUsuario], [password]) VALUES (1, N'admin', N'123456')
GO
INSERT [dbo].[usuarios] ([id], [nombreUsuario], [password]) VALUES (2, N'jperez', N'654321')
GO
INSERT [dbo].[usuarios] ([id], [nombreUsuario], [password]) VALUES (3, N'amunoz', N'123123')
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_check_usuario]    Script Date: 08-09-2021 11:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_check_usuario] @nombreUsuario varchar(50), @password varchar(50)
as
select count(*) from usuarios
where nombreUsuario=@nombreUsuario and password=@password
GO
