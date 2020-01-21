using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContaBancaria.Application.Operacao.Model
{
    class OperacaoModel
    {
        public decimal Num_Codigo { get; set; }
        public DateTime Dat_Data { get; set; }
        public string Nom_TipoOperacao { get; set; }
        public char Ind_TipoMovimento { get; set; }
        public decimal Vlr_Valor { get; set; }
        public decimal Num_NumeroConta { get; set; }
    }
}
