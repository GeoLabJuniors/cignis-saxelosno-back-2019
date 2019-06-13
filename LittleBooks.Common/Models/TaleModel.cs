using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LittleBooks.Common.Models
{
    public class TaleModel
    {
        public int Id { get; set; }

        [DisplayName("სათაური")]
        [Required(ErrorMessage = "შეიყვანეთ სათაური")]
        public string Title { get; set; }

        [DisplayName("მოთხრობის ლინკი")]
        [Required(ErrorMessage = "შეიყვანეთ ლინკი")]
        public string TaleLink { get; set; }

        [DisplayName("ავტორი")]
        [Required(ErrorMessage = "აირჩიეთ ავტორი")]
        public AuthorModel Author { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("შექმნის თარიღი")]
        public DateTime CreateDate { get; set; }

        public DateTime DeleteDate { get; set; }

        [DisplayName("სურათი")]
        [Required(ErrorMessage = "ატვირთეთ სურათი")]
        public HttpPostedFileBase ImageFile { get; set; }




    }
}
