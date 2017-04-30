using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.ViewModels.Landlord
{
    using System.ComponentModel.DataAnnotations;

    public class LandlordViewModel
    {
        public int Id { get; set; }
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
