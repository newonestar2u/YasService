namespace YasService
{
    using System.Web.Http;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
