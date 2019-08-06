using DevicesAPI.Filters;
using FluentValidation.WebApi;
using System.Web.Http;

namespace DevicesAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ActionFilter());
            config.Filters.Add(new ExeptionFilter());

            FluentValidationModelValidatorProvider.Configure(config);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
