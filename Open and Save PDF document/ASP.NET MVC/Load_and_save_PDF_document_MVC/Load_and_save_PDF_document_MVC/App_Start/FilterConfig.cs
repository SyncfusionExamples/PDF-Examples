using System.Web;
using System.Web.Mvc;

namespace Load_and_save_PDF_document_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
