using Microsoft.AspNetCore.Mvc;
using OrtosleepApi.Models;
using OrtosleepApi.Services;

namespace OrtosleepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IPrecificacaoService _precificacaoService;

        public ProdutosController(IPrecificacaoService precificacaoService)
        {
            _precificacaoService = precificacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarProdutos([FromQuery] string? busca = null)
        {
            var produtos = await _precificacaoService.BuscarProdutosAsync(busca);
            return Ok(produtos);
        }

        [HttpPost("calcular-precificacao")]
        public async Task<ActionResult<CalculoPrecificacaoResponse>> CalcularPrecificacao(CalculoPrecificacaoRequest request)
        {
            var resultado = await _precificacaoService.CalcularPrecificacaoAsync(request);
            
            if (resultado == null)
                return NotFound("Produto não encontrado");

            return Ok(resultado);
        }
    }
}