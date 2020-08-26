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
        public static void Agendar(string timeZone, string cronCode)
        {
            var processamentoOrdemCompra = InjetorDependencia.ObterServicos<IProcesssaOrdemCompraSolicitada>();

            TimeZoneInfo southZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            RecurringJob.AddOrUpdate(() => processamentoOrdemCompra.Processar(), cronCode, southZone);
        }
    }
}
