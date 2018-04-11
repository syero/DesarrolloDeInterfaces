select idTrilogia,nombreTrilogia from trilogias

select * from peliculas where idTrilogia=2

select * from personajesPeliculas

select * from personajes

select idPelicula,p.idTrilogia,nombrePelicula,nombreTrilogia from peliculas as p inner join trilogias as t on p.idTrilogia=t.idTrilogia  where p.idTrilogia=2


select * from peliculas as m inner join personajesPeliculas as mp on m.idPelicula=mp.idPelicula
 where m.idPelicula=1 and m.idTrilogia=1

 select p.idPersonaje,p.nombrePersonaje,p.tituloPersonaje,p.razaPersonaje,p.equipamientoPersonaje,p.fotoPersonaje,pl.nombrePelicula,t.nombreTrilogia
 from peliculas as pl 
 inner join trilogias as t on pl.idTrilogia=t.idTrilogia 
 inner join personajesPeliculas as pp on pl.idPelicula=pp.idPelicula 
 inner join personajes as p on pp.idPersonaje=p.idPersonaje
 where  t.idTrilogia=2 and pl.idPelicula=4