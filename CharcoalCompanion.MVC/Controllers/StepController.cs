using CharcoalCompanion.Models.Steps;
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
            var model = new StepListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}