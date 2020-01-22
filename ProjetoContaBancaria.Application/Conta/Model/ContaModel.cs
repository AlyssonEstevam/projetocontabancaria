using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Web.Application.Conta.Model
{
    public class ContaModel
    {
        [Key]
        [Display(Name = "Número da Conta")]
        public decimal Num_NumeroConta { get; set; }
        [Display(Name = "Saldo")]
        public decimal Vlr_Saldo { get; set; }
        [Display(Name = "Data de Abertura")]
        [ScaffoldColumn(false)]
        public DateTime Dat_DataAbertura { get; set; }
        [Display(Name = "Conta Ativa?")]
        public bool Ind_ContaAtiva { get; set; }

        [Display(Name = "Número da Conta")]
        public string Num_NumeroContaFormatada => string.Format("{0:N0}", Num_NumeroConta).Replace(".", "");

        [Display(Name = "Saldo")]
        public string Vlr_SaldoFormatado => "R$ " + string.Format("{0:N2}", Vlr_Saldo);

        [Display(Name = "Data de Abertura")]
        public string Dat_DataAberturaFormatada => string.Format("{0:dd/MM/yyyy}", Dat_DataAbertura);
    }
}
