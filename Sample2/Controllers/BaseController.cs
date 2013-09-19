using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcMultiLanguageSample2.Controllers {
    public abstract class BaseController : Controller {

        protected override void ExecuteCore() {

            if (RouteData.Values["lang"] != null
                && !string.IsNullOrWhiteSpace(RouteData.Values["lang"].ToString())
                ) {
                // set the culture from the route data (url)
                var lang = RouteData.Values["lang"].ToString();

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            }
            else {
                // load the culture info from the cookie
                var cookie = HttpContext.Request.Cookies["ShaunXu.MvcLocalization.CurrentUICulture"];
                var langHeader = string.Empty;
                if (cookie != null) {
                    // set the culture by the cookie content
                    langHeader = cookie.Value;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                else {
                    // set the culture by the location if not speicified
                    langHeader = HttpContext.Request.UserLanguages[0];
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                // set the lang value into route data
                RouteData.Values["lang"] = langHeader;
            }

            // save the location into cookie
            var _cookie = new HttpCookie("ShaunXu.MvcLocalization.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name);
            _cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Response.SetCookie(_cookie);

            base.ExecuteCore();
        }
    }
}
