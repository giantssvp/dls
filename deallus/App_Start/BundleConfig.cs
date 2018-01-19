using System.Web;
using System.Web.Optimization;

namespace deallus
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery-migrate-1.2.1.js",
                        "~/Scripts/jquery.equalheights.js",
                        "~/Scripts/jquery.mobile.customized.min.js",
                        "~/Scripts/camera.js",
                        "~/Scripts/slider.js",
                        "~/Scripts/slider.min.js",
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.min.js"));

               bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/grid.css",                     
                      "~/Content/camera.css",
                      "~/Content/slider.css",
                      "~/Content/contact-form.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/jquerysctipttop.css",                      
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/gst_js").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/gst_js/jquery.wizard.js",
                        "~/Scripts/gst_js/jquery.min.js",
                        "~/Scripts/gst_js/jquery.ui.custom.js",                      
                        "~/Scripts/gst_js/jquery.flot.min.js",
                        "~/Scripts/gst_js/jquery.flot.pie.min.js",
                        "~/Scripts/gst_js/jquery.flot.resize.min.js",                       
                        "~/Scripts/gst_js/fullcalendar.min.js",
                        "~/Scripts/gst_js/jquery.gritter.min.js",
                        "~/Scripts/gst_js/matrix.chat.js",                        
                        "~/Scripts/gst_js/jquery.uniform.js"                                      
                       ));
            
            bundles.Add(new StyleBundle("~/Content/gst_css").Include(
                    "~/Content/gst_css/bootstrap.min.css",
                    "~/Content/gst_css/bootstrap-responsive.min.css",
                    "~/Content/gst_css/fullcalendar.css",
                    "~/Content/gst_css/matrix-style.css",
                    "~/Content/gst_css/matrix-media.css",
                    "~/font/gst_font-awesome.css",
                    "~/Content/gst_css/jquery.gritter.css"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/login_js").Include(
                        "~/Scripts/gst_js/jquery.min.js",
                        "~/Scripts/gst_js/matrix.login.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/login_css").Include(
                    "~/Content/gst_css/bootstrap.min.css",
                    "~/Content/gst_css/bootstrap-responsive.min.css",
                    "~/Content/gst_css/matrix-login.css",
                    "~/font/gst_font-awesome.css"
                    ));
        }
    }
}