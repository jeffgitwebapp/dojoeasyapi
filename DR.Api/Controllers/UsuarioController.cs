using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.Infra.Seguranca.JWTConfig;
using DR.ModeloVisaoModelo.Identificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DR.Api.Controllers
{
    [Route("api/dr/usuario")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IAutorizarUsuarioVisaoModelo _autorizarUsuarioVisaoModelo;

        public UsuarioController(IAutorizarUsuarioVisaoModelo autorizarUsuarioVisaoModelo)
        {
            _autorizarUsuarioVisaoModelo = autorizarUsuarioVisaoModelo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] VisaoModeloUsuario usuario,
         [FromServices]SegurancaJWT signingConfigurations,
        [FromServices]ConfiguracaoToken tokenConfigurations)
        {
            try
            {
                _autorizarUsuarioVisaoModelo.ValidarUsuarioAutorizado(usuario.Login, usuario.Senha);

                return Ok(GetToken(usuario, signingConfigurations, tokenConfigurations));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}