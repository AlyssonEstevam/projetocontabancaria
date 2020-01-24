using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Web.Application.Conta.Model
{
    public class OperacoesContaModel
    {
        [Display(Name = "Número da Conta 1")]
        public string Num_NumeroContaT { get; set; }
        [Display(Name = "Número da Conta 2")]
        public string Num_NumeroContaR { get; set; }
        [Display(Name = "Valor")]
        public decimal Vlr_Valor { get; set; }

        public OperacoesContaModel()
        {

        }

        public OperacoesContaModel(string Num_NumeroConta, decimal Vlr_Valor)
        {
            this.Num_NumeroContaT = Num_NumeroConta;
            this.Vlr_Valor = Vlr_Valor;
        }

        public OperacoesContaModel(string Num_NumeroContaT, string Num_NumeroContaR, decimal Vlr_Valor)
        {
            this.Num_NumeroContaT = Num_NumeroContaT;
            this.Num_NumeroContaR = Num_NumeroContaR;
            this.Vlr_Valor = Vlr_Valor;
        }

        [Display(Name = "Número da Conta")]
        [ScaffoldColumn(false)]
        public string Num_NumeroConta { get; set; }
    }
}
