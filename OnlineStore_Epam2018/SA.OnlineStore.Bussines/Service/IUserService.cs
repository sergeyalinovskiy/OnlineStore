using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IUserService
    {
        User GetUserById(int id);

        void DeleteUserByUserId(int id);

        IEnumerable<User> GetUsersList();

        void SaveUser(User model);

        User GetUserByLogin(string login);
    }
}
