using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyAgency.Application.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Services;

    public class EditController : Controller
    {
        private EditService service;

        public EditController()
        {
            this.service = new EditService();
        }
        //GET: Edit
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Edit/{id:regex([0-9]+)}")]
        public ActionResult Edit(int id)
        {
            PropertyFormViewModel property = this.service.EditPropertyById(id);

            if (property == null)
            {
                return this.HttpNotFound();
            }
            return this.View(property);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "LandlordsList, LandlordId")] PropertyFormViewModel property)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProperty(property);
                //TODO: PROPERLY REDIRECT TO PROPERTY ID
                return this.RedirectToAction($"Show/Rent", "Properties", new {area = ""});
            }
            return this.View(property);
        }
    }
}