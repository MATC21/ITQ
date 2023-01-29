drop view SepararApellidosNombresEstudiantes
go

create view SepararApellidosNombresEstudiantes as
select * , 
	substring(Apellidos_nombre , 0 + 1, Separador1 - 0 - 1) apellido1, 
	substring(Apellidos_nombre , Separador1 + 1, Separador2 - Separador1 - 1) apellido2,
	substring(Apellidos_nombre , Separador2 + 1, 1000) nombre12
from (
	select *, charindex(' ', Apellidos_nombre, Separador2+1) Separador3
	from (
		select *, charindex(' ', Apellidos_nombre, Separador1+1) Separador2
		from (
			SELECT 
				codigo_estud,
				Apellidos_nombre, 
				charindex(' ', Apellidos_nombre) Separador1
			from DATOS_ESTUD  
		) Ape1
	) Ape2
) Ape3
go

drop function dbo.EstudianteApellido1
go

CREATE FUNCTION dbo.EstudianteApellido1(@codigo_estud int)
RETURNS nchar(30)
AS
BEGIN
    DECLARE @res nchar(30);
    SELECT @res = Apellido1 
	from SepararApellidosNombresEstudiantes v 
	where v.codigo_estud = @codigo_estud
	;
    RETURN trim(@res);
END;
go

drop function dbo.EstudianteApellido2
go

CREATE FUNCTION dbo.EstudianteApellido2(@codigo_estud int)
RETURNS nchar(30)
AS
BEGIN
    DECLARE @res nchar(30);
    SELECT @res = Apellido2 
	from SepararApellidosNombresEstudiantes v 
	where v.codigo_estud = @codigo_estud
	;
    RETURN trim(@res);
END;
go

drop function dbo.EstudianteNombres12
go

CREATE FUNCTION dbo.EstudianteNombres12(@codigo_estud int)
RETURNS nchar(50)
AS
BEGIN
    DECLARE @res nchar(50);
    SELECT @res = nombre12
	from SepararApellidosNombresEstudiantes v 
	where v.codigo_estud = @codigo_estud
	;
    RETURN trim(@res);
END;
go


select 
    codigo_estud
	, Apellidos_nombre 
	, dbo.EstudianteApellido1(codigo_estud) ape1
	, dbo.EstudianteApellido2(codigo_estud) ape2
	, dbo.EstudianteNombres12(codigo_estud) nombres
from DATOS_ESTUD
where codigo_estud = 101030



update DATOS_ESTUD
set 
	Apellido1 = dbo.EstudianteApellido1(codigo_estud),
	Apellido2 = dbo.EstudianteApellido2(codigo_estud),
	Nombres12 = dbo.EstudianteNombres12(codigo_estud)
where
   Apellido1 is null


select * from DATOS_ESTUD where Apellido1 is null

select * from DATOS_ESTUD where trim(Apellido1) like ''