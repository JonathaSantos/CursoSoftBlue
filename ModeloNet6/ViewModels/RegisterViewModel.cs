using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha precisa ter entre 6 e 20 caracteres")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string senha { get; set; }

        [Required]
        [Compare("senha")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Confirmar o Password")]
        public string senhaConfirmacao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Perfil do Usuário")]
        public string perfil { get; set; }
    }
}