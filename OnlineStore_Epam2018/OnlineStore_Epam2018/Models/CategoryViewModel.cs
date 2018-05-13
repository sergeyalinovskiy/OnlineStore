using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore_Epam2018.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
    }
}