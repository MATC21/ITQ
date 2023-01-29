-- Crea una función para recuperar la carrera de un estudiante mediante su codigo_estud
-- Añade a la tabla datos_estud una columna calculada en base de la función

CREATE or alter FUNCTION dbo.Nombre_Basica_By_Codigo_Estud(@codigo_estud decimal(18,0))
RETURNS varchar(120)
AS
-- Recupera la carrera a la que pertenece el estudiante codigo_estud
BEGIN
    DECLARE @carrera varchar(120);
    SELECT @carrera = car.Nombre_Basica 
		from carreras car 
		where car.Cod_AnioBasica in  
			(select top 1 cxe.cod_anio_Basica 
			 from CARRERAXESTUD cxe 
			 where cxe.codigo_estud = @codigo_estud and cxe.cod_anio_Basica <> 3);
    
	IF (@carrera IS NULL)
        SET @carrera = 'Carrera no encontrada';

    RETURN @carrera;
END;

alter table DATOS_ESTUD
add carrerafunc as dbo.Nombre_Basica_By_Codigo_Estud(DATOS_ESTUD.codigo_estud);

select codigo_estud, carrerafunc
from DATOS_ESTUD;
