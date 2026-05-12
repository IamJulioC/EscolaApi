using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        public Task<Curso> AddAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Curso>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Curso> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> UpdateAsync(Curso curso)
        {
            throw new NotImplementedException();
        }
    }
}
