using System.Web.Optimization;

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


            //Admin Configuration
            bundles.Add(new ScriptBundle("~/admin/assets/global/scripts").Include(
                "~/Content/assets/global/plugins/jquery.min.js",
                "~/Content/assets/global/plugins/js.cookie.min.js",
                "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/assets/global/plugins/jquery.blockui.min.js"));


            bundles.Add(new ScriptBundle("~/admin/assets/global/bootstrap").Include(
                "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.js"));


            bundles.Add(new ScriptBundle("~/admin/assets/pagelevel/jqueryval").Include(
                "~/Content/assets/global/plugins/jquery-validation/js/jquery.validate.min.js"));


            bundles.Add(new ScriptBundle("~/admin/assets/pagelevel/scripts").Include(
                "~/Content/assets/global/plugins/jquery-validation/js/additional-methods.min.js",
                "~/Content/assets/global/plugins/bootstrap-growl/jquery.bootstrap-growl.min.js",
                "~/Content/assets/pages/scripts/ui-bootstrap-growl.js"));

            bundles.Add(new ScriptBundle("~/admin/assets/global/theme/scripts").Include(
                "~/Content/assets/global/scripts/app.js"));

            bundles.Add(new ScriptBundle("~/admin/assets/global/theme/layout/scripts").Include(
                "~/Content/assets/layouts/layout/scripts/layout.js",
                "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js"));


            bundles.Add(new StyleBundle("~/admin/assets/global/css").Include(
                "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
            ));

            bundles.Add(new StyleBundle("~/admin/assets/global/theme/css").Include(
                "~/Content/assets/global/css/components.min.css",
                "~/Content/assets/global/css/plugins.min.css"));

            bundles.Add(new StyleBundle("~/admin/assets/global/theme/layout").Include(
                "~/Content/assets/layouts/layout/css/layout.min.css",
                "~/Content/assets/layouts/layout/css/themes/darkblue.min.css",
                "~/Content/assets/layouts/layout/css/custom.min.css"));

        }
    }
}