using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Pessoa
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public void Post(PessoaDto pessoa)
        {
            _repository.Post(pessoa);
        }

        public void Put(PessoaDto pessoa)
        {
            _repository.Put(pessoa);
        }
    }
}