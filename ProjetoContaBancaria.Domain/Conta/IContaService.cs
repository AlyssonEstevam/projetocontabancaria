using ProjetoContaBancaria.Domain.Conta.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Conta
{
    public interface IContaService
    {
        void Post(ContaDto conta);
        void Put(ContaDto conta);
        void Deposito(OperacoesContaDto operacoesConta);
        void Saque(OperacoesContaDto operacoesConta);
        void Transferencia(OperacoesContaDto operacoesConta);
    }
}
