using System.ComponentModel.DataAnnotations;

namespace OnlineStore_Epam2018.Models
{
    public class PublicityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Укажите название")]
        public string Name { get; set; }
        [Display(Name = "Текст")]
        [Required(ErrorMessage = "Ввведите текст рекламы")]
        public string Text { get; set; }
        public string Picture { get; set; }
    }
}