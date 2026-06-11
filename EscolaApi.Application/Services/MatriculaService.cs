using EscolaApi.Application.DTOs.Matricula;
using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Exceptions;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITurmaRepository _turmaRepository;
        public MatriculaService(IMatriculaRepository matriculaRepository, IUsuarioRepository usuarioRepository, ITurmaRepository turmaRepository)
        {
            _matriculaRepository = matriculaRepository;
            _usuarioRepository = usuarioRepository;
            _turmaRepository = turmaRepository;
        }

        public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
        {
            if(await _usuarioRepository.GetByIdAsync(matriculaPostDTO.UsuarioId) == null)
                throw new NotFoundException($"Usuário não encontrado.");
            if (await _turmaRepository.GetByIdAsync(matriculaPostDTO.TurmaId) == null)
                throw new NotFoundException($"Turma não encontrada.");

            var matricula = new Matricula
            {
                UsuarioId = matriculaPostDTO.UsuarioId,
                TurmaId = matriculaPostDTO.TurmaId,
                DataMatricula = DateTime.UtcNow,
                DataExpiracao = matriculaPostDTO.DataExpiracao,
                Ativa = true
            };

            var createdMatricula = await _matriculaRepository.AddAsync(matricula);
            return new MatriculaGetDTO
            {
                Id = createdMatricula.Id,
                UsuarioId = createdMatricula.UsuarioId,
                TurmaId = createdMatricula.TurmaId,
                DataMatricula = createdMatricula.DataMatricula,
                DataExpiracao = createdMatricula.DataExpiracao,
                Ativa = createdMatricula.Ativa
            };
        }

        public async Task<MatriculaGetDTO> DeleteAsync(int id)
        {
            var deletedMatricula = await _matriculaRepository.DeleteAsync(id);
            if (deletedMatricula == null)
                throw new NotFoundException($"Matrícula não encontrada.");
            return new MatriculaGetDTO
            {
                Id = deletedMatricula.Id,
                UsuarioId = deletedMatricula.UsuarioId,
                TurmaId = deletedMatricula.TurmaId,
                DataMatricula = deletedMatricula.DataMatricula,
                DataExpiracao = deletedMatricula.DataExpiracao,
                Ativa = deletedMatricula.Ativa
            };
        }

        public async Task<PagedList<MatriculaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var matriculas = await _matriculaRepository.GetAllAsync(pageNumber, pageSize);
            var matriculaGetDetailDTOs = matriculas.Select(matricula => new MatriculaGetDetailDTO
            {
                Id = matricula.Id,
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email,
                    Perfil = matricula.Usuario.Perfil
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao,
                    CursoId = matricula.Turma.CursoId
                }
            }).ToList();
            return new PagedList<MatriculaGetDetailDTO>(matriculaGetDetailDTOs, matriculas.CurrentPage, matriculas.PageSize, matriculas.TotalCount);
        }

        public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                throw new NotFoundException($"Matrícula não encontrada.");
            return new MatriculaGetDetailDTO
            {
                Id = matricula.Id,
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email,
                    Perfil = matricula.Usuario.Perfil
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao,
                    CursoId = matricula.Turma.CursoId
                }
            };
        }

        public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
        {
            if (await _turmaRepository.GetByIdAsync(matriculaPutDTO.TurmaId) == null)
                throw new NotFoundException($"Turma não encontrada.");
            if (await _matriculaRepository.GetByIdAsync(matriculaPutDTO.Id) == null)
                throw new NotFoundException($"Matrícula não encontrada.");

            var matricula = await _matriculaRepository.GetByIdAsync(matriculaPutDTO.Id);

            matricula.TurmaId = matriculaPutDTO.TurmaId;
            matricula.DataExpiracao = matriculaPutDTO.DataExpiracao;

            var updatedMatricula = await _matriculaRepository.UpdateAsync(matricula);
            if (updatedMatricula == null)
                return null;
            return new MatriculaGetDTO
            {
                Id = matriculaPutDTO.Id,
                UsuarioId = updatedMatricula.UsuarioId,
                TurmaId = updatedMatricula.TurmaId,
                DataMatricula = updatedMatricula.DataMatricula,
                DataExpiracao = updatedMatricula.DataExpiracao,
                Ativa = updatedMatricula.Ativa
            };
        }
    }
}
