﻿namespace AcademyGrandPrix.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/bootstrap/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/KendoUI/kendo.web.min.js",
                "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/KendoUI/kendo.common-bootstrap.min.css",
                "~/Content/KendoUI/kendo.bootstrap.min.css"));
        }
    }
}
