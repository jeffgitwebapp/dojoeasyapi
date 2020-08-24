using DR.Dominio.ServicosAplicacao.Contratos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Infra.InjecaoDependencia.IOCExtesions
{
    internal static  class ServicosAplicacaoExtensions
    {
        public static void AddServicosAplicacao<TServicosAplicacaoAssembly>(this IServiceCollection services) where TServicosAplicacaoAssembly : class, IServicoAplicacao
        {
            services.Scan(config =>
            {
                config.FromAssemblyOf<TServicosAplicacaoAssembly>()
                .AddClasses(classes => classes.AssignableTo<IServicoAplicacao>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }
    }
}
