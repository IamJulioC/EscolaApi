using EscolaApi.Application.DTOs.Curso;
using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface ICursoService
    {
        Task<CursoGetDTO> GetByIdAsync(int id);
        Task<List<CursoGetDTO>> GetAllAsync();
        Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO);
        Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO);
        Task<CursoGetDTO> DeleteAsync(int id);
    }
}
