using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.ModeloVisaoModelo.CriarOrdemCompra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DR.Api.Controllers
{
    [Route("api/dr/ordemcompra")]
    [ApiController]
    public class CriarOrdemController : BaseController
    {
        private readonly ICriarOrdemCompraVisaoModelo _criarOrdemCompraVisaoModelo;

        public CriarOrdemController(ICriarOrdemCompraVisaoModelo criarOrdemCompraVisaoModelo)
        {
            _criarOrdemCompraVisaoModelo = criarOrdemCompraVisaoModelo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criar")]
        public IActionResult Post([FromBody] VisaoModeloCriarOrdemCompra visaoModeloCriarOrdemCompra)
        {
            try
            {
                _criarOrdemCompraVisaoModelo.CriarOrdem(visaoModeloCriarOrdemCompra);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}