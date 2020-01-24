using System.Net;
using ProjetoContaBancaria.Domain.Operacao;
using System.Web.Http;
using ProjetoContaBancaria.Domain.Notification;
using ProjetoContaBancaria.Domain.Operacao.Dto;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class OperacaoController : ApiController
    {
        private readonly IOperacaoRepository _operacaoRepository;
        private readonly NotificationContext _notification;

        public OperacaoController(IOperacaoRepository operacaoRepository, NotificationContext notification)
        {
            _operacaoRepository = operacaoRepository;
            _notification = notification;
        }

        public IHttpActionResult Get()
        {
            return Ok(_operacaoRepository.Get());
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(_operacaoRepository.GetById(id));
        }

        [HttpGet, Route("api/Operacao/GetOperacao")]
        public IHttpActionResult GetOperacao(string id)
        {
            return Ok(_operacaoRepository.GetByIdOperacao(id));
        }

        [HttpPost, Route("api/Operacao/Estorno")]
        public IHttpActionResult Estorno(OperacaoDto operacao)
        {
            _operacaoRepository.Estorno(operacao);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);
            return Ok();
        }
    }
}