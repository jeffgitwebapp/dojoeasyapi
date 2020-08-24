using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.Contratos.ProdutosDisponiveis
{
    public interface IServicoAplicacaoObterProdutosDisponiveis : IServicoAplicacao
    {
        IEnumerable<Produto> Obter();
    }
}
