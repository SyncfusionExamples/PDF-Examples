using System.Web;
using System.Web.Mvc;

namespace Creating_PDF_document_with_basic_elements
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
