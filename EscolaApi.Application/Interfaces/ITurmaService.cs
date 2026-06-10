using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<TurmaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
        Task<PagedList<TurmaGetDetailDTO>> GetTurmasByUsuario(int idUsuario, int pageNumber, int pageSize);
    }
}
