namespace PropertyAgency.Models.ViewModels.Landlord
{
    using System.Collections.Generic;
    using PropertyAgency.Models.PaginationModels;

    public class LandlordsViewModel
    {
        public IEnumerable<LandlordViewModel> Landlords { get; set; }

        public Pager Pager { get; set; }
    }
}
