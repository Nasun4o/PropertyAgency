using System.Collections.Generic;

namespace PropertyAgency.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Landlord
    {
        public Landlord()
        {
            this.Properties = new List<Property>();
        }
        public int Id { get; set; }
  
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "Client Name is Required!")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Client Phone number is Required!")]
        [MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
        [Required]
        public bool IsAcceptingAnimals { get; set; }

    }
}
