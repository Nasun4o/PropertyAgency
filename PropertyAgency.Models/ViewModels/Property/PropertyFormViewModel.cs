using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.ViewModels.Property
{
    using PropertyAgency.Models.Enums;
    using PropertyAgency.Models.ViewModels.Landlord;

    public class PropertyFormViewModel
    {

        public string FullAddress { get; set; }

        public double? ApartmentSize { get; set; }

        public int NumberOf0Rooms { get; set; }

        public bool IsActive { get; set; }
        //For Rent or for Sale
        public PropertyType Type { get; set; }
        //TODO: Images should be array of pics
        public string UrlPicture { get; set; }

        public decimal? Price { get; set; }

        public IEnumerable<LandlordViewModel> LandlordsList { get; set; }

        public int LandlordId { get; set; }
    }
}
