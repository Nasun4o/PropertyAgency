using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View("Admina e tuk");
        }
    }
}