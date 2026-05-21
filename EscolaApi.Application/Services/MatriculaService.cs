using EscolaApi.Application.DTOs.Matricula;
using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
        {
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
                return null;
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

        public async Task<List<MatriculaGetDetailDTO>> GetAllAsync()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();
            var matriculaGetDetailDTOs = new List<MatriculaGetDetailDTO>();
            matriculaGetDetailDTOs.AddRange(matriculas.Select(matricula => new MatriculaGetDetailDTO
            {
                Id = matricula.Id,
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao
                }
            }));
            return matriculaGetDetailDTOs;
        }

        public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                return null;
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
                    Email = matricula.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao
                }
            };
        }

        public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
        {
            var matricula = new Matricula
            {
                Id = matriculaPutDTO.Id,
                TurmaId = matriculaPutDTO.TurmaId,
                DataExpiracao = matriculaPutDTO.DataExpiracao
            };
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
