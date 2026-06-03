using EscolaApi.Application.DTOs.Curso;
using EscolaApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCurso (CursoPostDTO cursoPostDTO ) 
        {
            var result = await _cursoService.AddAsync(cursoPostDTO);
            if (result == null)
            {
                return BadRequest("Não foi possível criar o curso.");
            }
            return Ok(new { message = "Cruso incluído com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
        {
            var result = await _cursoService.UpdateAsync(cursoPutDTO);
            if (result == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar este curso.");
            }
            return Ok(new { message = "Curso atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCurso(int id)
        {
            var result = await _cursoService.DeleteAsync(id);
            if (result == null)
            {
                return BadRequest("Ocorreu um erro ao excluir este curso.");
            }
            return Ok(new { message = "Curso excluído com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCursoById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(curso);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCursos()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }

    }
}
