using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore_Epam2018.Models
{
    public class ProductViewModel
    {
       
        public int Id { get; set; }
        [Required (ErrorMessage ="Ввведите имя ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вs,thbnt rfntujhb. ")]
        public string CategoryName { get; set; }
        public string SeasonName{ get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public IEnumerable<string> SeasonNameList { get; set; }
        public IEnumerable<string> CategoryNameList { get; set; }
        //public IEnumerable<string> sortList { get; set; }
    }
}