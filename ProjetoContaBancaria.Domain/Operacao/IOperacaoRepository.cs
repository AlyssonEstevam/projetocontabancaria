using ProjetoContaBancaria.Domain.Operacao.Dto;
using System.Collections.Generic;

namespace ProjetoContaBancaria.Domain.Operacao
{
    public interface IOperacaoRepository
    {
        IEnumerable<OperacaoDto> Get();
        IEnumerable<OperacaoDto> GetById(string id);
    }
}
