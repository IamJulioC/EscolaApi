using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;  
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        public Task<Matricula> AddAsync(Matricula matricula)
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Matricula>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> UpdateAsync(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}
