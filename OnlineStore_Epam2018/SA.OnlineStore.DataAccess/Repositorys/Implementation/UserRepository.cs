namespace SA.OnlineStore.DataAccess.Repositorys.Implementation
{
    #region Usings
        using SA.OnlineStore.Common.Const;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.Common.Logger;
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.Linq;
    #endregion

    internal class UserRepository : IUserRepository
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;
        private readonly SqlConnection _connection;

        public UserRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(User item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUser);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.UserId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserLogin",
                    Value = item.Login
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Password",
                    Value = item.Password
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserName",
                    Value = item.Name
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "LastName",
                    Value = item.LastName
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = item.Role.RoleId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Phone",
                    Value = item.Phone.PhoneNumber
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Email",
                    Value = item.Email.EmailAddress
                });
                command.ExecuteNonQuery();
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

        public void Delete(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.DeleteUserByUserId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                command.ExecuteNonQuery();
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

        public IReadOnlyCollection<User> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetUserList);
                var userTable = _realization.CreateTable("Users");
                userTable = _realization.FillInTable(userTable, command);
                var list =ParsToUserList(userTable);
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

        public User GetByLogin(string login)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetUserByLogin);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "login",
                    Value = login
                });
                var userTable = _realization.CreateTable("User");
                userTable = _realization.FillInTable(userTable, command);
                var @user = ParsToUser(userTable);
                return @user;
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

        public User GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetUserListByUserId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                var userTable = _realization.CreateTable("User");
                userTable = _realization.FillInTable(userTable, command);
                var @user = ParsToUser(userTable);
                return @user;
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

        public void Update(User item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUser);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.UserId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserLogin",
                    Value = item.Login
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Password",
                    Value = item.Password
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserName",
                    Value = item.Name
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "LastName",
                    Value = item.LastName
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = item.Role.RoleId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Phone",
                    Value = item.Phone.PhoneNumber
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Email",
                    Value = item.Email.EmailAddress
                });
                command.ExecuteNonQuery();
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

        private User ParsToUser(DataTable table)
        {
            var user = table.AsEnumerable().Select(m =>
            {
                return new User()
                {
                    UserId = m.Field<int>("Id"),
                    Login = m.Field<string>("UserLogin"),
                    Password = m.Field<string>("Password"),
                    Name = m.Field<string>("Name"),
                    LastName = m.Field<string>("LastName"),

                    Role = new Role()
                    {
                        RoleId = m.Field<int>("RoleId"),
                        Name = m.Field<string>("RoleName")
                    },
                    Phone = new Phone()
                    {
                        PhoneId = m.Field<int>("PhoneId"),
                        PhoneNumber = m.Field<string>("Phone"),
                        UserId = m.Field<int>("Id")
                    },
                    Email = new Email()
                    {
                        EmailId = m.Field<int>("EmailId"),
                        EmailAddress = m.Field<string>("Email"),
                        UserId = m.Field<int>("Id")
                    }
                };
            }).First();
            return user;
        }

        private List<User> ParsToUserList(DataTable table)
        {
            var userList = table.AsEnumerable().Select(m =>
            {
                return new User()
                {
                    UserId = m.Field<int>("Id"),
                    Login = m.Field<string>("UserLogin"),
                    Password = m.Field<string>("Password"),
                    Name = m.Field<string>("Name"),
                    LastName = m.Field<string>("LastName"),

                    Role = new Role()
                    {
                        RoleId = m.Field<int>("RoleId"),
                        Name = m.Field<string>("RoleName")
                    },
                    Phone = new Phone()
                    {
                        PhoneId = m.Field<int>("PhoneId"),
                        PhoneNumber = m.Field<string>("Phone"),
                        UserId = m.Field<int>("Id")
                    },
                    Email = new Email()
                    {
                        EmailId = m.Field<int>("EmailId"),
                        EmailAddress = m.Field<string>("Email"),
                        UserId = m.Field<int>("Id")
                    }
                };
            }).ToList();
            return userList;
        }
    }
}