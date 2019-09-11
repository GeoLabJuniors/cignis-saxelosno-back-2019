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
    public class ContactModel
    {
        public int Id { get; set; }

        public ContactTypeModel ContactType { get; set; }

        [DisplayName("მონაცემი")]
        public string Value { get; set; }

        public string IconUrl { get; set; }

        [DisplayName("სურათი")]
        [Required(ErrorMessage = "ატვირთეთ სურათი")]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
