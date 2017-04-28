namespace PropertyAgency.Models.ViewModels.Property
{
    using System.Collections;
    using PropertyAgency.Models.EntityModels;

    public class PropertyInfoViewModel
    {
        public int Id { get; set; }

        public string FullAddress { get; set; }

        public double? ApartmentSize { get; set; }

        public int NumberOfRooms { get; set; }

        public bool IsActive { get; set; }
        //TODO: Images should be array of pics
        public string UrlPicture { get; set; }

        public decimal? Price { get; set; }

        public string LandlordName { get; set; }

    }
}
