using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LittleBooks.Common.Models;
using LittleBooks.DAL.Data;
using LittleBooks.DAL.Interfaces;
using LittleBooks.DAL.Repositories;
using LittleBooks.DAL.UnitOfWork;

namespace LittleBooks.BLL.Services
{
    public class ContactService
    {
        IUnitOfWork Uow;

        public ContactService()
        {
            this.Uow = new UnitOfWork(new LittleBooksEntities());
        }

        public List<ContactModel> GetAll()
        {
            List<ContactModel> data = Uow.Contacts.GetAll().Select(x => new ContactModel
            {
                Id = x.Id,
                ContactType = new ContactTypeModel
                {
                    Id = x.ContactType.Id,
                    Code = x.ContactType.Code,
                    Name = x.ContactType.Name
                },
                IconUrl = x.IconUrl,
                Value = x.Value
            }).ToList();

            return data;
        }

        public ContactModel Get(int id)
        {
            var data = Uow.Contacts.Get(id);

            ContactModel model = new ContactModel
            {
                Id = data.Id,
                ContactType = new ContactTypeModel
                {
                    Id = data.ContactType.Id,
                    Code = data.ContactType.Code,
                    Name = data.ContactType.Name
                },
                IconUrl=data.IconUrl,
                Value = data.Value
            };

            return model;

        }


        public void Edit(ContactModel contactModel)
        {
            string imagePath = SaveImageAndGetUrl(contactModel.ImageFile);
            var data = Uow.Contacts.Get(contactModel.Id);

            data.Value = contactModel.Value;
            data.IconUrl = contactModel.IconUrl;
            if (contactModel.ImageFile != null)
            {
                data.IconUrl = imagePath;
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
