using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleBooks.Common.Models
{
    public class CatalogueWievModel
    {
        public List<TaleModel> Tales { get; set; }
        public int PageQuantity { get; set; }
        public int ListCount { get; set; }
        public bool byAuthor { get; set; }
        public bool byTitle { get; set; }
    }
}
