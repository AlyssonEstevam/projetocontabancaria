using System;

namespace ProjetoContaBancaria.Domain.Operacao.Dto
{
    public class OperacaoDto
    {
        public decimal Num_Codigo { get; set; }
        public DateTime Dat_Data { get; set; }
        public string Nom_TipoOperacao { get; set; }
        public char Ind_TipoMovimento { get; set; }
        public decimal Vlr_Valor { get; set; }
        public decimal Num_NumeroConta { get; set; }
    }
}
