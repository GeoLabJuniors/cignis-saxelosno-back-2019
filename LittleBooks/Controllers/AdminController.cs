using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LittleBooks.BLL.Services;
using LittleBooks.Common.Models;

namespace LittleBooks.Controllers
{
    public class AdminController : Controller
    {
        TaleService taleService;
        AuthorService authorService;
        AboutService aboutService;
        ContactService contactService;

        public AdminController()
        {
            taleService = new TaleService();
            authorService = new AuthorService();
            aboutService = new AboutService();
            contactService = new ContactService();
        }

        
        // GET: Admin
        public ActionResult Index()
        {
            var data = taleService.GetAllTales();
            return View(data);
        }

        public ActionResult AddTale()
        {
            TaleViewModel model = new TaleViewModel();
            model = this.taleService.FillAddTaleModel(model);

            return View(model);
        }


        [HttpPost]
        public ActionResult AddTale(TaleViewModel model)
        {
            taleService.AddTale(model);

            return RedirectToAction("Index", "Admin");
        }


        public ActionResult EditTale(int id)
        {
            var data = taleService.GetTale(id);

            return View(data);
        }



        [HttpPost]
        public ActionResult EditTale(TaleViewModel model)
        {
            taleService.EditTale(model);
            return RedirectToAction("Index", "Admin");
        }


        public ActionResult DeleteTale(int id)
        {
            taleService.DeleteTale(id);

            return RedirectToAction("Index");
        }


        public ActionResult GetAllAuthors()
        {
            var data = authorService.GetAllAuthor();
            return View(data);
        }


        public ActionResult EditAuthor(int id)
        {
            var data = authorService.GetAuthor(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult EditAuthor(AuthorModel model)
        {
            authorService.EditAuthor(model);
            return RedirectToAction("GetAllAuthors", "Admin");
        }

        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(AuthorModel model)
        {

            authorService.AddAuthor(model);


            return RedirectToAction("GetAllAuthors", "Admin");
        }

        public ActionResult DeleteAuthor(int id)
        {
            authorService.DeleteAuthor(id);

            return RedirectToAction("GetAllAuthors", "Admin");
        }

        public ActionResult GetAllContact()
        {
            var data = contactService.GetAll();

            return View(data);
        }

        public ActionResult EditContact(int id)
        {
            var data = contactService.Get(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditContact(ContactModel model)
        {

            contactService.Edit(model);

            return RedirectToAction("GetAllContact");
        }

        public ActionResult GetAboutProject()
        {
            var data = aboutService.GetAboutProject();

            return View(data);

        }

        public ActionResult EditAboutProject()
        {
            var data=aboutService.GetAboutProject();

            return View(data);
        }

        [HttpPost]
        public ActionResult EditAboutProject(AboutProjectModel model)
        {

            aboutService.Edit(model);

            return RedirectToAction("GetAboutProject");
        }


    }
}