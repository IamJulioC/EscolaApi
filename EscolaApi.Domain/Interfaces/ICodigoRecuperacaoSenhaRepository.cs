using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Interfaces
{
    public interface ICodigoRecuperacaoSenhaRepository
    {
        Task AddAsync(CodigoRecuperacaoSenha codigoRecuperacaoSenha);
        Task  <CodigoRecuperacaoSenha> GetAtivoByUsuarioAsync(int usuarioId);
        Task InvalidarAtivosAsync(int usuarioId);
        Task UpdateAsync(CodigoRecuperacaoSenha codigoRecuperacaoSenha);
    }
}
