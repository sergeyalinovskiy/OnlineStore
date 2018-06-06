using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore_Epam2018.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public IEnumerable<Email> Emails { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Role> Roles { get; set; }

    }
}