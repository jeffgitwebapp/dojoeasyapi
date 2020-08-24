using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ProdutosDisponiveis;
using DR.Dominio.ServicosAplicacao.Contratos.ProdutosDisponiveis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.ServicosAplicacao.ProdutosDisponiveis
{
    public class ServicoAplicacaoObterProdutosDisponiveis : IServicoAplicacaoObterProdutosDisponiveis
    {
        private readonly IRepositorioObterProdutosDisponiveis _repositorioProdutosDisponiveis;

        public ServicoAplicacaoObterProdutosDisponiveis(IRepositorioObterProdutosDisponiveis repositorioProdutosDisponiveis)
        {
            _repositorioProdutosDisponiveis = repositorioProdutosDisponiveis;
        }

        public IEnumerable<Produto> Obter()
        {
            throw new NotImplementedException();
        }
    }
}
