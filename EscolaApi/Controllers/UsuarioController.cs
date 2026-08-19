using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Account;
using EscolaApi.Extensions;
using EscolaApi.Infra.Ioc;
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

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetUsuarios([FromQuery] PaginationParams paginationParams)
        {
            var usuarios = await _usuarioService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(
                new PaginationHeader(usuarios.CurrentPage, usuarios.PageSize, usuarios.TotalCount, usuarios.TotalPages));

            return Ok(usuarios);
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUsuario(UserLogin userLogin)
        {
            var usuario = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Senha);

            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
            return Ok(new { Nome = usuario.Nome, Token = token });
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUsuario(UsuarioPutDTO usuarioPutDTO)
        {
            await _usuarioService.UpdateAsync(User.GetUserId(),usuarioPutDTO);
            return Ok(new {message = "Usuário atualizado com sucesso!"});

        }

        [HttpPut("senha")]
        [Authorize]
        public async Task<ActionResult> AlterarSenha(AlterarSenhaDTO alterarSenhaDTO)
        {
            await _usuarioService.AlterarSenhaAsync(User.GetUserId(), alterarSenhaDTO);
            return Ok(new { message = "Senha alterada com sucesso!" });
        }
    }
}
