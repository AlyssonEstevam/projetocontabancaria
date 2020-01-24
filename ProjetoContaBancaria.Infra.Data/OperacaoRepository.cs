using ProjetoContaBancaria.Domain.Operacao;
using ProjetoContaBancaria.Domain.Operacao.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoContaBancaria.Infra.Data
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private Contexto _contexto;

        private enum Procedures
        {
            SelOperacao,
            SelPorIdOperacao,
            SelPorContaOperacao,
            UpdEstorno
        }

        public IEnumerable<OperacaoDto> Get()
        {
            using (_contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelOperacao.ToString(), _contexto.ConexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        public IEnumerable<OperacaoDto> GetById(string id)
        {
            using (_contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPorContaOperacao.ToString(), _contexto.ConexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", id);

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        public OperacaoDto GetByIdOperacao(string id)
        {
            using (_contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPorIdOperacao.ToString(), _contexto.ConexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_Codigo", id);

                return ReaderToList(cmd.ExecuteReader()).FirstOrDefault();
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

        public int Estorno(OperacaoDto operacao)
        {
            using (_contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdEstorno.ToString(), _contexto.ConexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_Codigo", operacao.Num_Codigo);
                cmd.Parameters.AddWithValue("@Ind_TipoMovimento", operacao.Ind_TipoMovimento);
                cmd.Parameters.AddWithValue("@Vlr_Valor", operacao.Vlr_Valor);
                cmd.Parameters.AddWithValue("@Num_NumeroConta", operacao.Num_NumeroConta);
                cmd.Parameters.Add("@Num_Retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["@Num_Retorno"].Value.ToString());
            }
        }
    }
}
