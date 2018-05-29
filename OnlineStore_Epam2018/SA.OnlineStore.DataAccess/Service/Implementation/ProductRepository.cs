namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    #endregion

    public class ProductRepository : IRepository<Product>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;

        private readonly SqlConnection _connection;

        public ProductRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Product item)
        {
            try
            {
                //_realization.GetConnection().Open();
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.SaveProduct);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.Name
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = item.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "SeasonsId",
                    Value = item.SeasonId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Picture",
                    Value = item.Picture
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Description",
                    Value = item.Description
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Count",
                    Value = item.Count
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Price",
                    Value = item.Price
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
        public void Update(Product item)
        {
            try
            {
                _connection.Open();
                //_realization.GetConnection().Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.SaveProduct);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.Name
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = item.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "SeasonsId",
                    Value = item.SeasonId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Picture",
                    Value = item.Picture
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Description",
                    Value = item.Description
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Count",
                    Value = item.Count
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Price",
                    Value = item.Price
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
        public Product GetById(int id)
        {
            try
            {
                _connection.Open();
                //_realization.GetConnection().Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProductByProductId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                using (IDataReader reader = command.ExecuteReader())
                {
                    Product product = null;
                    try
                    {
                        if (reader.Read())
                        {
                            product = this.ParseToProduct(reader);
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
                    return product;
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
        public void Delete(int id)
        {
            try
            {
                _connection.Open();
                //_realization.GetConnection().Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.DeleteProductByProductId);
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
        public IReadOnlyCollection<Product> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProductList);
               
                using (IDataReader reader = command.ExecuteReader())
                {
                    List<Product> products = new List<Product>();
                    try
                    {
                        while (reader.Read())
                        {
                            products.Add(ParseToProduct(reader));
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
                    
                    return products;
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
        
        private Product ParseToProduct(IDataReader reader)
        {
            try
            {
                return new Product()
                {
                    Id = _realization.GetFieldValue<int>(reader, "Id"),
                    Name = _realization.GetFieldValue<string>(reader, "Name"),
                    CategoryId = _realization.GetFieldValue<int>(reader, "CategoryId"),
                    SeasonId = _realization.GetFieldValue<int>(reader, "SeasonsId"),
                    Picture = _realization.GetFieldValue<string>(reader, "Picture"),
                    Description = _realization.GetFieldValue<string>(reader, "Description"),
                    Count = _realization.GetFieldValue<int>(reader, "Count"),
                    Price = _realization.GetFieldValue<int>(reader, "Price")
                };
            }
            catch (Exception)
            {
                _commonLogger.Info("Input model is notValid ProductRepository/ParseToProduct");
                var model = new Product();
                model = null;
                return model;
            }
        }
    }
}