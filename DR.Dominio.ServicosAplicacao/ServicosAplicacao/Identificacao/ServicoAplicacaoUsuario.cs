using DR.Dominio.Repositorios.Contratos.Identificacao;
using DR.Dominio.ServicosAplicacao.Contratos;
using DR.Dominio.ServicosAplicacao.Contratos.Identificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.ServicosAplicacao.Identificacao
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ServicoAplicacaoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void ValidarUsuarioAutorizado(string login, string senha)
        {
            var autorizado = _repositorioUsuario.UsuarioAutorizado(login, senha);

            if (!autorizado)
            {
                throw new Exception("Usuário não identificado");
            }
        }
    }
}
