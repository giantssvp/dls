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
        }
    }
}