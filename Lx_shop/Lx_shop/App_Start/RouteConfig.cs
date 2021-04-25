using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lx_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Get Product By Brand",
                url: "san-pham/{brand_id}",
                defaults: new { controller = "Home", action = "GetProductByBrand", brand_id = UrlParameter.Optional },
                namespaces: new string[] { "Lx_shop.Controllers" }
                );
            routes.MapRoute(
                name: "Product Details",
                url: "chi-tiet-san-pham/{id}",
                defaults: new { controller = "Home", action = "ViewProductDetail", id = UrlParameter.Optional },
                namespaces: new string[] { "Lx_shop.Controllers" }
                );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "ViewCart", id = UrlParameter.Optional },
               namespaces: new string[] { "Lx_shop.Controllers" }
               );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[]{"Lx_shop.Controllers"}
            );
        }
    }
}
