using System.Web;
using System.Web.Mvc;

namespace ConfigurationManager.AppSettings["BasePath"]
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
