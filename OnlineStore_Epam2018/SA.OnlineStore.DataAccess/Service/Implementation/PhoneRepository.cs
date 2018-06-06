using SA.OnlineStore.Common.Const;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.Common.Logger;
using SA.OnlineStore.DataAccess.Implements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SA.OnlineStore.DataAccess.Service.Implementation
{
    public class PhoneRepository : IRepository<Phone>
    {

        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        private readonly SqlConnection _connection;

        public PhoneRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Phone item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUserPhone);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.PhoneId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Phone",
                    Value = item.PhoneNumber
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.DeletePhoneByUserId);
                _realization.AddParametr(command, "Id", id, DbType.Int32);
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

        public IReadOnlyCollection<Phone> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetPhonesList);
                var phoneTable = _realization.CreateTable("Phones");
                phoneTable = _realization.FillInTable(phoneTable, command);
                var list = ParsToPhoneList(phoneTable);
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

        public Phone GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetPhonesByUserId);
                _realization.AddParametr(command, "Id", id, DbType.Int32);
                var phoneTable = _realization.CreateTable("Phone");
                phoneTable = _realization.FillInTable(phoneTable, command);
                var @phone = ParsToPhone(phoneTable);
                return @phone;
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

        public void Update(Phone item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveUserPhone);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.PhoneId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Phone",
                    Value = item.PhoneNumber
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

        private Phone ParsToPhone(DataTable table)
        {
            var phone = table.AsEnumerable().Select(m =>
            {
                return new Phone()
                {
                    UserId = m.Field<int>("Id"),
                    PhoneId = m.Field<int>("UserId"),
                    PhoneNumber = m.Field<string>("Phone")
                };
            }).First();
            return phone;
        }

        private List<Phone> ParsToPhoneList(DataTable table)
        {
            var phoneList = table.AsEnumerable().Select(m =>
            {
                return new Phone()
                {
                    UserId = m.Field<int>("Id"),
                    PhoneId = m.Field<int>("UserId"),
                    PhoneNumber = m.Field<string>("Phone")
                };
            }).ToList();
            return phoneList;
        }
    }
}