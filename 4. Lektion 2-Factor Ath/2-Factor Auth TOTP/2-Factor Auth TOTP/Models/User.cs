using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_Factor_Auth_TOTP.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSMS { get; set; }
    }
}