using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoContaBancaria.Web.Application.Operacao.Model
{
    public class OperacaoModel
    {
        [Key]
        [Display(Name = "Código")]
        public decimal Num_Codigo { get; set; }
        [Display(Name = "Data")]
        public DateTime Dat_Data { get; set; }
        [Display(Name = "Tipo")]
        public string Nom_TipoOperacao { get; set; }
        [Display(Name = "Tipo de Movimento")]
        public char Ind_TipoMovimento { get; set; }
        [Display(Name = "Valor")]
        public decimal Vlr_Valor { get; set; }
        [Display(Name = "Número da Conta")]
        public decimal Num_NumeroConta { get; set; }

        [Display(Name = "Código")]
        public string Num_CodigoFormatado => string.Format("{0:N0}", Num_Codigo).Replace(".", "");

        [Display(Name = "Valor")]
        public string Vlr_ValorFormatado => "R$ " + string.Format("{0:N2}", Vlr_Valor);

        [Display(Name = "Número da Conta")]
        public string Num_NumeroContaFormatado => string.Format("{0:N0}", Num_NumeroConta).Replace(".", "");

        [Display(Name = "Data")]
        public string Dat_DataFormatada => string.Format("{0:dd/MM/yyyy}", Dat_Data);
    }
}
