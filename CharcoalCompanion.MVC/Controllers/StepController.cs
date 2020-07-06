using CharcoalCompanion.Models.Steps;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharcoalCompanion.MVC.Controllers
{
    [Authorize]
    public class StepController : Controller
    {
        // GET: Step
        public ActionResult Index()
        {
            var service = CreateStepService();
            var model = service.GetAllSteps();

            return View(model);
        }

        // GET: Step/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Step/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StepCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateStepService();

            if (service.CreateStep(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private StepService CreateStepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StepService(userId);
            return service;
        }
    }
}