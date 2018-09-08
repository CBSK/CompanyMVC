using System.Web;
using System.Web.Optimization;

namespace Company
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/LayoutStyles").Include(
             "~/Content/bootstrap.css",
              "~/Content/css/bootstrap.min.css",//-- Basic Styles -->
              "~/Content/css/font-awesome.min.css", //-- Basic Styles -->
              "~/Content/css/smartadmin-production-plugins.min.css",//SmartAdmin Styles : Caution! DO NOT change the order
              "~/Content/css/smartadmin-production.min.css",//SmartAdmin Styles : Caution! DO NOT change the order
              "~/Content/css/smartadmin-skins.min.css", //SmartAdmin Styles : Caution! DO NOT change the order
              "~/Content/css/smartadmin-rtl.min.css",
              "~/Content/css/normalize.css",
              "~/Content/css/your_style.css",
              "~/Content/css/style.css",
                "~/js/plugin/ckeditor/skins/moono/editor.css",
                "~/js/plugin/ckeditor/contents.css",
               "~/Content/Site.css"
                 ));
            bundles.Add(new ScriptBundle("~/LayoutScripts").Include(

                       "~/Scripts/bootstrap.js",/////
                        "~/Scripts/respond.js",
                        "~/js/plugin/pace/pace.min.js",
                "~/js/libs/jquery-3.2.1.min.js",
                "~/js/libs/jquery-ui.min.js",
                         "~/Scripts/jquery.easing-1.3.min.js",
                "~/js/app.config.js",
                "~/js/app.js",
                "~/js/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/js/bootstrap/bootstrap.min.js",
                "~/js/notification/SmartNotification.min.js",
                "~/js/app.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/js/smartwidgets/jarvis.widget.min.js",
                           "~/Scripts/jquery-ui-1.10.0.js",
                        "~/Scripts/jquery-ui-1.10.0.min.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.min.js",
                "~/js/plugin/bootstrapvalidator/bootstrapValidator.min.js",
                "~/js/plugin/sparkline/jquery.sparkline.min.js",
                "~/js/plugin/jquery-validate/jquery.validate.min.js",
                "~/js/plugin/masked-input/jquery.maskedinput.min.js",
                "~/js/plugin/select2/select2.min.js",
                "~/js/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/js/plugin/msie-fix/jquery.mb.browser.min.js",
                           "~/js/plugin/fastclick/fastclick.min.js",
                           "~/js/plugin/moment/moment.min.js",
                           "~/js/plugin/ckeditor/ckeditor.js",
                           //"~/Scripts/jquery.min.js",///////////
                           "~/Scripts/Common/ErrorHelper.js",
                           "~/js/plugin/ckeditor/styles.js  ",
                           "~/js/plugin/ckeditor/lang/en.js",
                           "~/js/plugin/ckeditor/ckeditor.js",
                            "~/js/plugin/datatables/jquery.dataTables.min.js",
                            "~/js/plugin/datatables/dataTables.colVis.min.js",
                            "~/js/plugin/datatables/dataTables.tableTools.min.js",
                            "~/js/plugin/datatables/dataTables.bootstrap.min.js",
                            "~/js/plugin/datatable-responsive/datatables.responsive.min.js"
                  ));
        }
    }
}