﻿using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore_Epam2018.Models
{
    public class UserViewModel
    {
        [Display(Name = "Номер пользователя")]
        public int UserId { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Ввведите логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Ввведите имя ")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Ввведите фамилию ")]
        public string LastName { get; set; }
        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Укажите роль")]
        public string RoleName { get; set; }
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Укажите телефонный номер")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Введить почтовый адрес")]
        public string EmailAddress { get; set; }

        public IEnumerable<Email> Emails { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Role> Roles { get; set; }

    }
}