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
            var service = new PlanService();
            var model = service.GetAllPlans();

            return View(model);
        }

        // GET: Plan/Create
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCreate model)
        {
            var service = CreatePlanService();

            if (!ModelState.IsValid)
            {
                return View(service.CreateModelLoadSteps(model));
            }

            int? newPlanId = service.CreatePlan(model);

            if (newPlanId != null)
            {
                TempData["SaveResult"] = "Your Plan was created.";
                return RedirectToAction("KeyPoints", new { id = newPlanId });
            }

            return View(service.CreateModelLoadSteps(model));
        }

        // GET: Plan/Details/{id}
        public ActionResult Details(int id)
        {
            var service = new PlanService();
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

        // GET: Plan/KeyPoints/{id}
        public ActionResult KeyPoints(int id)
        {
            var service = new PlanService();
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            var service = CreatePlanService();
            try
            {
                var detail = service.GetOwnedPlanById(id);
                var model =
                    new PlanUpdate
                    {
                        PlanId = detail.PlanId,
                        Title = detail.Title,
                        StepOneId = detail.StepOne.StepId,
                        StepTwoId = detail.StepTwo.StepId,
                        StepThreeId = detail.StepThree.StepId
                    };
                return View(service.UpdateModelLoadSteps(model));
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Plan could not be found.";
                return RedirectToAction("Index");
            }
            catch (UnauthorizedAccessException)
            {
                TempData["NotOwner"] = "You can only Edit Plans that you created.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["NeedSteps"] = "A Plan cannot be made if there are not at least one of each step.";
                return RedirectToAction("Index");
            }
        }

        // POST: Plan/Edit/{id}
        [Authorize]
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
        [Authorize]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePlanService();
            try
            {
                var model = service.GetOwnedPlanById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Plan could not be found.";
                return RedirectToAction("Index");
            }
            catch (UnauthorizedAccessException)
            {
                TempData["NotOwner"] = "You can only Delete Plans that you created.";
                return RedirectToAction("Index");
            }
        }

        // PATCH: Plan/Delete/{id}
        [Authorize]
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