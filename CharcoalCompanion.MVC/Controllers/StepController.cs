using CharcoalCompanion.Models.Steps;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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
                TempData["SaveResult"] = "Your Step was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Step/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateStepService();
            try
            {
                var model = service.GetStepById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Step could not be found.";
                return RedirectToAction("Index");
            }
        }

        // GET: Step/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateStepService();
            try
            {
                var detail = service.GetStepById(id);
                var model =
                    new StepUpdate
                    {
                        StepId = detail.StepId,
                        StepType = detail.StepType,
                        Name = detail.Name,
                        Description = detail.Description,
                        ImageLink = detail.ImageLink
                    };
                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Step could not be found.";
                return RedirectToAction("Index");
            }
        }

        // POST: Step/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StepUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.StepId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateStepService();

            if (service.UpdateStep(model))
            {
                TempData["SaveResult"] = "Your Step was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Step could not be updated.");
            return View(model);
        }

        // GET: Step/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateStepService();
            try
            {
                var model = service.GetStepById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Step could not be found.";
                return RedirectToAction("Index");
            }
        }

        // PATCH: Step/Delete/{id}
        [HttpPatch]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStep(int id)
        {
            var service = CreateStepService();

            service.DeleteStep(id);

            TempData["SaveResult"] = "The Step was deleted.";

            return RedirectToAction("Index");
        }

        private StepService CreateStepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StepService(userId);
            return service;
        }
    }
}