using System.Web;
using System.Web.Optimization;

namespace Puppet
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/vendor/fontawesome/css/all.css",
                        "~/content/DataTables/css/jquery.dataTables.min.css",
                        "~/Content/stylish.min.css"
            ));


            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/stylish-portfolio.min.js",
                        "~/Scripts/agency.min.js",
                        "~/Scripts/jquery.easing.min.js"
            ));
        }
    }
}
