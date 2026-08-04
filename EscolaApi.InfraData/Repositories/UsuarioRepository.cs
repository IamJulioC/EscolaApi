using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using EscolaApi.Domain.Pagination;
using EscolaApi.Infra.Data.Context;
using EscolaApi.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
            if (usuario == null) 
            {
                return null;
            }

            usuario.Excluido = true;
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ExisteUsuarioAsync()
        {
            return await _context.Usuario.AnyAsync(x => x.Excluido == false);
        }
        public async Task<PagedList<Usuario>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Usuario.Where(x => x.Excluido == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuario.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Usuario.AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.Excluido == false);
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
