using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.Dominio.ServicosAplicacao.Contratos.ClientesCadastrados;
using DR.ModeloVisaoModelo;
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
        IMapClientesCadastrados _mapVisaoModelo;

        public ClientesCadastradosController(IMapClientesCadastrados visaoModelo)
        {
            _mapVisaoModelo = visaoModelo;
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("todos")]
        public IActionResult Get()
        {
            try
            {
                var clientesVisao = _mapVisaoModelo.Resultado();

                return Ok(clientesVisao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}