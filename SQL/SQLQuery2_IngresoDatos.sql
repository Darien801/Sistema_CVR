INSERT INTO empleado (nombre, apellido, DUI, hashEmpleado, rolEmpleado, estadoEmpleado) VALUES
('Carlos',   'Martínez',  '01234567-8', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Admin2026!'),   2), 'Administrador',  'Activo'),
('María',    'Hernández', '02345678-9', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Gerente2026!'), 2), 'Gerente',        'Activo'),
('José',     'López',     '03456789-0', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Vend2026a!'),   2), 'Vendedor',       'Activo'),
('Ana',      'Ramírez',   '04567890-1', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Vend2026b!'),   2), 'Vendedor',       'Activo'),
('Luis',     'Flores',    '05678901-2', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Vend2026c!'),   2), 'Vendedor',       'Activo'),
('Sofía',    'Castillo',  '06789012-3', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Vend2026d!'),   2), 'Vendedor',       'Activo'),
('Diego',    'Mejía',     '07890123-4', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Recep2026!'),   2), 'Recepcionista',  'Activo'),
('Patricia', 'Guzmán',    '08901234-5', CONVERT(VARCHAR(250), HASHBYTES('SHA2_256', 'Vend2026e!'),   2), 'Vendedor',       'Inactivo');
GO

INSERT INTO cliente (nombre, apellido, DUI, direccion, telefono) VALUES
('Roberto',   'Alvarado',  '10111213-1', 'Col. Escalón, Calle Principal #123, San Salvador',   '7012-3456'),
('Gabriela',  'Cruz',      '10222324-2', 'Residencial Los Pinos, Santa Tecla',                 '7123-4567'),
('Fernando',  'Portillo',  '10333435-3', 'Barrio El Centro, Av. Cuscatlán #45, San Miguel',    '7234-5678'),
('Daniela',   'Rivas',     '10444546-4', 'Col. Médica, Pasaje 5 #78, San Salvador',            '7345-6789'),
('Ricardo',   'Menjívar',  '10555657-5', 'Urb. Jardines de la Sabana, Antiguo Cuscatlán',      '7456-7890'),
('Valeria',   'Orellana',  '10666768-6', 'Col. Layco, Calle Mandes #12, San Salvador',         '7567-8901'),
('Mauricio',  'Barrera',   '10777879-7', 'Res. Altos de Santa Tecla, Casa 21',                 '7678-9012'),
('Karla',     'Domínguez', '10888980-8', 'Av. Independencia #200, Santa Ana',                  '7789-0123');
GO

INSERT INTO marca (nombreMarca) VALUES
('Toyota'),     -- 1
('Honda'),      -- 2
('Nissan'),     -- 3
('Hyundai'),    -- 4
('Kia'),        -- 5
('Mazda'),      -- 6
('Ford'),       -- 7
('Chevrolet');  -- 8
GO

INSERT INTO modelo (nombreModelo) VALUES
('Corolla'),   -- 1  Toyota
('Hilux'),     -- 2  Toyota
('Civic'),     -- 3  Honda
('CR-V'),      -- 4  Honda
('Sentra'),    -- 5  Nissan
('Frontier'),  -- 6  Nissan
('Elantra'),   -- 7  Hyundai
('Tucson'),    -- 8  Hyundai
('Rio'),       -- 9  Kia
('Sportage'),  -- 10 Kia
('Mazda3'),    -- 11 Mazda
('CX-5'),      -- 12 Mazda
('Ranger'),    -- 13 Ford
('Explorer'),  -- 14 Ford
('Spark'),     -- 15 Chevrolet
('Silverado'); -- 16 Chevrolet
GO

INSERT INTO estado (nombreEstado) VALUES
('Disponible'),          -- 1
('Vendido'),             -- 2
('Rentado'),             -- 3
('En mantenimiento'),    -- 4
('En importación'),      -- 5
('Reservado'),           -- 6
('Dañado'),              -- 7
('En trámite');          -- 8
GO

INSERT INTO compra (id_empleado, fechaRegistro, paisOrigen, observaciones, nombreModelo, nombreMarca, nombreTipo) VALUES
(1, '2026-01-10', 'Estados Unidos', 'Compra en subasta, buen estado general',        'Corolla',   'Toyota',    'Sedán'),
(1, '2026-01-18', 'Japón',          'Importación directa, bajo kilometraje',          'Hilux',     'Toyota',    'Pickup'),
(2, '2026-02-02', 'Estados Unidos', 'Un solo dueño, historial completo',              'Civic',     'Honda',     'Sedán'),
(2, '2026-02-15', 'Estados Unidos', 'Revisión mecánica aprobada',                     'CR-V',      'Honda',     'SUV'),
(1, '2026-03-01', 'México',         'Vehículo de agencia, sin accidentes',            'Sentra',    'Nissan',    'Sedán'),
(1, '2026-03-12', 'Japón',          'Tracción 4x4, pintura original',                 'Frontier',  'Nissan',    'Pickup'),
(2, '2026-03-25', 'Corea del Sur',  'Modelo reciente, interior en excelente estado',  'Elantra',   'Hyundai',   'Sedán'),
(2, '2026-04-05', 'Corea del Sur',  'Pendiente de cambio de llantas',                 'Tucson',    'Hyundai',   'SUV'),
(1, '2026-04-20', 'Corea del Sur',  'Destinado a flota de renta',                     'Rio',       'Kia',       'Hatchback'),
(1, '2026-05-08', 'Estados Unidos', 'Destinado a flota de renta',                     'Sportage',  'Kia',       'SUV'),
(2, '2026-05-22', 'Japón',          'Destinado a flota de renta, transmisión manual', 'Mazda3',    'Mazda',     'Sedán'),
(2, '2026-06-10', 'Japón',          'Destinado a flota de renta',                     'CX-5',      'Mazda',     'SUV'),
(1, '2026-06-28', 'Estados Unidos', 'Destinado a flota de renta, doble cabina',       'Ranger',    'Ford',      'Pickup'),
(1, '2026-07-15', 'Estados Unidos', 'Destinado a flota de renta, 7 pasajeros',        'Explorer',  'Ford',      'SUV'),
(2, '2026-08-03', 'México',         'Destinado a flota de renta, económico',          'Spark',     'Chevrolet', 'Hatchback'),
(2, '2026-08-20', 'Estados Unidos', 'Destinado a flota de renta, carga pesada',       'Silverado', 'Chevrolet', 'Pickup');
GO

INSERT INTO vehiculo (id_modelo, id_marca, id_estado, id_compra, placa, chasis, numeroMotor, precioCompra, ruta_imagen) VALUES
( 1, 1, 2,  1, 'P101-234', 'JTDBR32E720000001', '1ZRFE0000001', 9500.00,  '/imagenes/vehiculos/corolla_p101234.jpg'),
( 2, 1, 2,  2, 'P102-345', 'MR0FZ29G700000002', '2GDFTV000002', 21000.00, '/imagenes/vehiculos/hilux_p102345.jpg'),
( 3, 2, 2,  3, 'P103-456', '2HGFC2F50J0000003', 'R18Z10000003', 11500.00, '/imagenes/vehiculos/civic_p103456.jpg'),
( 4, 2, 2,  4, 'P104-567', '2HKRW2H50K0000004', 'K24W10000004', 16800.00, '/imagenes/vehiculos/crv_p104567.jpg'),
( 5, 3, 2,  5, 'P105-678', '3N1AB7AP5J0000005', 'MRA8DE000005', 8900.00,  '/imagenes/vehiculos/sentra_p105678.jpg'),
( 6, 3, 2,  6, 'P106-789', '1N6AD0ER5K0000006', 'QR25DE000006', 18500.00, '/imagenes/vehiculos/frontier_p106789.jpg'),
( 7, 4, 6,  7, 'P107-890', 'KMHD84LF5J0000007', 'G4NB00000007', 10200.00, '/imagenes/vehiculos/elantra_p107890.jpg'),
( 8, 4, 8,  8, 'P108-901', 'KM8J3CA46K0000008', 'G4NA00000008', 15400.00, '/imagenes/vehiculos/tucson_p108901.jpg'),
( 9, 5, 1,  9, 'P201-111', '3KPA24AB5J0000009', 'G4LC00000009', 7800.00,  '/imagenes/vehiculos/rio_p201111.jpg'),
(10, 5, 1, 10, 'P202-222', 'KNDPM3AC5K0000010', 'G4NA00000010', 14200.00, '/imagenes/vehiculos/sportage_p202222.jpg'),
(11, 6, 3, 11, 'P203-333', 'JM1BN1U75K0000011', 'PEY700000011', 10900.00, '/imagenes/vehiculos/mazda3_p203333.jpg'),
(12, 6, 3, 12, 'P204-444', 'JM3KFBCM5K0000012', 'PY0200000012', 15900.00, '/imagenes/vehiculos/cx5_p204444.jpg'),
(13, 7, 6, 13, 'P205-555', '8AFER5AD5K0000013', 'P4AT00000013', 19800.00, '/imagenes/vehiculos/ranger_p205555.jpg'),
(14, 7, 4, 14, 'P206-666', '1FM5K8D85K0000014', 'TBA300000014', 22500.00, '/imagenes/vehiculos/explorer_p206666.jpg'),
(15, 8, 3, 15, 'P207-777', 'KL8CD6SA5K0000015', 'B10D00000015', 6200.00,  '/imagenes/vehiculos/spark_p207777.jpg'),
(16, 8, 1, 16, 'P208-888', '3GCUKREC5K0000016', 'L8B000000016', 24300.00, '/imagenes/vehiculos/silverado_p208888.jpg');
GO

INSERT INTO venta (id_cliente, id_empleado, id_vehiculo, fecha, precioVenta, estadoVenta, observaciones) VALUES
(1, 3, 1, '2026-02-10', 11800.00, 'Completada', 'Pago de contado'),
(2, 4, 2, '2026-03-05', 25500.00, 'Completada', 'Financiamiento a 48 meses'),
(3, 5, 3, '2026-03-28', 13900.00, 'Completada', 'Incluye traspaso y cambio de aceite'),
(4, 6, 4, '2026-04-14', 19800.00, 'Completada', 'Pago con cheque certificado'),
(5, 3, 5, '2026-05-02', 10900.00, 'Completada', 'Cliente recoge el vehículo en sucursal'),
(6, 4, 6, '2026-06-18', 22400.00, 'Completada', 'Se entregó con llanta de repuesto nueva'),
(7, 5, 7, '2026-10-20', 12600.00, 'Pendiente',  'Cliente dejó reserva de $1,000'),
(8, 6, 8, '2026-10-23', 18700.00, 'En trámite', 'Pendiente de aprobación del crédito bancario');
GO

INSERT INTO renta (id_cliente, id_empleado, id_vehiculo, fecha_inicio, fecha_fin, fecha_devolucion, precioHora, estadoRenta, observaciones) VALUES
-- Finalizadas (con fecha de devolución)
(1, 7,  9, '2026-09-01 08:00', '2026-09-03 08:00', '2026-09-03 07:45',  4.50, 'Finalizada', 'Devuelto sin novedades'),
(2, 7, 10, '2026-09-10 09:00', '2026-09-12 09:00', '2026-09-12 11:30',  7.00, 'Finalizada', 'Devolución con 2.5 horas de retraso'),
-- Activas (aún sin devolución)
(3, 7, 11, '2026-10-23 08:00', '2026-10-28 08:00', NULL,                5.50, 'Activa',     'Renta para viaje a la zona oriental'),
(4, 7, 12, '2026-10-24 10:00', '2026-10-29 10:00', NULL,                8.00, 'Activa',     'Incluye accesorios adicionales'),
-- Reservada (a futuro)
(5, 7, 13, '2026-11-02 07:00', '2026-11-06 07:00', NULL,               10.00, 'Reservada',  'Reserva confirmada con adelanto'),
-- Finalizada
(6, 7, 14, '2026-10-01 08:00', '2026-10-04 08:00', '2026-10-04 08:10', 11.00, 'Finalizada', 'Se reportó rayón leve en puerta trasera'),
-- Activa
(7, 7, 15, '2026-10-25 06:00', '2026-10-27 18:00', NULL,                3.75, 'Activa',     'Renta corta dentro de la ciudad'),
-- Cancelada
(8, 7, 16, '2026-10-15 08:00', '2026-10-18 08:00', NULL,               12.00, 'Cancelada',  'Cliente canceló por cambio de planes');
GO

INSERT INTO accesorio (nombreAccesorio, descripcion) VALUES
('GPS',                   'Navegador GPS portátil con mapas de Centroamérica'),
('Silla para bebé',       'Asiento de seguridad infantil para niños de 9 a 18 kg'),
('Portaequipajes',        'Portaequipajes de techo con capacidad de 50 kg'),
('Cargador USB',          'Cargador múltiple USB para encendedor del vehículo'),
('Kit de emergencia',     'Triángulos, extintor, botiquín y cables pasacorriente'),
('Cobertor de asientos',  'Fundas protectoras para asientos delanteros y traseros'),
('Wifi portátil',         'Router móvil con datos ilimitados durante la renta'),
('Porta bicicletas',      'Soporte para transportar hasta 2 bicicletas');
GO

INSERT INTO renta_accesorio (id_renta, id_accesorio, cantidad) VALUES
(1, 1, 1),
(1, 4, 2),
(2, 2, 1),
(3, 3, 1),
(3, 5, 1),
(4, 1, 1),
(4, 7, 1),
(5, 8, 1),
(6, 5, 1),
(6, 6, 1),
(7, 4, 2),
(8, 1, 1);
GO

INSERT INTO documentacion (id_vehiculo, id_venta, id_renta, tipoDocumento, rutaArchivo, fechaRegistro) VALUES
-- Documentos del vehículo
(1,  NULL, NULL, 'Tarjeta de circulación', '/documentos/vehiculos/P101-234_tarjeta.pdf',    '2026-01-12'),
(2,  NULL, NULL, 'Factura de importación', '/documentos/vehiculos/P102-345_factura.pdf',    '2026-01-20'),
(9,  NULL, NULL, 'Póliza de seguro',       '/documentos/vehiculos/P201-111_poliza.pdf',     '2026-04-25'),
(11, NULL, NULL, 'Tarjeta de circulación', '/documentos/vehiculos/P203-333_tarjeta.pdf',    '2026-05-25'),
-- Documentos de venta (con y sin vehículo asociado)
(1,  1,    NULL, 'Contrato de compraventa', '/documentos/ventas/venta_001_contrato.pdf',    '2026-02-10'),
(2,  2,    NULL, 'Contrato de financiamiento', '/documentos/ventas/venta_002_financ.pdf',   '2026-03-05'),
(NULL, 3,  NULL, 'Factura de venta',        '/documentos/ventas/venta_003_factura.pdf',     '2026-03-28'),
(NULL, 4,  NULL, 'Comprobante de pago',     '/documentos/ventas/venta_004_pago.pdf',        '2026-04-14'),
(NULL, 7,  NULL, 'Recibo de reserva',       '/documentos/ventas/venta_007_reserva.pdf',     '2026-10-20'),
-- Documentos de renta
(NULL, NULL, 1,  'Contrato de renta',       '/documentos/rentas/renta_001_contrato.pdf',    '2026-09-01'),
(NULL, NULL, 2,  'Contrato de renta',       '/documentos/rentas/renta_002_contrato.pdf',    '2026-09-10'),
(NULL, NULL, 3,  'Contrato de renta',       '/documentos/rentas/renta_003_contrato.pdf',    '2026-10-23'),
(14, NULL, 6,    'Reporte de daños',        '/documentos/rentas/renta_006_danos.pdf',       '2026-10-04'),
(NULL, NULL, 8,  'Comprobante de cancelación', '/documentos/rentas/renta_008_cancel.pdf',   '2026-10-15');
GO