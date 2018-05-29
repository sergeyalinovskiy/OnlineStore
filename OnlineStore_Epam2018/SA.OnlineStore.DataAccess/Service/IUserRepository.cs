﻿using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface IUserRepository
    {
        User GetUserByUserId(int id);
        User GetUserByUserLogin(string userLogin);
    }
}