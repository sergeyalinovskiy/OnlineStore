﻿namespace OnlineStore_Epam2018.Models
{
    using SA.OnlineStore.Common.Entity;
    #region Usings
    using System;
    using System.ComponentModel.DataAnnotations;
    #endregion

    public class OrderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public int ProductListId { get; set; }
        [Required(ErrorMessage = "Укажите адрес доставки")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        public StatusOrder Status { get; set; }
        [Required(ErrorMessage = "Укажите дату")]
        [Display(Name = "Дата")]
        public DateTime DateOrder { get; set; }
    }
}