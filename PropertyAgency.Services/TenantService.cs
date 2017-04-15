using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;

    public class TenantService : Service
    {
        public void AddTenant(TenantsBindingModel tenantsBindingModel)
        {
            Tenant tenant = Mapper.Map<Tenant>(tenantsBindingModel);
            this.Context.Tenants.Add(tenant);
            this.Context.SaveChanges();
        }
    }
}
