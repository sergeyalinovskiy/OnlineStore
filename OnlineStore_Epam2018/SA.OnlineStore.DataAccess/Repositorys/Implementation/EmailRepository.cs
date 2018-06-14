namespace SA.OnlineStore.DataAccess.Repositorys.Implementation
{
    #region Usings
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Data.SqlClient;
        using System.Linq;
        using SA.OnlineStore.Common.Const;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.Common.Logger;
        using SA.OnlineStore.DataAccess.Implements;
    #endregion

    public class EmailRepository : IRepository<Email>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        private readonly SqlConnection _connection;

        public EmailRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Email item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUserEmail);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.EmailId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Email",
                    Value = item.EmailAddress
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = item.UserId
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.DeleteEmailByUserId);
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

        public IReadOnlyCollection<Email> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetEmailsList);
                var emailTable = _realization.CreateTable("Emails");
                emailTable = _realization.FillInTable(emailTable, command);
                var list = ParsToEmailList(emailTable);
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

        public Email GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetEmailsByUserId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                var emailTable = _realization.CreateTable("Email");
                emailTable = _realization.FillInTable(emailTable, command);
                var @email = ParsToEmail(emailTable);
                return @email;
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

        public void Update(Email item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUserEmail);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.EmailId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Email",
                    Value = item.EmailAddress
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = item.UserId
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

        private Email ParsToEmail(DataTable table)
        {
            var email = table.AsEnumerable().Select(m =>
            {
                return new Email()
                {
                    UserId = m.Field<int>("Id"),
                    EmailId = m.Field<int>("UserId"),
                    EmailAddress = m.Field<string>("Email")
                };
            }).First();
            return email;
        }

        private List<Email> ParsToEmailList(DataTable table)
        {
            var emailList = table.AsEnumerable().Select(m =>
            {
                return new Email()
                {
                    UserId = m.Field<int>("Id"),
                    EmailId = m.Field<int>("UserId"),
                    EmailAddress = m.Field<string>("Email")
                };
            }).ToList();
            return emailList;
        }

    }
}