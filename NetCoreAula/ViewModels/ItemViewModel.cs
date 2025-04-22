using System.ComponentModel.DataAnnotations;

namespace ModeloNet6.ViewModels
{

    public class ItemViewModel
    {
        [Required]
        [Display(Prompt = "Description")]
        public string Description { get; set; }
    }
}
