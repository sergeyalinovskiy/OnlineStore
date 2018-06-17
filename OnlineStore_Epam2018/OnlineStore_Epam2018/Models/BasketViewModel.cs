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
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Укажите цену")]
        public int Price { get; set; }
        [Display(Name = "Номер заказа")]
        public int OrderId { get; set; }
        [Display(Name = "Картинка")]
        public string Picture { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
