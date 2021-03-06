﻿using SA.OnlineStore.Bussines.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.RoleAttribut
{
    public class Admin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if(user is UserPrincipal)
            {
                return user.IsInRole("admin");
            }
            return false;
        }
    }
}