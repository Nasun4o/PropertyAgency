namespace PropertyAgency.Application.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Models.ViewModels.Tenant;
    using PropertyAgency.Services;

    public class EditController : Controller
    {
        private EditService service;

        public EditController()
        {
            this.service = new EditService();
        }
        //GET: Edit
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("EditProperty/{id:regex([0-9]+)}")]
        public ActionResult EditProperty(int id)
        {
            PropertyFormViewModel property = this.service.EditPropertyById(id);

            if (property == null)
            {
                return this.HttpNotFound();
            }
            return this.View(property);
        }

        [Route("EditProperty")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProperty([Bind(Exclude = "LandlordsList, LandlordId")] PropertyFormViewModel property)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProperty(property);
               
                return this.RedirectToAction($"Show/Rent", "Properties", new {area = ""});
            }
            return this.View(property);
        }

        [HttpGet]
        [Route("EditLandlord/{id:regex([0-9]+)}")]
        public ActionResult EditLandlord(int id)
        {
            LandlordViewModel landlord = this.service.EditLandlordById(id);

            if (landlord == null)
            {
                return this.HttpNotFound();
            }
            return this.View(landlord);
        }
        [Route("EditLandlord")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLandlord([Bind(Include = "Id, FullName, PhoneNumber, IsAcceptingAnimals")] LandlordViewModel landlord)
        {
            if (ModelState.IsValid)
            {
                this.service.EditLandlordById(landlord);
                return this.RedirectToAction($"Show/Landlords", "Properties", new { area = "" });
            }
            return this.View(landlord);
        }

        [HttpGet]
        [Route("EditTenant/{id:regex([0-9]+)}")]
        public ActionResult EditTenant(int id)
        {
            TenantViewModel tenant = this.service.EditTenantById(id);

            if (tenant == null)
            {
                return this.HttpNotFound();
            }
            return this.View(tenant);
        }
        [Route("EditTenant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTenant([Bind(Include = "Id, FullName, PhoneNumber, Description")] TenantViewModel tenant)
        {
            if (ModelState.IsValid)
            {
                this.service.EditTenantById(tenant);
                return this.RedirectToAction($"Show/Tenants", "Properties", new { area = "" });
            }
            return this.View(tenant);
        }
    }
}