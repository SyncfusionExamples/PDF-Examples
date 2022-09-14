using System.Web;
using System.Web.Mvc;

namespace Creating_a_new_PDF_document
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
