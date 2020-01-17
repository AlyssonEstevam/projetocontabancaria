using ProjetoContaBancaria.Domain.Conta.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Conta
{
    public interface IContaRepository
    {
        IEnumerable<ContaDto> Get();
        ContaDto GetById(string id);
        void Post(ContaDto conta);
        void Put(ContaDto conta);
        void Delete(string id);
        void Deposito(decimal Num_NumeroConta, decimal Vlr_Valor);
        void Saque(decimal Num_NumeroConta, decimal Vlr_Valor);
        void Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor);
    }
}
