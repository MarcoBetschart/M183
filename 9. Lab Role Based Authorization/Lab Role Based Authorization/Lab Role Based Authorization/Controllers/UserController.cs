using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_Role_Based_Authorization.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Dashboard()
		{
			var currentUser = (string)Session["username"];
			var userRoles = MvcApplication.UserRoles;
			var currenUserRole = (string)userRoles[currentUser];

			if (currenUserRole == "User")
			{
				// mit DB verbinden
			}
			else
				return RedirectToAction("Index", "Home");
			
			return View();
        }
    }
}