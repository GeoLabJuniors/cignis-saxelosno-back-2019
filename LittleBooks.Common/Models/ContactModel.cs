using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.Common.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        public ContactTypeModel ContactType { get; set; }

        [DisplayName("მონაცემი")]
        public string Value { get; set; }

    }
}
