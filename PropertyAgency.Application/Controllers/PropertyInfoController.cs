using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Controllers
{
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Services;
    [RoutePrefix("Properties")]
    public class PropertyInfoController : Controller
    {
        private PropertyService service;

        public PropertyInfoController()
        {
            this.service = new PropertyService();
        }
        // GET: PropertyInfo
        [Route("Properties/Properties")]
        public ActionResult Properties()
        {
            return View();
        }

        [Route("Properties/Show")]
        public ActionResult Show()
        {
            ShowPropertiesViewModel model = this.service.GetPropertyInfo();
            return this.View(model);
        }
    }
}