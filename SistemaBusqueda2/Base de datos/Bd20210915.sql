USE [sistemaBusqueda2]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 15-09-2021 21:41:02 ******/
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
SET IDENTITY_INSERT [dbo].[roles] ON 
GO
INSERT [dbo].[roles] ([id], [nombre]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[roles] ([id], [nombre]) VALUES (2, N'Supervisor')
GO
INSERT [dbo].[roles] ([id], [nombre]) VALUES (3, N'Vendedor')
GO
INSERT [dbo].[roles] ([id], [nombre]) VALUES (4, N'Supervisor ventas')
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([id], [nombres], [apellidos], [rolId], [nombreUsuario], [password]) VALUES (1, N'Hans', N'Lopez', 1, N'hlopez', 0x020000004DB4AE6C6B74117AE0B1D4667304DD55FA81052187EAC3F0139494D254E08423FA04BEE1E2CD744BE1CDD1D2897B33C1)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles] FOREIGN KEY([rolId])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_roles]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualiza_usuario]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_actualiza_usuario]
@id int,
@nombres varchar(50),
@apellidos varchar(50),
@rolId int
as
update usuarios set 
nombres = @nombres,
apellidos = @apellidos,
rolId = @rolId
where id= @id 
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_password]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_actualizar_password]
@id int, 
@password varchar(50)
as
update usuarios set password = ENCRYPTBYPASSPHRASE('sistemabusqueda2021!!',@password) 
where id=@id 
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_rol]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_actualizar_rol]
@id int,
@nombre varchar(50)
as
update roles set nombre = @nombre
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_check_nombre_usuario]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_check_nombre_usuario] @nombreUsuario varchar(50)
as
select count(*) from usuarios
where nombreUsuario=@nombreUsuario
GO
/****** Object:  StoredProcedure [dbo].[sp_check_usuario]    Script Date: 15-09-2021 21:41:02 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_eliminar_rol]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_eliminar_rol]
@id int
as
delete roles
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_usuario]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_eliminar_usuario]
@id int
as
delete usuarios 
where id=@id
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_rol]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insertar_rol]
@nombre varchar(50)
as
insert into roles(nombre)
values(@nombre)
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_usuario]    Script Date: 15-09-2021 21:41:02 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_mostrar_roles]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_mostrar_roles]
as
select id,nombre from roles
GO
/****** Object:  StoredProcedure [dbo].[sp_mostrar_usuarios]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_mostrar_usuarios]
as
select id,nombreUsuario,nombres,apellidos, rolId 
from usuarios
GO
/****** Object:  StoredProcedure [dbo].[sp_obtener_usuario_por_id]    Script Date: 15-09-2021 21:41:02 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_obtiene_rol_por_id]    Script Date: 15-09-2021 21:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtiene_rol_por_id]
@id int
as
select id, nombre from roles
where id= @id
GO
