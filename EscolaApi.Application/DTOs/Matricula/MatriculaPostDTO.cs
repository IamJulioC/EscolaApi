using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Matricula
{
    public class MatriculaPostDTO
    {
        [Required(ErrorMessage = "O campo UsuarioId é obrigatório.")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo TurmaId é obrigatório.")]
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "O campo Data de expiração é obrigatório.")]
        public DateTime DataExpiracao { get; set; }
    }
}
