using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.Common.Models
{
   public  class AboutProjectModel
    {
        public int Id { get; set; }

        [DisplayName("ტექსტი")]
        public string Text { get; set; }
        
    }
}
