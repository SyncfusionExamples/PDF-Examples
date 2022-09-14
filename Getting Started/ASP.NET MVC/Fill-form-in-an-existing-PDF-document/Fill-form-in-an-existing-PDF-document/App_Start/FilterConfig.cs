using System.Web;
using System.Web.Mvc;

namespace Fill_form_in_an_existing_PDF_document
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
