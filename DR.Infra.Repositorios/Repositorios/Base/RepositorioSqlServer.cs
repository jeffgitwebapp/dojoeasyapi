using DR.Dominio.Repositorios.Contratos;
using DR.Infra.BD.Fabrica.ClienteBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.Base
{
    public class RepositorioSqlServer : RepositorioBD
    {
        private string _stringConexao { get; set; }

        public RepositorioSqlServer(ConfiguracaoConexao configuracaoConexao)
        {
            _stringConexao = configuracaoConexao.conexao;
        }

        public override void AtivarCliente()
        {
            this._fabricaClienteBD = new FabricaClienteBD();

            var clientDataBase = this._fabricaClienteBD.ObterClienteSqlServerBD(_stringConexao);

            _clienteSQL = clientDataBase.ObterConexao();
        }

        public override void DesativarCliente()
        {
            if (_clienteSQL.State == System.Data.ConnectionState.Open)
            {
                _clienteSQL.Close();
                _clienteSQL.Dispose();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RepositorioSqlServer()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
