using DR.Infra.BD.Fabrica.ClienteBD.Abstracao;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DR.Infra.InjecaoDependecia.IOCExtesions
{
    public static class ClientBDExtesion
    {
        public static void AddClienteBD<TClienteBDAssembly>(this IServiceCollection services) where TClienteBDAssembly : class, IClienteBD<IDbConnection>
        {
            services.Scan(config =>
            {
                config.FromAssemblyOf<TClienteBDAssembly>()
                .AddClasses(classes => classes.AssignableTo<IClienteBD<IDbConnection>>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }
    }
}
