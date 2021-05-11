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
        // GET: Front
        public ActionResult Home()
        {
            //ViewBag.categorias=ProductoCategoriaRepo.ListarAgrupadoRaw();
            ViewBag.categorias=ProductoCategoriaRepo.ListarAgrupado();
            ViewBag.destacados=ProductoRepo.ListarDestacados();


            return View();
        }
    }
}