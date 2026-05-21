using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetByIdAsync(int id);
        Task<List<UsuarioGetDTO>> GetAllAsync();
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
        Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioGetDTO> DeleteAsync(int id);
    }
}
