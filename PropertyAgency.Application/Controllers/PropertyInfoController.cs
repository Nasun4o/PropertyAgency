namespace PropertyAgency.Application.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Models.ViewModels.Tenant;
    using PropertyAgency.Services;

    /// <summary>
    /// This Controller is used to Show our information about Properties and Clients
    /// </summary>
    [Authorize]
    [RoutePrefix("Properties")]
    public class PropertyInfoController : Controller
    {
        private readonly PropertyService propertyService;
        private readonly LandlordService landlordService;
        private readonly TenantService tenantService;

        public PropertyInfoController()
        {
            this.propertyService = new PropertyService();
            this.landlordService = new LandlordService();
            this.tenantService = new TenantService();
        }

        /// <summary>
        /// Here we Show All our Properties no matter what type are they (Sale or Rent)
        /// </summary>
        /// <param name="page">This param is send to our Pager or Pagination which will separate our data in pages with size of 10 or 20 items</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowAll")]
        public ActionResult ShowAll(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperies(page);
            return this.View(model);
        }

        /// <summary>
        /// Here we Show only the properties that are under a Rent.
        /// </summary>
        /// <param name="page">The same as the Previous Action</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Show/Rent/")]
        public ActionResult Rent(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForRent(page);
            return this.View(model);
        }

        /// <summary>
        /// Here we Show only the properties that are for Sale.
        /// </summary>
        /// <param name="page">The same as the Previous Action</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Show/Sale/")]
        public ActionResult Sale(int? page)
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForSale(page);
            return this.View(model);
        }
        /// <summary>
        /// Here we Show our Landlords.
        /// </summary>
        /// <param name="page">The same as the Previous Action</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Show/Landlords")]
        public ActionResult Landlords(int? page)
        {
            LandlordsViewModel model = this.landlordService.GetAllLandlords(page);
            return this.View(model);
        }
        /// <summary>
        /// Here we Show our Tenants.
        /// </summary>
        /// <param name="page">The same as the Previous Action</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Show/Tenants")]
        public ActionResult Tenants(int? page)
        {
            TenantsViewModel model = this.tenantService.GetAllTenants(page);
            return this.View(model);
        }
    }
}