using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Application.Exceptions;
using EscolaApi.Application.Interfaces;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Interfaces;
using EscolaApi.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EscolaApi.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            var usuarioExistente = await _usuarioRepository.UserExists(usuarioPostDTO.Email);

            if (usuarioExistente)
                throw new BadRequestException("Já existe um usuário com este email.");

            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var existeUsuario = await _usuarioRepository.ExisteUsuarioAsync();

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                Email = usuarioPostDTO.Email,
                Excluido = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = existeUsuario ? "Aluno" : "Administrador"
            };

            var createdUsuario = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = createdUsuario.Id,
                Nome = createdUsuario.Nome,
                Email = createdUsuario.Email,
                Perfil = createdUsuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> DeleteAsync(int id)
        {
            var deletedUsuario = await _usuarioRepository.DeleteAsync(id);
            if (deletedUsuario == null)
                throw new NotFoundException("Usuário não encontrado.");
            return new UsuarioGetDTO
            {
                Id = deletedUsuario.Id,
                Nome = deletedUsuario.Nome,
                Email = deletedUsuario.Email,
                Perfil = deletedUsuario.Perfil
            };
        }

        public async Task<bool> ExisteUsuarioAsync()
        {
            return await _usuarioRepository.ExisteUsuarioAsync();
        }

        public async Task<PagedList<UsuarioGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var usuarios = await _usuarioRepository.GetAllAsync(pageNumber, pageSize);
            var usuarioDTOs = new List<UsuarioGetDTO>();
            usuarioDTOs.AddRange(usuarios.Select(u => new UsuarioGetDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Perfil = u.Perfil,
            }).ToList());
            return new PagedList<UsuarioGetDTO>(usuarioDTOs, usuarios.TotalCount, pageNumber, pageSize);
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado.");
            return new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> GetUsuarioByEmail(string email)
        {
            var usuario = await _usuarioRepository.GetUsuarioByEmail(email);
            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado.");
            return new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome= usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado.");
            usuario.Nome = usuarioPutDTO.Nome;

            if(usuarioPutDTO.Email != usuario.Email)
            {
                var usuarioExistente = await _usuarioRepository.UserExists(usuarioPutDTO.Email);
                if (usuarioExistente)
                    throw new BadRequestException("O e-mail informado já está em uso!");

                usuario.Email = usuarioPutDTO.Email;
            }
                        
            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = updatedUsuario.Id,
                Nome = updatedUsuario.Nome,
                Email = updatedUsuario.Email,
                Perfil = updatedUsuario.Perfil
            };
        }
    }
}
