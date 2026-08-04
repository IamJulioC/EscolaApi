using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<UsuarioGetDTO> AuthenticateAsync(string email, string senha);
        string GenerateToken(int id, string email, string role);
    }
}
