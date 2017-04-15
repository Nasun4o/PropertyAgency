using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Services;

    public class LandlordController : Controller
    {
        private LandlordService landlordService;

        public LandlordController()
        {
            this.landlordService = new LandlordService();
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View("");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken()]
        public ActionResult Add([Bind(Include = "FullName, PhoneNumber, IsAcceptingAnimals")] LandlordsBindingModel landlordsBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.landlordService.AddLandlord(landlordsBindingModel);
            }
            return this.Redirect("Success");
        }
 
    }
}