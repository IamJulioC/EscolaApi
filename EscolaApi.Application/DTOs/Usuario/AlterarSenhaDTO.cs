using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EscolaApi.Application.DTOs.Usuario
{
    public class AlterarSenhaDTO
    {
        [Required(ErrorMessage = "A senha atual é obrigatória.")]       
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "A nova senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A nova senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(250, ErrorMessage = "A nova senha deve ter no máximo 250 caracteres.")]
        public string NovaSenha { get; set; }
    }
}
