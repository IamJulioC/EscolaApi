using System.ComponentModel.DataAnnotations;

namespace EscolaApi.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O e-mail deve ter no máximo 200 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        public string Senha { get; set; }
    }
}
