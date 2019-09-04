using LittleBooks.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBooks.Controllers
{
    public class HomeController : Controller
    {
        TaleService taleService;
        AuthorService authorService;

        public HomeController()
        {
            taleService = new TaleService();
            authorService = new AuthorService();
        }

        // GET: Home
        public ActionResult Index()
        {
            var data = taleService.GetRandom3Tales();

            return View(data);
           
        }

        public ActionResult Catalogue( bool title, bool author, string search="")
        {

            var data = taleService.GetSortAndSearchTales(title, author,search);

            return View(data);
        }

       

        public ActionResult AuthorPage(int id)
        {
            var data = authorService.GetAuthor(id);

            return View(data);
        }

    }
}