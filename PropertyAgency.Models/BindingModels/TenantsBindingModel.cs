namespace PropertyAgency.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class TenantsBindingModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Client Name is Required!")]
        [MinLength(4), MaxLength(20)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Client Phone number is Required!")]
        [MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }

        //What Client looking for ? Should be Updated by the Broker.
        [Required(ErrorMessage = "Minimum characters20, Maximum characters 300")]
        [MinLength(20), MaxLength(300)]
        public string Description { get; set; }
    }
}
