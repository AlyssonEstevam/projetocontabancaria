using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System;
using System.Collections.Generic;
using ProjetoContaBancaria.Domain.Notification;

namespace ProjetoContaBancaria.Domain.Pessoa
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        private readonly NotificationContext _notification;

        public PessoaService(IPessoaRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public void Post(PessoaDto pessoa)
        {
            if (!pessoa.IsValid(_notification))
                return;

            _repository.Post(pessoa);
        }

        public void Put(PessoaDto pessoa)
        {
            if (!pessoa.IsValid(_notification))
                return;

            _repository.Put(pessoa);
        }
    }
}