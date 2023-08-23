using MaternidadeAPI.Modelo;
using MaternidadeAPI.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaesController : ControllerBase
    {
        private readonly IMaeServico _maeServico;

        public MaesController(IMaeServico maeServico)
        {
            _maeServico = maeServico;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mae = await _maeServico.GetMaeByIdAsync(id);
            return Ok(mae);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMae(MaeModelo model)
        {
            if (model == null)
            {
                return BadRequest("Id da Gênero na URL não corresponde ao ID no corpo da requisição");
            }
            await _maeServico.CreateMaeAsync(model);
            return NoContent();
        }

        [HttpGet("etnia/{etnia}")]
        public async Task<ActionResult<List<MaeModelo>>> GetMaeByEtniaAsync(string etnia)
        {
            var maes = await _maeServico.GetMaeByEtniaAsync(etnia);
            if (maes == null || maes.Count == 0)
                return NotFound($"Mãe com a etnia {etnia} não encontrada.");

            return Ok(maes);
        }

        [HttpGet("idade/{id}")]
        public async Task<IActionResult> GetMaeIdade(int id)
        {
            var idade = await _maeServico.GetIdadeMaeByIdAsync(id);
            if (idade == -1)
                return NotFound($"Mãe com o ID {id} não encontrada.");

            return Ok($"Idade da mãe: {idade} anos");
        }
    }
}
