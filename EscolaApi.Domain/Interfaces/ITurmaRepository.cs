using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> GetByIdAsync(int id);
        Task<List<Turma>> GetAllAsync();
        Task<Turma> AddAsync(Turma turma);
        Task<Turma> UpdateAsync(Turma turma);
        Task<Turma> DeleteAsync(int id);
        Task<List<Turma>> GetTurmasByUsuario(int idUsuario);
    }
}
