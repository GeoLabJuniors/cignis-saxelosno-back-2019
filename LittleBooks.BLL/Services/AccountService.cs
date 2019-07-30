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
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password
            }).ToList();

            return data;

        }

        public LoginModel GetLoginUser(LoginModel loginModel)
        {
            var data = db.LoginUsers.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            if (data != null)
            {
                LoginModel user = new LoginModel
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    Password = data.Password
                };
                return user;
            }


            return null;
        }
    }
}
