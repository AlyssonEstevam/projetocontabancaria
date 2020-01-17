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

        [HttpPut, Route("api/Conta/Deposito")]
        public IHttpActionResult Deposito(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            //Implementar Notification
            _contaService.Deposito(Num_NumeroConta, Vlr_Valor);
            return Ok();
        }

        [HttpPut, Route("api/Conta/Saque")]
        public IHttpActionResult Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            //Implementar Notification
            _contaService.Saque(Num_NumeroConta, Vlr_Valor);
            return Ok();
        }

        [HttpPut, Route("api/Conta/Transferencia")]
        public IHttpActionResult Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR,
            decimal Vlr_Valor)
        {
            //Implementar Notification
            _contaService.Transferencia(Num_NumeroContaT, Num_NumeroContaR, Vlr_Valor);
            return Ok();
        }
    }
}