using ClassLibrary1.database;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecolifefront.Controllers
{
    public class ProductoCategoriaController : Controller
    {
        [HttpGet]  
        public ActionResult Insertar()
        {
            var cat=new ProductoCategoria();
            return View(cat);
        }
        [HttpPost]  
        public ActionResult Insertar(ProductoCategoria cat)
        {
            // inicio subir archivo
            if (Request.Files["ImagenSubir"].ContentLength<50000) {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(Request.Files["ImagenSubir"].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files["ImagenSubir"].ContentLength);
                }
                cat.ImagenBinario=fileData;
                cat.Imagen=Request.Files["ImagenSubir"].FileName;
            }
            // fin subir archivos

            if(ModelState.IsValid)
            {
                // aqui insertariamos
                ViewBag.mensaje="todo ok";
                try {
                    using(var database=new Model1())
                    {
                        database.ProductoCategoria.Add(cat);
                        database.SaveChanges();
                    }
                } catch(Exception ex)
                {
#if DEBUG
                    ViewBag.mensaje=ex.InnerException.InnerException.Message;
#else
                    // productivo
                    ViewBag.mensaje="Error en la base de datos";
#endif
                }
            } else
            {
                ViewBag.mensaje="error";
            }
            
            return View(cat);
        }

    }
}