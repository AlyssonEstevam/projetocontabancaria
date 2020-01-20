using ProjetoContaBancaria.Domain.Conta;
using ProjetoContaBancaria.Domain.Conta.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoContaBancaria.Infra.Data
{
    public class ContaRepository : IContaRepository
    {
        private Contexto contexto;

        private enum Procedures
        {
            InsConta,
            SelConta,
            SelPorIdConta,
            DelConta,
            UpdConta,
            UpdDeposito,
            UpdSaque,
            UpdTransferencia
        }

        public void Post(ContaDto conta)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.InsConta.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", conta.Num_NumeroConta);
                cmd.Parameters.AddWithValue("@Vlr_Saldo", conta.Vlr_Saldo);
                cmd.Parameters.AddWithValue("@Ind_ContaAtiva", conta.Ind_ContaAtiva);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ContaDto> Get()
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelConta.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        public ContaDto GetById(string id)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPorIdConta.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", id);

                return ReaderToList(cmd.ExecuteReader()).FirstOrDefault();
            }
        }

        private List<ContaDto> ReaderToList(SqlDataReader reader)
        {
            List<ContaDto> contas = new List<ContaDto>();
            while (reader.Read())
            {
                ContaDto tempConta = new ContaDto()
                {
                    Num_NumeroConta = decimal.Parse(reader["Num_NumeroConta"].ToString()),
                    Vlr_Saldo = decimal.Parse(reader["Vlr_Saldo"].ToString()),
                    Dat_DataAbertura = DateTime.Parse(reader["Dat_DataAbertura"].ToString()),
                    Ind_ContaAtiva = bool.Parse(reader["Ind_ContaAtiva"].ToString())
                };

                contas.Add(tempConta);
            }
            reader.Close();
            return contas;
        }

        public void Delete(string id)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.DelConta.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Put(ContaDto conta)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdConta.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", conta.Num_NumeroConta);
                cmd.Parameters.AddWithValue("@Vlr_Saldo", conta.Vlr_Saldo);
                cmd.Parameters.AddWithValue("@Dat_DataAbertura", conta.Dat_DataAbertura);
                cmd.Parameters.AddWithValue("@Ind_ContaAtiva", conta.Ind_ContaAtiva);
                cmd.ExecuteNonQuery();
            }
        }

        public int Deposito(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdDeposito.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", Num_NumeroConta);
                cmd.Parameters.AddWithValue("@Vlr_ValorDeposito", Vlr_Valor);
                cmd.Parameters.Add("@Num_Retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["@Num_Retorno"].Value.ToString());
            }
        }

        public int Saque(decimal Num_NumeroConta, decimal Vlr_Valor)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdSaque.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroConta", Num_NumeroConta);
                cmd.Parameters.AddWithValue("@Vlr_ValorSaque", Vlr_Valor);
                cmd.Parameters.Add("@Num_Retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["@Num_Retorno"].Value.ToString());
            }
        }

        public int Transferencia(decimal Num_NumeroContaT, decimal Num_NumeroContaR, decimal Vlr_Valor)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdTransferencia.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_NumeroContaTransferindo", Num_NumeroContaT);
                cmd.Parameters.AddWithValue("@Num_NumeroContaRecebendo", Num_NumeroContaR);
                cmd.Parameters.AddWithValue("@Vlr_ValorTransferencia", Vlr_Valor);
                cmd.Parameters.Add("@Num_Retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                return int.Parse(cmd.Parameters["@Num_Retorno"].Value.ToString());
            }
        }
    }
}
