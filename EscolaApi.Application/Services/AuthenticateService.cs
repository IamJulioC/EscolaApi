using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Exceptions;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class AuthenticateService : IAuthenticateService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthenticateService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioGetDTO> AuthenticateAsync(string email, string senha)
    {
        var usuario = await _usuarioRepository.GetUsuarioByEmail(email);
        if (usuario == null || usuario.Excluido)
            throw new BadRequestException("Usuário ou senha inválidos");

        using var hmac = new HMACSHA512(usuario.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

        if (!computedHash.SequenceEqual(usuario.PasswordHash)) // veja observação abaixo
            throw new BadRequestException("Usuário ou senha inválidos");

        return new UsuarioGetDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Perfil = usuario.Perfil
        };
    }

    public string GenerateToken(int id, string email, string role)
    {
        // sua lógica real de geração do JWT deve entrar aqui
        throw new NotImplementedException();
    }
}