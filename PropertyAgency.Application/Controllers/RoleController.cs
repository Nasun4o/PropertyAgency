using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyAgency.Data;
using PropertyAgency.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        PropertyAgencyContext context;
       
        // GET: Role
        public RoleController()
        {
            this.context = new PropertyAgencyContext();
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                    return RedirectToAction("Index", "Home");
            }
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManger = new UserManager<User>(new UserStore<User>(context));
                var s = UserManger.GetRoles(user.GetUserId());
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