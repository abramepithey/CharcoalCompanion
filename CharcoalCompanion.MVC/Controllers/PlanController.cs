using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        private PlanService CreatePlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlanService(userId);

            return service;
        }
    }
}