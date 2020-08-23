﻿using DR.Dominio.Repositorios.Contratos;
using DR.Infra.BD.Fabrica.ClienteBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Repositorios.Repositorios.Base
{
    public class RepositorioSqlServer<TEntidade> : RepositorioBD, IRepositorio<TEntidade> where TEntidade : class
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

            _sqlServeClient = clientDataBase.ObterConexao();
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
