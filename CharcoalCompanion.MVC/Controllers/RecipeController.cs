using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Recipes;
using CharcoalCompanion.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
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
            var service = CreateRecipeService();
            var model = new RecipeCreate();
            service.CreateRecipeModelLoadPlans(model);
            return View(model);
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            var service = CreateRecipeService();

            if (!ModelState.IsValid)
            {
                return View(service.CreateRecipeModelLoadPlans(model));
            }

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was created.";
                return RedirectToAction("Index");
            }

            return View(service.CreateRecipeModelLoadPlans(model));
        }

        // GET: Recipe/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateRecipeService();
            try
            {
                var model = service.GetRecipeById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Recipe could not be found.";
                return RedirectToAction("Index");
            }
        }

        // GET: Recipe/Update/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            try
            {
                var detail = service.GetRecipeById(id);
                var model =
                    new RecipeUpdate
                    {
                        RecipeId = detail.RecipeId,
                        Name = detail.Name,
                        Directions = detail.Directions,
                        Ingredients = detail.Ingredients,
                        Steps = detail.Steps
                    };
                return View(service.UpdateRecipeModelLoadPlans(model));
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Recipe could not be found.";
                return RedirectToAction("Index");
            }
        }

        // POST: Recipe/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeUpdate model)
        {
            var service = CreateRecipeService();

            if (!ModelState.IsValid)
                return View(service.UpdateRecipeModelLoadPlans(model));

            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(service.UpdateRecipeModelLoadPlans(model));
            }

            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Recipe could not be updated.");
            return View(service.UpdateRecipeModelLoadPlans(model));
        }

        // GET: Recipe/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateRecipeService();
            try
            {
                var model = service.GetRecipeById(id);

                return View(model);
            }
            catch (InvalidOperationException)
            {
                TempData["NoResult"] = "The Recipe could not be found.";
                return RedirectToAction("Index");
            }
        }

        // PATCH: Recipe/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateRecipeService();

            if (service.DeleteRecipe(id))
            {
                TempData["SaveResult"] = "The Recipe was deleted.";
            }

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