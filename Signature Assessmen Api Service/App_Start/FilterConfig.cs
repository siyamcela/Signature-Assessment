using System.Web;
using System.Web.Mvc;

namespace Signature_Assessmen_Api_Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
