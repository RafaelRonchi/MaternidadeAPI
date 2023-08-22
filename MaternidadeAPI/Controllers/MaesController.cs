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

        [HttpGet("{id}/recemnascidos")]
        public async Task<IActionResult> GetById(int id)
        {
            await _maeServico.GetMaeByIdAsync(id);
            return Ok();
        }







    }
}
