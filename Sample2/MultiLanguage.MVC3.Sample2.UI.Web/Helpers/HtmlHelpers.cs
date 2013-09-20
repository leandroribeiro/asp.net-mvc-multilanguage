using System.Web.Mvc;

namespace MvcMultiLanguageSample2.Helpers {

    public static class Extensions {

        public static string LocalResources(this WebViewPage page, string key) {
            return page.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, key) as string;
        }
    }

}