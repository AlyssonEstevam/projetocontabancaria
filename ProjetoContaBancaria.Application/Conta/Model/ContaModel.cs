using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Application.Conta.Model
{
    public class ContaModel
    {
        public decimal Num_NumeroConta { get; set; }
        public decimal Vlr_Saldo { get; set; }
        public DateTime Dat_DataAbertura { get; set; }
        public bool Ind_ContaAtiva { get; set; }
    }
}
