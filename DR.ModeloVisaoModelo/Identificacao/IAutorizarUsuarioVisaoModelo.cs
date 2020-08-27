using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.Identificacao
{
    public interface IAutorizarUsuarioVisaoModelo: IProcessamentoVisaoModelo
    {
        void ValidarUsuarioAutorizado(string login, string senha);
    }
}
