﻿using DR.Dominio.Repositorios.Contratos;
using DR.Dominio.Repositorios.Contratos.Identificacao;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.Repositorios.Autorizador;
using DR.Infra.Repositorios.Repositorios.Base;
using System;

namespace DR.Infra.BD.Repositorios.Identificacao
{
    public class RepositorioUsuario : IRepositorio, IRepositorioUsuario
    {
        private readonly IAutorizador _autorizador;

        public RepositorioUsuario(IAutorizador autorizador)
        {
            _autorizador = autorizador;
        }

        public bool UsuarioAutorizado(string login, string senha)
        {
            try
            {
                return _autorizador.UsuarioAutorizado(login, senha);
            }
            catch (Exception ex)
            {

                throw ex;
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
        // ~RepositorioUsuario()
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
