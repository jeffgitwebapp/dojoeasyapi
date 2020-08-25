using DR.Dominio.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.Contratos.CriarOrdemCompra
{
    public interface IServicoAplicacaoCriarOrdemCompra : IServicoAplicacao
    {
        void CriarOrdem(OrdemCompra novaOrdemCompra);
    }
}
