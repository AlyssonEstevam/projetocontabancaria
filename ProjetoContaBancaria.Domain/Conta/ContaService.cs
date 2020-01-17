using ProjetoContaBancaria.Domain.Conta.Dto;
using System;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Conta
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }

        public void Post(ContaDto conta)
        {
            _repository.Post(conta);
        }

        public void Put(ContaDto conta)
        {
            _repository.Put(conta);
        }

        public void Deposito(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            _repository.Deposito(Num_NumeroConta, Vlr_Valor);
        }

        public void Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            _repository.Saque(Num_NumeroConta, Vlr_Valor);
        }

        public void Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor)
        {
            _repository.Transferencia(Num_NumeroContaT, Num_NumeroContaR, Vlr_Valor);
        }
    }
}
