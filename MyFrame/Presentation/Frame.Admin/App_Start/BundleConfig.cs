using System.Web;
using System.Web.Optimization;

namespace Frame.Admin
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region system
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #endregion system

            #region customs

            #region style
            bundles.Add(new StyleBundle("~/assets/bootstrap").Include(
                  "~/assets/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/assets/base").Include(
                 "~/assets/css/font-awesome.min.css",
                 "~/assets/css/weather-icons.min.css"));


            bundles.Add(new StyleBundle("~/assets/beyond").Include(
              "~/assets/css/beyond.min.css",
              "~/assets/css/typicons.min.css",
              "~/assets/css/animate.min.css"));
            #endregion style
            #region script

            bundles.Add(new ScriptBundle("~/bundles/jquery/skins").Include(
                   "~/assets/js/skins.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/assets/js/jquery-2.0.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/assets/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/beyonds").Include(
                     "~/assets/js/beyond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-validate").Include(
                   "~/Scripts/jquery.validate.min.js",
                   "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstarp-table").Include(
                   "~/Scripts/bootstrap-table/bootstrap-table.min.js",
                    "~/Scripts/bootstrap-table/bootstrap-table-zh-CN.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstarp-datetime").Include(
                  "~/assets/js/datetime/moment.js",
                   "~/assets/js/datetime/bootstrap-timepicker.js",
                   "~/assets/js/datetime/daterangepicker.js",
                   "~/assets/js/datetime/bootstrap-datepicker.js"));


            #endregion scrpit
            #endregion customs
        }
    }
}
