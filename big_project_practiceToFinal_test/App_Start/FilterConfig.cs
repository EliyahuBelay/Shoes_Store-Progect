using System.Web;
using System.Web.Mvc;

namespace big_project_practiceToFinal_test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
