using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Application.Pessoa.Model
{
    class PessoaModel
    {
        public decimal Num_Cpf { get; set; }
        public string Nom_Nome { get; set; }
        public string Nom_Sobrenome { get; set; }
        public DateTime Dat_DataNascimento { get; set; }
        public char Ind_Sexo { get; set; }
        public decimal Vlr_Renda { get; set; }
        public decimal Num_NumeroConta { get; set; }
    }
}
