using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> GetByIdAsync(int id);
        Task<PagedList<Turma>> GetAllAsync(int pageNumber, int pageSize);
        Task<Turma> AddAsync(Turma turma);
        Task<Turma> UpdateAsync(Turma turma);
        Task<Turma> DeleteAsync(int id);
        Task<PagedList<Turma>> GetTurmasByUsuario(int idUsuario, int pageNumber, int pageSize);
    }
}
