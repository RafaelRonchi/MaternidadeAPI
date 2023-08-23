using MaternidadeAPI.DTO;
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
            if (mae == null)
                return NotFound($"Mãe com ID {id} não encontrada.");
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
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateMae(int id,MaeModelo model)
        {
            if (id != model.Id)
            {
                return BadRequest("Id da mãe na URL não corresponde ao ID no corpo da requisição");
            }
            await _maeServico.UpdateMaeAsync(model);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<MaeModelo>>> GetMaes()
        {
            var maes = await _maeServico.GetAllMaesAsync();
            return Ok(maes);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHistorico(int id,[FromBody] HistoricoUpdateDto historicoDto)
        {
            var maeDb = await _maeServico.GetMaeByIdAsync(id);
            if (maeDb == null)
            {
                return NotFound();
            }
            await _maeServico.UpdateHistoricoAsync(id,historicoDto);
            return Ok(maeDb);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMae(int id)
        {
            var mae = await _maeServico.DeleteMaeAsync(id);
            if (!mae)
            {
                return NotFound("Mãe não encontrada.");
            }
            return NoContent();
        }

        [HttpGet("estadoCivil/{estadoCivil}")]
        public async Task<ActionResult<List<MaeModelo>>> GetMaesPorEstadoCivil(string estadoCivil)
        {
            var maes = await _maeServico.GetMaesPorEstadoCivilAsync(estadoCivil);
            if (maes == null || maes.Count == 0)
                return NotFound($"Mãe solteira não encontrada.");
            return Ok(maes);
        }

        [HttpGet("etnia/{etnia}")]
        public async Task<ActionResult<List<MaeModelo>>> GetMaesByEtnia(string etnia)
        {
            var maes = await _maeServico.GetMaesByEtniaAsync(etnia);
            if (maes == null || maes.Count == 0)
                return NotFound($"Mãe com a etnia {etnia} não encontrada.");
            return Ok(maes);
        }

        [HttpGet("{id}/idade")]
        public async Task<IActionResult> GetMaeIdade(int id)
        {
            var idade = await _maeServico.GetMaeIdadeAsync(id);
            if (idade == -1)
                return NotFound($"Mãe com o ID {id} não encontrada.");
            return Ok($"Idade da mãe: {idade} anos");
        }
    }
}
