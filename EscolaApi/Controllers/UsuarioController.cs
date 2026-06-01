
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
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            var userExists = await _authenticate.UserExists(usuarioPostDTO.Email);
            if (userExists)
                return BadRequest(new { Message = "Usuário já existe." });
            var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUsuario(UserLogin userLogin)
        {
            var usuario = await _authenticate.GetUsuarioByEmail(userLogin.Email);
            if (usuario == null)
                return BadRequest(new { Message = "Usuário ou senha inválidos." });

            var usuarioValido = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Senha);
            if (!usuarioValido)
                return BadRequest(new { Message = "Usuário ou senha inválidos." });
            
            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }

    }
}
