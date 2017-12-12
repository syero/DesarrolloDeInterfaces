using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandraRepasoBindingNavegarEntrePaginasCommand.Model
{
   public class ListaPeliculas
    {

        public ObservableCollection<Pelicula> obtenerLista()
        {
            clsListadoPersonas listadoActores = new clsListadoPersonas();

            ObservableCollection<Pelicula> listaPeliculas = new ObservableCollection<Pelicula>();

            //lista de acotes vacia
            ObservableCollection<Persona> actoresBancaNieves = listadoActores.ObtenerListado();
            ObservableCollection<Persona> actoresFantacia = new ObservableCollection<Persona>();
            ObservableCollection<Persona> actoresBambi = new ObservableCollection<Persona>();
            ObservableCollection<Persona> actoresCenicienta = new ObservableCollection<Persona>();
            ObservableCollection<Persona> actoresPeterPan = new ObservableCollection<Persona>();
            ObservableCollection<Persona> actoresLaDamaYElVagabundo = new ObservableCollection<Persona>();

            //imagenes de las peliculas
            Uri ImagenBlancaNieves = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);
            Uri ImagenFantacia = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);
            Uri ImagenBambi = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);
            Uri ImagenCenicienta = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);
            Uri ImagenPeterPan = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);
            Uri ImagenLaDamaYElVagabundo = new Uri("ms-appx://_SandraRepasoBindingNavegarEntrePaginasCommand/Assets/imagenes/blancanieves.png", UriKind.Absolute);

            Pelicula Blancanieves = new Pelicula(1, ImagenBlancaNieves, "Blancanieves y los Siete Enanitos", 83, 1937, "David Hand",
                    "Blancanieves es la primera película de la colección “Los Clásicos de Disney” producido por Walt Disney, y una adaptación del " +
                                "cuento de hadas homónimo que los hermanos Grimm publicaron en 1812. Puede haber sido reemplazado técnicamente por muchas de las " +
                                "películas que le siguieron, pero su sencilla historia de una pequeña princesa encantadora salvado de las malas acciones de su malvada" +
                                " madrastra, la reina, por un grupo de siete enanos adorables cambió la historia del cine cuando fue lanzado por primera vez en diciembre " +
                                "de 1937, y se ha convertido en un clásico del cine incomparable. ", actoresBancaNieves);

            Pelicula Fantasia = new Pelicula(2, ImagenFantacia, "Fantasia", 120, 1940, "Jim Handley",
                    "Los animadores de Disney crean imágenes para obras de música clásica occidental mientras Leopold Stokowski dirige la orquesta de Filadelfia. " +
                                "“El aprendiz de brujo” cuenta con Mickey Mouse como un aspirante a mago que sobrepasa sus límites. “La consagración de la primavera” cuenta la " +
                                "historia de la evolución, desde seres unicelulares hasta la muerte de los dinosaurios. “Danza de las horas” es un ballet cómico realizado por avestruces," +
                                "hipopótamos, elefantes y cocodrilos. “Una noche en el monte pelado” y Ave María enfrenta las fuerzas de la oscuridad y la luz entre ellas en una rebeldía" +
                                "endiablada que se ve interrumpida por la llegada de un nuevo día.", actoresFantacia);

            Pelicula Bambi = new Pelicula(3, ImagenBambi, "Bambi", 70, 1942, "Graham Heid",
                    "La historia animada de Bambi, un joven ciervo aclamado como el ‘Príncipe del Bosque su nacimiento. A medida que Bambi crece, forja amistad con los otros " +
                               "animales del bosque, aprende las habilidades necesarias para sobrevivir, e incluso encuentra el amor. Un día, sin embargo, los cazadores vienen y Bambi debe" +
                               "aprender a ser tan valiente como su padre y conducir a los otros ciervos a un lugar seguro.", actoresBambi);

            Pelicula Cenicienta = new Pelicula(4, ImagenCenicienta, "Cenicienta", 72, 1950, "Wilfred Jackson",
                    "En un reino lejano y hace mucho tiempo, la princesa Cenicienta vive felizmente con su madre y padre hasta que su madre muere. El padre de Cenicienta se vuelve " +
                                "a casar con una mujer fría y cruel que tiene dos hijas, Drizella y Anastasia. Cuando el padre muere, la malvada madrastra de Cenicienta la convierte en sirvienta " +
                                "de su propia casa. Mientras tanto, al otro lado de la ciudad, en el castillo, el rey decide que su hijo, el príncipe, debe encontrar una novia adecuada para que le" +
                                " proporcione los nietos suficientes. Así que el rey invita a cada doncella del reino a una fiesta de disfraces, donde su hijo será capaz de elegir una novia. Cenicienta " +
                                "no tiene un vestido adecuado para la fiesta, pero sus amigos los ratones, liderados por Jaq y Gus y los pájaros le echan una mano para hacer uno, un vestido que las " +
                                "malvadas hermanastras rompen la noche de la fiesta. En ese momento, aparece la Hada Madrina, el carruaje calabaza, el baile real, la media noche, el zapato de cristal y " +
                                "el resto, como se suele decir, es cuento de hadas.", actoresCenicienta);

            Pelicula PeterPan = new Pelicula(5, ImagenPeterPan, "Peter Pan", 78, 1953, "Wilfred Jackson",
                    "Una adaptación de la historia de J. M. Barrie sobre un niño que nunca creció. Los tres hijos de la familia Darling reciben la visita de Peter Pan, que los lleva al País" +
                                "de Nunca Jamás, donde se está produciendo una guerra continua entre la banda de Peter Pan y el malvado Capitán Garfio.", actoresPeterPan);

            Pelicula LaDamaYElVagabundo = new Pelicula(6, ImagenLaDamaYElVagabundo, "La Dama y el Vagabundo", 75, 1955, "Wilfred Jackson",
                    "Lady, una Cocker Spaniel rubia, se encuentra con un perro mestizo que se llama a sí mismo Vagabundo. Él obviamente, es del lado malo de la ciudad, pero por diversos " +
                            "acontecimientos en casa de Lady, la llevan a viajar con él durante un rato. Esto resulta ser una mala idea, ya que ningún perro está por encima de la ley.", actoresLaDamaYElVagabundo);




            listaPeliculas.Add(Blancanieves);
            listaPeliculas.Add(Fantasia);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);
            listaPeliculas.Add(LaDamaYElVagabundo);
            listaPeliculas.Add(Blancanieves);
            listaPeliculas.Add(Fantasia);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);
            listaPeliculas.Add(LaDamaYElVagabundo);
            listaPeliculas.Add(Blancanieves);
            listaPeliculas.Add(Fantasia);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);
            listaPeliculas.Add(LaDamaYElVagabundo);
            listaPeliculas.Add(Blancanieves);
            listaPeliculas.Add(Fantasia);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);
            listaPeliculas.Add(LaDamaYElVagabundo);
            listaPeliculas.Add(Blancanieves);
            listaPeliculas.Add(Fantasia);
            listaPeliculas.Add(Bambi);
            listaPeliculas.Add(Cenicienta);
            listaPeliculas.Add(PeterPan);


            return (listaPeliculas);
        }

    }
}
