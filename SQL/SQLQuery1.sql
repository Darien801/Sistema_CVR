CREATE DATABASE SistemaCVR;
GO

USE SistemaCVR;
GO

-- =============================================
-- 1. TABLA: empleado
-- =============================================
CREATE TABLE empleado (
    id_empleado INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_empleado PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    DUI VARCHAR(10) NOT NULL UNIQUE,
    hashEmpleado VARCHAR(250) NOT NULL,
    rolEmpleado VARCHAR(50) NOT NULL,
    estadoEmpleado NVARCHAR(50) NOT NULL
);
GO

-- =============================================
-- 2. TABLA: cliente
-- =============================================
CREATE TABLE cliente (
    id_cliente INT NOT NULL IDENTITY(1,1)  CONSTRAINT pk_id_cliente PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    DUI VARCHAR(10) NOT NULL UNIQUE,
    direccion NVARCHAR(250),
    telefono VARCHAR(20)
);
GO

-- =============================================
-- 3. TABLA: marca
-- =============================================
CREATE TABLE marca (
    id_marca INT NOT NULL IDENTITY(1,1)  CONSTRAINT pk_id_marca PRIMARY KEY,
    nombreMarca NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- =============================================
-- 4. TABLA: modelo
-- =============================================
CREATE TABLE modelo (
    id_modelo INT NOT NULL IDENTITY(1,1)  CONSTRAINT pk_id_modelo PRIMARY KEY,
    nombreModelo VARCHAR(100) NOT NULL
);
GO

-- =============================================
-- 5. TABLA: estado
-- =============================================
CREATE TABLE estado (
    id_estado INT NOT NULL IDENTITY(1,1)  CONSTRAINT pk_id_estado PRIMARY KEY,
    nombreEstado VARCHAR(50) NOT NULL UNIQUE
);
GO

-- =============================================
-- 6. TABLA: compra
-- =============================================
CREATE TABLE compra (
    id_compra INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_compra PRIMARY KEY,
    id_empleado INT NOT NULL CONSTRAINT fk_compra_empleado FOREIGN KEY REFERENCES empleado,
    fechaRegistro DATE NOT NULL DEFAULT GETDATE(),
    paisOrigen VARCHAR(100),
    observaciones VARCHAR(500),
    nombreModelo VARCHAR(100),
    nombreMarca VARCHAR(100),
    nombreTipo VARCHAR(50),      
);
GO

-- =============================================
-- 7. TABLA: vehiculo
-- =============================================
CREATE TABLE vehiculo (
    id_vehiculo INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_vehiculo PRIMARY KEY,
    id_modelo INT NOT NULL CONSTRAINT fk_vehiculo_modelo  FOREIGN KEY  REFERENCES modelo,
    id_marca INT NOT NULL CONSTRAINT fk_vehiculo_marca FOREIGN KEY  REFERENCES marca,
    id_estado INT NOT NULL CONSTRAINT fk_vehiculo_estado FOREIGN KEY REFERENCES estado,
    id_compra INT NOT NULL CONSTRAINT fk_vehiculo_compra FOREIGN KEY REFERENCES compra,
    placa VARCHAR(15) NOT NULL UNIQUE,
    chasis VARCHAR(50) NOT NULL UNIQUE,
    numeroMotor VARCHAR(50) NOT NULL UNIQUE,
    precioCompra DECIMAL(12,2) NOT NULL  CONSTRAINT ck_vehiculo_precio CHECK (precioCompra >= 0),
    ruta_imagen NVARCHAR(500),
);
GO

-- =============================================
-- 8. TABLA: venta
-- =============================================
CREATE TABLE venta (
    id_venta INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_venta PRIMARY KEY,
    id_cliente INT NOT NULL CONSTRAINT fk_venta_cliente FOREIGN KEY REFERENCES cliente,
    id_empleado INT NOT NULL CONSTRAINT fk_venta_empleado FOREIGN KEY REFERENCES empleado,
    id_vehiculo INT NOT NULL CONSTRAINT fk_venta_vehiculo FOREIGN KEY REFERENCES vehiculo,
    fecha DATE NOT NULL DEFAULT GETDATE(),
    precioVenta DECIMAL(12,2) NOT NULL CONSTRAINT ck_venta_precio CHECK (precioVenta >= 0),
    estadoVenta NVARCHAR(30) NOT NULL,
    observaciones NVARCHAR(500),
);
GO

-- =============================================
-- 9. TABLA: renta
-- =============================================
CREATE TABLE renta (
    id_renta INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_renta PRIMARY KEY,
    id_cliente INT NOT NULL CONSTRAINT fk_renta_cliente FOREIGN KEY REFERENCES cliente,
    id_empleado INT NOT NULL CONSTRAINT fk_renta_empleado FOREIGN KEY REFERENCES empleado,
    id_vehiculo INT NOT NULL CONSTRAINT fk_renta_vehiculo FOREIGN KEY REFERENCES vehiculo,
    fecha_inicio DATETIME2 NOT NULL,
    fecha_fin DATETIME2 NOT NULL,
    fecha_devolucion DATETIME2 NULL,
    precioHora DECIMAL(12,2) NOT NULL  CONSTRAINT ck_renta_precio CHECK (precioHora >= 0),
    estadoRenta NVARCHAR(30) NOT NULL,
    observaciones NVARCHAR(500), 
    

    CONSTRAINT ck_renta_fechas CHECK (fecha_fin > fecha_inicio),

    CONSTRAINT ck_renta_devolucion
        CHECK (
            fecha_devolucion IS NULL
            OR fecha_devolucion >= fecha_inicio
        ),
);
GO

-- =============================================
-- 10. TABLA: accesorio
-- =============================================
CREATE TABLE accesorio (
    id_accesorio INT NOT NULL IDENTITY(1,1)CONSTRAINT pk_id_accesorio PRIMARY KEY,
    nombreAccesorio VARCHAR(100) NOT NULL UNIQUE,
    descripcion VARCHAR(300)
);
GO

-- =============================================
-- 11. TABLA INTERMEDIA: renta_accesorio
-- =============================================
CREATE TABLE renta_accesorio (
    id_renta_accesorio INT NOT NULL IDENTITY CONSTRAINT pk_id_renta_accesorio PRIMARY KEY,
    id_renta INT NOT NULL CONSTRAINT fk_renta_accesorio FOREIGN KEY REFERENCES renta,
    id_accesorio INT NOT NULL CONSTRAINT FK_renta_accesorio_accesorio FOREIGN KEY REFERENCES accesorio, 
    cantidad INT NOT NULL DEFAULT 1 CONSTRAINT ck_renta_accesorio_cantidad CHECK (cantidad > 0),

    CONSTRAINT uq_renta_accesorio
    UNIQUE (id_renta, id_accesorio)
);
GO

-- =============================================
-- 12. TABLA: documentacion
-- =============================================
CREATE TABLE documentacion (
    id_documento INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_id_documento PRIMARY KEY,
    id_vehiculo INT NULL CONSTRAINT fk_documentacion_vehiculo FOREIGN KEY REFERENCES vehiculo,
    id_venta INT NULL CONSTRAINT fk_documentacion_venta FOREIGN KEY REFERENCES venta,
    id_renta INT NULL CONSTRAINT fk_documentacion_renta FOREIGN KEY REFERENCES renta,
    tipoDocumento NVARCHAR(100) NOT NULL,
    rutaArchivo NVARCHAR(500) NOT NULL,
    fechaRegistro DATE NOT NULL DEFAULT GETDATE(),

    CONSTRAINT ck_documentacion_relacion
        CHECK (
            id_vehiculo IS NOT NULL
            OR id_venta IS NOT NULL
            OR id_renta IS NOT NULL
        ),
);
GO