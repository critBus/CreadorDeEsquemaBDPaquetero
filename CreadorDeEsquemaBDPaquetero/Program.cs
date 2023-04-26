using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles;
using ReneUtiles.Clases;
using ReneUtiles.Clases.BD;
using ReneUtiles.Clases.BD.Factory;

using Delimon.Win32.IO;
using ReneUtiles.Clases.BD.Factory.UtilesFactory;

namespace CreadorDeEsquemaBDPaquetero
{
    public class Program:ConsolaBasica
    {
        static void Main(string[] args)
        {
            crearBD_Sharp_BDPostgres(getEsquema_BDPostgresOriginal());
            endC();
        }
        public static EsquemaBD getEsquema_BDPostgresOriginal()
        {
            int TAMAÑO_NOMBRE = 50;
            int TAMAÑO_TIPO_DE_MONEDA = 50;
            int TAMAÑO_NORMAL = 50;
            int TAMAÑO_TELEFONO = 50;
            int TAMAÑO_CORREO = 50;
            int TAMAÑO_URL = 500;
            int TAMAÑO_STR = 256;
            int TAMAÑO_GRANDE = 500;
            int TAMAÑO_FOTO = 2500;


            ModeloBD_ID Pelicula = new ModeloBD_ID("peliculas");
            ColumnaDeModeloBD c_nombreIng_Pelicula = Pelicula.addC("NombreIng", TAMAÑO_GRANDE, TipoDeClasificacionSQL.NOT_NULL);
            ColumnaDeModeloBD c_nombre_Pelicula = Pelicula.addC("Nombre", TAMAÑO_GRANDE);
            Pelicula.addC("Subgenero", TAMAÑO_GRANDE);
            Pelicula.addC("Duracion", TAMAÑO_GRANDE);
            Pelicula.addC("Anno", TipoDeDatoSQL.INTEGER);
            Pelicula.addC("Origen", TAMAÑO_GRANDE);
            Pelicula.addC("Sinopsis", TipoDeDatoSQL.TEXT);
            Pelicula.addC("Saga", TAMAÑO_GRANDE);
            //Pelicula.addC("Inicial", TAMAÑO_GRANDE);
            Pelicula.addC("FotoPelicula", TAMAÑO_FOTO);
            Pelicula.addC("Definicion", TAMAÑO_GRANDE);
            Pelicula.addC("Idioma", TAMAÑO_GRANDE);
            Pelicula.addC("Formato", TAMAÑO_GRANDE);
            ColumnaDeModeloBD c_genero_Pelicula= Pelicula.addC("Genero", TAMAÑO_GRANDE);

            Pelicula.addC("film_affinity", TipoDeDatoSQL.BOOLEAN);
            Pelicula.addC("imdb", TipoDeDatoSQL.BOOLEAN);
            Pelicula.addC("reviewed", TipoDeDatoSQL.BOOLEAN, TipoDeClasificacionSQL.NOT_NULL);

            Pelicula.addBuscarPor(c_nombreIng_Pelicula);
            Pelicula.addBuscarPor(c_nombre_Pelicula);
            Pelicula.addBuscarPor(c_nombre_Pelicula, c_nombreIng_Pelicula);

            Pelicula.addBuscarListaPor(c_nombreIng_Pelicula);
            Pelicula.addBuscarListaPor(c_nombre_Pelicula);
            Pelicula.addBuscarListaPor(c_nombre_Pelicula, c_nombreIng_Pelicula);
            Pelicula.addBuscarListaPor(c_genero_Pelicula);


            Pelicula.addExiste(c_nombreIng_Pelicula);
            Pelicula.addExiste(c_nombre_Pelicula);
            Pelicula.addExiste(c_nombre_Pelicula, c_nombreIng_Pelicula);


            ModeloBD_ID Serie = new ModeloBD_ID("series");
            Serie.addC("Tipo");
            ColumnaDeModeloBD c_titulo_Serie = Serie.addC("Titulo", 1000);
            ColumnaDeModeloBD c_tituloIng_Serie = Serie.addC("TituloIng", 1000, TipoDeClasificacionSQL.NOT_NULL);

            Serie.addC("Origen");
            Serie.addC("Sinopsis", TipoDeDatoSQL.TEXT);
            Serie.addC("FotoSerie", TAMAÑO_FOTO);
            Serie.addC("Inicial", TAMAÑO_GRANDE);
            Serie.addC("EnCurso", TipoDeDatoSQL.BOOLEAN);

            ColumnaDeModeloBD c_genero_Serie= Serie.addC("Genero", TipoDeClasificacionSQL.NOT_NULL);

            Serie.addC("film_affinity", TipoDeDatoSQL.BOOLEAN);
            Serie.addC("imdb", TipoDeDatoSQL.BOOLEAN);
            Serie.addC("reviewed", TipoDeDatoSQL.BOOLEAN, TipoDeClasificacionSQL.NOT_NULL);

            Serie.addBuscarPor(c_titulo_Serie);
            Serie.addBuscarPor(c_tituloIng_Serie);
            Serie.addBuscarPor(c_titulo_Serie, c_tituloIng_Serie);

            Serie.addBuscarListaPor(c_titulo_Serie);
            Serie.addBuscarListaPor(c_tituloIng_Serie);
            Serie.addBuscarListaPor(c_titulo_Serie, c_tituloIng_Serie);
            Serie.addBuscarListaPor(c_genero_Serie);

            Serie.addExiste(c_titulo_Serie);
            Serie.addExiste(c_tituloIng_Serie);
            Serie.addExiste(c_titulo_Serie, c_tituloIng_Serie);



            ModeloBD_ID Actor = new ModeloBD_ID("actors");
            ColumnaDeModeloBD c_nombre_Actor = Actor.addC("Nombre", TAMAÑO_GRANDE);
            Actor.addC("FotoActor", TAMAÑO_FOTO);
            Actor.addC("Mostrar", TipoDeDatoSQL.BOOLEAN);

            Actor.addC("imdb", TipoDeDatoSQL.BOOLEAN);


            Actor.addBuscarPor(c_nombre_Actor);
            Actor.addBuscarListaPor(c_nombre_Actor);
            Actor.addExiste(c_nombre_Actor);


            ModeloBD_ID Saga = new ModeloBD_ID("sagas");
            ColumnaDeModeloBD c_saga_Saga = Saga.addC("Saga", TAMAÑO_GRANDE);

            Saga.addBuscarPor(c_saga_Saga);
            Saga.addBuscarListaPor(c_saga_Saga);
            Saga.addExiste(c_saga_Saga);

            ModeloBD_ID Formato = new ModeloBD_ID("formatos");
            ColumnaDeModeloBD c_formato_Formato = Formato.addC("Formato", TAMAÑO_GRANDE);

            Formato.addBuscarPor(c_formato_Formato);
            Formato.addBuscarListaPor(c_formato_Formato);
            Formato.addExiste(c_formato_Formato);


            ModeloBD_ID Genero = new ModeloBD_ID("generos");
            ColumnaDeModeloBD c_genero_Genero = Genero.addC("Genero", TAMAÑO_GRANDE);
            Genero.addC("FotoGenero", TAMAÑO_FOTO);

            Genero.addBuscarPor(c_genero_Genero);
            Genero.addBuscarListaPor(c_genero_Genero);
            Genero.addExiste(c_genero_Genero);


            ModeloBD_ID SeriesTemporadas = new ModeloBD_ID("seriestemporadas");
            SeriesTemporadas.addC("Temporada", TAMAÑO_GRANDE);
            SeriesTemporadas.addC("Capitulos", TAMAÑO_GRANDE);
            SeriesTemporadas.addC("Definicion", TAMAÑO_GRANDE);
            SeriesTemporadas.addC("Anno", TAMAÑO_GRANDE);
            SeriesTemporadas.addC("Idioma", TAMAÑO_GRANDE);
            SeriesTemporadas.addC("Formato", TAMAÑO_GRANDE);
            SeriesTemporadas.addC_ID("IdSerie", Serie);

            Serie.addGetListaDe(SeriesTemporadas);

            ModeloBD_ID Autor = new ModeloBD_ID("autors");
            ColumnaDeModeloBD c_nombre_Autor = Autor.addC("Nombre", TAMAÑO_GRANDE);
            Autor.addC("Foto", TAMAÑO_FOTO);



            Autor.addBuscarPor(c_nombre_Autor);
            Autor.addBuscarListaPor(c_nombre_Autor);
            Autor.addExiste(c_nombre_Autor);


            ModeloBD_ID Album = new ModeloBD_ID("albums");
            ColumnaDeModeloBD c_titulo_Album = Album.addC("Titulo", TAMAÑO_GRANDE);
            Album.addC("Anno", TipoDeDatoSQL.INTEGER);
            Album.addC("Foto", TAMAÑO_FOTO);
            Album.addC("IdAutorNavigationId", TipoDeDatoSQL.INTEGER);
            Album.addC("FotoBack", TAMAÑO_FOTO);
            ColumnaDeModeloBD c_idAutor_Album = Album.addC_ID("IdAutor", Autor);

            Album.addBuscarPor(c_titulo_Album);
            Album.addBuscarListaPor(c_titulo_Album);
            Album.addExiste(c_titulo_Album);

            Album.addBuscarPor(c_titulo_Album, c_idAutor_Album);
            Album.addBuscarListaPor(c_titulo_Album, c_idAutor_Album);
            Album.addExiste(c_titulo_Album, c_idAutor_Album);

            Autor.addGetListaDe(Album);


            ModeloBD_ID CancionAlbum = new ModeloBD_ID("cancionalbums");
            ColumnaDeModeloBD c_titulo_CancionAlbum = CancionAlbum.addC("Titulo", TAMAÑO_GRANDE);
            ColumnaDeModeloBD c_IdAlbum_CancionAlbum = CancionAlbum.addC_ID("IdAlbum", Album);

            CancionAlbum.addBuscarPor(c_titulo_CancionAlbum);
            CancionAlbum.addBuscarListaPor(c_titulo_CancionAlbum);
            CancionAlbum.addExiste(c_titulo_CancionAlbum);

            CancionAlbum.addBuscarPor(c_titulo_CancionAlbum, c_IdAlbum_CancionAlbum);
            CancionAlbum.addBuscarListaPor(c_titulo_CancionAlbum, c_IdAlbum_CancionAlbum);
            CancionAlbum.addExiste(c_titulo_CancionAlbum, c_IdAlbum_CancionAlbum);

            Album.addGetListaDe(CancionAlbum);


            ModeloBD_ID DVD = new ModeloBD_ID("dvd");
            ColumnaDeModeloBD c_titulo_DVD = DVD.addC("Titulo", TAMAÑO_GRANDE);
            ColumnaDeModeloBD c_Autor_DVD = DVD.addC("Autor", TAMAÑO_GRANDE);
            DVD.addC("Anno", TipoDeDatoSQL.INTEGER);
            DVD.addC("Foto", TAMAÑO_FOTO);
            DVD.addC("FotoBack", TAMAÑO_FOTO);

            DVD.addBuscarPor(c_titulo_DVD);
            DVD.addBuscarListaPor(c_titulo_DVD);
            DVD.addExiste(c_titulo_DVD);

            DVD.addBuscarPor(c_titulo_DVD, c_Autor_DVD);
            DVD.addBuscarListaPor(c_titulo_DVD, c_Autor_DVD);
            DVD.addExiste(c_titulo_DVD, c_Autor_DVD);

            Autor.addGetListaDe(DVD, c_Autor_DVD,"ListaDeDVDs");

            ModeloBD_ID CancionDVD = new ModeloBD_ID("canciondvd");
            ColumnaDeModeloBD c_nombre_CancionDVD = CancionDVD.addC("Nombre", TAMAÑO_GRANDE);
            ColumnaDeModeloBD c_IdDvd_CancionDVD = CancionDVD.addC_ID("IdDvd", DVD);

            CancionDVD.addBuscarPor(c_nombre_CancionDVD);
            CancionDVD.addBuscarListaPor(c_nombre_CancionDVD);
            CancionDVD.addExiste(c_nombre_CancionDVD);

            CancionDVD.addBuscarPor(c_nombre_CancionDVD, c_IdDvd_CancionDVD);
            CancionDVD.addBuscarListaPor(c_nombre_CancionDVD, c_IdDvd_CancionDVD);
            CancionDVD.addExiste(c_nombre_CancionDVD, c_IdDvd_CancionDVD);

            DVD.addGetListaDe(CancionDVD);

            EsquemaBD e = new EsquemaBD();
            e.addModelo(Pelicula, Serie, Actor, Saga
                , Formato, Genero, SeriesTemporadas, Autor
                ,Album, CancionAlbum, DVD, CancionDVD);
            //e.addManyToMany(Pelicula, Actor,);
            e.addManyToMany(Serie, "serial_id", Actor, "actor_id", "series_actor").setIdStr("id");
            e.addManyToMany(Pelicula, "movie_id", Actor, "actor_id", "peliculas_actor").setIdStr("id");
            //getAlbums_PG_For_Nombre

            //e.addInnerJoinOne(Album, le( c_idAutor_Album,Autor), le(Album, c_nombre_Autor));
            e.addInnerJoinOne(Album, le(c_idAutor_Album, Autor), le(c_titulo_Album, c_nombre_Autor));

            e.IdDeafult = "Id";

            return e;
        }

