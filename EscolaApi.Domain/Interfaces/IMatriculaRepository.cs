using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> GetByIdAsync(int id);
        Task<PagedList<Matricula>> GetAllAsync(int pageNumber, int pageSize);
        Task<Matricula> AddAsync(Matricula matricula);
        Task<Matricula> UpdateAsync(Matricula matricula);
        Task<Matricula> DeleteAsync(int id);
    }
}
