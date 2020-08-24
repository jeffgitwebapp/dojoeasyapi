using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados;
using DR.ModeloVisaoModelo.ClientesCadastrados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DR.Api.Controllers
{
    [Route("api/dr/clientes")]
    [ApiController]
    public class ClientesCadastradosController : BaseController
    {
        private readonly IServicoAplicacaoClientesCadastrados _servicoAplicacaoClientesCadastrados;

        public ClientesCadastradosController(IServicoAplicacaoClientesCadastrados servicoAplicacaoClientesCadastrados)
        {
            _servicoAplicacaoClientesCadastrados = servicoAplicacaoClientesCadastrados;
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("todos")]
        public IActionResult Get()
        {
            try
            {
                var clientesModelo = _servicoAplicacaoClientesCadastrados.Obter();

                var clientesVisao = ModeloClientesCadastrados.ModeloParaVisao(clientesModelo);

                return Ok(clientesVisao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}