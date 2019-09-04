using LittleBooks.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class ContactTypeRepository : GenericRepository<ContactType>
    {
        public ContactTypeRepository(DbContext context) : base(context)
        {

        }
    }
    
}
