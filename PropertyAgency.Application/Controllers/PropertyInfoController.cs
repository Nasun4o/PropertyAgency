namespace PropertyAgency.Application.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Models.ViewModels.Tenant;
    using PropertyAgency.Services;

    [Authorize]
    [RoutePrefix("Properties")]
    public class PropertyInfoController : Controller
    {
        private PropertyService propertyService;
        private LandlordService landlordService;
        private TenantService tenantService;

        public PropertyInfoController()
        {
            this.propertyService = new PropertyService();
            this.landlordService = new LandlordService();
            this.tenantService = new TenantService();
        }
        [HttpGet]
        [Route("ShowAll")]
        public ActionResult ShowAll(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperies(page);
            return this.View(model);
        }

        [HttpGet]
        [Route("Show/Rent/")]
        public ActionResult Rent(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForRent(page);
            return this.View(model);
        }
        [HttpGet]
        [Route("Show/Sale/")]
        public ActionResult Sale(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForSale(page);
            return this.View(model);
        }
        [HttpGet]
        [Route("Show/Landlords")]
        public ActionResult Landlords(int? page)
        {
            LandlordsViewModel model = this.landlordService.GetAllLandlords(page);
            return this.View(model);
        }
        [HttpGet]
        [Route("Show/Tenants")]
        public ActionResult Tenants(int? page)
        {
            TenantsViewModel model = this.tenantService.GetAllTenants(page);
            return this.View(model);
        }
    }
}