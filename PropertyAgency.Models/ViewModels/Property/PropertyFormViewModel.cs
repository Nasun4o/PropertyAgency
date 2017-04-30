namespace PropertyAgency.Models.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PropertyAgency.Models.Enums;
    using PropertyAgency.Models.ViewModels.Landlord;

    public class PropertyFormViewModel
    {
        public PropertyFormViewModel()
        {
            this.LandlordsList = new List<LandlordViewModel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Property Address is Required!")]
        [MinLength(4), MaxLength(30)]
        public string FullAddress { get; set; }

        [Required(ErrorMessage = "Property Size is Required!")]
        [Range(15, Double.MaxValue)]
        public double? ApartmentSize { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [Range(0, 30)]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public bool IsActive { get; set; }
        //For Rent or for Sale
        [Required(ErrorMessage = "This field is Required!")]
        public PropertyType Type { get; set; }
        //TODO: Images should be array of pics
        [Required(ErrorMessage = "Picture Address is Required!")]
        public string UrlPicture { get; set; }

        [Required(ErrorMessage = "The price of the Property is Required!")]
        [Range(0, Double.MaxValue)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Landlord is Required!")]
        public IEnumerable<LandlordViewModel> LandlordsList { get; set; }

        public int LandlordId { get; set; }
    }
}
