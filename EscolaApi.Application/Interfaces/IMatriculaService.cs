using EscolaApi.Application.DTOs.Curso;
using EscolaApi.Application.DTOs.Matricula;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<MatriculaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO);
        Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO);
        Task<MatriculaGetDTO> DeleteAsync(int id);
    }
}
