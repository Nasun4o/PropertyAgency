﻿namespace PropertyAgency.Models.EntityModels
{
    using PropertyAgency.Models.Enums;

    public class Property
    {
        public int Id { get; set; }

        public virtual Landlord Owner { get; set; }

        public string FullAddress { get; set; }

        public double? ApartmentSize { get; set; }

        public int NumberOfRooms { get; set; }

        public bool IsActive { get; set; }
        //For Rent or for Sale
        public PropertyType Type { get; set; }
        //TODO: Images should be array of pics
        public string UrlPicture { get; set; }
   
        public decimal? Price { get; set; }
    }

}
