using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImbarkPlatform.Areas.AccountManagement.Models
{
    public class RegisterModel
    {
        public string Email { set; get; }
        public string Nickname { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
}