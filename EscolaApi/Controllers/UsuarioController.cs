
using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }
    }
}
