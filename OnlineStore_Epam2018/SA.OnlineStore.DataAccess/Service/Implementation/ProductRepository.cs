namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    #endregion

    public class ProductRepository : IProductRepository
    {
        private readonly ICommonLogger _commonLogger;
        public ProductRepository(ICommonLogger commonLogger)
        {
            _commonLogger = commonLogger;
        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                
                SqlCommand command = new SqlCommand(DbConstant.Command.DeleteProductByProductId, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB ProductRepository/Delete");
                    throw;
                }

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = Id
                };
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }

        public Product Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                using (SqlCommand command = new SqlCommand(DbConstant.Command.GetProductByProductId, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "Id",
                        Value = Id
                    };
                    command.Parameters.Add(nameParam);
                
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB ProductRepository/Get");
                    
                }

                using (SqlDataReader reader = command.ExecuteReader())
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
                    return product;
                    }
                }
            }
        }

        public void Save(Product model)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB ProductRepository/Save");
                    throw;
                }
                
                SqlCommand command = new SqlCommand(DbConstant.Command.SaveProduct, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = model.Id
                };
                SqlParameter paramName = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = model.Name
                };
                SqlParameter paramCategory = new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = model.CategoryId
                };
                SqlParameter paramSeason = new SqlParameter
                {
                    ParameterName = "SeasonsId",
                    Value = model.SeasonId
                };
                SqlParameter paramPicture = new SqlParameter
                {
                    ParameterName = "Picture",
                    Value = model.Picture
                };
                SqlParameter paramDescription = new SqlParameter
                {
                    ParameterName = "Description",
                    Value = model.Description
                };
                SqlParameter paramCount = new SqlParameter
                {
                    ParameterName = "Count",
                    Value = model.Count
                };
                SqlParameter paramPrice = new SqlParameter
                {
                    ParameterName = "Price",
                    Value = model.Price
                };
                
                command.Parameters.Add(paramId);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramCategory);
                command.Parameters.Add(paramSeason);
                command.Parameters.Add(paramPicture);
                command.Parameters.Add(paramDescription);
                command.Parameters.Add(paramCount);
                command.Parameters.Add(paramPrice);

                command.ExecuteNonQuery();
            }
        }

        public List<Product> GetList()
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetProductList, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB ProductRepository/GetList");
                    throw;
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Product> productList = new List<Product>();
                    try
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                productList.Add(ParseToProduct(reader));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error reader with DB ProductRepository/GetList");
                        throw;
                    }
                    return productList;
                }
            }
        }

        private Product ParseToProduct(SqlDataReader reader)
        {
            try
            {
                return new Product()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    CategoryId = (int)reader["CategoryId"],
                    SeasonId = (int)reader["SeasonsId"],
                    Picture = reader["Picture"].ToString(),
                    Description = reader["Description"].ToString(),
                    Count = (int)reader["Count"],
                    Price = (int)reader["Price"]
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