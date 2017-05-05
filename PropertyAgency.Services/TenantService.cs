namespace PropertyAgency.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.PaginationModels;
    using PropertyAgency.Models.ViewModels.Tenant;

    public class TenantService : Service
    {
        private const int NumberOfItemsInPage = 20;
        public void AddTenant(TenantsBindingModel tenantsBindingModel)
        {
            Tenant tenant = Mapper.Map<Tenant>(tenantsBindingModel);
            this.Context.Tenants.Add(tenant);
            this.Context.SaveChanges();
        }


        /// <summary>
        /// This is the logic which will Display All Tenants and will separate them in pages and each page will show 20 items.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public TenantsViewModel GetAllTenants(int? page)
        {
            TenantsViewModel model = new TenantsViewModel();
            List<TenantViewModel> tenantsList = new List<TenantViewModel>();

            var tenants = this.Context.Tenants.OrderBy(m => m.Id).ToArray();

            if (page == null)
            {
                model.Pager = new Pager(tenants.Count(), 1, NumberOfItemsInPage);

                foreach (var tenant in tenants.Take(20))
                {
                    TenantViewModel tenantModel = Mapper.Map<Tenant, TenantViewModel>(tenant);
                    tenantsList.Add(tenantModel);
                }
                model.Tenants = tenantsList;
            }
            else
            {
                model.Pager = new Pager(tenants.Count(), (int)page, NumberOfItemsInPage);

                model.Tenants = Mapper.Instance.Map<IEnumerable<Tenant>, IEnumerable<TenantViewModel>>(
                    tenants.Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize));
            }
            return model;
        }

        public void Delete(int? id)
        {
            var tenant = this.Context.Tenants.Find(id);
            if (tenant != null)
            {
                this.Context.Tenants.Remove(tenant);
                this.Context.SaveChanges();
            }
        }
    }
}
