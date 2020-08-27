using DR.Dominio.ServicosAplicacao.ServicosAplicacao.Identificacao;
using DR.Infra.BD.Fabrica.ClienteBD;
using DR.Infra.BD.Repositorios.Identificacao;
using DR.Infra.Comum.JWTConfig;
using DR.Infra.Comum.InjecaoDependencia.IOCExtesions;
using DR.ModeloVisaoModelo.ClientesCadastrados;
using DR.ModeloVisaoModelo.CriarOrdemCompra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace DR.Infra.Comum.InjecaoDependencia
{
    public static class InjetorDependencia
    {
        private static ServiceProvider _service;
        private static ConfiguracaoToken _configuracaoToken;
        private static ConfiguracaoConexao _configuracaoConexao;

        private const string ConfiguracaoConexao = "ConfiguracaoConexao";
        private const string ConfiguracaoToken = "ConfiguracaoToken";

        public static void RegistrarServicos(IServiceCollection service)
        {
            service.AddRepositorio<RepositorioUsuario>();
            service.AddServicosAplicacao<ServicoAplicacaoUsuario>();
            service.AddClienteBD<ClienteBDSqlServer>();
            service.AddVisaoModelo<MapClientesCadastrados>();
            service.AddProcessamentoVisaoModelo<CriarOrdemCompraVisaoModelo>();
        }

        public static void ConfigurarComponentesSeguranca(IServiceCollection service, IConfiguration configuration)
        {
            var seguranca = new Seguranca();

            service.AddSingleton(seguranca);

            RegistrarChavesAppSettings(service, configuration);

            var authAdded = service.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            authAdded.AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = seguranca.Key;
                paramsValidation.ValidAudience = _configuracaoToken.Audience;
                paramsValidation.ValidIssuer = _configuracaoToken.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            service.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            _service = service.BuildServiceProvider();
        }

        private static void RegistrarChavesAppSettings(IServiceCollection service, IConfiguration configuration)
        {
            _configuracaoConexao = new ConfiguracaoConexao();

            var conexaoConfig = configuration.GetSection(ConfiguracaoConexao);

            new ConfigureFromConfigurationOptions<ConfiguracaoConexao>(conexaoConfig).Configure(_configuracaoConexao);

            service.AddSingleton(_configuracaoConexao);

            _configuracaoToken = new ConfiguracaoToken();

            var configuracaoToken = configuration.GetSection(ConfiguracaoToken);

            new ConfigureFromConfigurationOptions<ConfiguracaoToken>(configuracaoToken).Configure(_configuracaoToken);

            service.AddSingleton(_configuracaoToken);
        }

        public static Servico ObterServicos<Servico>()
        {
            return _service.GetService<Servico>();
        }
    }
}
