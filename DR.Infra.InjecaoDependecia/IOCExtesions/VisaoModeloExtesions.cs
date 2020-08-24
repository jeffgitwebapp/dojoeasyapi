using DR.ModeloVisaoModelo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.InjecaoDependencia.IOCExtesions
{
    /// <summary>
    /// IVisaoModelo
    /// </summary>
    public static class VisaoModeloExtesions
    {
        public static void AddVisaoModelo<TVisaoModeloAssembly>(this IServiceCollection services) where TVisaoModeloAssembly : class, IVisaoModeloResultado
        {
            services.Scan(config =>
            {
                config.FromAssemblyOf<TVisaoModeloAssembly>()
                .AddClasses(classes => classes.AssignableTo<IVisaoModeloResultado>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }
    }
}
