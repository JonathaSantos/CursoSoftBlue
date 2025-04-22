using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{
    public class UsuariosViewModel
    {
        [DataType(DataType.Text)]
        [Display(Prompt = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Perfil do Usuário")]
        public string perfil { get; set; }
    }
}