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

namespace SA.OnlineStore.DataAccess.Repositorys.Implementation
{

    public class OrderRepository : IOrderRepository
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
                    Value = item.User.UserId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Address",
                    Value = item.Address
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "StatusId",
                    Value = item.StatusOrder.Id
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

        public IEnumerable<StatusOrder> GetStatusOrder()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetStatusOrder);
                var orderStatusTable = _realization.CreateTable("OrderStatus");
                orderStatusTable = _realization.FillInTable(orderStatusTable, command);
                var list = CreateStatusOrderListFromTable(orderStatusTable);
                return list;
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetOrdersList);
                var orderTable = _realization.CreateTable("Orders");
                orderTable = _realization.FillInTable(orderTable, command);
                var list = CreateListFromTable(orderTable);
                return list;
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetOrdersListById);
                _realization.AddParametr(command, "Id", id, DbType.Int32);
                var orderTable = _realization.CreateTable("Order");
                orderTable = _realization.FillInTable(orderTable, command);
                var @order = FillEntity(orderTable);
                return @order;
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

        public void SaveDefaultOrder(int userId)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveDefaultOrder);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = userId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "DateOrder",
                    Value = DateTime.Now
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
                    Value = item.StatusOrder.Id
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

        private List<StatusOrder> CreateStatusOrderListFromTable(DataTable table)
        {
            var list = table.AsEnumerable().Select(m =>
            {
                return new StatusOrder()
                {
                    Id = m.Field<int>("Id"),
                    StatusOrderName = m.Field<string>("Name")
                };
               
            }).ToList();
            return list;
        }

        private List<Order> CreateListFromTable(DataTable table)
        {
            List<Order> orders = new List<Order>();
            var list = table.AsEnumerable().Select(m =>
            {
                return new Order()
                {
                    Id = m.Field<int>("Id"),
                    User = new User()
                    {
                        UserId = m.Field<int>("UserId"),
                        Name = m.Field<string>("UserName"),
                        LastName = m.Field<string>("LastName")
                    },
                    Address = m.Field<string>("Address"),
                    StatusOrder = new StatusOrder()
                    {
                        Id = m.Field<int>("StatusId"),
                        StatusOrderName = m.Field<string>("OrderStatusName")
                    },
                    DateOrder = m.Field<DateTime>("DateOrder")
                };
            }).ToList();
            return list;
        }

        private Order FillEntity(DataTable table)
        {
            var order = table.AsEnumerable().Select(m =>
            {
                return new Order()
                {
                    Id = m.Field<int>("Id"),
                    User = new User()
                    {
                        UserId = m.Field<int>("UserId"),
                        Name = m.Field<string>("UserName"),
                        LastName = m.Field<string>("LastName")
                    },
                    Address = m.Field<string>("Address"),
                    StatusOrder = new StatusOrder()
                    {
                        Id = m.Field<int>("StatusId"),
                        StatusOrderName = m.Field<string>("OrderStatusName")
                    },
                    DateOrder = m.Field<DateTime>("DateOrder")
                };
            }).First();
            return order;
        }
    }
}