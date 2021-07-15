using System.Web;
using System.Web.Optimization;

namespace Calendar4e
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
           
            // Including fullcalendar dependencies
            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
                "~/Content/fullcalendar.css",
                "~/Content/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                "~/Scripts/lib/jquery-ui.min.css",
                "~/Scripts/lib/moment.min.js",
                "~/Scripts/lib/jquery.min.js",
                "~/Scripts/fullcalendar.min.js",
                "~/Scirpts/fullcalendar.js"));
        }
    }
}
