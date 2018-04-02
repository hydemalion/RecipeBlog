﻿using System.Web;
using System.Web.Optimization;

namespace RecipeBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/html5up").Include(
                      "~/Scripts/skel.min.js",
                      "~/Scripts/util.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/main.css",
                      "~/Content/ie8.css",
                      "~/Content/ie9.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/site.css"));
        }
    }
}
