using EscolaApi.Application.DTOs.Nota;
using EscolaApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class NotaController : Controller
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNota(NotaPostDTO notaPostDTO)
        {
            var createdNota = await _notaService.AddAsync(notaPostDTO);
            if (createdNota == null)
            {
                return BadRequest("Não foi possível criar a nota.");
            }
            return Ok(new { message = "Nota incluída com sucesso." });
        }

        [HttpPut]

        public async Task<ActionResult> UpdateNota(NotaPutDTO notaPutDTO)
        {
            var updatedNota = await _notaService.UpdateAsync(notaPutDTO);
            if (updatedNota == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar a nota.");
            }
            return Ok(new { message = "Nota atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNota(int id)
        {
            var deletedNota = await _notaService.DeleteAsync(id);
            if (deletedNota == null)
            {
                return BadRequest("Ocorreu um erro ao excluir esta nota.");
            }
            return Ok(new { message = "Nota excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotaById(int id)
        {
            var nota = await _notaService.GetByIdAsync(id);
            if (nota == null)
            {
                return NotFound("Nota não encontrada.");
            }
            return Ok(nota);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotas()
        {
            var notas = await _notaService.GetAllAsync();
            return Ok(notas);
        }

    }
}
