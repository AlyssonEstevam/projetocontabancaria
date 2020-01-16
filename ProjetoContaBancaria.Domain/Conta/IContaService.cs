using ProjetoContaBancaria.Domain.Conta.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Conta
{
    public interface IContaService
    {
        void Post(ContaDto conta);
        IEnumerable<ContaDto> Get();
        ContaDto GetById(string id);
        void Put(ContaDto conta);
        void Delete(string id);
    }
}
