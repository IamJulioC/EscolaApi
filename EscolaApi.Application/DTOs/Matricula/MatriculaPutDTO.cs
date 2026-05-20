using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Matricula
{
    public class MatriculaPutDTO
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo TurmaId é obrigatório.")]
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "O campo Data de expiração é obrigatório.")]
        public DateTime DataExpiracao { get; set; }
    }
}
