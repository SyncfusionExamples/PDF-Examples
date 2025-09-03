using System.Web;
using System.Web.Mvc;

namespace PDF_generation_through_ASMX_based_web_app
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
