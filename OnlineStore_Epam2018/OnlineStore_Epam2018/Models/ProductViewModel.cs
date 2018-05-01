using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore_Epam2018.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SeasonName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}