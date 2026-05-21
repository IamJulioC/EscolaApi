using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Nota
{
    public class NotaPutDTO
    {
        [Required(ErrorMessage = "O indetificador da nota é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Matricula é obrigatória.")]
        public int MatriculaId { get; set; }
        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e 100.")]
        public int ValorNota { get; set; }

    }
}
