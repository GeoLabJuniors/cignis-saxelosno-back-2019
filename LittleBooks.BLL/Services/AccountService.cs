using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleBooks.Common.Models;
using LittleBooks.DAL.Data;

namespace LittleBooks.BLL.Services
{
    public class AccountService
    {
        LittleBooksEntities db;

        public AccountService()
        {
           db = new LittleBooksEntities();
        }
        
        public List<LoginModel> GetLogins()
        {
            List<LoginModel> data = db.LoginUsers.Select(x => new LoginModel
            {
                Email = x.Email,
                Password = x.Password
            }).ToList();

            return data;

        }

        public bool GetLogin(LoginModel loginModel)
        {
            LoginUser user = db.LoginUsers.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            if (user == null)
            {
                return false;
            }

            else
            {
               
                return true;
            }
            
        }
    }
}
