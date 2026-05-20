using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.DTOs.Turma
{
    public class TurmaGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CursoId { get; set; }
    }
}
