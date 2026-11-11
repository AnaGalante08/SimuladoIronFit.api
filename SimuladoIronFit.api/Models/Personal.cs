
using System.ComponentModel.DataAnnotations;

namespace SimuladoIronFit.Api.Models
{
    public class Personal
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        public string Telefone { get; set; }
    }
}
