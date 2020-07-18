using CharcoalCompanion.Models.Plans;
using CharcoalCompanion.Models.Steps;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace CharcoalCompanion.MVC.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            var service = CreatePlanService();
            var model = service.GetAllPlans();

            return View(model);
        }

        // GET: Plan/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var service = CreatePlanService();
                var model = new PlanCreate();
                service.CreateModelLoadSteps(model);
                return View(model);
            }
            catch (Exception)
            {
                TempData["NeedSteps"] = "A Plan cannot be made if there are not at least one of each step.";
                return RedirectToAction("Index");
            }
        }

        // POST: Plan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCreate model)
        {
            var service = CreatePlanService();

            if (!ModelState.IsValid)
            {
                return View(service.CreateModelLoadSteps(model));
            }

            if (service.CreatePlan(model))
            {
                TempData["SaveResult"] = "Your Plan was created.";
                return RedirectToAction("Index");
            }

            return View(service.CreateModelLoadSteps(model));
        }

        // GET: Plan/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreatePlanService();
            try
            {
                var model = service.GetPlanById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Plan could not be found.";
                return RedirectToAction("Index");
            }
        }

        // GET: Plan/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreatePlanService();
            try
            {
                var detail = service.GetPlanById(id);
                var model =
                    new PlanUpdate
                    {
                        PlanId = detail.PlanId,
                        Title = detail.Title,
                        StepOneId = detail.StepOne.StepId,
                        StepTwoId = detail.StepTwo.StepId,
                        StepThreeId = detail.StepThree.StepId,
                        IsSaved = detail.IsSaved
                    };
                return View(service.UpdateModelLoadSteps(model));
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Plan could not be found.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["NeedSteps"] = "A Plan cannot be made if there are not at least one of each step.";
                return RedirectToAction("Index");
            }
        }

        // POST: Plan/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlanUpdate model)
        {
            var service = CreatePlanService();

            if (!ModelState.IsValid)
                return View(service.UpdateModelLoadSteps(model));

            if (model.PlanId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(service.UpdateModelLoadSteps(model));
            }

            if (service.UpdatePlan(model))
            {
                TempData["SaveResult"] = "Your Plan was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Plan could not be updated.");
            return View(service.UpdateModelLoadSteps(model));
        }

        // GET: Plan/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePlanService();
            try
            {
                var model = service.GetPlanById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Step could not be found.";
                return RedirectToAction("Index");
            }
        }

        // PATCH: Plan/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlan(int id)
        {
            var service = CreatePlanService();
            if (service.DeletePlan(id))
            {
                TempData["SaveResult"] = "The Plan was deleted.";
            }

            return RedirectToAction("Index");
        }

        private PlanService CreatePlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlanService(userId);

            return service;
        }
    }
}