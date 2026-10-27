SELECT 'empleado' AS tabla, COUNT(*) AS registros FROM empleado
UNION ALL SELECT 'cliente',          COUNT(*) FROM cliente
UNION ALL SELECT 'marca',            COUNT(*) FROM marca
UNION ALL SELECT 'modelo',           COUNT(*) FROM modelo
UNION ALL SELECT 'estado',           COUNT(*) FROM estado
UNION ALL SELECT 'compra',           COUNT(*) FROM compra
UNION ALL SELECT 'vehiculo',         COUNT(*) FROM vehiculo
UNION ALL SELECT 'venta',            COUNT(*) FROM venta
UNION ALL SELECT 'renta',            COUNT(*) FROM renta
UNION ALL SELECT 'accesorio',        COUNT(*) FROM accesorio
UNION ALL SELECT 'renta_accesorio',  COUNT(*) FROM renta_accesorio
UNION ALL SELECT 'documentacion',    COUNT(*) FROM documentacion;
GO

SELECT * FROM empleado
SELECT * FROM cliente
SELECT * FROM marca
SELECT * FROM modelo
SELECT * FROM estado
SELECT * FROM compra
SELECT * FROM vehiculo
SELECT * FROM venta
SELECT * FROM renta
SELECT * FROM accesorio
SELECT * FROM renta_accesorio
SELECT * FROM documentacion

