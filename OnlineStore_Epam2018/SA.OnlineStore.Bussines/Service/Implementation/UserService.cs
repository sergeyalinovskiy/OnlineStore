using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA.OnlineStore.Common.Entity;

namespace SA.OnlineStore.Bussines.Service.Implementation
{
     public  class UserService : IUserService
    {
        public User GetUserById(int id)
        {
            if (id < 1)
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
