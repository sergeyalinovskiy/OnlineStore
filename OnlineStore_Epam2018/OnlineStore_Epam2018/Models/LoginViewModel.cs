using System.ComponentModel.DataAnnotations;
namespace OnlineStore_Epam2018.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Логин введен не верно")]
        [Display(Name = "Логин")]
        public string  Login { get; set; }
        [Required(ErrorMessage = "Пароль не подходит")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}