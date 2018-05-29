using SA.OnlineStore.Common.Const;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.Common.Logger;
using SA.OnlineStore.DataAccess.Implements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service.Implementation
{

    public class OrderRepository : IRepository<Order>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        private readonly SqlConnection _connection;

        public OrderRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Order item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveOrder);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = item.UserId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Address",
                    Value = item.Address
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "StatusId",
                    Value = item.StatusId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "DateOrder",
                    Value = item.DateOrder
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.DeleteOrderByOrderId);
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

        public IReadOnlyCollection<Order> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetOrders);

                using (IDataReader reader = command.ExecuteReader())
                {
                    List<Order> orders = new List<Order>();
                    try
                    {
                        while (reader.Read())
                        {
                            orders.Add(ParseToOrder(reader));
                        }
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error reader with DB ProductRepository/Get");
                        throw;
                    }
                    finally
                    {
                        reader.Close();
                    }

                    return orders;
                }
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

        public Order GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetOrderByUserId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = id
                });
                using (IDataReader reader = command.ExecuteReader())
                {
                    Order order = null;
                    try
                    {
                        if (reader.Read())
                        {
                            order = this.ParseToOrder(reader);
                        }
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error reader with DB ProductRepository/Get");
                        throw;
                    }
                    finally
                    {
                        reader.Close();
                    }
                    return order;
                }
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


        public void Update(Order item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.UpdateOrder);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Address",
                    Value = item.Address
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "StatusId",
                    Value = item.StatusId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "DateOrder",
                    Value = item.DateOrder
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

        private Order ParseToOrder(IDataReader reader)
        {
            try
            {
                return new Order()
                {
                    Id = _realization.GetFieldValue<int>(reader, "Id"),
                    UserId = _realization.GetFieldValue<int>(reader, "UserId"),
                    Address = _realization.GetFieldValue<string>(reader, "Address"),
                    StatusId = _realization.GetFieldValue<int>(reader, "StatusId"),
                    DateOrder = _realization.GetFieldValue<DateTime>(reader, "DateOrder")
                };
            }
            catch (Exception)
            {
                _commonLogger.Info("Input model is notValid ProductRepository/ParseToProduct");
                var model = new Order();
                model = null;
                return model;
            }
        }
    }
}
