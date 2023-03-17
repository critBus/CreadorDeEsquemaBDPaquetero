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
            Pelicula.addC("Genero", TAMAÑO_GRANDE);

            Pelicula.addC("film_affinity", TipoDeDatoSQL.BOOLEAN);
            Pelicula.addC("imdb", TipoDeDatoSQL.BOOLEAN);
            Pelicula.addC("reviewed", TipoDeDatoSQL.BOOLEAN, TipoDeClasificacionSQL.NOT_NULL);

            Pelicula.addBuscarPor(c_nombreIng_Pelicula);
            Pelicula.addBuscarPor(c_nombre_Pelicula);
            Pelicula.addBuscarPor(c_nombre_Pelicula, c_nombreIng_Pelicula);

            Pelicula.addBuscarListaPor(c_nombreIng_Pelicula);
            Pelicula.addBuscarListaPor(c_nombre_Pelicula);
            Pelicula.addBuscarListaPor(c_nombre_Pelicula, c_nombreIng_Pelicula);


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

            Serie.addC("Genero", TipoDeClasificacionSQL.NOT_NULL);

            Serie.addC("film_affinity", TipoDeDatoSQL.BOOLEAN);
            Serie.addC("imdb", TipoDeDatoSQL.BOOLEAN);
            Serie.addC("reviewed", TipoDeDatoSQL.BOOLEAN, TipoDeClasificacionSQL.NOT_NULL);

            Serie.addBuscarPor(c_titulo_Serie);
            Serie.addBuscarPor(c_tituloIng_Serie);
            Serie.addBuscarPor(c_titulo_Serie, c_tituloIng_Serie);

            Serie.addBuscarListaPor(c_titulo_Serie);
            Serie.addBuscarListaPor(c_tituloIng_Serie);
            Serie.addBuscarListaPor(c_titulo_Serie, c_tituloIng_Serie);

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


            EsquemaBD e = new EsquemaBD();
            e.addModelo(Pelicula, Serie, Actor, Saga, Formato, Genero);
            //e.addManyToMany(Pelicula, Actor,);
            e.addManyToMany(Serie, "serial_id", Actor, "actor_id", "series_actor").setIdStr("id");
            e.addManyToMany(Pelicula, "movie_id", Actor, "actor_id", "peliculas_actor").setIdStr("id");

            e.IdDeafult = "Id";

            return e;
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
