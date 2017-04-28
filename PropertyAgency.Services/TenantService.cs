using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Services
{
    using AutoMapper;
    using Models.ViewModels.Tenant;
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

        public TenantsViewModel GetAllTenants()
        {
            TenantsViewModel model = new TenantsViewModel();
            List<TenantViewModel> tenantsList = new List<TenantViewModel>();

            var tenants = this.Context.Tenants;
            //TODO: AutoMapper has Configuration BUG!!!!
            foreach (var tenant in tenants)
            {
                TenantViewModel tenantModel = Mapper.Map<Tenant, TenantViewModel>(tenant);
                tenantsList.Add(tenantModel);
            }
            model.Tenants = tenantsList;
            return model;
        }
    }
}
