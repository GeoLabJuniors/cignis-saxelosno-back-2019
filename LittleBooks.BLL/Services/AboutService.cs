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
    public class AboutService
    {
        IUnitOfWork Uow;

        public AboutService()
        {
            this.Uow = new UnitOfWork(new LittleBooksEntities());
        }
        

        public AboutProjectModel GetAboutProject()
        {
            var data = Uow.AboutProject.GetAll().FirstOrDefault();

            AboutProjectModel model = new AboutProjectModel
            {
                Id = data.Id,
                Text = data.Text
            };

            return model;
        }

        public AboutProjectModel GetAboutProject(int id)
        {
            var data = Uow.AboutProject.Get(id);

            AboutProjectModel model = new AboutProjectModel
            {
                Id = data.Id,
                Text = data.Text
            };

            return model;
        }

        public void Edit(AboutProjectModel about)
        {
            var data = Uow.AboutProject.Get(about.Id) ;
            data.Text = about.Text;

            Uow.Save();

        }
    }
}
