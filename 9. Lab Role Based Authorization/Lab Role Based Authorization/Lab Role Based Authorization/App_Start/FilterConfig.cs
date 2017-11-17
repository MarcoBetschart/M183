using System.Web;
using System.Web.Mvc;

namespace Lab_Role_Based_Authorization
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
