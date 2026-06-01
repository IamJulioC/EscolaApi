using EscolaApi.Domain.Account;
using EscolaApi.Domain.Entities;
using EscolaApi.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EscolaApi.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var usuario =  await _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
            if(usuario == null || usuario.Excluido)
                return false;

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.PasswordHash[i])
                    return false;
            }

            return true;
        }

        public string GenerateToken(int id, string email, string role)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email.ToLower()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
        }

        public Task<bool> UserExists(string email)
        {
            return _context.Usuario.AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
        }
    }
}
