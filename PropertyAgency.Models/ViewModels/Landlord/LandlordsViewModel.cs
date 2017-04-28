using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.ViewModels.Landlord
{
    public class LandlordsViewModel
    {
        public IEnumerable<LandlordViewModel> Landlords { get; set; }
    }
}
