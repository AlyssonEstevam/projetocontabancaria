using System;

namespace ProjetoContaBancaria.Domain.Conta.Dto
{
    public class ContaDto
    {
        public decimal Num_NumeroConta { get; set; }
        public decimal Vlr_Saldo { get; set; }
        public DateTime Dat_DataAbertura { get; set; }
        public bool Ind_ContaAtiva { get; set; }
    }
}
