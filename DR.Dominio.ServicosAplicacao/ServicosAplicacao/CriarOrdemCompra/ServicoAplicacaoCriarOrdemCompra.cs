using DR.Dominio.Entidades.Entidades;
using DR.Dominio.Repositorios.Contratos.ClientePorId;
using DR.Dominio.Repositorios.Contratos.CriarOrdemCompra;
using DR.Dominio.Repositorios.Contratos.ProdutoPorId;
using DR.Dominio.ServicosAplicacao.Contratos.CriarOrdemCompra;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.ServicosAplicacao.CriarOrdemCompra
{
    public class ServicoAplicacaoCriarOrdemCompra : IServicoAplicacaoCriarOrdemCompra
    {
        private readonly IRepositorioObterClientePorId _repositorioObterClientesPorId;

        private readonly IRepositorioObterProdutoPorId _repositorioObterProdutosPorId;

        private readonly IRepositorioCriarOrdemCompra _repositorioCriarOrdemCompra;

        public ServicoAplicacaoCriarOrdemCompra(IRepositorioObterClientePorId repositorioObterClientesPorId,
            IRepositorioObterProdutoPorId repositorioObterProdutosPorId,
            IRepositorioCriarOrdemCompra repositorioCriarOrdemCompra)
        {
            _repositorioCriarOrdemCompra = repositorioCriarOrdemCompra;
            _repositorioObterClientesPorId = repositorioObterClientesPorId;
            _repositorioObterProdutosPorId = repositorioObterProdutosPorId;
        }

        public void CriarOrdem(OrdemCompra novaOrdemCompra)
        {
            try
            {
                CarregarProdutoInformadoNaOrdem(novaOrdemCompra);

                var cliente = ObterClienteInformadoNaOrdem(novaOrdemCompra);

                novaOrdemCompra.AtribuirCliente(cliente);

                _repositorioCriarOrdemCompra.CriarOrdem(novaOrdemCompra);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void CarregarProdutoInformadoNaOrdem(OrdemCompra novaOrdemCompra)
        {
            var produto = _repositorioObterProdutosPorId.Obter(novaOrdemCompra.Produto.Id);

            if (produto != null)
            {
                if (!produto.ExisteEstoque(novaOrdemCompra.QuantidadeSolicitada))
                {
                    throw new Exception("O produto informado não disponível para compra");
                }

                novaOrdemCompra.AtribuirProduto(produto);

                if (!produto.CompraPossuiValorMinimo(novaOrdemCompra.ValorOperacao))
                {
                    throw new Exception("O produto informado não disponível");
                }
            }
            else
            {
                throw new Exception("O produto informado não encontrado");
            }
        }

        private Cliente ObterClienteInformadoNaOrdem(OrdemCompra novaOrdemCompra)
        {
            var cliente = _repositorioObterClientesPorId.Obter(novaOrdemCompra.Cliente.Id);

            if (cliente == null)
            {
                throw new Exception("Cliente informado não encontrado");
            }

            return cliente;
        }
    }
}
