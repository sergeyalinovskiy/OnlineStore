namespace OnlineStore_Epam2018.Models
{
    using SA.OnlineStore.Common.Entity;
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class OrderViewModel
    {
      
        [Display(Name = "Номер заказа")]
        public int Id { get; set; }
        [Display(Name = "Номер пользователя")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Укажите адрес доставки")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Статус заказа")]
        public StatusOrder Status { get; set; }
        [Required(ErrorMessage = "Укажите дату")]
        [Display(Name = "Дата")]
        public DateTime DateOrder { get; set; }

        public List<StatusOrder> StatusOrders { get; set; }
    }
}