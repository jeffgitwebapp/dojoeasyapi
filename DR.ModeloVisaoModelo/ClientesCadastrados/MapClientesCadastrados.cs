using DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ClientesCadastrados
{
    public class MapClientesCadastrados : IMapClientesCadastrados
    {
        private readonly IServicoAplicacaoClientesCadastrados _servicoAplicacaoClientesCadastrados;

        public MapClientesCadastrados(IServicoAplicacaoClientesCadastrados servicoAplicacaoClientesCadastrados)
        {
            _servicoAplicacaoClientesCadastrados = servicoAplicacaoClientesCadastrados;
        }
        public IEnumerable<VisaoModeloClientesCadastrados> Resultado()
        {
            var clientes = _servicoAplicacaoClientesCadastrados.Obter();

            return VisaoModeloClientesCadastrados.Resultado(clientes);
        }
    }
}
