using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LittleBooks.BLL.Services;
using LittleBooks.Common.Filters;
using LittleBooks.Common.Models;

namespace LittleBooks.Controllers
{
    public class AccountController : Controller
    {
        AccountService accountService;

        public AccountController()
        {
            accountService = new AccountService();
        }
        // GET: Account
        [LoginFilter]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (accountService.GetLogin(user)==false)
            {
                ViewBag.error = "not allowed";
                return View();
            }

            else
            {
                Session["LoggedUser"] = user;
                return RedirectToAction("Index", "Admin");
            }
        }


        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }



    }
}