using DR.Infra.BD.Fabrica.ClienteBD.Abstracao;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DR.Infra.BD.Fabrica.ClienteBD
{
    public class ClienteBDSqlServer : IClienteBD<IDbConnection>
    {
        private string _stringConexao = string.Empty;
        public ClienteBDSqlServer(string stringConexao = null)
        {
            _stringConexao = stringConexao;
        }

        public IDbConnection ObterConexao(string stringConexao = null)
        {
            try
            {
                if (string.IsNullOrEmpty(_stringConexao) && string.IsNullOrEmpty(stringConexao))
                {
                    throw new Exception("Nenhuma string de conexão com banco de dados foi definida");
                }

                SqlConnection sqlConnection = null;

                if (string.IsNullOrEmpty(stringConexao) && !string.IsNullOrEmpty(_stringConexao))
                {
                    sqlConnection = new SqlConnection(_stringConexao);
                }
                else
                {
                    sqlConnection = new SqlConnection(stringConexao);
                }

                return sqlConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
