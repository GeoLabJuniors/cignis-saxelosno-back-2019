using LittleBooks.DAL.Interfaces;
using LittleBooks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext Context;

        public UnitOfWork(DbContext Context)
        {
            this.Context = Context;
        }


        public TaleRepository Tales  => new TaleRepository(Context);
        public AuthorRepository Authors { get
            {
                return new AuthorRepository(Context);
            } }
        public ContactRepository Contacts => new ContactRepository(Context);
        public AboutProjectRepository AboutProject => new AboutProjectRepository(Context);
        public ContactTypeRepository ContactType => new ContactTypeRepository(Context);
        public LoginUserRepository LoginUsers => new LoginUserRepository(Context);

        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
