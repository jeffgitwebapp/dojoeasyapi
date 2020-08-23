﻿using DR.Dominio.Repositorios.Contratos;
using Microsoft.Extensions.DependencyInjection;

namespace DR.Infra.InjecaoDependecia.IOCExtesions
{
    internal static class RepositorioExtensions
    {
        public static void AddRepositorio<TRepositorioAssembly>(this IServiceCollection services) where TRepositorioAssembly : class, IRepositorio<object>
        {
            services.Scan(config =>
            {
                config.FromAssemblyOf<TRepositorioAssembly>()
                .AddClasses(classes => classes.AssignableTo<IRepositorio<object>>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }
    }
}
