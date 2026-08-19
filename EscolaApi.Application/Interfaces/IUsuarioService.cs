using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetByIdAsync(int id);
        Task<PagedList<UsuarioGetDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
        Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioGetDTO> DeleteAsync(int id);
        Task<bool> ExisteUsuarioAsync();
        Task<UsuarioGetDTO> GetUsuarioByEmail(string email);
        Task AlterarSenhaAsync(int usuarioId, AlterarSenhaDTO alterarSenhaDTO);
    }
}
