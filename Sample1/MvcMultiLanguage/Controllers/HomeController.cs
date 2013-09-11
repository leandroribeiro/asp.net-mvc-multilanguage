using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Mvc3MultiLanguageSample1.Controllers {
    public class HomeController : BaseController {

        //[Localization]
        public ActionResult Index() {

            var culture = Thread.CurrentThread.CurrentUICulture;
            //ViewBag.Message = "Welcome to ASP.NET MVC!";

            //System.Threading.Thread.CurrentThread.CurrentUICulture.ToString(

            if (Request.UserLanguages != null && Request.UserLanguages.Any())
                ViewBag.Message = Request.UserLanguages[0];

            ViewBag.Culture = String.Format("{0}/{1}/{2}", culture.Name, culture.NativeName, culture.DisplayName);

            return View();
        }

        //public ActionResult SetCulture()
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        //    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

        //    return RedirectToAction("Index");
        //}

        public ActionResult About() {
            return View();
        }
    }
}
