using System.Web;
using System.Web.Optimization;

namespace MaisonVotre
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                        "~/Scripts/jquery.dropotron.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/template2").Include(
                        "~/Scripts/breakpoint.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/template3").Include(
                        "~/Scripts/browser.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/template4").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/template5").Include(
                        "~/Scripts/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/template6").Include(
                        "~/Scripts/jquery.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/template7").Include(
                        "~/Scripts/jquery.scrollex.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/template8").Include(
                        "~/Scripts/jquery.scrolly.min.css"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/xcss").Include(
                      "~/Content/TemplateCustom/styles.css"));
        }
    }
}
