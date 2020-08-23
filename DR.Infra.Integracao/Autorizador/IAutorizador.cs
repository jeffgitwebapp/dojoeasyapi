using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Integracao.Autorizador
{
    public interface IAutorizador
    {
        bool UsuarioAutorizado(string login, string senha);
    }
}
