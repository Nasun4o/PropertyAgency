namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Services;

    [Authorize(Roles = "Admin, Moderator")]
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
        [ValidateAntiForgeryToken()]
        public ActionResult Add([Bind(Include = "FullName, PhoneNumber, IsAcceptingAnimals")] LandlordsBindingModel landlordsBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.landlordService.AddLandlord(landlordsBindingModel);
            }
            return this.RedirectToAction($"Show/Landlords", "Properties", new { area = "" });
        }
 
    }
}