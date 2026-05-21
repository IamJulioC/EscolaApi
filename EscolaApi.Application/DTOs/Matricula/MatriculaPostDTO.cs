using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Matricula
{
    public class MatriculaPostDTO
    {
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "A Turma é obrigatória.")]
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "O campo data de expiração é obrigatório.")]
        public DateTime DataExpiracao { get; set; }
    }
}
