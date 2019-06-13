using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleBooks.Common.Models;
using LittleBooks.DAL.Data;

namespace LittleBooks.BLL.Services
{
    public class ContactService
    {
        LittleBooksEntities db;
        public ContactService()
        {
            db = new LittleBooksEntities();
        }

        public List<ContactModel> GetAll()
        {
            List<ContactModel> data = db.Contacts.Select(x => new ContactModel
            {
                Id=x.Id,
                ContactType= new ContactTypeModel
                {
                    Id = x.ContactType.Id,
                    Code = x.ContactType.Code,
                    Name = x.ContactType.Name
                },
                Value=x.Value
            }).ToList();

            return data;
        }

        public ContactModel Get(int id)
        {
            var data = db.Contacts.FirstOrDefault(x=>x.Id == id);

            ContactModel model = new ContactModel
            {
                Id = data.Id,
                ContactType= new ContactTypeModel
                {
                    Id=data.ContactType.Id,
                    Code=data.ContactType.Code,
                    Name=data.ContactType.Name
                },
                Value=data.Value
            };

            return model;

        }


        public void Edit(ContactModel contactModel)
        {
            var data = db.Contacts.FirstOrDefault(x=>x.Id==contactModel.Id);

            data.Value = contactModel.Value;

            db.SaveChanges();
        }
            

    }
}
