namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Services;

    [Authorize(Roles = "Admin, Moderator")]
    public class TenantController : Controller
    {
        /// <summary>
        /// Tenants Services is the logic behind the Controller
        /// </summary>
        private TenantService tenantService;
      
        public TenantController()
        {
            this.tenantService = new TenantService();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }
        /// <summary>
        /// Add new Tenant from Control Panel which takes BindingModel
        /// </summary>
        /// <param name="tenantsBindingModel"></param>
        /// <returns>ActionResult or a New Tenant</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add([Bind(Include = "FullName, PhoneNumber, Description")] TenantsBindingModel tenantsBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.tenantService.AddTenant(tenantsBindingModel);
                return this.RedirectToAction("Index", "ControlPanel");
            }
            // If Faild return to Form
            return this.View(tenantsBindingModel);
        }

        /// <summary>
        /// Delete Landlord by Given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteTenant/{id:regex([0-9]+)}")]
        public ActionResult DeleteTenant(int? id)
        {
            this.tenantService.Delete(id);

            return RedirectToAction($"Show/Tenants", "Properties", new { area = "" });
        }
    }
}