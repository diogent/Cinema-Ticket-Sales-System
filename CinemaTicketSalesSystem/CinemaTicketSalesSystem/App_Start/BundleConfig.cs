using System.Web.Optimization;
using System.Web;

namespace CinemaTicketSalesSystem.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                "~/Scripts/Chosen/chosen.jquery.min.js"));
            bundles.Add(new StyleBundle("~/bundles/chosenStyles").Include(
                "~/Content/ChosenStyles/chosen.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
        }
    }
}