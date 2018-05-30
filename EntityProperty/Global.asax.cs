using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;

namespace EntityModel
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            var serializerSettings = GlobalConfiguration.Configuration
               .Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.TypeNameHandling = TypeNameHandling.All;
            formatter.SerializerSettings = serializerSettings;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
