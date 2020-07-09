using CharcoalCompanion.Models.Plans;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
            var service = CreatePlanService();
            var model = service.GetAllStepsToChooseFrom();
            return View(model);
        }

        // POST: Plan/Create
        [HttpPost]
        public ActionResult Create(PlanCreate model)
        {
            var service = CreatePlanService();

            if (ModelState.IsValid)
            {
                service.CreatePlan(model);
                return RedirectToAction("Index");
            }
            model = service.GetAllStepsToChooseFrom();
            return View(model);
        }

        private PlanService CreatePlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlanService(userId);

            return service;
        }
    }
}