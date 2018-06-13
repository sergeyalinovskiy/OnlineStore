using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;

namespace SA.OnlineStore.Bussines.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Role GetRoleById(int id)
        {
            if (id < 1)
            {
                return null;
            }
                return _roleRepository.GetById(id);
        }

        public IEnumerable<Role> GetRoleList()
        {
            return _roleRepository.GetAll();
        }
    }
}
