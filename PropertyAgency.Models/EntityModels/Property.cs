namespace PropertyAgency.Models.EntityModels
{
    using PropertyAgency.Models.Enums;

    public class Property
    {
        public int Id { get; set; }

        public virtual PropertyOwner Owner { get; set; }

        public string FullAddress { get; set; }

        public double? ApartmentSize { get; set; }

        public int NumberOf0Rooms { get; set; }

        public bool IsActive { get; set; }
        //For Rent or for Sale
        public PropertyType Type { get; set; }
        //TODO: Images should be array of pics
        public string UrlPicture { get; set; }

        public decimal? Price { get; set; }
    }

}
