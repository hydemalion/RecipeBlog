using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using RecipeBlog.Models;

namespace RecipeBlog.Controllers
{
    public class FoodController : Controller
    {
        private RecipeModels db = new RecipeModels();


        // GET: Food/
        public ActionResult Index()
        {

            return View();
        }



        // GET: Food/Show/[SEName]/[id]
        public ActionResult Article(int? id)
        {
            if (id != null)
            {
                Recipe ShowRecipe = db.Recipes.Include(i => i.SelectedCategories).Where(i => i.Id == id).Single();
                if (ShowRecipe == null)
                {
                    return HttpNotFound();
                }
                return View(ShowRecipe);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}