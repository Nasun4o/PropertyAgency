using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Controllers
{
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Services;
    [Authorize]
    [RoutePrefix("Properties")]
    public class PropertyInfoController : Controller
    {
        private PropertyService service;

        public PropertyInfoController()
        {
            this.service = new PropertyService();
        }
        // GET: PropertyInfo
        //[Route("Properties/Properties")]
        //public ActionResult Properties()
        //{
        //    return View();
        //}

        [Route("Show/Rent/")]
        public ActionResult Rent()
        {
            ShowPropertiesViewModel model = this.service.GetProperiesForRent();
            return this.View(model);
        }
        [Route("Show/Sale/")]
        public ActionResult Sale()
        {
            ShowPropertiesViewModel model = this.service.GetProperiesForSale();
            return this.View(model);
        }
    }
}