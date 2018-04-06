using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using RecipeBlog.Models;

namespace RecipeBlog.Controllers
{
    public class HomeController : Controller
    {
        private RecipeModels db = new RecipeModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult _CategoryRepeater()
        {
            List<Category> allCategories = db.Categories.ToList();
            return PartialView("~/Views/Shared/_CategoryRepeater.cshtml", allCategories);
        }
    }
}