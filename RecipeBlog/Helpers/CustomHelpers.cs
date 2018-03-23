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
        public static string CheckBoxList(this HtmlHelper helper, List<Category> categories)
        {
            string CheckBoxList = "";

            CheckBoxList += "<div class='form-check'>";

            foreach (Category c in categories)
            {
                var builder = new TagBuilder("input");
                builder.GenerateId("category" + c.Id.ToString());
                builder.MergeAttribute("name", "Category");
                builder.MergeAttribute("value", c.Id.ToString());
                CheckBoxList += builder.ToString(TagRenderMode.SelfClosing);
            }

            CheckBoxList += "</div>";
            return CheckBoxList;
        }

    }
}