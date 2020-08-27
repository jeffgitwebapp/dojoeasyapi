﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.Dominio.ServicosAplicacao.Contratos.Identificacao;
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
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;

        public UsuarioController(IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
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