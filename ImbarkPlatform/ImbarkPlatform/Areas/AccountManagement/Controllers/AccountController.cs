﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImbarkPlatform.Areas.AccountManagement.Models;
using ImbarkPlatform.Lib.UserManagement;
using ImbarkPlatform.Services.AccountManagement.AccountServiceImplements;
using ImbarkPlatform.Services.AccountManagement.AccountServiceInterfaces;

namespace ImbarkPlatform.Areas.AccountManagement.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService ias;
        //
        // GET: /UserInfo/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( LoginModel model )
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("/Areas/AccountManagement/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register( RegisterModel model )
        {
            if ( ValidateRegisterModel(model) )
            {
                ias = new AccountServiceImpl();

                ias.Register((UserInfo) model);
            }
            else
            {
                ViewBag.ErrorMessage = "";
            }
            return View();
        }

        private bool ValidateRegisterModel( RegisterModel model )
        {
            return true;
        }

    }
}
