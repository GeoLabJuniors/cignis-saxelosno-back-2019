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
using LittleBooks.DAL.Interfaces;
using LittleBooks.DAL.Repositories;
using LittleBooks.DAL.UnitOfWork;

namespace LittleBooks.BLL.Services
{
    public class AuthorService
    {
        IUnitOfWork Uow;

        public AuthorService()
        {
            this.Uow = new UnitOfWork(new LittleBooksEntities());
            

        }


        public List<AuthorModel> GetAllAuthor()
        {
            List<AuthorModel> data = Uow.Authors.GetAll().Where(d => d.DeleteDate == null).Select(x => new AuthorModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                About = x.About,
                ImageUrl = x.ImageUrl

            }).ToList();

            return data;
        }


        public AuthorModel GetAuthor(int id)
        {
            var data = Uow.Authors.Get(id);
            AuthorModel model = new AuthorModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Tales = data.Tales.Where(d => d.DeleteDate == null).Select(t => new TaleModel
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
            var data = Uow.Authors.Get(author.Id);

            data.FirstName = author.FirstName;
            data.LastName = author.LastName;
            data.About = author.About;


            if (author.ImageFile != null)
            {

                string imagePath = SaveImageAndGetUrl(author.ImageFile);

                data.ImageUrl = imagePath;
            }

            Uow.Save();

        }

        public void AddAuthor(AuthorModel authorModel)
        {
            string imagePath = SaveImageAndGetUrl(authorModel.ImageFile);

            Author addAuthor = new Author
            {
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
                About = authorModel.About,
                ImageUrl = imagePath,

            };

            Uow.Authors.Add(addAuthor);
            Uow.Save();

        }

        public void DeleteAuthor(int id)
        {
            var author = Uow.Authors.Get(id);
            author.DeleteDate = DateTime.Now;

            var tales = Uow.Tales.GetAll().Where(x => x.AuthorId == id);

            foreach (var tale in tales)
            {
                tale.AuthorId = null;
            }

            Uow.Save();
            

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
