using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LittleBooks.BLL.Services;
using LittleBooks.Common.Models;

namespace LittleBooks.Controllers
{
    public class AboutController : Controller
    {
        AboutService aboutService;

        public AboutController()
        {
            aboutService = new AboutService();
        }
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var data = aboutService.GetAboutProject();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        


    }
}