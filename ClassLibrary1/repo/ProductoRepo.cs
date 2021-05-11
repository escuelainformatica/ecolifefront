
using ClassLibrary1.database;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace ClassLibrary1.repo
{
    // Repositorio, DAL, DAO (clase de servicio)

    public class ProductoRepo
    {
        public static void Insertar(Producto prod)
        {
            using (var database = new Model1())
            {
                database.Producto.Add(prod);
                database.SaveChanges();
            }
        }

        public static void Insertar2(Producto prod, Producto prod2)
        {
            using (var database = new Model1())
            {
                using (var transaccion = database.Database.BeginTransaction())
                {
                    try
                    {
                        database.Producto.Add(prod);  // ok.
                        database.Producto.Add(prod2); // falla.
                        database.SaveChanges(); // se guardan en la base de datos pero para la sesion actual
                        transaccion.Commit(); // guardar los cambios pendiente en la transaccion
                                              // Commit = guardar los datos pendientes.
                                              // Rollback = cancelar los datos pendientes.
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                    }
                } // si sale de la transaccion se hace un rollback
            }
        }
        public static List<Producto> Listar()
        {
            var resultado = new List<Producto>();
            using (var database = new Model1())
            {
                resultado = database.Producto.ToList();
            }

            return resultado;
        }
        public static List<Producto> ListarDestacados()
        {
            // 1) voy a consultar a redis si el dato existe.
            // 2) si existe, devuelve el valor que ya tengo.
            // 3) si el dato no existe, me conecto a sql, hago la operacion y lo guardo en redis
            var resultado = new List<Producto>();
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var redisdb = redis.GetDatabase();
                var destacados = redisdb.StringGet("destacados");
                if (destacados.HasValue)
                {
                    resultado = JsonConvert.DeserializeObject<List<Producto>>(destacados);
                    return resultado;
                }
                using (var database = new Model1())
                {
                    database.Configuration.ProxyCreationEnabled=false; // para serializar.
                    resultado = database.Producto
                         .Include("ProductoCategoria")
                         .Where(p => p.Destacado == 1)
                         .ToList();
                }

                redisdb.StringSet("destacados"
                    ,JsonConvert.SerializeObject(resultado),TimeSpan.FromSeconds(90));
            }

            return resultado;
        }
        public static Producto Obtener(int id)
        {
            var resultado = new Producto();
            using (var database = new Model1())
            {
                resultado = database.Producto.FirstOrDefault(p => p.Id == id);
            }
            return resultado;
        }
    }
}