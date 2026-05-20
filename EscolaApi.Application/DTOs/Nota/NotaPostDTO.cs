using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Nota
{
    public class NotaPostDTO
    {
        [Required(ErrorMessage = "O campo MatriculaId é obrigatório.")]
        public int MatriculaId { get; set; }
        [Required(ErrorMessage = "O campo ValorNota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O campo ValorNota deve estar entre 0 e 100.")]
        public int ValorNota { get; set; }
    }
}
