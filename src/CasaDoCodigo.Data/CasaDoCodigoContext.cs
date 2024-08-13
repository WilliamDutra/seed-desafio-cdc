using Npgsql;
using System;

namespace CasaDoCodigo.Data
{
    public class CasaDoCodigoContext : IDisposable
    {
        public NpgsqlConnection Conexao;

        public CasaDoCodigoContext(string connectionStrings)
        {
            Conexao = new NpgsqlConnection(connectionStrings);
            Conexao.Open();
        }

        public void Dispose()
        {
            Conexao.Close();
        }
    }
}
