using DR.Dominio.ServicosAplicacao.Contratos.CriarOrdemCompra;
using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.CriarOrdemCompra
{
    public class CriarOrdemCompraVisaoModelo : ICriarOrdemCompraVisaoModelo
    {
        private readonly IServicoAplicacaoCriarOrdemCompra _servicoAplicacaoCriarOrdemCompra;

        public CriarOrdemCompraVisaoModelo(IServicoAplicacaoCriarOrdemCompra servicoAplicacaoCriarOrdemCompra)
        {
            _servicoAplicacaoCriarOrdemCompra = servicoAplicacaoCriarOrdemCompra;
        }

        public void CriarOrdem(VisaoModeloCriarOrdemCompra ordem)
        {
            var novaOrdem = OrdemCompra.IniciarOrdem(ordem.ClienteId, ordem.ProdutoId, ordem.Quantidade);

            _servicoAplicacaoCriarOrdemCompra.CriarOrdem(novaOrdem);

        }
    }
}
