using ProjetoContaBancaria.Domain.Pessoa;
using ProjetoContaBancaria.Domain.Pessoa.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoContaBancaria.Infra.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private Contexto contexto;

        private enum Procedures
        {
            InsPessoa,
            SelPessoa,
            SelPorIdPessoa,
            DelPessoa,
            UpdPessoa
        }

        public void Post(PessoaDto pessoa)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.InsPessoa.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_cpf", pessoa.Num_Cpf);
                cmd.Parameters.AddWithValue("@Nom_Nome", pessoa.Nom_Nome);
                cmd.Parameters.AddWithValue("@Nom_Sobrenome", pessoa.Nom_Sobrenome);
                cmd.Parameters.AddWithValue("@Dat_DataNascimento", pessoa.Dat_DataNascimento);
                cmd.Parameters.AddWithValue("@Ind_Sexo", pessoa.Ind_Sexo);
                cmd.Parameters.AddWithValue("@Vlr_Renda", pessoa.Vlr_Renda);
                cmd.Parameters.AddWithValue("@Num_NumeroConta", pessoa.Num_NumeroConta);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<PessoaDto> Get()
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPessoa.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;

                return ReaderToList(cmd.ExecuteReader());
            }
        }

        public PessoaDto GetById(string id)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.SelPorIdPessoa.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_Cpf", id);

                return ReaderToList(cmd.ExecuteReader()).FirstOrDefault();
            }
        }

        private List<PessoaDto> ReaderToList(SqlDataReader reader)
        {
            List<PessoaDto> pessoas = new List<PessoaDto>();
            while (reader.Read())
            {
                PessoaDto tempPessoa = new PessoaDto()
                {
                    Num_Cpf = decimal.Parse(reader["Num_Cpf"].ToString()),
                    Nom_Nome = reader["Nom_Nome"].ToString(),
                    Nom_Sobrenome = reader["Nom_Sobrenome"].ToString(),
                    Dat_DataNascimento = DateTime.Parse(reader["Dat_DataNascimento"].ToString()),
                    Ind_Sexo = char.Parse(reader["Ind_Sexo"].ToString()),
                    Vlr_Renda = decimal.Parse(reader["Vlr_Renda"].ToString()),
                    Num_NumeroConta = decimal.Parse(reader["Num_NumeroConta"].ToString())
                };

                pessoas.Add(tempPessoa);
            }
            reader.Close();
            return pessoas;
        }

        public void Delete(string id)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.DelPessoa.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_cpf", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Put(PessoaDto pessoa)
        {
            using (contexto = new Contexto())
            {
                SqlCommand cmd = new SqlCommand(Procedures.UpdPessoa.ToString(), contexto.conexaoBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_cpf", pessoa.Num_Cpf);
                cmd.Parameters.AddWithValue("@Nom_Nome", pessoa.Nom_Nome);
                cmd.Parameters.AddWithValue("@Nom_Sobrenome", pessoa.Nom_Sobrenome);
                cmd.Parameters.AddWithValue("@Dat_DataNascimento", pessoa.Dat_DataNascimento);
                cmd.Parameters.AddWithValue("@Ind_Sexo", pessoa.Ind_Sexo);
                cmd.Parameters.AddWithValue("@Vlr_Renda", pessoa.Vlr_Renda);
                cmd.Parameters.AddWithValue("@Num_NumeroConta", pessoa.Num_NumeroConta);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
