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
        bool Login(string login, string password);
        void Logout();
    }
}
