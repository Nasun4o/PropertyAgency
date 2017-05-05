namespace PropertyAgency.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PropertyAgency.Models.Enums;

    public class PropertyBindingModel
    {
        [Required(ErrorMessage = "Property Address is Required!")]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullAddress { get; set; }

        [Required(ErrorMessage = "Property Size is Required!")]
        [Range(15, Double.MaxValue)]
        public double? ApartmentSize { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [Range(0, 30)]
        public int NumberOfRooms { get; set; }


        //This will show us if the property is Avaible for Rent or Sale
        [Required(ErrorMessage = "This field is Required!")]
        public bool IsActive { get; set; }

        //This Enum is about the Type of Property(For Sale or Rent)
        [Required(ErrorMessage = "This field is Required!")]
        public PropertyType Type { get; set; }

        //TODO: Images should be Byte array form more Images
        public string UrlPicture { get; set; }

        [Required(ErrorMessage = "The price of the Property is Required!")]
        [Range(0, Double.MaxValue)]
        public decimal? Price { get; set; }

        public int LandlordId { get; set; }
    }
}