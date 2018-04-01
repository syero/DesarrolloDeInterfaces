select * from mafiosos
select * from misiones

insert into misiones (tituloMision,reservada,cumplida,observaciones,descripcionMision)
			   values('Cobrando voy,Cobrando vengo',0,0,NULL,'Tenemos que cobrar las armas que vendimos a los amarillos')
			        ,('Rompre Huesos',0,0,Null,'Poner chupar gladiolos a los que han matado a nuetro perro chiguagua')

update misiones set codigoMafioso=NULL where codigoMision=15 or codigoMision=16 

update misiones set reservada=0,codigoMafioso=NULL ,cumplida=0 , fechaCumplimiento=NULL  where codigoMision=15

update misiones set cumplida=0 , fechaCumplimiento=NULL where codigoMision=10

update misiones set observaciones='La mision ha fallado' where codigoMision=10

update misiones set observaciones=NULL where codigoMision=10