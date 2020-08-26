using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos;
using DR.Dominio.Repositorios.Contratos.AtualizarEstoqueProduto;
using DR.Dominio.Repositorios.Contratos.AtualizarStatusOrdem;
using DR.Dominio.Repositorios.Contratos.EnviarOrdemCompraProcessadora;
using DR.Dominio.Repositorios.Contratos.OrdensSolicitadas;
using DR.Dominio.Repositorios.Contratos.ProdutoPorId;
using DR.Dominio.Repositorios.Contratos.ProdutosDisponiveis;
using DR.Dominio.ServicosAplicacao.Contratos.FluxoEnvioOrdemCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.ServicosAplicacao.FluxoEnvioOrdemCompra
{
    public class ServicoAplicacaoFluxoEnvioOrdemCompra : IServicoAplicacaoFluxoEnvioOrdemCompra
    {
        private readonly IRepositorioObterOrdenSolicitadas _repositorioObterOrdenSolicitadas;

        private readonly IRepositorioEnviarOrdemParaProcessadora _repositorioEnviarOrdemParaProcessadora;

        private readonly IRepositorioObterProdutosDisponiveis _repositorioObterProdutosDisponiveis;

        private readonly IRepositorioAtualizarStatusOrdem _repositorioAtualizarStatusOrdem;

        private readonly IRepositorioAtualizarEstoqueProduto _repositorioAtualizarEstoqueProduto;

        public ServicoAplicacaoFluxoEnvioOrdemCompra(
            IRepositorioObterOrdenSolicitadas repositorioObterOrdenSolicitadas,
            IRepositorioEnviarOrdemParaProcessadora repositorioEnviarOrdemParaProcessadora,
            IRepositorioObterProdutosDisponiveis repositorioObterProdutosDisponiveis,
            IRepositorioAtualizarStatusOrdem repositorioAtualizarStatusOrdem,
            IRepositorioAtualizarEstoqueProduto repositorioAtualizarEstoqueProduto)
        {
            _repositorioEnviarOrdemParaProcessadora = repositorioEnviarOrdemParaProcessadora;
            _repositorioObterOrdenSolicitadas = repositorioObterOrdenSolicitadas;
            _repositorioObterProdutosDisponiveis = repositorioObterProdutosDisponiveis;
            _repositorioAtualizarStatusOrdem = repositorioAtualizarStatusOrdem;
            _repositorioAtualizarEstoqueProduto = repositorioAtualizarEstoqueProduto;
        }

        public void ExecutarFluxoEnvioOrdemCompra()
        {
            var ordensSolicitadas = _repositorioObterOrdenSolicitadas.Obter().OrderByDescending(o => o.DataOperacao).ToList();

            var produtosDisponiveis = _repositorioObterProdutosDisponiveis.Obter().ToList();

            if (produtosDisponiveis.Count > 0)
            {
                foreach (var ordem in ordensSolicitadas)
                {
                    var produtoOrdem = produtosDisponiveis.Where(p => p.Id == ordem.Produto.Id && p.Estoque > 0).FirstOrDefault();

                    if (produtoOrdem == null || !produtoOrdem.ExisteEstoque(ordem.QuantidadeSolicitada) || !produtoOrdem.CompraPossuiValorMinimo(ordem.ValorOperacao))
                    {
                        ExecutarCancelamentoOrdem(ordem);
                    }
                    else
                    {
                        ProcessarEnvioOrdem(ordem, produtoOrdem);
                    }
                }
            }
        }

        private void ProcessarEnvioOrdem(OrdemCompra ordem, Produto produtoOrdem)
        {
            _repositorioEnviarOrdemParaProcessadora.Enviar(ordem);

            produtoOrdem.AtualizarEstoque(ordem.QuantidadeSolicitada);

            _repositorioAtualizarEstoqueProduto.AtualizarEstoque(produtoOrdem);

            ordem.FecharOrdem();

            _repositorioAtualizarStatusOrdem.AtualizarStatus(ordem);
        }

        private void ExecutarCancelamentoOrdem(OrdemCompra ordem)
        {
            ordem.CancelarOrdem();

            _repositorioAtualizarStatusOrdem.AtualizarStatus(ordem);
        }
    }
}
