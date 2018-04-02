using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RecipeBlog.Models;


namespace RecipeBlog.Helpers
{
    public static class CustomHelpers
    {
        public static IHtmlString CategoryCheckBoxList(List<Category> categories, ICollection<Category> selectedCategories, bool noSelected)
        {
            string CheckBoxList = "";

            CheckBoxList += "<div class='form-check'>";

            foreach (Category c in categories)
            {
                CheckBoxList += "<div>";
                var builder = new TagBuilder("input");
                //builder.GenerateId("category" + c.Id.ToString());
                builder.MergeAttribute("name", "selectedCategories");
                builder.MergeAttribute("value", c.Id.ToString());
                builder.MergeAttribute("type", "checkbox");
                if (selectedCategories != null)
                { 
                    if (selectedCategories.Contains(c))
                        builder.MergeAttribute("checked", "checked");
                }
                CheckBoxList += builder.ToString(TagRenderMode.SelfClosing);
                CheckBoxList += "<span>" + c.Name + "</span>";
                CheckBoxList += "</div>";
            }

            CheckBoxList += "</div>";
            return new HtmlString(CheckBoxList);
        }

    }
}