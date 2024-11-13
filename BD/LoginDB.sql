--CREATE DATABASE MD_LOGIN

USE [MD_LOGIN]
GO

/****** Object:  Table [dbo].[Compania]    Script Date: 2/11/2024 14:22:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Compania](
	[CompaniaID] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompania] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](255) NULL,
	[Email] [nvarchar](100) NULL,
	[Telefono] [nvarchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [bit] NULL,
	[UrlDestino] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompaniaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Compania] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[Compania] ADD  DEFAULT ((1)) FOR [Estado]
GO


/****** Object:  Table [dbo].[Usuario]    Script Date: 2/11/2024 14:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CompaniaID] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [bit] NULL,
	[PasswordSalt] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Estado]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([CompaniaID])
REFERENCES [dbo].[Compania] ([CompaniaID])
GO

CREATE TABLE [dbo].[Sesion](
	[SesionID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[TokenSesion] [nvarchar](255) NOT NULL,
	[EstadoSesion] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SesionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sesion] ADD  DEFAULT (getdate()) FOR [FechaInicio]
GO

ALTER TABLE [dbo].[Sesion] ADD  DEFAULT ((1)) FOR [EstadoSesion]
GO

ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO

/****** Object:  Table [dbo].[Rol]    Script Date: 2/11/2024 14:21:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rol](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](50) NOT NULL,
	[Descripción] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Permiso]    Script Date: 2/11/2024 14:21:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permiso](
	[PermisoID] [int] IDENTITY(1,1) NOT NULL,
	[NombrePermiso] [nvarchar](50) NOT NULL,
	[DescripciónPermiso] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LogActividad]    Script Date: 2/11/2024 14:22:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogActividad](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[FechaActividad] [datetime] NULL,
	[TipoActividad] [nvarchar](50) NOT NULL,
	[DescripciónActividad] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogActividad] ADD  DEFAULT (getdate()) FOR [FechaActividad]
GO

ALTER TABLE [dbo].[LogActividad]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO

/****** Object:  Table [dbo].[RolPermiso]    Script Date: 2/11/2024 14:23:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RolPermiso](
	[RolPermisoID] [int] IDENTITY(1,1) NOT NULL,
	[RolID] [int] NOT NULL,
	[PermisoID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolPermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RolPermiso]  WITH CHECK ADD FOREIGN KEY([PermisoID])
REFERENCES [dbo].[Permiso] ([PermisoID])
GO

ALTER TABLE [dbo].[RolPermiso]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([RolID])
GO

/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 2/11/2024 14:23:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuarioRol](
	[UsuarioRolID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[RolID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioRolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([RolID])
GO

ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO



--INSERT
  INSERT INTO [dbo].[Rol] VALUES ('Alumno', 'Usuario Alumno'),
								('Docente', 'Usuario Docente')


INSERT INTO [MD_LOGIN].[dbo].[Permiso] (NombrePermiso, DescripciónPermiso)
VALUES 
    ('Acceso_App', 'Permite el acceso general a la aplicación.'),
    ('Gestionar_Usuarios', 'Permite crear, editar y eliminar usuarios.'),
    ('Gestionar_Compañias', 'Permite crear, editar y eliminar compañías.'),
    ('Gestionar_Roles', 'Permite crear, editar y eliminar roles.'),
    ('Ver_LogActividades', 'Permite acceder a los logs de actividad del sistema.'),
    ('Cerrar_Sesiones', 'Permite cerrar sesiones activas de otros usuarios.'),
    ('Cambiar_Contraseña', 'Permite al usuario cambiar su propia contraseña.'),
    ('Acceso_Soporte', 'Permite al usuario acceder a herramientas de soporte técnico.');


INSERT INTO [MD_LOGIN].[dbo].[Compania] (NombreCompania, Direccion, Email, Telefono, FechaCreacion, Estado, UrlDestino)
VALUES 
    ('Tpi', 'UTN', 'm@m.com', '3513535353', '2024-10-27 16:09:12.977', 1, 'http://127.0.0.1:5500/');
