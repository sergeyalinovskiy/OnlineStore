using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Entity
{
    public class UserLogin
    {
        public int id { get; set; }
        public string userLogin { get; set; }
        public string passsword { get; set; }
        public Role[] role { get; set; }

    }
}
