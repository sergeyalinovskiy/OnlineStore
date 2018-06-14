namespace OnlineStore_Epam2018.Models
{
    using SA.OnlineStore.Common.Entity;
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class ProductViewModel
    {
        public int Id { get; set; }

         [Display(Name = "Название")]
        [Required (ErrorMessage ="Ввведите имя ")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Выберите категорию")]
        public string CategoryName { get; set; }

        [Display(Name = "Сезон")]
        [Required(ErrorMessage = "Выберите сезон")]
        public string SeasonName{ get; set; }

        [Required]
        [Display(Name = "Картинка")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Колличество")]
        [Required(ErrorMessage = "Укажите колличество на складе")]
        public int Count { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Установите цену")]
        public int Price { get; set; }

        public Category Category { get; set; }
        public Season Season { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Season> SeasonList { get; set; }
        public int SeasonId { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Role> RoleList { get; set; }
    }
}