using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using EscolaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.Repositories
{
    internal class CodigoRecuperacaoSenhaRepository : ICodigoRecuperacaoSenhaRepository
    {
        private readonly ApplicationDbContext _context;

        public CodigoRecuperacaoSenhaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CodigoRecuperacaoSenha codigoRecuperacaoSenha)
        {
            _context.CodigoRecuperacaoSenha.Add(codigoRecuperacaoSenha);
            await _context.SaveChangesAsync();
        }

        public async Task<CodigoRecuperacaoSenha> GetAtivoByUsuarioAsync(int usuarioId)
        {
            var dataAgora = DateTime.UtcNow;

            return await _context.CodigoRecuperacaoSenha
                .Where(x => x.UsuarioId == usuarioId 
                && x.Utilizado == false && x.ExpiraEm > dataAgora)
                .OrderByDescending(x => x.CriadoEm)
                .FirstOrDefaultAsync();
        }

        public async Task InvalidarAtivosAsync(int usuarioId)
        {
           await _context.CodigoRecuperacaoSenha
                .Where(x => x.UsuarioId == usuarioId && x.Utilizado == false)
                .ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Utilizado, true));
        }

        public async Task UpdateAsync(CodigoRecuperacaoSenha codigoRecuperacaoSenha)
        {
            _context.CodigoRecuperacaoSenha.Update(codigoRecuperacaoSenha);
            await _context.SaveChangesAsync();
        }
    }
}
