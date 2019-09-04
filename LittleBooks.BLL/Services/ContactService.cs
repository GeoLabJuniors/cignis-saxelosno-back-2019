using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Value = data.Value
            };

            return model;

        }


        public void Edit(ContactModel contactModel)
        {
            var data = Uow.Contacts.Get(contactModel.Id);

            data.Value = contactModel.Value;

            Uow.Save();
        }


    }
}
