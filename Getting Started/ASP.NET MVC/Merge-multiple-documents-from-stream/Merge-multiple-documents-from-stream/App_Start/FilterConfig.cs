using System.Web;
using System.Web.Mvc;

namespace Merge_multiple_documents_from_stream
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
