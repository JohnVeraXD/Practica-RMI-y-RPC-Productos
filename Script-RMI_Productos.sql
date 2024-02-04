
drop table productos

CREATE TABLE productos (
	id_producto int generated always as identity,
    nombre VARCHAR(100),
    descripcion VARCHAR(100),
    tipo VARCHAR(100),
    cantidad integer ,
    precio float,
    Primary Key(id_producto)
);


--select id_producto ,nombre ,descripcion ,tipo ,cantidad ,precio  from productos 
------------------------------------------------------------------------------------------
-- Crear o reemplazar el procedimiento almacenado
CREATE OR REPLACE PROCEDURE insertar_producto(
    p_nombre VARCHAR(100),
    p_descripcion VARCHAR(100),
    p_tipo VARCHAR(100),
    p_cantidad INTEGER,
    p_precio FLOAT
)
AS $$
BEGIN
    -- Insertar datos en la tabla productos
    INSERT INTO productos(nombre, descripcion, tipo, cantidad, precio)
    VALUES (p_nombre, p_descripcion, p_tipo, p_cantidad, p_precio);
END;
$$ LANGUAGE plpgsql;


--call insertar_producto('hola','hola','hola',5,25.5)

------------------------------------------------------------------------------------------
-- Crear o reemplazar el procedimiento almacenado
CREATE OR REPLACE PROCEDURE eliminar_producto(p_id_producto INTEGER)
AS $$
BEGIN
    -- Eliminar el producto por su ID
    DELETE FROM productos WHERE id_producto = p_id_producto;
END;
$$ LANGUAGE plpgsql;


--CALL eliminar_producto(1);


------------------------------------------------------------------------------------------
-- Crear o reemplazar el procedimiento almacenado
CREATE OR REPLACE PROCEDURE modificar_producto(
    p_id_producto INTEGER,
    p_nombre VARCHAR(100),
    p_descripcion VARCHAR(100),
    p_tipo VARCHAR(100),
    p_cantidad INTEGER,
    p_precio FLOAT
)
AS $$
BEGIN
    -- Modificar el producto por su ID
    UPDATE productos
    SET
        nombre = p_nombre,
        descripcion = p_descripcion,
        tipo = p_tipo,
        cantidad = p_cantidad,
        precio = p_precio
    WHERE
        id_producto = p_id_producto;
END;
$$ LANGUAGE plpgsql;


--CALL modificar_producto(1, 'NuevoNombre', 'NuevaDescripcion', 'NuevoTipo', 20, 39.99);





