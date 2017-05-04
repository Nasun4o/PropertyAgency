namespace PropertyAgency.Application.Areas.Admin.Controllers
{
    using System.Web.Mvc;

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