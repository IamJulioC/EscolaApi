using EscolaApi.Application.DTOs.Turma;
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
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
        {
            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);            
            return Ok(new { message = "Turma incluída com sucesso." });
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
        {
            var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);            
            return Ok(new { message = "Turma atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);            
            return Ok(new { message = "Turma excluída com sucesso." });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetByIdAsync(id);            
            return Ok(turma);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetAllTurmas([FromQuery] PaginationParams paginationParams)
        {
            var turmas = await _turmaService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, turmas.TotalCount, turmas.TotalPages));
            return Ok(turmas);
        }

        [HttpGet("user")]
        [Authorize(Roles = "Aluno, Administrador")]
        public async Task<ActionResult> GetAllTurmasByUsuario([FromQuery] PaginationParams paginationParams)
        {
            var userId = User.GetUserId();

            var turmas = await _turmaService.GetTurmasByUsuario(paginationParams.PageNumber, paginationParams.PageSize, userId);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, turmas.TotalCount, turmas.TotalPages));
            return Ok(turmas);
        }

    }
}
