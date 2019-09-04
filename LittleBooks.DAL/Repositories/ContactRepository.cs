using LittleBooks.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>
    {
        public ContactRepository(DbContext context) : base(context)
        {

        }
    }
   
}
