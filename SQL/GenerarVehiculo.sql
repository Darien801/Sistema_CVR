CREATE OR ALTER TRIGGER GenerarVehiculo
ON compra AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO vehiculo (id_modelo, id_marca, id_compra)
	SELECT NEW.id_modelo, NEW.id_marca, NEW.id_compra
	FROM inserted NEW

END
