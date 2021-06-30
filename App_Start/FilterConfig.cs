using System.Web;
using System.Web.Mvc;

namespace _1911061972_NguyenBinhAn_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
