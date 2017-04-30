namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System;
    using System.Web.Mvc;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Services;
    using Models.Enums;

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
        [ValidateAntiForgeryToken()]
        public ActionResult Add([Bind(Include = "FullAddress, ApartmentSize, NumberOfRooms, IsActive, Type, UrlPicture, Price, LandlordId")] PropertyFormViewModel propertyFormViewModelgModel)
        {
            
            if (ModelState.IsValid)
            {
                this.propertyService.AddProperty(propertyFormViewModelgModel);
                if (propertyFormViewModelgModel.Type == PropertyType.Rent)
                {
                    return this.RedirectToAction($"Show/Rent", "Properties", new { area = "" });
                }

                return this.RedirectToAction($"Show/Sale", "Properties", new { area = "" });
            }
            PropertyFormViewModel model = this.propertyService.GeneratePropertyViewModel();
            return this.View(model);
        }
    }
}