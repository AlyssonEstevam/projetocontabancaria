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
        int Deposito(OperacoesContaDto operacoesConta);
        int Saque(OperacoesContaDto operacoesConta);
        int Transferencia(OperacoesContaDto operacoesConta);
    }
}
