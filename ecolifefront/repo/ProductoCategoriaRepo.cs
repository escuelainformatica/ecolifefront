using ecolifefront.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecolifefront.repo
{
    public class ProductoCategoriaRepo
    {
        public static List<ProductoCategoria> Listar()
        {
            var resultado = new List<ProductoCategoria>();
            using (var database = new Base())
            {
                resultado = database.ProductoCategoria.ToList();
            }
            return resultado;
        }
        public static ProductoCategoria Obtener(int id)
        {
            var resultado = new ProductoCategoria();
            using (var database = new Base())
            {
                resultado = database.ProductoCategoria.Where(p => p.Id == id).FirstOrDefault();
            }
            return resultado;
        }
    }
}