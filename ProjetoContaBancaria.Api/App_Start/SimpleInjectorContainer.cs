using ProjetoContaBancaria.Domain.Conta;
using ProjetoContaBancaria.Domain.Notification;
using ProjetoContaBancaria.Domain.Operacao;
using ProjetoContaBancaria.Domain.Pessoa;
using ProjetoContaBancaria.Infra.Data;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ProjetoContaBancaria.Api
{
    public static class SimpleInjectorContainer
    {
        private static readonly Container Container = new Container();

        public static Container Build()
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<NotificationContext>(Lifestyle.Scoped);

            RegisterRepositories();
            RegisterServices();

            Container.Verify();
            return Container;
        }

        private static void RegisterRepositories()
        {
            Container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
            Container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);
            Container.Register<IOperacaoRepository, OperacaoRepository>(Lifestyle.Scoped);
        }

        private static void RegisterServices()
        {
            Container.Register<IPessoaService, PessoaService>(Lifestyle.Scoped);
            Container.Register<IContaService, ContaService>(Lifestyle.Scoped);
        }
    }
}