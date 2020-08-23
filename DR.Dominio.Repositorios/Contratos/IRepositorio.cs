using System;

namespace DR.Dominio.Repositorios.Contratos
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : class
    {
    }
}
