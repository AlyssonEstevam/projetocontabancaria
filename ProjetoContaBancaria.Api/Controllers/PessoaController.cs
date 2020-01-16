using ProjetoContaBancaria.Domain.Pessoa;
using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System.Web.Http;

namespace ProjetoContaBancaria.Api.Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaRepository pessoaRepository, IPessoaService pessoaService)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
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
            //Implementar Notification
            _pessoaService.Post(pessoa);
            return Ok();
        }

        public IHttpActionResult Put(PessoaDto pessoa)
        {
            //Implementar Notification
            _pessoaService.Put(pessoa);
            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {
            _pessoaRepository.Delete(id);
            return Ok();
        }
    }
}