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
                    }
            );
        }
    }
}
