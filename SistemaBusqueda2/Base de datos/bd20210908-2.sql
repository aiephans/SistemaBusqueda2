USE [sistemaBusqueda2]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[rolId] [int] NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[password] [varbinary](100) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (1, N'Hans', N'Lopez', 1, N'hlopez', 0x020000004DB4AE6C6B74117AE0B1D4667304DD55FA81052187EAC3F0139494D254E08423FA04BEE1E2CD744BE1CDD1D2897B33C1)
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (2, N'Felipe', N'Diaz', 2, N'fdiaz', 0x02000000B2ADC10731219BAEC31F2FF727C926A0B27D088B33ECF59C47D937D0694675C234591AC7B9E1CA544FC098C41F1DD24E)
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (3, N'Francisca', N'Soto', 3, N'fsoto', 0x02000000321D315164B7AC225E7D0F1288700817C38828E93BE3CF324F828B636070FAE659AC133A7C4F43D46DD7EFDAAF9DC516)
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (4, N'Boris', N'Alarcon', 1, N'balarcon', 0x02000000041DC1DF2CFD1432366B22B61BA2E079DB0BB370AF399AF2C4EBC5672598E0B5F6E6C813687096F103196E84917FBF37)
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (5, N'Carla', N'Arriagada', 3, N'carriagada', 0x020000002FA6491C2412405DF6D4600769A6F2A8A735249F20804101FAA36C2910E9E6D4626849F1B546BBB689070CD9A9787730)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_check_nombre_usuario]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_check_nombre_usuario] @nombreUsuario varchar(50)
as
select count(*) from usuarios
where nombreUsuario=@nombreUsuario
GO
/****** Object:  StoredProcedure [dbo].[sp_check_usuario]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_check_usuario] @nombreUsuario varchar(50), @password varchar(50)
as
select count(*) from usuarios
where nombreUsuario=@nombreUsuario and 
convert(varchar(50),DECRYPTBYPASSPHRASE('sistemabusqueda2021!!',password))=@password
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_usuario]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insertar_usuario]
@nombres varchar(50),
@apellidos varchar(50),
@rolId int,
@nombreUsuario varchar(50),
@password varchar(50)
as
insert into usuarios (nombres, apellidos,rolId,nombreUsuario,password)
values
(
@nombres,
@apellidos,
@rolId,
@nombreUsuario,
ENCRYPTBYPASSPHRASE('sistemabusqueda2021!!',@password) 
)
GO
/****** Object:  StoredProcedure [dbo].[sp_mostrar_usuarios]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_mostrar_usuarios]
as
select id,nombreUsuario,nombres,apellidos, rolId 
from usuarios
GO
/****** Object:  StoredProcedure [dbo].[sp_obtener_usuario_por_id]    Script Date: 08-09-2021 21:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtener_usuario_por_id] @id int
as
select 
id,
nombres,
apellidos,
rolId,
nombreUsuario,
convert(varchar(50),DECRYPTBYPASSPHRASE('sistemabusqueda2021!!',password)) as password
from usuarios
where id=@id
GO
