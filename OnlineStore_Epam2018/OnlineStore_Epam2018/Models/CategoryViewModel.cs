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
    }
}