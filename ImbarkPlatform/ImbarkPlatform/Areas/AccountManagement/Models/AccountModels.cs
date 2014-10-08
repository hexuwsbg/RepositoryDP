using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImbarkPlatform.Lib.Helper;
using ImbarkPlatform.Lib.UserManagement;

namespace ImbarkPlatform.Areas.AccountManagement.Models
{
    public class RegisterModel
    {
        public string Email { set; get; }
        public string Nickname { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }

        public static explicit operator UserInfo( RegisterModel model )
        {
            UserInfo ui = new UserInfo();
            ui.Nickname = model.Nickname;
            ui.Password = Encryption.EncryptText(model.Password);
            ui.Email = model.Email;
            ui.Role = CommEnum.UserRole.CUSTOMER;
            return ui;
        }
    }
}