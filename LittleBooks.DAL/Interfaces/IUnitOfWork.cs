using LittleBooks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        TaleRepository Tales { get; }
        AuthorRepository Authors { get;  }
        ContactRepository Contacts { get;  }
        AboutProjectRepository AboutProject { get; }
        ContactTypeRepository ContactType { get; }
        LoginUserRepository LoginUsers { get;}
        void Save();

    }
}
