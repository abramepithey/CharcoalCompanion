using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Recipes;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharcoalCompanion.MVC.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var service = CreateRecipeService();
            var model = service.GetAllRecipes();

            return View(model);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Recipe/Details/{id}

        // GET: Recipe/Update/{id}
        // POST: Recipe/Update/{id}

        // GET: Recipe/Delete/{id}
        // POST: Recipe/Delete/{id}

        public RecipeService CreateRecipeService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(user);
            return service;
        }
    }
}