using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Turma> Turmas { get; set; }
    }
}
