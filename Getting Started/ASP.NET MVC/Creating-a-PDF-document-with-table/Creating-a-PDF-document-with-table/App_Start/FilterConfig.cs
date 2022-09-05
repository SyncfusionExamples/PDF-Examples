using System.Web;
using System.Web.Mvc;

namespace Creating_a_PDF_document_with_table
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
