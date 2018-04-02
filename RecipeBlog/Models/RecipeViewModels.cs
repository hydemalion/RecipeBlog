using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeBlog.Models
{
    public class RecipeDisplayViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
       
        public string PrepTime { get; set; }
        public string Ingredients { get; set; }
        
        public string QuickInstructions { get; set; }
        public string FullInstructions { get; set; }
        public string ImageName { get; set; }
        public bool Published { get; set; }
        public DateTime PublishDate { get; set; }

    }

    public class RecipeCategories
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Linked { get; set; }
    }

}