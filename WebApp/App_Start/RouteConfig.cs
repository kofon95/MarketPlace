using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "IndexPage",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            #region GetterById

            routes.MapRoute(
                name: "ArgoProduct",
                url: "agro/{word}/{id}",
                defaults: new {controller = "GetterById", action = "GetAgro"}
                );

            routes.MapRoute(
                name: "ClothesProduct",
                url: "clothes/{word}/{id}",
                defaults: new {controller = "GetterById", action = "GetClothes"}
                );

            #endregion

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Searchs",
                url: "{action}",
                defaults: new { controller = "Search" }
            );
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
