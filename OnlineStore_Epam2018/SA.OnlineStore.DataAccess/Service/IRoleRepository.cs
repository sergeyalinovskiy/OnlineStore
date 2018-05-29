using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface IRoleRepository
    {
       IEnumerable<Role> GetRolesByUserId(int id);
    }
}
