using DR.Dominio.ServicosAplicacao.Contratos.FluxoEnvioOrdemCompra;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.ModeloVisaoModelo.ProcessarOrdemCompraSolicitada
{
    public class ProcesssaOrdemCompraSolicitada : IProcesssaOrdemCompraSolicitada
    {
        private readonly IServicoAplicacaoFluxoEnvioOrdemCompra _servicoAplicacaoFluxoEnvioOrdemCompra;

        public ProcesssaOrdemCompraSolicitada(IServicoAplicacaoFluxoEnvioOrdemCompra servicoAplicacaoFluxoEnvioOrdemCompra)
        {
            _servicoAplicacaoFluxoEnvioOrdemCompra = servicoAplicacaoFluxoEnvioOrdemCompra;
        }

        public void Processar()
        {
            _servicoAplicacaoFluxoEnvioOrdemCompra.ExecutarFluxoEnvioOrdemCompra();
        }
    }
}
