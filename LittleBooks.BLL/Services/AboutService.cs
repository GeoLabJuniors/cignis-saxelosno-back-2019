using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleBooks.Common.Models;
using LittleBooks.DAL.Data;

namespace LittleBooks.BLL.Services
{
    public class AboutService
    {
        LittleBooksEntities db;

        public AboutService()
        {
            db = new LittleBooksEntities();
        }

        public AboutProjectModel GetAboutProject()
        {
            var data = db.AboutProjects.FirstOrDefault();

            AboutProjectModel model = new AboutProjectModel
            {
                Id = data.Id,
                Text = data.Text
            };

            return model;
        }

        public AboutProjectModel GetAboutProject(int id)
        {
            var data = db.AboutProjects.FirstOrDefault(x => x.Id == id);

            AboutProjectModel model = new AboutProjectModel
            {
                Id = data.Id,
                Text = data.Text
            };

            return model;
        }

        public void Edit(AboutProjectModel about)
        {
            var data = db.AboutProjects.FirstOrDefault(x => x.Id==about.Id);
            data.Text = about.Text;

            db.SaveChanges();

        }
    }
}
