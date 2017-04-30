namespace PropertyAgency.Application.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
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
        [Route("Edit/{id:regex([0-9]+)}")]
        public ActionResult Edit(int id)
        {
            PropertyFormViewModel property = this.service.EditPropertyById(id);

            if (property == null)
            {
                return this.HttpNotFound();
            }
            return this.View(property);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "LandlordsList, LandlordId")] PropertyFormViewModel property)
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
    }
}