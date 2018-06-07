using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Authentication
{
    public interface ILoginService
    {
        void Login(string login, string password);
        void Logout();
        //bool IsValidUser(string login, string password);
        //User GetUser(string login);
    }
}
