using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.Contratos.Identificacao
{
    public interface IServicoAplicacaoUsuario : IServicoAplicacao
    {
        void ValidarUsuarioAutorizado(string login, string senha);
    }
}
