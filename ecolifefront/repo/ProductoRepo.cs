using ecolifefront.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecolifefront.repo
{
    public class ProductoRepo
    {
        public static List<Producto> Listar()
        {
            var resultado=new List<Producto>();
            using(var database=new Base())
            {
               resultado=database.Producto.ToList();
            }
            return resultado;
        }
        public static List<Producto> ListarDestacados()
        {
            var resultado=new List<Producto>();
            using(var database=new Base())
            {
               resultado=database.Producto
                    .Include("ProductoCategoria")
                    .Where( p=>p.Destacado==1 )
                    .ToList();
            }
            return resultado;
        }
        public static Producto Obtener(int id)
        {
            var resultado=new Producto();
            using(var database=new Base())
            {
               resultado=database.Producto.FirstOrDefault(p=>p.Id==id);
            }
            return resultado;
        }
    }
}