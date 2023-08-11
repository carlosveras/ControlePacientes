using System.Web;
using System.Web.Mvc;
using ControlePacientes.Filters;
namespace ControlePacientes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificarSession());
        }
    }
}
