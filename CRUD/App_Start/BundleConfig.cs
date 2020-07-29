using System.Web;
using System.Web.Optimization;

namespace CRUD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                     
                      "~/Content/site.css"));


            #region Script View

            #region pessoas
            bundles.Add(new ScriptBundle("~/bundles/pessoas").Include(
                    "~/Scripts/views/pessoa/pessoa-incluir.js"));

            bundles.Add(new ScriptBundle("~/bundles/pessoas-atualizar").Include(
                  "~/Scripts/views/pessoa/pessoa-atualizar.js"));

            bundles.Add(new ScriptBundle("~/bundles/pessoas-deletar").Include(
                  "~/Scripts/views/pessoa/pessoa-deletar.js"));
            #endregion


            #endregion


        }
    }
}
