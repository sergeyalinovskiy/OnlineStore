using System.ComponentModel.DataAnnotations;

namespace OnlineStore_Epam2018.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Название")]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Колличество")]
        [Required(ErrorMessage = "Выберите колличество")]
        public int Count { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        public string Picture { get; set; }
    }
}
