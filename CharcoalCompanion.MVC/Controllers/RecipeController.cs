using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Recipes;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharcoalCompanion.MVC.Controllers
{
    [Authorize]
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
        public ActionResult Details(int id)
        {
            var service = CreateRecipeService();
            var model = service.GetRecipeById(id);

            return View(model);
        }

        // GET: Recipe/Update/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model =
                new RecipeUpdate
                {
                    RecipeId = detail.RecipeId,
                    Name = detail.Name,
                    Directions = detail.Directions,
                    Ingredients = detail.Ingredients,
                    Steps = detail.Steps,
                    Plan = detail.Plan
                };
            return View(model);
        }

        // POST: Recipe/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateRecipeService();

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your Step was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Step could not be updated.");
            return View(model);
        }

        // GET: Recipe/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateRecipeService();
            var model = service.GetRecipeById(id);

            return View(model);
        }

        // POST: Recipe/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "The Recipe was deleted.";

            return RedirectToAction("Index");
        }

        public RecipeService CreateRecipeService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(user);
            return service;
        }
    }
}