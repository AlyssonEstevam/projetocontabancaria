using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoContaBancaria.Infra.Data
{
    public class Contexto : IDisposable
    {
        public readonly SqlConnection ConexaoBD;

        public Contexto()
        {
            ConexaoBD = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjetoContaBancariaConfig"].ConnectionString);
            ConexaoBD.Open();
        }

        public void Dispose()
        {
            if (ConexaoBD.State == ConnectionState.Open)
                ConexaoBD.Close();
        }
    }
}