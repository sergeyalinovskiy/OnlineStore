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
                    ParameterName = "ProductId",
                    Value = item.ProductId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "OrderId",
                    Value = item.OrderId
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetBaskets);

                using (IDataReader reader = command.ExecuteReader())
                {
                    List<Basket> baskets = new List<Basket>();
                    try
                    {
                        while (reader.Read())
                        {
                            baskets.Add(ParseToBasket(reader));
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
                    return baskets;
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

        public Basket GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetBasketById);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                using (IDataReader reader = command.ExecuteReader())
                {
                    Basket basket = null;
                    try
                    {
                        if (reader.Read())
                        {
                            basket = this.ParseToBasket(reader);
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
                    return basket;
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

        public void Update(Basket item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.SaveProductInBasket);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = item.ProductId
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

        private Basket ParseToBasket(IDataReader reader)
        {
            try
            {
                return new Basket()
                {
                    Id = _realization.GetFieldValue<int>(reader, "Id"),
                    OrderId = _realization.GetFieldValue<int>(reader, "OrderId"),
                    ProductName = _realization.GetFieldValue<string>(reader, "Name"),
                    ProductId=_realization.GetFieldValue<int>(reader, "ProductId"),
                    Picture= _realization.GetFieldValue<string>(reader, "Picture"),
                    Count =_realization.GetFieldValue<int>(reader, "Count"),
                    Price=_realization.GetFieldValue<int>(reader, "Price")
                };
            }
            catch (Exception)
            {
                _commonLogger.Info("Input model is notValid ProductRepository/ParseToProduct");
                var model = new Basket();
                model = null;
                return model;
            }
        }
    }
}
