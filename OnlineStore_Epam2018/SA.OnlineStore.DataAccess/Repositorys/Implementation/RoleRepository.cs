namespace SA.OnlineStore.DataAccess.Repositorys.Implementation
{
    #region Usings
        using SA.OnlineStore.Common.Const;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.Common.Logger;
        using SA.OnlineStore.DataAccess.Implements;
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.Linq;
    #endregion

    public class RoleRepository : IRepository<Role>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;
        private readonly SqlConnection _connection;

        public RoleRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Role item)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetRoles);
                var roleTable = _realization.CreateTable("Roles");
                roleTable = _realization.FillInTable(roleTable, command);
                var list = ParsToRoleList(roleTable);
                return @list;

            }
            catch (Exception exeption)
            {
                _commonLogger.Info(exeption.Message);
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }

        private List<Role> ParsToRoleList(DataTable table)
        {
            var roleList = table.AsEnumerable().Select(m =>
            {
                return new Role()
                {
                    RoleId = m.Field<int>("Id"),
                    Name = m.Field<string>("RoleName")   
                };
            }).ToList();
            return roleList;
        }
    }
}