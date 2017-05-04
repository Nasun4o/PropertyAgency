namespace PropertyAgency.Application
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using Models.ViewModels.Tenant;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(
                expression =>
                    {
                        expression.CreateMap<LandlordsBindingModel, Landlord>();
                        expression.CreateMap<Landlord, LandlordViewModel>();
                        expression.CreateMap<LandlordsViewModel, Landlord>();
                        expression.CreateMap<PropertyFormViewModel, Property>();
                        expression.CreateMap<Property, PropertyInfoViewModel>()
                            .ForMember(ld => ld.LandlordName,
                             configurationExpression => configurationExpression.MapFrom(t => t.Owner.FullName));
                        expression.CreateMap<Property, PropertyFormViewModel>();
                        expression.CreateMap<TenantsBindingModel, Tenant>();
                        expression.CreateMap<TenantsViewModel, Tenant>();
                        expression.CreateMap<Tenant, TenantViewModel>();
                    }
            );
        }
    }
}
