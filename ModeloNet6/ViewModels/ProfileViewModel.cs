using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        [Display(Prompt = "Usuario")]
        public string usuario { get; set; }


        [DataType(DataType.Password)]
        public string senha { get; set; }


        [Compare("senha")]
        [DataType(DataType.Password)]
        public string senhaConfirmacao { get; set; }

        [Required]
        public string perfil { get; set; }
    }
}
