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
    public class BasketRepository : IRepository<Basket>
    {

        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        private readonly SqlConnection _connection;

        public BasketRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }


        public void Create(Basket item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveNewProductInBasket);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = 1
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = item.Product.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "OrderId",
                    Value = item.Order.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Count",
                    Value = item.Count
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
            };
        }


    public void Delete(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.DeleteProductInBasketById);
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

        public IReadOnlyCollection<Basket> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProductsInBaskets);
                var basketTable = _realization.CreateTable("Buskets");
                basketTable = _realization.FillInTable(basketTable, command);
                var list = ParseToBasketList(basketTable);
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

        public Basket GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProductsInBasketsByBasketId);
                _realization.AddParametr(command, "Id", id, DbType.Int32);
                var basketTable = _realization.CreateTable("Basket");
                basketTable = _realization.FillInTable(basketTable, command);
                var basket = ParseToBasket(basketTable);
                return basket;
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

        public void Update(Basket item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.UpdateProductCountInBasket);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                 });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = item.Product.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "OrderId",
                    Value = item.Order.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Count",
                    Value = item.Count
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
            };
        }   


        private List<Basket> ParseToBasketList(DataTable table)
        {
            List<Basket> productsList = new List<Basket>();
            var list = table.AsEnumerable().Select(m =>
            {
                return new Basket()
                {
                    Id = m.Field<int>("Id"),
                    Order = new Order()
                    {
                         Id = m.Field<int>("OrderId"),
                        User = new User()
                        {
                            UserId=m.Field<int>("UserId")
                        },
                         Address = m.Field<string>("Address"),
                         StatusOrder=new StatusOrder()
                         {
                             Id= m.Field<int>("StatusId")
                         },
                         DateOrder=m.Field<DateTime>("DateOrder"),
                    },
                    Product = new Product()
                    {
                       Id = m.Field<int>("ProductId"),
                        Name = m.Field<string>("Name"),
                       
                        Season = new Season()
                        {
                            SeasonId = m.Field<int>("SeasonsId")
                        },
                        Picture=m.Field<string>("Picture"),
                        Description=m.Field<string>("Description"),
                        Price=m.Field<int>("Price"),
                    },
                    Category = new Category()
                    {
                        CategoryId = m.Field<int>("CategoryId"),
                        CategoryName = m.Field<string>("CategoryName")
                    },
                    Count =m.Field<int>("Count")
                };
            }).ToList();
            return list;
        }

        private Basket ParseToBasket(DataTable table)
        {
            var order = table.AsEnumerable().Select(m =>
            {
                return new Basket()
                {
                    Id = m.Field<int>("Id"),
                    Order = new Order()
                    {
                        Id = m.Field<int>("OrderId"),
                        User = new User()
                        {
                            UserId = m.Field<int>("UserId")
                        },
                        Address = m.Field<string>("Address"),
                        StatusOrder = new StatusOrder()
                        {
                            Id = m.Field<int>("StatusId")
                        },
                        DateOrder = m.Field<DateTime>("DateOrder"),
                    },
                    Product = new Product()
                    {
                        Id = m.Field<int>("ProductId"),
                        Name = m.Field<string>("Name"),
                       
                        Season = new Season()
                        { 
                            SeasonId = m.Field<int>("SeasonsId")
                        },
                        Picture = m.Field<string>("Picture"),
                        Description = m.Field<string>("Description"),
                        Price = m.Field<int>("Price"),
                    },
                    Category = new Category()
                    {
                        CategoryId = m.Field<int>("CategoryId"),
                        CategoryName = m.Field<string>("CategoryName")
                    },
                    Count = m.Field<int>("Count")
                };
            }).First();
            return order;
        }
     }
}
