namespace SA.OnlineStore.Bussines.Service.Implementation
{
    #region Usings
        using System.Collections.Generic;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
    #endregion
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