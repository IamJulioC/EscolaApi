using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Curso
{
    public class CursoPutDTO
    {
        [Required(ErrorMessage = "O campo Id do curso é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome do curso é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O campo nome do curso deve conter no máximo 80 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [MaxLength(180, ErrorMessage = "O campo descrição do curso deve conter no máximo 180 caracteres.")]
        public string Descricao { get; set; }
    }
}
