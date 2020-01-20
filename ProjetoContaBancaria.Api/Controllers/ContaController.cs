using System.Net;
using ProjetoContaBancaria.Domain.Conta;
using ProjetoContaBancaria.Domain.Conta.Dto;
using System.Web.Http;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class ContaController : ApiController
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContaService _contaService;
        private readonly NotificationContext _notification;

        public ContaController(IContaRepository contaRepository, IContaService contaService, NotificationContext notification)
        {
            _contaRepository = contaRepository;
            _contaService = contaService;
            _notification = notification;
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
            _contaService.Post(conta);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
            return Ok();
        }

        public IHttpActionResult Put(ContaDto conta)
        {
            _contaService.Put(conta);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
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
            _contaService.Deposito(Num_NumeroConta, Vlr_Valor);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
            return Ok();
        }

        [HttpPut, Route("api/Conta/Saque")]
        public IHttpActionResult Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            _contaService.Saque(Num_NumeroConta, Vlr_Valor);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
            return Ok();
        }

        [HttpPut, Route("api/Conta/Transferencia")]
        public IHttpActionResult Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR,
            decimal Vlr_Valor)
        {
            _contaService.Transferencia(Num_NumeroContaT, Num_NumeroContaR, Vlr_Valor);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
            return Ok();
        }
    }
}