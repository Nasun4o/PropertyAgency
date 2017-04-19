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
    }
}