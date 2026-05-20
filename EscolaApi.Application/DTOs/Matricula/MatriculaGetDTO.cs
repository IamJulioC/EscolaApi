using EscolaApi.Application.DTOs.Turma;
using EscolaApi.Application.DTOs.Usuario;
using EscolaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.DTOs.Matricula
{
    public class MatriculaGetDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativa { get; set; }
    }
}
