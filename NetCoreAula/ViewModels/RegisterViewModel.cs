using System;
using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Prompt = "Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Prompt = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}
