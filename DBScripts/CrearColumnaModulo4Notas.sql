-- Cambios para añadir el control de las fechas a las cuatro notas

alter table activarexamen
add NumModulo numeric(18,0)  default 0 not null;

alter table activarexamen
add Id_Jornada numeric(18,0) default 0 not null;

update activarexamen 
set NumModulo = 0, Id_Jornada = 0;


-- Cambiar la clave primaria para incluir el módullo
-- PK_ACTIVAREXAMEN    ACTIVAREXAMEN
-- Return the name of primary key.  
SELECT name  
FROM sys.key_constraints  
WHERE type = 'PK' AND OBJECT_NAME(parent_object_id) = N'ACTIVAREXAMEN';  
  
-- Modificar la clave primaria para añadir la jornada y el módulo 
ALTER TABLE ACTIVAREXAMEN  
DROP CONSTRAINT PK_ACTIVAREXAMEN;    

-- Crear la clave primaria incluyendo al módulo
ALTER TABLE ACTIVAREXAMEN
   ADD CONSTRAINT PK_ACTIVAREXAMEN PRIMARY KEY 
   CLUSTERED (periodo_acad, Id_Jornada, NumModulo, NumNota);


select * from ACTIVAREXAMEN;

select *
from ACTIVAREXAMEN act
inner join JORNADA jor on act.Id_Jornada = jor.Id_Jornada


select *,COALESCE( (select jor.DetalleJornada from JORNADA jor where jor.Id_Jornada = act.Id_Jornada) ,'')DetalleJornada
from ACTIVAREXAMEN act