namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Services;

    [Authorize(Roles = "Admin, Moderator")]
    public class TenantController : Controller
    {
        // GET: Admin/Tenant

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

        [HttpPost]
        public ActionResult Add([Bind(Include = "FullName, PhoneNumber, Description")] TenantsBindingModel tenantsBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.tenantService.AddTenant(tenantsBindingModel);
            }
            return this.Redirect("Success");
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