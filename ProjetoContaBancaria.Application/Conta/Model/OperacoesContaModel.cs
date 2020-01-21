using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Application.Conta.Model
{
    public class OperacoesContaModel
    {
        public decimal Num_NumeroContaT { get; set; }
        public decimal Num_NumeroContaR { get; set; }
        public decimal Vlr_Valor { get; set; }

        public OperacoesContaModel(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            this.Num_NumeroContaT = Num_NumeroConta;
            this.Vlr_Valor = Vlr_Valor;
        }

        public OperacoesContaModel(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor)
        {
            this.Num_NumeroContaT = Num_NumeroContaT;
            this.Num_NumeroContaR = Num_NumeroContaR;
            this.Vlr_Valor = Vlr_Valor;
        }
    }
}
