select * from trilogias

select * from peliculas where idTrilogia=2

select * from personajesPeliculas

select * from personajes

select * from peliculas as p inner join trilogias as t on p.idTrilogia=t.idTrilogia  where p.idTrilogia=2


select * from peliculas as m inner join personajesPeliculas as mp on m.idPelicula=mp.idPelicula
 where m.idPelicula=1 and m.idTrilogia=1

 select * from peliculas as m inner join personajesPeliculas as mp on m.idPelicula=mp.idPelicula
 where m.idPelicula=1