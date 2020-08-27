using DR.Dominio.ServicosAplicacao.Contratos.Identificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.Identificacao
{
    public class AutorizarUsuarioVisaoModelo : IAutorizarUsuarioVisaoModelo
    {
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;

        public AutorizarUsuarioVisaoModelo(IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }

        public void ValidarUsuarioAutorizado(string login, string senha)
        {
            _servicoAplicacaoUsuario.ValidarUsuarioAutorizado(login, senha);
        }
    }
}
