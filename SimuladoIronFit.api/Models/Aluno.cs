
using System.ComponentModel.DataAnnotations;

namespace SimuladoIronFit.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Telefone { get; set; }

        [Required]
        public int PersonalId { get; set; }

        public Personal Personal { get; set; }
    }
}
