using ProjetoContaBancaria.Domain.Conta.Dto;
using System;
using System.Collections.Generic;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Domain.Conta
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;
        private readonly NotificationContext _notification;

        public ContaService(IContaRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public void Post(ContaDto conta)
        {
            if (!conta.IsValid(_notification))
                return;

            _repository.Post(conta);
        }

        public void Put(ContaDto conta)
        {
            if (!conta.IsValid(_notification))
                return;

            _repository.Put(conta);
        }

        public void Deposito(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            int valorRetorno = _repository.Deposito(Num_NumeroConta, Vlr_Valor);

            if (valorRetorno == 1)
            {
                _notification.Add(new Notification.Notification("1", "Conta inativa"));
            }else if (valorRetorno == 2)
            {
                _notification.Add(new Notification.Notification("2", "Valor do depósito negativo"));
            }
        }

        public void Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            int valorRetorno = _repository.Saque(Num_NumeroConta, Vlr_Valor);

            if (valorRetorno == 1)
            {
                _notification.Add(new Notification.Notification("1", "Conta inativa"));
            }
            else if (valorRetorno == 2)
            {
                _notification.Add(new Notification.Notification("2", "Valor do saque negativo"));
            }
            else if (valorRetorno == 3)
            {
                _notification.Add(new Notification.Notification("3", "Saldo atual insuficiente"));
            }
        }

        public void Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor)
        {
            int valorRetorno = _repository.Transferencia(Num_NumeroContaT, Num_NumeroContaR, Vlr_Valor);

            if (valorRetorno == 1)
            {
                _notification.Add(new Notification.Notification("1", "Conta que está transferindo está inativa"));
            }
            else if (valorRetorno == 2)
            {
                _notification.Add(new Notification.Notification("2", "Conta que está recebendo está inativa"));
            }
            else if (valorRetorno == 3)
            {
                _notification.Add(new Notification.Notification("3", "Valor de transferência negativo"));
            }
            else if (valorRetorno == 4)
            {
                _notification.Add(new Notification.Notification("4", "Conta que está transferindo não possui saldo suficiente"));
            }
        }
    }
}
