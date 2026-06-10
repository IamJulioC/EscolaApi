using EscolaApi.Application.DTOs.Nota;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaGetDTO>GetByIdAsync(int id);
        Task<PagedList<NotaGetDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<NotaGetDTO> AddAsync (NotaPostDTO notaPostDTO);
        Task<NotaGetDTO> UpdateAsync (NotaPutDTO notaPutDTO);
        Task<NotaGetDTO> DeleteAsync(int id);
        Task<PagedList<NotaGetDTO>> GetNotasByTurmaUsuario(int idTurma, int idUsuario, int pageNumber, int pageSize);
    }
}
