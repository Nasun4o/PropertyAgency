namespace PropertyAgency.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PropertyAgency.Models.Enums;

    public class Property
    {
        public int Id { get; set; }

        public virtual Landlord Owner { get; set; }
        [Required(ErrorMessage = "Property Address is Required!")]
        [MinLength(4), MaxLength(30)]
        public string FullAddress { get; set; }
        [Required(ErrorMessage = "Property Size is Required!")]
        [Range(15,Double.MaxValue)]
        public double? ApartmentSize { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [Range(0, 30)]
        public int NumberOfRooms { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public bool IsActive { get; set; }
        /// <summary>
        /// This enumeration help us to know If the property will be on sales market or in rents market.
        /// </summary>
        [Required(ErrorMessage = "This field is Required!")]
        public PropertyType Type { get; set; }
        //TODO: Images should be array of pics
        public string UrlPicture { get; set; }
        [Required(ErrorMessage = "The price of the Property is Required!")]
        [Range(0, Double.MaxValue)]
        public decimal? Price { get; set; }

    }

}
