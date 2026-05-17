
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        public Task<Turma> AddAsync(Turma turma)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Turma>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Turma> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> UpdateAsync(Turma turma)
        {
            throw new NotImplementedException();
        }
    }
}