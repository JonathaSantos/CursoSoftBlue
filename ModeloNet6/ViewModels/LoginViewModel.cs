using ModeloNet6.Interface;
using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{
    public class LoginViewModel: ILoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Prompt = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string senha { get; set; }
    }
}
