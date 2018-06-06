﻿using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IEmailService
    {
        IEnumerable<Email> GetEmailsByUserId(int id);
        IEnumerable<Email> GetEmailList();
    }
}
