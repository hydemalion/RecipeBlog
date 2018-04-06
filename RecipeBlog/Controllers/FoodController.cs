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
            //get top 10 more recent recipes
            List<Recipe> RecentRecipes = db.Recipes.OrderByDescending<Recipe, DateTime>(r => r.CreatedOn).Take(10).ToList();
            return View(RecentRecipes);
        }



        // GET: Food/Article/[SEName]/[id]
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

        // GET: Food/Article/[SEName]/[id]
        public ActionResult Category(int? id)
        {
            if (id != null)
            {
                Category thisCategory = db.Categories.Find(id);

                if (thisCategory != null)
                {
                    ViewBag.Title = thisCategory.Name;
                    ViewBag.Blurb = thisCategory.Blurb;
                    List<Recipe> RecentRecipes = db.Recipes.Include(i => i.SelectedCategories).AsEnumerable().Where(i => i.SelectedCategories.Contains(thisCategory)).OrderByDescending<Recipe, DateTime>(r => r.CreatedOn).Take(10).ToList();
                    return View(RecentRecipes);
                }

                else 
                {
                    return HttpNotFound();
                }
                
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}