        public static List<ElementoPorElQueBuscar> le(params ElementoPorElQueBuscar[] P) {
            return P.ToList();
        }

        public static void crearBD_Sharp_BDPostgres(EsquemaBD e)
        {



            FactoryBD f = new FactoryBD(e);

            f.addConexion_POSTGRES(
                nombreBDAdmin: "BDManager_Admin"
                , nombreBD: "BDManager"
                );
            f.addConexion_SQLite(
                 nombreBDAdmin: "BDManager_SQlite"
                 , direccionBDSqlite: "BDManager.sqlite"
                 );
            //f.NombreBDAdmin = "BDPaquetero";
            //f.DireccionBDSqlite = "BDPaquetero.sqlite";
            f.DireccionPaquete = "BDManagerPaquete";
            f.sufijoModelos = "_PG";
            f.NombreClaseBDPadre = "I_BD_AdminPosgres";

            //f.idDeafult = "Id";
            //f.TipoDeConexion = TipoDeConexionBD.SQL_LITE;
            f.crearCodigoCSharp(new DirectoryInfo(@"D:\_Cosas\pincha\Paqutero Vietnamita Frances con Katanas\Segundo trabajo\EsquemaBD_C#\BDPaquetero_EsquemaYUtilesConsola\BDPaquetero\BDManagerPeliculas"));
            cwl("termino");
        }

    }
}
