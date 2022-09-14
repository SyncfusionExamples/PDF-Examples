using System.Web;
using System.Web.Mvc;

namespace Merge_multiple_PDF_documents_from_disk
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
