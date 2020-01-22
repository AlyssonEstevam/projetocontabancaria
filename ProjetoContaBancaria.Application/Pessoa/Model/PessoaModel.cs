using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoContaBancaria.Web.Application.Conta.Model;

namespace ProjetoContaBancaria.Web.Application.Pessoa.Model
{
    public class PessoaModel
    {
        [Key]
        [Display(Name = "CPF")]
        public decimal Num_Cpf { get; set; }
        [Display(Name = "Nome")]
        public string Nom_Nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string Nom_Sobrenome { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime Dat_DataNascimento { get; set; }
        [Display(Name = "Sexo")]
        public char Ind_Sexo { get; set; }
        [Display(Name = "Renda")]
        public decimal Vlr_Renda { get; set; }
        [Display(Name = "Número da Conta")]
        public decimal Num_NumeroConta { get; set; }

        public virtual ContaModel Conta { get; set; }

        [Display(Name = "CPF")]
        public string Num_CpfFormatado => string.Format("{0:N0}", Num_Cpf).Replace(".", "");

        [Display(Name = "Data Nascimento")]
        public string Dat_DataNascimentoFormatada => string.Format("{0:dd/MM/yyyy}", Dat_DataNascimento);

        [Display(Name = "Renda")]
        public string Vlr_RendaFormatada => "R$ " + string.Format("{0:N2}", Vlr_Renda);

        [Display(Name = "Número da Conta")]
        public string Num_NumeroContaFormatada => string.Format("{0:N0}", Num_NumeroConta).Replace(".", "");
    }
}
