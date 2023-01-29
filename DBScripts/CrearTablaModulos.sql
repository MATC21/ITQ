drop table Modulo;

create table Modulo
(
   cod_periodo int  not null,
   modulo_id int not null ,
   modulo_nombre varchar(100) not null default '',
   fecha_inicio datetime,
   fecha_fin datetime,
   Primary Key (cod_periodo, modulo_id)
);

select * from PERIODO;

select * from modulo;


insert into Modulo values(    1021,1,'pao2 modulo 1' , 01/12/2022, 31/12/2022);
insert into Modulo values(    1021,1,'pao2 modulo 2' , 01/01/2023ssssssssssssssssss, 31/12/2022);
insert into Modulo values(    1021,1,'pao2 modulo 3' , 01/12/2022, 31/12/2022);