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

        public ActionResult Catalogue( int pageNum=1,bool byTitle=false, bool byAuthor=false, string search="")
        {
            Dictionary<string, object> siteData = new Dictionary<string, object>();
            int pageQuantity = 0;
            int count = 0;
            var data = taleService.GetSortAndSearchTales(pageNum,byTitle, byAuthor, search, ref count, ref pageQuantity);

            siteData.Add("Count", count);
            siteData.Add("PageQuantity", pageQuantity);
            siteData.Add("List", data);

            return View(siteData);
        }

       

        public ActionResult AuthorPage(int id)
        {
            var data = authorService.GetAuthor(id);

            return View(data);
        }

    }
}