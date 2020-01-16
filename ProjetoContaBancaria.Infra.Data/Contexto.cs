using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoContaBancaria.Infra.Data
{
    public class Contexto : IDisposable
    {
        public readonly SqlConnection conexaoBD;

        public Contexto()
        {
            conexaoBD = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjetoContaBancariaConfig"].ConnectionString);
            conexaoBD.Open();
        }

        public void Dispose()
        {
            if (conexaoBD.State == ConnectionState.Open)
                conexaoBD.Close();
        }
    }
}