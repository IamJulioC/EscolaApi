using EscolaApi.Application.DTOs.Curso;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Application.DTOs.Turma
{
    public class TurmaGetDetailDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CursoGetDTO Curso { get; set; }
    }
}
