using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ControlPanelController : Controller
    {
        // GET: Admin/ControlPanel
        public ActionResult Index()
        {
            return View("");
        }
    }
}