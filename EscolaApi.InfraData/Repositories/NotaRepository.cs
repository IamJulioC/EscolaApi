
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
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _context;
        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Nota.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota> DeleteAsync(int id)
        {
            var nota = await _context.Nota.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
            if (nota == null)
            {
                return null;
            }
            nota.Excluido = true;
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<PagedList<Nota>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Nota.Where(x => x.Excluido == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Nota>> GetNotasByTurmaUsuario(int idTurma, int idUsuario, int pageNumber, int pageSize)
        {
            var query = _context.Nota.Where(x => x.Excluido == false && x.Matricula.TurmaId == idTurma && x.Matricula.UsuarioId == idUsuario && x.Matricula.Excluido == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}