using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.Dominio.ServicosAplicacao.Contratos.Identificacao;
using DR.Infra.Comum.JWTConfig;
using DR.ModeloVisaoModelo.Identificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DR.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;

        public UsuarioController(IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] VisaoModeloUsuario usuario,
         [FromServices]Seguranca signingConfigurations,
        [FromServices]ConfiguracaoToken tokenConfigurations)
        {
            try
            {
                _servicoAplicacaoUsuario.ValidarUsuarioAutorizado(usuario.Login, usuario.Senha);

                return Ok(GetToken(usuario, signingConfigurations, tokenConfigurations));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}