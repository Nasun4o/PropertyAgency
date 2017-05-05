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

        /// <summary>
        /// Adding new Landlord to our Database by given BindingModel which come from our Form.
        /// </summary>
        /// <param name="landlordsBindingModel"></param>
        /// <returns>ActionResult(New Landlord)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add([Bind(Include = "FullName, PhoneNumber, IsAcceptingAnimals")] LandlordsBindingModel landlordsBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.landlordService.AddLandlord(landlordsBindingModel);
                return this.RedirectToAction("Index", "ControlPanel");
            }
            return this.View(landlordsBindingModel);
        }
    

        /// <summary>
        /// Delete Landlord by Given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteLandlord/{id:regex([0-9]+)}")]
        public ActionResult DeleteLandlord(int? id)
        {
            this.landlordService.Delete(id);
            
            return RedirectToAction($"Show/Landlords", "Properties", new { area = "" });
        }
    }
}