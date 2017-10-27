using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sessions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {

            var username = Request["username"];
            var password = Request["password"];
            var stay_logged_in = Request["stay_logged_in"];

            if (username == "test" && password == "test")
            {
                if (stay_logged_in == "on")
                {
                    var auth_cookie = new HttpCookie("misleading_name_for_an_authentication_cookie");
                    auth_cookie.Value = "SOME_NONCE_VALUE";
                    auth_cookie.Expires = DateTime.Now.AddDays(14);
                    auth_cookie.Path = "localhost:49473";

                    Response.Cookies.Add(auth_cookie);

                }
                else
                {
                    Session["misleading_name_for_an_authentication_cookie"] = "SOME_NONCE_VALUE";
                }

                Response.Redirect("Admin/Home");
            }
            else
            {
                ViewBag.Content("Failed to Login");
            }

            return View();
        }
    }
}