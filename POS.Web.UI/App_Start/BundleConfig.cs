using System.Web;
using System.Web.Optimization;

namespace POS.Web.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));



            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                 "~/Scripts/js/lib/jquery/jquery.min.js",
                   "~/Scripts/js/lib/bootstrap/js/popper.min.js",
                     "~/Scripts/js/lib/bootstrap/js/bootstrap.min.js",
                       "~/Scripts/js/jquery.slimscroll.js",
                         "~/Scripts/js/sidebarmenu.js",
                           "~/Scripts/js/lib/sticky-kit-master/dist/sticky-kit.min.js",
                             "~/Scripts/js/lib/morris-chart/raphael-min.js",
                               "~/Scripts/js/lib/morris-chart/morris.js",
                                 "~/Scripts/js/lib/morris-chart/dashboard1-init.js",
                                   "~/Scripts/js/lib/calendar-2/moment.latest.min.js",
                                     "~/Scripts/js/lib/calendar-2/semantic.ui.min.js",
                                     "~/Scripts/js/lib/calendar-2/prism.min.js",
                                     "~/Scripts/js/lib/calendar-2/pignose.calendar.min.js",
                                        "~/Scripts/js/lib/calendar-2/pignose.init.js",
                                           //"~/Scripts/js/lib/owl-carousel/owl.carousel.min.jsjs/lib/calendar-2/pignose.calendar.min.js",
                                           //"~/Scripts/js/lib/owl-carousel/owl.carousel-init.js",
                                            "~/Scripts/js/scripts.js",
                 "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts/datatable").Include(
                "~/Scripts/js/lib/datatables/datatables.min.js",
                  "~/Scripts/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js",
                    "~/Scripts/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.flash.min.js",
                      "~/Scripts/js/lib/datatables/cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js",
                        "~/Scripts/js/lib/datatables/cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js",
                          "~/Scripts/js/lib/datatables/cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js",
                            "~/Scripts/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js",
                              "~/Scripts/js/lib/datatables/cdn.datatables.net/buttons/1.2.2/js/buttons.print.min.js",
                                "~/Scripts/js/lib/datatables/datatables-init.js"
                                 ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/css/lib/bootstrap/bootstrap.min.css",
                      "~/Content/css/lib/calendar2/pignose.calendar.min.css",
                       "~/Content/css/lib/owl.carousel.min.css",
                        "~/Content/css/lib/owl.theme.default.min.css",
                         "~/Content/css/helper.css",
                          "~/Content/css/style.css"
                         ));
        }
    }
}
