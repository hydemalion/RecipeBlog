using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeBlog.Models;

namespace RecipeBlog.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeModels db = new RecipeModels();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            //var model = new Recipe();
            //InitializeRecipeDisplayCategories(model);
            //return View(model);
            InitializeAllCategories();
            ViewBag.NewCreate = true;
            return View();
        }

        public void InitializeAllCategories()
        {
            ViewBag.AllCategories = db.Categories.ToList();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Blurb,PrepTime,Ingredients,QuickInstructions,FullInstructions,ImageName,Published,PublishDate")] Recipe recipe, string[] selectedCategories)
        {
            if (selectedCategories != null)
            {
                //this is done in constructor so may not have to do here?
                recipe.SelectedCategories = new List<Category>();
                foreach (string c in selectedCategories)
                {
                    Category addCategory = db.Categories.Find(int.Parse(c));
                    recipe.SelectedCategories.Add(addCategory);
                }

            }
            if (ModelState.IsValid)
            {
                recipe.CreatedOn = DateTime.Today;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorText = "Model State not valid.";
            }
            ViewBag.NewCreate = false;
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitializeAllCategories();
            ViewBag.NewCreate = false;
            Recipe recipe = db.Recipes.Include(i => i.SelectedCategories).Where(i => i.Id == id).Single();
            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);
        }


        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Blurb,PrepTime,Ingredients,QuickInstructions,FullInstructions,ImageName,CreatedOn,Published,PublishDate")] Recipe recipe, string[] selectedCategories)
        public ActionResult Edit([Bind(Include = "Id,Title,Blurb,PrepTime,Ingredients,QuickInstructions,FullInstructions,ImageName,CreatedOn,Published,PublishDate")] Recipe recipe, string[] selectedCategories)
        {

            

            if (ModelState.IsValid)
            {
                
                db.Entry(recipe).State = EntityState.Modified;
                //update other fields first
                //UpdateModel(recipe, new string[] { "Title", "Blurb", "PrepTime", "Ingredients", "QuickInstructions", "FullInstructions", "ImageName", "Published", "PublishDate", "SelectedCategories" });
                if (TryUpdateModel(recipe, new string[] { "Title", "Blurb", "PrepTime", "Ingredients", "QuickInstructions", "FullInstructions", "ImageName", "Published", "PublishDate" }))
                {
                    Recipe updateRecipe = db.Recipes.Include(i => i.SelectedCategories).Where(i => i.Id == recipe.Id).Single();
                    //then update categories
                    if (selectedCategories != null)
                    {
                        
                        foreach (var c in db.Categories)
                        {
                            //previously selected
                            if (updateRecipe.SelectedCategories.Contains(c))
                            {
                                //if now deselected, remove
                                if (!selectedCategories.Contains(c.Id.ToString()))
                                {
                                    updateRecipe.SelectedCategories.Remove(c);
                                }

                            }
                            else //not previously selected
                            {
                                //if now selected, add
                                if (selectedCategories.Contains(c.Id.ToString()))
                                {
                                    updateRecipe.SelectedCategories.Add(c);
                                }

                            }
                        }
                    }
                    else
                    {
                            updateRecipe.SelectedCategories = new List<Category>();
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.ErrorText = "Model State not valid.";
            }
            InitializeAllCategories();
            ViewBag.NewCreate = false;
            return View(recipe);

            //to test: update from 1 to 2 selected; update to none selected
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
