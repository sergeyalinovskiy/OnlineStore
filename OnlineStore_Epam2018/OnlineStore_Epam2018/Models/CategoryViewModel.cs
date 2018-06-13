using SA.OnlineStore.Common.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore_Epam2018.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        [Required(ErrorMessage = "Ввведите имя")]
        [Display(Name = "Имя новой категории")]
        public string NewCategoryName { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Категория")]
        public string ParentCategoryName { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

    }
}