using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LittleBooks.Common.Models
{
    public class TaleViewModel : TaleModel
    {
        [DisplayName("ავტორი")]
        public List<SelectListItem> AuthorsList { get; set; }
    }
}
