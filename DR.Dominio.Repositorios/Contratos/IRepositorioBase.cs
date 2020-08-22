using System;

namespace DR.Dominio.Repositorios.Contratos
{
    public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : class
    {
    }
}
