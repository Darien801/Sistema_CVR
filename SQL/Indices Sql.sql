
USE [SistemaCVR]
GO
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO

--filtrado por fecha
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_venta_fecha' AND object_id = OBJECT_ID(N'dbo.venta'))
    CREATE NONCLUSTERED INDEX [IX_venta_fecha] ON [dbo].[venta] ([fecha] DESC);
GO

-- Un mismo vehículo no puede tener dos ventas vigentes a la vez
--evita doble venta si dos equipos guardan al mismo tiempo; las ventas 'Cancelada' no cuenta
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_venta_vehiculo_vigente' AND object_id = OBJECT_ID(N'dbo.venta'))
    CREATE UNIQUE NONCLUSTERED INDEX [UX_venta_vehiculo_vigente] ON [dbo].[venta] ([id_vehiculo])
    WHERE ([estadoVenta] <> N'Cancelada');
GO

-- Rentas activas y consulta por vehículo/fechas
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_renta_estado_fechas' AND object_id = OBJECT_ID(N'dbo.renta'))
    CREATE NONCLUSTERED INDEX [IX_renta_estado_fechas] ON [dbo].[renta] ([estadoRenta], [fecha_inicio], [fecha_fin]);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_renta_vehiculo' AND object_id = OBJECT_ID(N'dbo.renta'))
    CREATE NONCLUSTERED INDEX [IX_renta_vehiculo] ON [dbo].[renta] ([id_vehiculo]);
GO