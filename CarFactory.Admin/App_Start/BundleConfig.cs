﻿using System.Web.Optimization;

namespace CarFactory.Admin
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();



            //Admin Configuration

            bundles.Add(new ScriptBundle("~/abp/scripts").Include(
                "~/lib/abp-web-resources/Abp/Framework/scripts/abp.js",
                "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js",
                "~/lib/json2/json2.js"
                ));

            bundles.Add(new ScriptBundle("~/assets/global/scripts").Include(
                "~/Content/assets/global/plugins/jquery.min.js",
                "~/Content/assets/global/plugins/js.cookie.min.js",
                "~/Content/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/assets/global/plugins/jquery.blockui.min.js"));


            bundles.Add(new ScriptBundle("~/assets/global/bootstrap").Include(
                "~/Content/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.js"));


            bundles.Add(new ScriptBundle("~/assets/pagelevel/jqueryval").Include(
                "~/Content/assets/global/plugins/jquery-validation/js/jquery.validate.min.js"));


            bundles.Add(new ScriptBundle("~/assets/pagelevel/scripts").Include(
                "~/Content/assets/global/plugins/jquery-validation/js/additional-methods.min.js",
                "~/Content/assets/global/plugins/bootstrap-growl/jquery.bootstrap-growl.min.js",
                "~/Content/assets/pages/scripts/ui-bootstrap-growl.js"));

            bundles.Add(new ScriptBundle("~/assets/global/theme/scripts").Include(
                "~/Content/assets/global/scripts/app.js"));

            bundles.Add(new ScriptBundle("~/assets/global/theme/layout/scripts").Include(
                "~/Content/assets/layouts/layout/scripts/layout.js",
                "~/Content/assets/layouts/global/scripts/quick-sidebar.min.js"));


            bundles.Add(new StyleBundle("~/assets/global/css").Include(
                "~/Content/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/theme/css").Include(
                "~/Content/assets/global/css/components.min.css",
                "~/Content/assets/global/css/plugins.min.css"));

            bundles.Add(new StyleBundle("~/assets/global/theme/layout").Include(
                "~/Content/assets/layouts/layout/css/layout.min.css",
                "~/Content/assets/layouts/layout/css/themes/darkblue.min.css",
                "~/Content/assets/layouts/layout/css/custom.min.css"));


            //ProductCategory-Index
            bundles.Add(new StyleBundle("~/assets/global/datatables/css").Include(
                "~/Content/assets/global/plugins/datatables/datatables.min.css",
                "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/assets/global/bootstrapModal/css").Include(
                "~/Content/assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css",
                "~/Content/assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css"
            ));

            bundles.Add(new ScriptBundle("~/assets/global/datatables/scripts").Include(
                "~/Content/assets/global/scripts/datatable.js",
                "~/Content/assets/global/plugins/datatables/datatables.min.js",
                "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"));


            bundles.Add(new ScriptBundle("~/assets/global/bootstrapModal/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
                "~/Content/assets/global/plugins/bootstrap-modal/js/bootstrap-modal.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapConfirmation/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-confirmation/bootstrap-confirmation.min.js"));
            //ProductCategory-Index End




        }
    }
}