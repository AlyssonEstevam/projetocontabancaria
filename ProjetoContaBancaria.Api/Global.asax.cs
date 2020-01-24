using ProjetoContaBancaria.Api.App_Start;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;

namespace ProjetoContaBancaria.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(config => config.Register(new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.Build())));
            
        }
    }
}
