using Microsoft.AspNetCore.Mvc;
using PrevisaoProjeto.DTOs;
using PrevisaoProjeto.Services;

namespace PrevisaoProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrevisaoController : ControllerBase
    {
        private readonly PrevisorService _previsor;

        public PrevisaoController()
        {
            _previsor = new PrevisorService();
        }

        [HttpPost]
        [ProducesResponseType(typeof(PrevisaoResponseDto), 200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] PrevisaoRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = _previsor.Prever(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
