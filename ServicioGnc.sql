USE [master]
GO
/****** Object:  Database [ServicioGnc]    Script Date: 01/11/2014 11:27:20 ******/
CREATE DATABASE [ServicioGnc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServicioGnc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.CJZILMAN\MSSQL\DATA\ServicioGnc.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ServicioGnc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.CJZILMAN\MSSQL\DATA\ServicioGnc_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ServicioGnc] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServicioGnc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServicioGnc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServicioGnc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServicioGnc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServicioGnc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServicioGnc] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServicioGnc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServicioGnc] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ServicioGnc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServicioGnc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServicioGnc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServicioGnc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServicioGnc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServicioGnc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServicioGnc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServicioGnc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServicioGnc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServicioGnc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServicioGnc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServicioGnc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServicioGnc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServicioGnc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServicioGnc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServicioGnc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServicioGnc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServicioGnc] SET  MULTI_USER 
GO
ALTER DATABASE [ServicioGnc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServicioGnc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServicioGnc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServicioGnc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ServicioGnc]
GO
/****** Object:  Table [dbo].[AsignacionTurno]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AsignacionTurno](
	[AsignacionTurnoId] [int] IDENTITY(1,1) NOT NULL,
	[TurnoId] [int] NULL,
	[PersonaId] [int] NULL,
	[Observacion] [varchar](150) NULL,
 CONSTRAINT [PK_AsignacionTurno] PRIMARY KEY CLUSTERED 
(
	[AsignacionTurnoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Domicilio] [varchar](150) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[Fecha] [date] NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Concepto](
	[ConceptoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Porcentaje] [float] NULL,
	[Importe] [float] NULL,
	[Utilidad] [int] NULL,
	[TipoConceptoId] [int] NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[ConceptoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[DetalleCompraId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NULL,
	[CompraId] [int] NULL,
	[Precio] [float] NULL,
	[Subtotal] [float] NULL,
	[Cantidad] [nchar](10) NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[DetalleCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleLiquidacion]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleLiquidacion](
	[DetalleLiquidacionId] [int] IDENTITY(1,1) NOT NULL,
	[LiquidacionId] [int] NULL,
	[ConceptoId] [int] NULL,
	[SubTotal] [float] NULL,
 CONSTRAINT [PK_DetalleLiquidacion] PRIMARY KEY CLUSTERED 
(
	[DetalleLiquidacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleTurno]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleTurno](
	[DetalleTurnoId] [int] IDENTITY(1,1) NOT NULL,
	[HorarioId] [int] NULL,
	[Dia] [varchar](10) NULL,
	[TurnoId] [int] NULL,
 CONSTRAINT [PK_DetalleTurno] PRIMARY KEY CLUSTERED 
(
	[DetalleTurnoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[DetalleVentaId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NULL,
	[VentaId] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [float] NULL,
	[Subtotal] [float] NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[DetalleVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[EmpresaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cuit] [varchar](13) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[EmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fichada]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fichada](
	[FichadaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaEgreso] [datetime] NULL,
	[PersonaId] [int] NULL,
	[Observacion] [varchar](250) NULL,
 CONSTRAINT [PK_Fichada] PRIMARY KEY CLUSTERED 
(
	[FichadaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Horario](
	[HorarioId] [int] IDENTITY(1,1) NOT NULL,
	[ComienzoTurno] [varchar](50) NULL,
	[FinalTurno] [varchar](50) NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[HorarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LecturaPresionTemperatura]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LecturaPresionTemperatura](
	[LecturaPresionTemperaturaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Presion] [float] NULL,
	[Temperatura] [float] NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_LecturaPresionTemperatura] PRIMARY KEY CLUSTERED 
(
	[LecturaPresionTemperaturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Liquidacion]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Liquidacion](
	[LiquidacionId] [int] IDENTITY(1,1) NOT NULL,
	[PersonaId] [int] NULL,
	[EmpresaId] [int] NULL,
	[Total] [float] NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_Liquidacion] PRIMARY KEY CLUSTERED 
(
	[LiquidacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[RolId] [int] NULL,
	[Apellido] [varchar](50) NULL,
	[Domicilio] [varchar](250) NULL,
	[FechaNacimiento] [date] NULL,
	[FechaEgreso] [date] NULL,
	[FechaIngreso] [date] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](80) NULL,
	[PrecioCompra] [float] NULL,
	[UnidadId] [int] NULL,
	[PrecioVenta] [float] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](85) NULL,
	[CUIT] [varchar](13) NULL,
	[Domicilio] [varchar](250) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoConcepto]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoConcepto](
	[TipoConceptoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
 CONSTRAINT [PK_TipoConcepto] PRIMARY KEY CLUSTERED 
(
	[TipoConceptoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turno](
	[TurnoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[TurnoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unidad](
	[UnidadId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[UnidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 01/11/2014 11:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Total] [float] NULL,
	[ClienteId] [int] NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AsignacionTurno]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionTurno_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[AsignacionTurno] CHECK CONSTRAINT [FK_AsignacionTurno_Persona]
GO
ALTER TABLE [dbo].[AsignacionTurno]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionTurno_Turno] FOREIGN KEY([TurnoId])
REFERENCES [dbo].[Turno] ([TurnoId])
GO
ALTER TABLE [dbo].[AsignacionTurno] CHECK CONSTRAINT [FK_AsignacionTurno_Turno]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([ProveedorId])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Proveedor]
GO
ALTER TABLE [dbo].[Concepto]  WITH CHECK ADD  CONSTRAINT [FK_Concepto_TipoConcepto] FOREIGN KEY([TipoConceptoId])
REFERENCES [dbo].[TipoConcepto] ([TipoConceptoId])
GO
ALTER TABLE [dbo].[Concepto] CHECK CONSTRAINT [FK_Concepto_TipoConcepto]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Compra] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compra] ([CompraId])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Compra]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Producto]
GO
ALTER TABLE [dbo].[DetalleLiquidacion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleLiquidacion_Concepto] FOREIGN KEY([ConceptoId])
REFERENCES [dbo].[Concepto] ([ConceptoId])
GO
ALTER TABLE [dbo].[DetalleLiquidacion] CHECK CONSTRAINT [FK_DetalleLiquidacion_Concepto]
GO
ALTER TABLE [dbo].[DetalleLiquidacion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleLiquidacion_Liquidacion] FOREIGN KEY([LiquidacionId])
REFERENCES [dbo].[Liquidacion] ([LiquidacionId])
GO
ALTER TABLE [dbo].[DetalleLiquidacion] CHECK CONSTRAINT [FK_DetalleLiquidacion_Liquidacion]
GO
ALTER TABLE [dbo].[DetalleTurno]  WITH CHECK ADD  CONSTRAINT [FK_DetalleTurno_Horario] FOREIGN KEY([HorarioId])
REFERENCES [dbo].[Horario] ([HorarioId])
GO
ALTER TABLE [dbo].[DetalleTurno] CHECK CONSTRAINT [FK_DetalleTurno_Horario]
GO
ALTER TABLE [dbo].[DetalleTurno]  WITH CHECK ADD  CONSTRAINT [FK_DetalleTurno_Turno] FOREIGN KEY([TurnoId])
REFERENCES [dbo].[Turno] ([TurnoId])
GO
ALTER TABLE [dbo].[DetalleTurno] CHECK CONSTRAINT [FK_DetalleTurno_Turno]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Producto]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([VentaId])
REFERENCES [dbo].[Venta] ([VentaId])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Venta]
GO
ALTER TABLE [dbo].[Fichada]  WITH CHECK ADD  CONSTRAINT [FK_Fichada_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[Fichada] CHECK CONSTRAINT [FK_Fichada_Persona]
GO
ALTER TABLE [dbo].[Liquidacion]  WITH CHECK ADD  CONSTRAINT [FK_Liquidacion_Empresa] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresa] ([EmpresaId])
GO
ALTER TABLE [dbo].[Liquidacion] CHECK CONSTRAINT [FK_Liquidacion_Empresa]
GO
ALTER TABLE [dbo].[Liquidacion]  WITH CHECK ADD  CONSTRAINT [FK_Liquidacion_Persona] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Persona] ([PersonaId])
GO
ALTER TABLE [dbo].[Liquidacion] CHECK CONSTRAINT [FK_Liquidacion_Persona]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Rol] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([RolId])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Rol]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Unidad] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[Unidad] ([UnidadId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Unidad]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
USE [master]
GO
ALTER DATABASE [ServicioGnc] SET  READ_WRITE 
GO
