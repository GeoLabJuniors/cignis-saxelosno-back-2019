using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LittleBooks.BLL.Services;
using LittleBooks.Common.Models;

namespace LittleBooks.Controllers
{
    public class ContactController : Controller
    {
        ContactService contactService;

        public ContactController()
        {
            contactService = new ContactService();
        }
        // GET: Contact
        public ActionResult Index()
        {
            var data = contactService.GetAll();

            return View(data);
        }

        
    }
}