using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public string perfil { get; set; }
    }
}