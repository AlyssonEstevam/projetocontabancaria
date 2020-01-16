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

        public IEnumerable<ContaDto> Get()
        {
            return _repository.Get();
        }

        public ContaDto GetById(string id)
        {
            return _repository.GetById(id);
        }

        public void Put(ContaDto conta)
        {
            _repository.Put(conta);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
