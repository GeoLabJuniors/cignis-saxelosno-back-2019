using LittleBooks.BLL.Services;
using LittleBooks.Common.Models;
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

        public ActionResult Catalogue( int pageNum=1,bool byTitle=false, bool byAuthor=false, string search="")
        {
            CatalogueWievModel ob = new CatalogueWievModel();
            int pageQuantity = 0;
            int listCount = 0;
            var data = taleService.GetSortAndSearchTales(pageNum,  byTitle, byAuthor, search, ref listCount, ref pageQuantity);

            ob.ListCount = listCount;
            ob.PageQuantity = pageQuantity;
            ob.byTitle = byTitle;
            ob.byAuthor = byAuthor;
            ob.Tales = data;

            return View(ob);
        }

       

        public ActionResult AuthorPage(int id)
        {
            var data = authorService.GetAuthor(id);

            return View(data);
        }

    }
}