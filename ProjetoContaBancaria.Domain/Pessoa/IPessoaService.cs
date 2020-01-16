using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Pessoa
{
    public interface IPessoaService
    {
        void Post(PessoaDto pessoa);
        IEnumerable<PessoaDto> Get();
        PessoaDto GetById(string id);
        void Put(PessoaDto pessoa);
        void Delete(string id);
    }
}