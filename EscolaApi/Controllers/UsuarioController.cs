using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Account;
using EscolaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticateService _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticateService authenticate)
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

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUsuario(UserLogin userLogin)
        {            
            var usuario = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Senha);

            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }
    }
}
