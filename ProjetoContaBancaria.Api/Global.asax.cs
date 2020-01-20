using System.Web;
using ProjetoContaBancaria.Domain.Conta;
using ProjetoContaBancaria.Domain.Pessoa;
using ProjetoContaBancaria.Infra.Data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using ProjetoContaBancaria.Api.App_Start;

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
