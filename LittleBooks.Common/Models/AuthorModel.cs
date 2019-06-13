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
    public class AuthorModel
    {
        public int Id { get; set; }

        [DisplayName("სახელი")]
        [Required(ErrorMessage = "შეიყვანეთ სახელი")]
        public string FirstName { get; set; }

        [DisplayName("გვარი")]
        [Required(ErrorMessage = "შეიყვანეთ გვარი")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("სურათი")]
        [Required(ErrorMessage = "ატვირთეთ სურათი")]
        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("ბიოგრაფია")]
        [Required(ErrorMessage = "შეიყვანეთ ბიოგრაფია")]
        public string About { get; set; }

        [DisplayName("ნამუშევრები")]
        public List<TaleModel> Tales { get; set; }

        public DateTime DeleteDate { get; set; }
    }
}
