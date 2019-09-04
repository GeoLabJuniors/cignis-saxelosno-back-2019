using LittleBooks.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class AboutProjectRepository : GenericRepository<AboutProject>
    {
        public AboutProjectRepository(DbContext context) : base(context)
        {

        }
    }
}
