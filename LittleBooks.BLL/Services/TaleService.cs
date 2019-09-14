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
    public class TaleService
    {
        IUnitOfWork Uow;

        public TaleService()
        {
            this.Uow = new UnitOfWork(new LittleBooksEntities());
        }
        public List<TaleModel> GetAllTales()
        {
            List<TaleModel> data = Uow.Tales.GetAll().Where(d => d.DeleteDate == null).Select(x => new TaleModel
            {
                Id = x.Id,
                Title = x.Title,
                TaleLink = x.TaleLink,
                Author = x.Author == null ? null : new AuthorModel
                {
                    Id = x.Id,
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
            var tale = Uow.Tales.Get(id);
            var authorsList = Uow.Authors.GetAll().Where(x => x.DeleteDate == null).Select(x => new SelectListItem
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
            var authorsList = Uow.Authors.GetAll().Where(x => x.DeleteDate == null).Select(x => new SelectListItem
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

            Uow.Tales.Add(addTale);
            Uow.Save();

        }

        public void EditTale(TaleViewModel tale)
        {
            var data = Uow.Tales.Get(tale.Id);

            data.Title = tale.Title;
            data.TaleLink = tale.TaleLink;
            data.AuthorId = tale.Author.Id;

            if (tale.ImageFile != null)
            {

                string imagePath = SaveImageAndGetUrl(tale.ImageFile);

                data.ImageUrl = imagePath;
            }


            Uow.Save();
        }

        public void DeleteTale(int id)
        {
            var data = Uow.Tales.Get(id);
            data.DeleteDate = DateTime.Now;

            Uow.Save();
        }


        public List<TaleModel> GetRandom3Tales()
        {
            List<TaleModel> data = Uow.Tales.GetAll().Where(d => d.DeleteDate == null).Select(x => new TaleModel
            {
                Id = x.Id,
                Title = x.Title,
                TaleLink = x.TaleLink,
                Author = new AuthorModel
                {
                    Id = x.Author.Id,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                },
                ImageUrl = x.ImageUrl,
                CreateDate = x.CreateDate
            }).OrderBy(g => Guid.NewGuid()).Take(3).ToList();


            //Random rand = new Random();

            //List<TaleModel> randTales = new List<TaleModel>();

            //int num = data.Count() >= 3 ? 3 : data.Count();


            //for (int i = num; i > 0; i--)
            //{
            //    var a = data[rand.Next(0, data.Count())];
            //    if (randTales.Contains(a))
            //    {
            //        i++;
            //        continue;
            //    }
            //    randTales.Add(a);
            //}

            return data;
        }
        public List<TaleModel> GetSortAndSearchTales(int pageNum,  bool byTitle,  bool byAuthor, string search, ref int count, ref int pageQuantity)
        {

            List<TaleModel> tales;

            var data = Uow.Tales.GetAll().Where
                   (
                   x => x.Title.Contains(search) ||
                   x.Author.FirstName.Contains(search) ||
                   x.Author.LastName.Contains(search)
                   );
            var model = data.Where(d => d.DeleteDate == null).Select(x => new TaleModel
            {
                Id = x.Id,
                Title = x.Title,
                TaleLink = x.TaleLink,
                Author = x.Author == null ? null : new AuthorModel
                {
                    Id = x.Id,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                },
                ImageUrl = x.ImageUrl,
                CreateDate = x.CreateDate
            });

            if (byTitle == true && byAuthor == false)
            {
                tales = model.OrderBy(o => o.Title).ToList();
            }

            else if (byTitle == false && byAuthor == true)
            {
                tales = model.OrderBy(o => o.Author.LastName).ToList();
            }
            else
            {
                tales = model.ToList();
            }
            count = tales.Count;


            if (count % 3 == 0)
            {
                pageQuantity = count / 3;
            }

            else
            {
                pageQuantity = (count / 3) + 1;
            }

            int rangeIndex = (pageNum - 1) * 3;
            int rangeCount = 3;
            if (pageQuantity == pageNum)
            {
                if (count % 3 == 1)
                {
                    rangeCount = 1;
                }
                else if (count % 3 == 2)
                {
                    rangeCount = 2;
                }
                else
                {
                    rangeCount = 3;
                }
            }

            tales = tales.GetRange(rangeIndex, rangeCount);

            return tales;

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
