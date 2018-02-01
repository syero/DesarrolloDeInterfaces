CREATE DATABASE SnakeDataBase
GO
USE SnakeDataBase
GO

--use master
--drop SnakeDataBase

CREATE TABLE SK_Puntuaciones (
   IDRanking INT IDENTITY
  ,NombreUsuario NVARCHAR(30)
  ,Valor INT
  ,CONSTRAINT PK_SK_Ranking PRIMARY KEY (IDRanking)
)


CREATE TABLE SK_Mapas(
	 IDMapa INT IDENTITY
	 ,NombreMapa NVARCHAR(30)
	 ,NombreUsuario NVARCHAR(30)
	 ,MapaJson NVARCHAR(max)
	 ,ValoracionMapa INT 
	 ,FecharCreacion DATETIME
	 ,CONSTRAINT PK_SK_Mapas PRIMARY KEY (IDMapa)
)



insert into SK_Puntuaciones (NombreUsuario,Valor)
					  values('Recaredo',120)
						   ,('Pepo',50)
						   ,('Paco',130)
						   ,('Doris',60)
						   ,('Marco',150)


insert into SK_Mapas (NombreMapa,NombreUsuario,MapaJson,ValoracionMapa,FecharCreacion)
			   values('SuperOscuro','Dante',3,CURRENT_TIMESTAMP)
			        ,('MapaInterminable','Ester',5,CURRENT_TIMESTAMP)
					,('Calamidad','Paco','{}',4,CURRENT_TIMESTAMP)

Select IDRanking,NombreUsuario,Valor from SK_Puntuaciones order by Valor desc

Select IDMapa,NombreMapa,NombreUsuario,MapaJson,ValoracionMapa,FecharCreacion from SK_Mapas order by FecharCreacion desc

Select IDMapa,NombreMapa,NombreUsuario,MapaJson,ValoracionMapa,FecharCreacion from SK_Mapas order by ValoracionMapa desc

delete  from SK_Mapas

select * from  SK_Mapas

Select top (50) IDRanking,NombreUsuario,Valor from SK_Puntuaciones order by Valor desc