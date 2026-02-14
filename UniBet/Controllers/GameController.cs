using Microsoft.AspNetCore.Mvc;
using UniBet.DTOs;
using UniBet.Entities;
using UniBet.Interfaces.IServices;

namespace UniBet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpPost("CadastrarJogo")]
        public IActionResult CadastrarJogo([FromBody] GameDTO gameDto)
        {
            try
            {
                _service.CadastrarJogo(gameDto);
                return Created("CadastrarJogo", "Jogo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarJogo")]
        public IActionResult BuscarJogo([FromQuery] Guid id)
        {
            try
            {
                var jogo = _service.BuscarJogo(id);
                if (jogo == null) return NotFound("Jogo não encontrado");

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarJogos")]
        public IActionResult ListarJogos()
        {
            try
            {
                var listaJogos = _service.ListarJogos();
                return Ok(listaJogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditarJogo")]
        public IActionResult EditarJogo([FromQuery] Guid id, [FromBody] GameDTO gameDto)
        {
            try
            {
                _service.EditarJogo(id, gameDto);
                return Ok("Jogo editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoverJogo")]
        public IActionResult RemoverJogo([FromQuery] Guid id)
        {
            try
            {
                _service.RemoverJogo(id);
                return Ok("Jogo removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}