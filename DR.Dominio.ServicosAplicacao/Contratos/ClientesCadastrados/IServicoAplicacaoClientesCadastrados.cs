using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados
{
    public interface IServicoAplicacaoClientesCadastrados : IServicoAplicacao
    {
        IEnumerable<Cliente> Obter();
    }
}
