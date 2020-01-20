using ProjetoContaBancaria.Domain.Operacao;
using System.Web.Http;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class OperacaoController : ApiController
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoController(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_operacaoRepository.Get());
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(_operacaoRepository.GetById(id));
        }
    }
}