using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Controllers
{
    using Models.ViewModels.Landlord;
    using Models.ViewModels.Tenant;
    using PropertyAgency.Models.ViewModels.Property;
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

        [Route("Show/Rent/")]
        public ActionResult Rent()
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForRent();
            return this.View(model);
        }
        [Route("Show/Sale/")]
        public ActionResult Sale()
        {
            ShowPropertiesViewModel model = this.propertyService.GetProperiesForSale();
            return this.View(model);
        }
        [Route("Show/Landlords")]
        public ActionResult Landlords()
        {
            LandlordsViewModel model = this.landlordService.GetAllLandlords();
            return this.View(model);
        }
        [Route("Show/Tenants")]
        public ActionResult Tenants()
        {
            TenantsViewModel model = this.tenantService.GetAllTenants();
            return this.View(model);
        }
    }
}