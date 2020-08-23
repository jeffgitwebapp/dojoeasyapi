using DR.Dominio.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.Repositorios.Contratos.Autorizador
{
    public interface IAutorizador : IRepositorio
    {
        bool UsuarioAutorizado(string login, string senha);
    }
}
