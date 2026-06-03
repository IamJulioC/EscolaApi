using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
        {
            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);            
            return Ok(new { message = "Turma incluída com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
        {
            var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);            
            return Ok(new { message = "Turma atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);            
            return Ok(new { message = "Turma excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetByIdAsync(id);            
            return Ok(turma);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTurmas()
        {
            var turmas = await _turmaService.GetAllAsync();
            return Ok(turmas);
        }

    }
}
