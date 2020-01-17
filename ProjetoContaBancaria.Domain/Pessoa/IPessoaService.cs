using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Pessoa
{
    public interface IPessoaService
    {
        void Post(PessoaDto pessoa);
        void Put(PessoaDto pessoa);
    }
}