using MaternidadeAPI.Modelo;
using MaternidadeAPI.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecemNascidosController : ControllerBase
    {
        private readonly RecemNascidoServico _recemNascidoServico;

        public RecemNascidosController(RecemNascidoServico recemNascidoServico)
        {
            _recemNascidoServico = recemNascidoServico;
        }

        [HttpPost("maes/{id}/recemnascidoscontroller")]
        public async Task<IActionResult> CreateRecemNascido(int id,RecemNascidoModelo recemNascido)
        {
            await _recemNascidoServico.CreateRecemNascido(recemNascido);
            return Ok();
        }

        [HttpDelete("recemnascidoscontroller/{id}")]
        public async Task<IActionResult> DeleteRecemNascido(int id)
        {
            await _recemNascidoServico.DeleterRecemNascido(id);
            return Ok();
        }

        [HttpGet("maes/{id}/recemnascidoscontroller/{genero}")]
        public async Task<IActionResult> GetRecemNascidoGenero(string genero)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoGenero(genero);
            if (recemNascido == null)
                return NotFound();

            return Ok(recemNascido);
        }

        [HttpGet("recemnascidoscontroller/{id}")]
        public async Task<IActionResult> GetRecemNascidoId(int id)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoId(id);
            if (recemNascido == null)
                return NotFound();

            return Ok(recemNascido);
        }

        [HttpGet("maes/{id}/recemnascidoscontroller")]
        public async Task<IActionResult> GetRecemNascidoPeso(int id,int peso)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoPeso(peso, id);
            if (recemNascido == null)
                return NotFound();

            return Ok(recemNascido);
        }

        [HttpGet("maes/{id}/recemnascidoscontroller")]
        public async Task<IActionResult> GetRecemNascidosMae(int id)
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidosMae(id);
            return Ok(recemNascidos);
        }

        [HttpGet("maes/{id}/recemnascidoscontroller")]
        public async Task<IActionResult> GetRecemNascidosMaeParto(int id, string parto)
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidosMaeParto(id, parto);
            return Ok(recemNascidos);
        }

        [HttpPut("recemnascidoscontroller/{id}")]
        public async Task<IActionResult> UpdateRecemNascido(RecemNascidoModelo recemNascido)
        {
            var updatedRecemNascido = await _recemNascidoServico.UpdateRecemNascido(recemNascido);
            if (updatedRecemNascido == null)
                return NotFound();

            return Ok(updatedRecemNascido);
        }




    }
}
