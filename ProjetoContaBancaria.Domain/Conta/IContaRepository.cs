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
        int Deposito(decimal Num_NumeroConta, decimal Vlr_Valor);
        int Saque(decimal Num_NumeroConta, decimal Vlr_Valor);
        int Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor);
    }
}
