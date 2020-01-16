using System.Collections.Generic;
using ProjetoContaBancaria.Domain.Pessoa.Dto;

namespace ProjetoContaBancaria.Domain.Pessoa
{
    public interface IPessoaRepository
    {
        IEnumerable<PessoaDto> Get();
        PessoaDto GetById(string id);
        void Post(PessoaDto pessoa);
        void Put(PessoaDto pessoa);
        void Delete(string id);
    }
}