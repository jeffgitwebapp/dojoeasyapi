using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ClientesCadastrados;
using DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.ServicosAplicacao.ClientesCadastrados
{
    public class ServicoAplicacaoClientesCadastrados : IServicoAplicacaoClientesCadastrados
    {
        private readonly IRepositorioClientesCadastrados _repositorioClientesCadastrados;
        public ServicoAplicacaoClientesCadastrados(IRepositorioClientesCadastrados repositorioClientesCadastrados)
        {
            _repositorioClientesCadastrados = repositorioClientesCadastrados;
        }

        public IEnumerable<Cliente> Obter()
        {
            try
            {
                return _repositorioClientesCadastrados.Obter();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
