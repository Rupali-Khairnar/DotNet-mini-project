using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe_Sharing_platform.Models;

namespace Recipe_Sharing_platform.Controllers
{
    public class RecipeController : Controller
    {
        // GET: RecipeController
        public ActionResult Index()
        {
          //  List<Recipe> lstRec = new List<Recipe>();


            
            List<Recipe> lstRec = Recipe.GetAllRecipes();
            return View(lstRec);
           
        }

        // GET: RecipeController/Details/5
        public ActionResult Details(int id)
        {
            //Recipe rec = new Recipe();
            //rec.Id = id;
            //rec.Title = "Rice";
            //rec.Ingredients = "Jira";
            //rec.Instructions = "ABC";
            Recipe rec = Recipe.GetRecipeById(id);
            return View(rec);
       

        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {  

            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                Recipe.InsertRecipe(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            Recipe rec = Recipe.GetRecipeById(id);
            if (rec == null)
            {
                return NotFound();
            }
            return View(rec);
            
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Recipe.UpdateRecipe(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            Recipe rec = Recipe.GetRecipeById(id);
            if (rec == null)
            {
                return NotFound();
            }
            return View(rec);
         
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Recipe recipe)
        {
            try
            {
                Recipe.DeleteRecipe(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
