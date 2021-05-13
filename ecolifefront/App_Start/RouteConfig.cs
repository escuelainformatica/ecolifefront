using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ecolifefront
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // webforms .axd (ajax)
           // routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"RutaProducto",
                url:"Productos/{id}",
                defaults:new {Controller="Front",action="MostrarProducto" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Front", action = "Home", id = UrlParameter.Optional }
            );
          
        }
    }
}
