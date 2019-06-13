using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LittleBooks.BLL.Services;

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
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }



    }
}