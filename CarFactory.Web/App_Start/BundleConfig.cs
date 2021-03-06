﻿using System.Web.Optimization;

namespace CarFactory.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //Web Configuration
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryval").Include(
                "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
                "~/Content/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/commom").Include(
                "~/Content/css/bannerSlider.css",
                "~/Content/css/layout.css",
                "~/Content/css/XPagedList.css"));

            bundles.Add(new StyleBundle("~/Content/css/Admin").Include(
                "~/Content/css/admin/commonStyle.css"));


            

        }
    }
}