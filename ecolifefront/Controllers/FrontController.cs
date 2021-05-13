using ClassLibrary1.database;
using ClassLibrary1.repo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecolifefront.Controllers
{
    public class FrontController : Controller
    {
        // http://localhost/
        public ActionResult Home()
        {
            //ViewBag.categorias=ProductoCategoriaRepo.ListarAgrupadoRaw();
            ViewBag.categorias=ProductoCategoriaRepo.ListarAgrupado();
            ViewBag.destacados=ProductoRepo.ListarDestacados();


            return View();
        }

        // http://locahost/Front/MostrarProducto/20  <-- no

        // http://localhost/Productos/<NombreProducto> <-- si

        public ActionResult MostrarProducto(string id)
        {
            Producto prod=ProductoRepo.ObtenerPorNombre(id); // First
            if(prod==null) {
                return View("productonoencontrado"); // crear una vista con ese nombre
            }
            return View(prod); // carga la vista MostrarProducto

        }
        [HttpGet]
        public ActionResult Login()
        {
            var usr=new Usuario();
            return View(usr);
        }
        [HttpPost]
        public ActionResult Login(Usuario usr)
        {
            var valido=UsuarioRepo.Validar(usr);
            if(valido)
            {
                Session.Add("usuario",usr);
                Response.Redirect("/ProductoCategoria/Insertar");
                Response.End();
                return null;
            }

            return View(usr);
        }
    }
}