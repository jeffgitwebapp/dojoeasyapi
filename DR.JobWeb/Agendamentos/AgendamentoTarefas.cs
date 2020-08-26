using DR.Infra.InjecaoDependencia;
using DR.ModeloVisaoModelo.ProcessarOrdemCompraSolicitada;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DR.JobWeb.Agendamentos
{
    public static class AgendamentoTarefas
    {
        public static void Agendar()
        {
            var processamentoOrdemCompra = InjetorDependencia.ObterServicos<IProcesssaOrdemCompraSolicitada>();

            RecurringJob.AddOrUpdate(() => processamentoOrdemCompra.Processar(), Cron.Minutely());
        }
    }
}
