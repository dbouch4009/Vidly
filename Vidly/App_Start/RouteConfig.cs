using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //map from most to least specific

            routes.MapRoute(
                name: "MoviesByReleaseDateDefault",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate"}  //action is the name of the method in the controller
            );

            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate", year = 2000, month = 01 }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",  //expected template of API calls
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //attribute routing is the new hotness -- see the MapMvc command above
        }
    }
}
