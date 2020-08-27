using DR.ModeloVisaoModelo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.Comum.InjecaoDependencia.IOCExtesions
{
    public static class ProcessamentoVisaoModeloExtesions
    {
        public static void AddProcessamentoVisaoModelo<TProcessamentoVisaoModeloAssembly>(this IServiceCollection services) where TProcessamentoVisaoModeloAssembly : class, IProcessamentoVisaoModelo
        {
            services.Scan(config =>
            {
                config.FromAssemblyOf<TProcessamentoVisaoModeloAssembly>()
                .AddClasses(classes => classes.AssignableTo<IProcessamentoVisaoModelo>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }
    }
}
