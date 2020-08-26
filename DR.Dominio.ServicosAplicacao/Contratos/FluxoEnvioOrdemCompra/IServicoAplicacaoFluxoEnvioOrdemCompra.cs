using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Dominio.ServicosAplicacao.Contratos.FluxoEnvioOrdemCompra
{
    public interface IServicoAplicacaoFluxoEnvioOrdemCompra : IServicoAplicacao
    {
        void ExecutarFluxoEnvioOrdemCompra();
    }
}
