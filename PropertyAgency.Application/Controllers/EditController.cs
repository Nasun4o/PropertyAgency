namespace PropertyAgency.Application.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Models.ViewModels.Tenant;
    using PropertyAgency.Services;

    [Authorize(Roles = "Admin, Moderator")]
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

        /// <summary>
        /// Here we should first catch our data about the porperty by given Id which we will Edit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// If the ModelState is valid, our action will send the Model to our Service in which we will change the old data with a new one and will save in to the Database.
        /// ValidateInput is set to false because only Admin and Moderator can insert Data in our Database so we know that we are protected from html tags
        /// </summary>
        /// <param name="property"></param>
        /// <returns>ActionResult or our Property with new data.</returns>
        [Route("EditProperty")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditProperty([Bind(Exclude = "LandlordsList, LandlordId")] PropertyFormViewModel property)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProperty(property);
               
                return this.RedirectToAction($"Show/Rent", "Properties", new {area = ""});
            }
            return this.View(property);
        }

        /// <summary>
        /// Here the logic is the same as the EditProperty Action.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Here the logic is the same as the EditProperty Action.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("EditLandlord")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
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

        /// <summary>
        /// Here the logic is the same as the EditProperty Action.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("EditTenant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
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