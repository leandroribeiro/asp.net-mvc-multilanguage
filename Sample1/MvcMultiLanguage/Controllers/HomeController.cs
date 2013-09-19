using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Mvc3MultiLanguageSample1.Controllers {
    public class HomeController : BaseController {

        public ActionResult Index() {

            //Linguagem Atribuida a Thread da Aplicação
            var culture = Thread.CurrentThread.CurrentUICulture;

            ViewBag.Culture = String.Format("{0} / {1} / {2}", culture.Name, culture.NativeName, culture.DisplayName);

            //Linguagem Configurado no Navegador do Usuário
            if (Request.UserLanguages != null && Request.UserLanguages.Any())
                ViewBag.BrowserCulture = Request.UserLanguages[0];

            return View();
        }

        //public ActionResult SetCulture()
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        //    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

        //    return RedirectToAction("Index");
        //}
    }
}
