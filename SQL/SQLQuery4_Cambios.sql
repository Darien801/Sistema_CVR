-- 1. Agregar las columnas nuevas (permitiendo NULL por ahora)
ALTER TABLE compra ADD id_marca  INT NULL;
ALTER TABLE compra ADD id_modelo INT NULL;

-- 2. Llenarlas a partir de los nombres existentes

UPDATE c
SET c.id_marca = ma.id_marca
FROM compra c
JOIN marca ma ON ma.nombreMarca = c.nombreMarca;

UPDATE c
SET c.id_modelo = mo.id_modelo
FROM compra c
JOIN modelo mo ON mo.nombreModelo = c.nombreModelo;

-- 3. Volverlas obligatorias y crear las llaves foráneas
ALTER TABLE compra ALTER COLUMN id_marca  INT NOT NULL;
ALTER TABLE compra ALTER COLUMN id_modelo INT NOT NULL;

ALTER TABLE compra ADD CONSTRAINT FK_compra_marca
    FOREIGN KEY (id_marca)  REFERENCES marca(id_marca);

ALTER TABLE compra ADD CONSTRAINT FK_compra_modelo
    FOREIGN KEY (id_modelo) REFERENCES modelo(id_modelo);

-- 5. Eliminar las columnas de texto

ALTER TABLE compra DROP COLUMN nombreMarca;
ALTER TABLE compra DROP COLUMN nombreModelo;

-- 6. Agregar año y color a la tabla vehiculo

ALTER TABLE vehiculo ADD anio SMALLINT NULL;
ALTER TABLE vehiculo ADD color VARCHAR(30) NULL;

SELECT * FROM vehiculo
SELECT * FROM compra