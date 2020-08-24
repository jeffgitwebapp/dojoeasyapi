using DR.Dominio.Entidades.Entidades;
using DR.Dominio.ServicosAplicacao.Contratos.ProdutosDisponiveis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ProdutosDisponiveis
{
    public class MapProdutosDisponiveis : IMapProdutosDisponiveis
    {
        private readonly IServicoAplicacaoObterProdutosDisponiveis _servicoAplicacaoProdutosDisponiveis;

        public MapProdutosDisponiveis(IServicoAplicacaoObterProdutosDisponiveis servicoAplicacaoProdutosDisponiveis)
        {
            _servicoAplicacaoProdutosDisponiveis = servicoAplicacaoProdutosDisponiveis;
        }

        public IEnumerable<VisaoModeloProdutosDisponiveis> Resultado()
        {
            var produtos = _servicoAplicacaoProdutosDisponiveis.Obter();

            return VisaoModeloProdutosDisponiveis.Resultado(produtos);
        }
    }
}
