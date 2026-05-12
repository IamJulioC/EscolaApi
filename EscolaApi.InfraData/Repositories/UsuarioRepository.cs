using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario> AddAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
