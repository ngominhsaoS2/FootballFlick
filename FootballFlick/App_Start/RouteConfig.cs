using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FootballFlick
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "News",
                url: "News",
                defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );

            routes.MapRoute(
                name: "News detail",
                url: "News/{MetaTitle}-{id}",
                defaults: new { controller = "Content", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );

            routes.MapRoute(
                name: "Tag",
                url: "Tag/{tagId}",
                defaults: new { controller = "Content", action = "Tag", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );

            routes.MapRoute(
                name: "Member Login",
                url: "Login",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );

            routes.MapRoute(
                name: "Member Logout",
                url: "Logout",
                defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );










            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FootballFlick.Controllers" }
            );
        }
    }
}
