using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ALPAY_WEP_PROJECT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "miraysu", action = "anasayfa", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UrunIncele",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "AlpayDental", action = "UrunIncele", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "UrunIletisim",
               url: "{controller}/{action}/{id}/{name}",
               defaults: new { controller = "AlpayDental", action = "UrunIletisim", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "SonUrunler",
              url: "{controller}/{action}/{id}/{name}",
              defaults: new { controller = "AlpayDental", action = "SonUrunler", id = UrlParameter.Optional }
              );

            routes.MapRoute(
               name: "BlogDetay",
               url: "{controller}/{action}/{id}/{name}",
               defaults: new { controller = "Blog", action = "BlogDetay", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "BlogPartial2",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "Blog", action = "BlogPartial2", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Urunlistesi",
               url: "{controller}/{action}/{id}/{ad}",
               defaults: new { controller = "AlpayDental", action = "UrunIncele", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "AnasayfaSonUrun",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller= "AlpayDental", action= "AnasayfaSonUrun", id=UrlParameter.Optional}
                );


        }

    }
}
