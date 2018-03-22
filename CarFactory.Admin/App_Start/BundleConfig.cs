using System.Web.Optimization;

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

            bundles.Add(new StyleBundle("~/assets/global/bootstrapFileinput/css").Include(
                "~/Content/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/bootstrapSelect/css").Include(
                "~/Content/assets/global/plugins/bootstrap-select/css/bootstrap-select.min.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/jqueryMultiSelect/css").Include(
                "~/Content/assets/global/plugins/jquery-multi-select/css/multi-select.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/select2/css").Include(
                "~/Content/assets/global/plugins/select2/css/select2.min.css",
                "~/Content/assets/global/plugins/select2/css/select2-bootstrap.min.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/bootstrapDatePicker/css").Include(
                "~/Content/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/bootstrapModal/css").Include(
                "~/Content/assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css",
                "~/Content/assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css"
            ));

            bundles.Add(new StyleBundle("~/assets/global/bootstrapSummernote/css").Include(
                "~/Content/assets/global/plugins/bootstrap-summernote/summernote.css"));

            bundles.Add(new StyleBundle("~/assets/global/profile/css").Include(
                "~/Content/assets/pages/css/profile.min.css"));

            bundles.Add(new StyleBundle("~/assets/global/dropzone/css").Include(
                "~/Content/assets/global/plugins/dropzone/dropzone.css"));

            bundles.Add(new ScriptBundle("~/assets/global/dropzone/scripts").Include(
                "~/Content/assets/global/plugins/dropzone/dropzone.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapSummernote/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-summernote/summernote.min.js"));

            bundles.Add(new ScriptBundle("~/assets/global/datatables/scripts").Include(
                "~/Content/assets/global/scripts/datatable.js",
                "~/Content/assets/global/plugins/datatables/jquery.dataTables.js",
                "~/Content/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapDatePicker/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapFileinput/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"));

            bundles.Add(new StyleBundle("~/assets/global/profile/scripts").Include(
                "~/Content/assets/pages/scripts/profile.js"));

            bundles.Add(new ScriptBundle("~/assets/global/select2/scripts").Include(
                "~/Content/assets/global/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapModal/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
                "~/Content/assets/global/plugins/bootstrap-modal/js/bootstrap-modal.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapConfirmation/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-confirmation/bootstrap-confirmation.js"));

            bundles.Add(new ScriptBundle("~/assets/global/jqueryMultiSelect/scripts").Include(
                "~/Content/assets/global/plugins/jquery-multi-select/js/jquery.multi-select.js"));

            bundles.Add(new ScriptBundle("~/assets/global/bootstrapSelect/scripts").Include(
                "~/Content/assets/global/plugins/bootstrap-select/js/bootstrap-select.min.js"));
            //ProductCategory-Index End




        }
    }
}