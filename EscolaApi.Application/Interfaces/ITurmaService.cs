using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaGetDetailDTO> GetByIdAsync(int id);
        Task<List<TurmaGetDetailDTO>> GetAllAsync();
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
    }
}
