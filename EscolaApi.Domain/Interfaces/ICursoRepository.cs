using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> GetByIdAsync(int id);
        Task<PagedList<Curso>> GetAllAsync(int pageNumber, int pageSize);
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<Curso> DeleteAsync(int id);
    }
}
