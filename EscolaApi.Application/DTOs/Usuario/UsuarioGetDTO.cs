using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.DTOs.Usuario
{
    public class UsuarioGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
