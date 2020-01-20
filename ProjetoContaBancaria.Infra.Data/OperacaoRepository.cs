using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoContaBancaria.Domain.Conta.Dto;
using ProjetoContaBancaria.Domain.Operacao;
using ProjetoContaBancaria.Domain.Operacao.Dto;

namespace ProjetoContaBancaria.Infra.Data
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private Contexto contexto;

        private enum Procedures
        {
            SelOperacao,
            SelPorContaOperacao
        }

        public IEnumerable<OperacaoDto> Get()
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelOperacao.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        public IEnumerable<OperacaoDto> GetById(string id)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPorContaOperacao.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", id);

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        private List<OperacaoDto> ReaderToList(SqlDataReader reader)
        {
            List<OperacaoDto> operacoes = new List<OperacaoDto>();
            while (reader.Read())
            {
                OperacaoDto tempOperacao = new OperacaoDto()
                {
                    Num_Codigo = decimal.Parse(reader["Num_Codigo"].ToString()),
                    Dat_Data = DateTime.Parse(reader["Dat_Data"].ToString()),
                    Nom_TipoOperacao = reader["Nom_TipoOperacao"].ToString(),
                    Ind_TipoMovimento = char.Parse(reader["Ind_TipoMovimento"].ToString()),
                    Vlr_Valor = decimal.Parse(reader["Vlr_Valor"].ToString()),
                    Num_NumeroConta = decimal.Parse(reader["Num_NumeroConta"].ToString())
                };

                operacoes.Add(tempOperacao);
            }
            reader.Close();
            return operacoes;
        }
    }
}
