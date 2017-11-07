using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                if (Request["username"] == "Marco" &&  Request["password"] == "Test")
                {
                    //if (users.UseSMS)
                    //{
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[6];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);



					var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");

					var postData = "api_key=56435b83";
					postData += "&api_secret=3350e362df8ec70";
					postData += "&to=41799456133";
					postData += "&from=\"\"NEXMO\"\"";
					postData += "&text=\"" + finalString + "\"";
					var data = Encoding.ASCII.GetBytes(postData);

					request.Method = "POST";
					request.ContentType = "application/x-www-form-urlencoded";
					request.ContentLength = data.Length;

					using(var stream = request.GetRequestStream())
					{
						stream.Write(data, 0, data.Length);
					}

					var response = (HttpWebResponse)request.GetResponse();

					var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

					ViewBag.Message = responseString;

					//}
					//else{
					//    var key = OtpNet.KeyGeneration.GenerateRandomKey(6);

					//}

				}
                else{
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }

            return View();
        }
    }
}