using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Exceptions;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Account;
using EscolaApi.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class AuthenticateService : IAuthenticateService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthenticate _authenticate;

    public AuthenticateService(IUsuarioRepository usuarioRepository, IAuthenticate authenticate)
    {
        _usuarioRepository = usuarioRepository;
        _authenticate = authenticate;
    }

    public async Task<UsuarioGetDTO> AuthenticateAsync(string email, string senha)
    {
        var usuario = await _usuarioRepository.GetUsuarioByEmail(email);
        if (usuario == null || usuario.Excluido)
            throw new BadRequestException("Usuário ou senha inválidos");

        using var hmac = new HMACSHA512(usuario.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

        if (!computedHash.SequenceEqual(usuario.PasswordHash))
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
        return _authenticate.GenerateToken(id, email, role);
    }
}