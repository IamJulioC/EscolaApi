using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations
using System.Text;

namespace EscolaApi.Application.DTOs.Usuario
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo Nome deve conter no máximo 250 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O campo Email deve conter no máximo 200 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength (8, ErrorMessage = "O campo Senha deve conter no mínimo 8 caracteres.")]
        [MaxLength(250, ErrorMessage = "O campo Senha deve conter no máximo 250 caracteres.")]
        public string Senha { get; set; }
    }
}
