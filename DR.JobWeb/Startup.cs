using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.InjecaoDependencia;
using DR.JobWeb.Agendamentos;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Threading;

namespace DR.JobWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string TIMEZONE = "WEBSITE_TIME_ZONE";

        private const string CRONCODE = "CRON_CONFIGURE_JOB";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            InjetorDependencia.RegistrarServicos(services);

            InjetorDependencia.ConfigurarComponentesSeguranca(services, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var configConexao = InjetorDependencia.ObterServicos<ConfiguracaoConexao>();

            services.AddHangfire(x => x.UseSqlServerStorage(configConexao.conexaoHangFire));

            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseHttpsRedirection();
            app.UseMvc();

            var timeZone = Configuration.GetSection(TIMEZONE)?.Value;

            var cronCode = Configuration.GetSection(CRONCODE)?.Value;

            AgendamentoTarefas.Agendar(timeZone, cronCode);
        }
    }
}
