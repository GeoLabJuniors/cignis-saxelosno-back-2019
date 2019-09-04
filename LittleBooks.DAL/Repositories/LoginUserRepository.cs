using LittleBooks.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.DAL.Repositories
{
    public class LoginUserRepository : GenericRepository<LoginUser>
    {
        public LoginUserRepository(DbContext context) : base(context)
        {
        }

        public LoginUser FindUser(string email, string password)
        {
            var data = base.Context.Set<LoginUser>().FirstOrDefault(x =>x.Email == email && x.Password == password);
            return data;
        }

    }
}
