using _2_Factor_Auth_TOTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Factor_Auth_TOTP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User users)
        {
            if (ModelState.IsValid)
            {
                if (users.UserName == "Marco" && users.Password == "Test")
                {
                    if (users.UseSMS)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[6];
                        var random = new Random();

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }

                        var finalString = new String(stringChars);


                        //Send(new SMSRequest
                        //{
                        //    from = "0799456133",
                        //    to = "0799456133",
                        //    text = finalString
                        //});
                    }
                    {
                        var key = OtpNet.KeyGeneration.GenerateRandomKey(6);
                        
                    }

                }
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }

            return View();
        }
    }
}