namespace PropertyAgency.Application
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;

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
                        expression.CreateMap<TenantsBindingModel, Tenant>();
                        expression.CreateMap<Landlord, LandlordViewModel>();
                        expression.CreateMap<PropertyBindingModel, Property>();
                        expression.CreateMap<Property, PropertyInfoViewModel>()
                            .ForMember(ld => ld.LandlordName,
                             configurationExpression => configurationExpression.MapFrom(t => t.Owner.FullName));
                    }
            );
        }
    }
}
