using LittleBooks.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class AuthorRepository:GenericRepository<Author>
    {
        public AuthorRepository(DbContext context) : base(context)
        {

        }
    }
}
