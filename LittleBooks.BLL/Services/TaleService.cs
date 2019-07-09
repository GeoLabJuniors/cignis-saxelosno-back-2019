using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LittleBooks.Common.Models;
using LittleBooks.DAL.Data;

namespace LittleBooks.BLL.Services
{
    public class TaleService
    {

        LittleBooksEntities db;

        public TaleService()
        {
            db = new LittleBooksEntities();
        }
        public List<TaleModel> GetAllTales()
        {
            List<TaleModel> data = db.Tales.Where(d => d.DeleteDate == null).Select(x => new TaleModel
            {
                Id = x.Id,
                Title = x.Title,
                TaleLink = x.TaleLink,
                Author = new AuthorModel
                {
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                },
                ImageUrl = x.ImageUrl,
                CreateDate = x.CreateDate
            }).ToList();

            return data;
        }

        public TaleViewModel GetTale(int id)
        {
            var tale = db.Tales.FirstOrDefault(x => x.Id == id);
            var authorsList = db.Authors.Where(x => x.DeleteDate == null).Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();

            TaleViewModel model = new TaleViewModel
            {
                Id = tale.Id,
                Title = tale.Title,
                TaleLink = tale.TaleLink,
                ImageUrl = tale.ImageUrl,
                CreateDate = tale.CreateDate,
                AuthorsList = authorsList
            };
            if (tale.AuthorId != null)
            {
                model.AuthorsList.FirstOrDefault(x => x.Value == tale.AuthorId.ToString()).Selected = true;
            }


            return model;

        }

        public TaleViewModel FillAddTaleModel(TaleViewModel model)
        {
            var authorsList = db.Authors.Where(x => x.DeleteDate == null).Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();

            model.AuthorsList = authorsList;

            return model;
        }


        public void AddTale(TaleViewModel taleModel)
        {
            string imagePath = SaveImageAndGetUrl(taleModel.ImageFile);

            Tale addTale = new Tale
            {
                Title = taleModel.Title,
                TaleLink = taleModel.TaleLink,
                AuthorId = taleModel.Author.Id,
                ImageUrl = imagePath,
                CreateDate = DateTime.Now
            };

            db.Tales.Add(addTale);
            db.SaveChanges();

        }

        public void EditTale(TaleViewModel tale)
        {
            var data = db.Tales.FirstOrDefault(x => x.Id == tale.Id);

            data.Title = tale.Title;
            data.TaleLink = tale.TaleLink;
            data.AuthorId = tale.Author.Id;

            if (tale.ImageFile != null)
            {

                string imagePath = SaveImageAndGetUrl(tale.ImageFile);

                data.ImageUrl = imagePath;
            }


            db.SaveChanges();
        }

        public void DeleteTale(int id)
        {
            var data = db.Tales.FirstOrDefault(x => x.Id == id);
            data.DeleteDate = DateTime.Now;

            db.SaveChanges();
        }


        public List<TaleModel> GetRandom3Tales()
        {
            List<TaleModel> data = db.Tales.Where(d => d.DeleteDate == null).Select(x => new TaleModel
            {
                Id = x.Id,
                Title = x.Title,
                TaleLink = x.TaleLink,
                Author = new AuthorModel
                {
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                },
                ImageUrl = x.ImageUrl,
                CreateDate = x.CreateDate
            }).ToList();


            Random rand = new Random();

            List<TaleModel> randTales = new List<TaleModel>();

            int num = data.Count() >= 3 ? 3 : data.Count();


            for (int i = num; i > 0; i--)
            {
                var a = data[rand.Next(0, data.Count())];
                if (randTales.Contains(a))
                {
                    i++;
                    continue;
                }
                randTales.Add(a);
            }

            return randTales;
        }


        private string SaveImageAndGetUrl(HttpPostedFileBase ImageFile)
        {
            var uniqueNumber = Random32();
            string extension = Path.GetExtension(ImageFile.FileName);
            string name = Path.GetFileNameWithoutExtension(ImageFile.FileName);

            string fileFullName = $"{name}_{uniqueNumber}{extension}";

            string imagePath = Path.Combine("~/Images/", fileFullName);

            ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(imagePath));

            return imagePath;
        }

        public static string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
