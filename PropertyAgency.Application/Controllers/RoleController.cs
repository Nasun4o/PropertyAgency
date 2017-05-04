namespace PropertyAgency.Application.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PropertyAgency.Data;
    using PropertyAgency.Models.EntityModels;

    [Authorize]
    public class RoleController : Controller
    {
        readonly PropertyAgencyContext context;
       
        // GET: Role
        public RoleController()
        {
            this.context = new PropertyAgencyContext();
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!this.IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                    return RedirectToAction("Index", "Home");
            }
            var roles = context.Roles.ToList();
            return View(roles);
        }

        private bool IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var userManger = new UserManager<User>(new UserStore<User>(context));
                var s = userManger.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}