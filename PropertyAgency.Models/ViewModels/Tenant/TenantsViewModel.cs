using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.ViewModels.Tenant
{
    public class TenantsViewModel
    {
        public IEnumerable<TenantViewModel> Tenants { get; set; }
    }
}
