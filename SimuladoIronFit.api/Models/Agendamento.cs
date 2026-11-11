
using System;
using System.ComponentModel.DataAnnotations;

namespace SimuladoIronFit.Api.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int PersonalId { get; set; }

        [Required]
        public DateTime DataAgendamento { get; set; }

        public Aluno Aluno { get; set; }

        public Personal Personal { get; set; }
    }
}
