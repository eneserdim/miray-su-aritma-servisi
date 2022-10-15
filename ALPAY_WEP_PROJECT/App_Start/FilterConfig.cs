using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
