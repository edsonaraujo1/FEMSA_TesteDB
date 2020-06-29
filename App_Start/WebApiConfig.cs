using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AppTeste
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      var formatters = GlobalConfiguration.Configuration.Formatters;
      formatters.Remove(formatters.XmlFormatter);

    }
  }
}
