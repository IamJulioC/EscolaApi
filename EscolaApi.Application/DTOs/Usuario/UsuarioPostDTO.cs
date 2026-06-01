using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Usuario
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo nome deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O e-mail deve ter no máximo 200 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength (8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        public string Senha { get; set; }
    }
}
