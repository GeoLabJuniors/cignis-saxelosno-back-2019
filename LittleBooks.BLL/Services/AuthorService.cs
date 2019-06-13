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
    public class AuthorService
    {
        LittleBooksEntities db;

        public AuthorService()
        {
            db = new LittleBooksEntities();
        }
        

        public List<AuthorModel> GetAllAuthor()
        {
            List<AuthorModel> data = db.Authors.Where(d => d.DeleteDate == null).Select(x => new AuthorModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                About=x.About,
                ImageUrl=x.ImageUrl

            }).ToList();

            return data;
        }


        public AuthorModel GetAuthor(int id)
        {
            var data = db.Authors.FirstOrDefault(x => x.Id == id);
            AuthorModel model = new AuthorModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Tales = data.Tales.Select(t => new TaleModel
                {
                    Title = t.Title,
                    TaleLink = t.TaleLink,
                    ImageUrl = t.ImageUrl

                }).ToList(),
                About = data.About,
                ImageUrl = data.ImageUrl

            };

            return model;

        }

        public void EditAuthor(AuthorModel author)
        {
            var data = db.Authors.FirstOrDefault(x => x.Id == author.Id);

            data.FirstName = author.FirstName;
            data.LastName = author.LastName;
            data.About = author.About;
            

            if (author.ImageFile != null)
            {

                string imagePath = SaveImageAndGetUrl(author.ImageFile);

                data.ImageUrl = imagePath;
            }

            db.SaveChanges();

        }

        public void AddAuthor(AuthorModel authorModel)
        {
            string imagePath = SaveImageAndGetUrl(authorModel.ImageFile);

            Author addAuthor = new Author
            {
                FirstName=authorModel.FirstName,
                LastName=authorModel.LastName,
                About=authorModel.About,
                ImageUrl=imagePath,
                
            };

            db.Authors.Add(addAuthor);
            db.SaveChanges();

        }

        public void DeleteAuthor(int id)
        {
            var author = db.Authors.FirstOrDefault(x => x.Id == id);
            author.DeleteDate = DateTime.Now;

            var tales = db.Tales.Where(x => x.AuthorId == id);

            foreach (var tale  in tales)
            {
                tale.AuthorId = null;
            }

            db.SaveChanges();
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
