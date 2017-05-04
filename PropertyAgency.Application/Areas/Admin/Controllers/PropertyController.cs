﻿namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Services;

    [Authorize(Roles = "Admin, Moderator")]
    public class PropertyController : Controller
    {
        private PropertyService propertyService;

        public PropertyController()
        {
            this.propertyService = new PropertyService();
        }
        // GET: Admin/Property
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            PropertyFormViewModel model = this.propertyService.GeneratePropertyViewModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add([Bind(Include = "FullAddress, ApartmentSize, NumberOfRooms, IsActive, Type, UrlPicture, Price, LandlordId")] PropertyFormViewModel propertyFormViewModelgModel)
        {

            if (ModelState.IsValid)
            {
                this.propertyService.AddProperty(propertyFormViewModelgModel);
                return this.RedirectToAction("Index", "ControlPanel");
            }
            PropertyFormViewModel model = this.propertyService.GeneratePropertyViewModel();
            return this.View(model);
        }

        [HttpGet]
        [Route("DeleteProperty/{id:regex([0-9]+)}")]
        public ActionResult DeleteProperty(int? id)
        {
            this.propertyService.Delete(id);
            return this.RedirectToAction($"ShowAll", "Properties", new { area = "" });
        }
    }
}