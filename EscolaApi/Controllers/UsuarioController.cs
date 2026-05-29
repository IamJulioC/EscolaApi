
using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            await _usuarioService.AddAsync(usuarioPostDTO);
            return Ok(new { message = "Usuário criado com sucesso!" });
        }
    }
}
