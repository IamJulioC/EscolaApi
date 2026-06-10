using EscolaApi.Application.DTOs.Nota;
using EscolaApi.Application.Interfaces;
using EscolaApi.Extensions;
using EscolaApi.Infra.Ioc;
using EscolaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : Controller
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]

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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetAllNotas([FromQuery] PaginationParams paginationParams)
        {
            var notas = await _notaService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, notas.TotalCount, notas.TotalPages));
            return Ok(notas);
        }


        [HttpGet("user/turma/{id}")]
        [Authorize(Roles = "Aluno, Administrador")]
        public async Task<ActionResult> GetAllNotasByTurmaUsuario([FromQuery] PaginationParams paginationParams, int id)
        {
            var userId = User.GetUserId();
            var notas = await _notaService.GetNotasByTurmaUsuario(paginationParams.PageNumber, paginationParams.PageSize, id, userId);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, notas.TotalCount, notas.TotalPages));
            return Ok(notas);
        }

    }
}
