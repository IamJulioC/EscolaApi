using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Nota
{
    public class NotaPostDTO
    {
        [Required(ErrorMessage = "A matricula é obrigatória.")]
        public int MatriculaId { get; set; }
        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e 100.")]
        public int ValorNota { get; set; }
    }
}
