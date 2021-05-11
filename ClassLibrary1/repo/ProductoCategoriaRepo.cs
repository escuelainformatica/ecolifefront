
using ClassLibrary1.database;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary1.repo
{
    public class ProductoCategoriaRepo
    {
        public static List<ProductoCategoria> Listar()
        {
            var resultado = new List<ProductoCategoria>();
            using (var database = new Model1())
            {
                resultado = database.ProductoCategoria.ToList();
            }
            return resultado;
        }
        public static List<AgrupacionProductoxCategoria> ListarAgrupado()
        {
            var resultado = new List<AgrupacionProductoxCategoria>();
            using (var database = new Model1())
            {
                var incluidos=database // categorias con los productos
                    .ProductoCategoria
                    .Include("Producto").ToList();

                resultado=incluidos
                    .Select(cat=>new AgrupacionProductoxCategoria {
                        Nombre=cat.Nombre
                        ,Cantidad=cat.Producto.Count()
                        ,Imagen=cat.Imagen
                        ,ImagenBinario=cat.ImagenBinario
                    })
                    .ToList();

                /*resultado = database
                    .ProductoCategoria
                    .Include("Producto")  // <--  solo se ejecuta si no ha modificado la estructura
                    .GroupBy(cat=>new {Nombre=cat.Nombre,Imagen=cat.Imagen }) // key=nombre, funciones agrupacion
                    .Select(agrupado=>new AgrupacionProductoxCategoria {
                        Nombre=agrupado.Key.Nombre
                        ,Cantidad=agrupado.Count()
                        ,Imagen=agrupado.Key.Imagen
                        })
                    .ToList();*/
            }
            return resultado;
        }
        public static List<AgrupacionProductoxCategoria> ListarAgrupadoRaw()
        {
            var resultado = new List<AgrupacionProductoxCategoria>();
            using(var database=new Model1())
            {
                var sql=@"SELECT ProductoCategoria.Nombre, ProductoCategoria.Imagen, COUNT(*) AS Cantidad
                        FROM     Producto INNER JOIN
                                          ProductoCategoria ON Producto.IdCategoria = ProductoCategoria.Id
                        GROUP BY ProductoCategoria.Nombre, ProductoCategoria.Imagen";
                resultado=database.Database
                    .SqlQuery<AgrupacionProductoxCategoria>(sql).ToList();
            }
            return resultado;
        }

        public static ProductoCategoria Obtener(int id)
        {
            var resultado = new ProductoCategoria();
            using (var database = new Model1())
            {
                resultado = database.ProductoCategoria.Where(p => p.Id == id).FirstOrDefault();
            }
            return resultado;
        }
    }
}