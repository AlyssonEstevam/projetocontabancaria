using ProjetoContaBancaria.Domain.Conta;
using ProjetoContaBancaria.Domain.Conta.Dto;
using System.Web.Http;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class ContaController : ApiController
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaService _contaService;

        public ContaController(IContaRepository contaRepository, IContaService contaService)
        {
            _contaRepository = contaRepository;
            _contaService = contaService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_contaRepository.Get());
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(_contaRepository.GetById(id));
        }

        public IHttpActionResult Post(ContaDto conta)
        {
            //Implementar Notification
            _contaService.Post(conta);
            return Ok();
        }

        public IHttpActionResult Put(ContaDto conta)
        {
            //Implementar Notification
            _contaService.Put(conta);
            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {
            _contaRepository.Delete(id);
            return Ok();
        }
    }
}