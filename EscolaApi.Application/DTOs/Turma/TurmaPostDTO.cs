using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Turma
{
    public class TurmaPostDTO
    {
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O nome do curso deve ter no máximo 80 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [MaxLength(180, ErrorMessage = "A descrição do curso deve ter no máximo 180 caracteres.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O ID do curso é obrigatório.")]
        public int CursoId { get; set; }
    }
}
