using System.ComponentModel.DataAnnotations;

namespace NetCoreAula.ViewModels
{

    public class ItemViewModel
    {
        [Required]
        [Display(Prompt = "Description")]
        public string Description { get; set; }
    }
}
