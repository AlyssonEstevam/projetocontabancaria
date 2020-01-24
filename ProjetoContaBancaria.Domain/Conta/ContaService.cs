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

        public void Deposito(OperacoesContaDto operacoesConta)
        {
            int valorRetorno = _repository.Deposito(operacoesConta);

            if (valorRetorno == 1)
            {
                _notification.Add(new Notification.Notification("1", "Conta inativa"));
            }else if (valorRetorno == 2)
            {
                _notification.Add(new Notification.Notification("2", "Valor do depósito negativo"));
            }
        }

        public void Saque(OperacoesContaDto operacoesConta)
        {
            int valorRetorno = _repository.Saque(operacoesConta);

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

        public void Transferencia(OperacoesContaDto operacoesConta)
        {
            int valorRetorno = _repository.Transferencia(operacoesConta);

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
