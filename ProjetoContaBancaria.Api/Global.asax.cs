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
            
            /*
                O código abaixo foi feito de acordo com a documentação descrita no
                link: https://simpleinjector.readthedocs.io/en/latest/webapiintegration.html
                Alysson Estevam - 16/01/2020

            // Declarando e instanciando o container normalmente.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registrando os tipos (Interfaces e Tipos) setando o scoped lifestyle:
            //Repositories
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
            container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);

            //Services
            container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);
            container.Register<IContaService, ContaService>(Lifestyle.Scoped);

            //Um método de extensão do pacote de integração.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //Verificando o container.
            container.Verify();

            //Chamando método da resolução de dependência do GlobalConfiguration
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            */
        }
    }
}
