using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.ViewModels.Property
{
    using PropertyAgency.Models.PaginationModels;

    public class ShowPropertiesViewModel
    {
        public IEnumerable<PropertyInfoViewModel> PropertyInfoViewModels { get; set; }

        public Pager Pager { get; set; }
    }
}
