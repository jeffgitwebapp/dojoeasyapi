using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR.Api.Controllers.BaseContoller;
using DR.ModeloVisaoModelo.ProdutosDisponiveis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DR.Api.Controllers
{
    [Route("api/dr/produtos")]
    [ApiController]
    public class ProdutosDisponiveisController : BaseController
    {

        private readonly IMapProdutosDisponiveis _mapVisaoModelo;

        public ProdutosDisponiveisController(IMapProdutosDisponiveis visaoModelo)
        {
            _mapVisaoModelo = visaoModelo;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("disponiveis")]
        public IActionResult Get()
        {
            try
            {
                var produtosDisponiveisVisao = _mapVisaoModelo.Resultado();

                return Ok(produtosDisponiveisVisao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}