namespace PropertyAgency.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class LandlordsBindingModel
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Client Name is Required!")]
        [StringLength(20, MinimumLength = 2)]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Client Phone number is Required!")]
        [MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsAcceptingAnimals { get; set; }
    }
}
