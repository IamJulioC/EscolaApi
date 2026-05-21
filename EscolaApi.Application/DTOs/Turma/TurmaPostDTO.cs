using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Turma
{
    public class TurmaPostDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [MaxLength(180, ErrorMessage = "A descrição deve ter no máximo 180 caracteres.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O curso é obrigatório.")]
        public int CursoId { get; set; }
    }
}
