﻿using MaternidadeAPI.DTO;
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
        private readonly IRecemNascidoServico _recemNascidoServico;

        public RecemNascidosController(IRecemNascidoServico recemNascidoServico)
        {
            _recemNascidoServico = recemNascidoServico;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecemNascidoId(int id)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoId(id);
            if (recemNascido == null)
                return NotFound();

            return Ok(recemNascido);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecemNascido(int id)
        {
            var response = await _recemNascidoServico.DeleteRecemNascido(id);
            if (response == null) return NotFound($"Recém nascido: {id} Não encontrado");
            
            return Ok($"Recém nascido: {id} removido!");
        }

        [HttpPost("maes/{id}/recem-nascidos")]
        public async Task<IActionResult> CreateRecemNascido(int id,RecemNascidoModelo recemNascido)
        {
             await _recemNascidoServico.CreateRecemNascido(recemNascido, id);
            return Ok();
        }

        [HttpGet("maes/{id}/recem-nascidos/{genero}")]
        public async Task<IActionResult> GetRecemNascidoGenero(int id,string genero)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoGenero( id ,genero);
            if (!recemNascido.Any()) return NotFound();

            return Ok(recemNascido);
        }


        [HttpGet("maes/{id}/recem-nascidos/peso_min={peso}")]
        public async Task<IActionResult> GetRecemNascidoPeso(int id,int peso)
        {
            var recemNascido = await _recemNascidoServico.GetRecemNascidoPeso(peso, id);
            if (!recemNascido.Any()) return NotFound();

            return Ok(recemNascido);
        }

        [HttpGet("maes/{id}/recem-nascidos")]
        public async Task<IActionResult> GetRecemNascidosMae(int id)
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidosMae(id);
            if (!recemNascidos.Any()) return NotFound();
            return Ok(recemNascidos);
        }

        [HttpGet("maes/{id}/recemnascidos/tipo_parto={parto}")]
        public async Task<IActionResult> GetRecemNascidosMaeParto(int id, string parto)
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidosMaeParto(id, parto);
            if (!recemNascidos.Any()) return NotFound();
            return Ok(recemNascidos);
        }

        [HttpGet("/Todos-recem-nascidos")]
        public async Task<IActionResult> GetRecemNascidosAll()
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidoAll();
            if (!recemNascidos.Any()) return NotFound();
            return Ok(recemNascidos);
        }

        [HttpGet("/Apgar/{apgar}")]
        public async Task<IActionResult> GetRecemNascidosApgar(int apgar )
        {
            var recemNascidos = await _recemNascidoServico.GetRecemnascidoApgar(apgar);
            if (!recemNascidos.Any()) return NotFound();
            return Ok(recemNascidos);
        }

        [HttpGet("/Saude/{saude}")]
        public async Task<IActionResult> GetRecemNascidosSaude(string saude)
        {
            var recemNascidos = await _recemNascidoServico.GetRecemNascidosCondicaoSaude(saude);
            if (!recemNascidos.Any()) return NotFound();
            return Ok(recemNascidos);
        }

        [HttpPut("atualizarRecem/{id}")]
        public async Task<IActionResult> UpdateRecemNascidoWeightAndHeight(int id, [FromBody] UpdateRecemNascidoDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid payload");
            }

            var updatedRecemNascido = await _recemNascidoServico.UpdateRecemNascidoWeightAndHeight(
                id, updateDto.PesoGramas, updateDto.AlturaCentimetros);

            if (updatedRecemNascido == null)
            {
                return NotFound();
            }

            return Ok(updatedRecemNascido);
        }
    }
}
