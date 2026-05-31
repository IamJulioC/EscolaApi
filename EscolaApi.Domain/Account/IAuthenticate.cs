using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Account
{
    public interface IAuthenticate
    {
        string GenerateToken(int id, string email, string role);
        Task<Usuario> GetUsuarioByEmail(string email);
        Task<bool> UserExists(string email);
    }
}
