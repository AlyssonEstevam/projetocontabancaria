using System.Net;
using ProjetoContaBancaria.Domain.Pessoa;
using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System.Web.Http;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;
        private readonly NotificationContext _notification;

        public PessoaController(IPessoaRepository pessoaRepository, IPessoaService pessoaService, NotificationContext notification)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
            _notification = notification;
        }

        public IHttpActionResult Get()
        {
            return Ok(_pessoaRepository.Get());
        }

        public IHttpActionResult Get(string id)
        {
            return Ok(_pessoaRepository.GetById(id));
        }

        public IHttpActionResult Post(PessoaDto pessoa)
        {
            _pessoaService.Post(pessoa);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);

            return Ok();
        }

        public IHttpActionResult Put(PessoaDto pessoa)
        {
            _pessoaService.Put(pessoa);
            if (_notification.HasNotifications)
                return Content(HttpStatusCode.BadRequest, _notification.Get);

            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {
            _pessoaRepository.Delete(id);
            return Ok();
        }
    }
}