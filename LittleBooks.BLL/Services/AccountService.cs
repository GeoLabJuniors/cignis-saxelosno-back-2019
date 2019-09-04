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
    public class AccountService
    {
        IUnitOfWork Uow;

        public AccountService()
        {
            this.Uow = new UnitOfWork(new LittleBooksEntities());
           
        }

        public List<LoginModel> GetLogins()
        {
            List<LoginModel> data = Uow.LoginUsers.GetAll().Select(x => new LoginModel
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
            var data = Uow.LoginUsers.FindUser(loginModel.Email, loginModel.Password);

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
