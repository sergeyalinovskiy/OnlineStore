using System.ComponentModel.DataAnnotations;

namespace OnlineStore_Epam2018.Models
{
    public class SeasonViewModel
    {
        public int SeasonId { get; set; }
        
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Сезон")]
        public string SeasonName { get; set; }
    }
}