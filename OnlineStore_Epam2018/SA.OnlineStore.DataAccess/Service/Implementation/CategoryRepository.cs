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

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICommonLogger _commonLogger;
        public CategoryRepository(ICommonLogger commonLogger)
        {
            _commonLogger = commonLogger;
        }
        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB CategoryRepository/Delete");
                    throw;
                }
                SqlCommand command = new SqlCommand(DbConstant.Command.DeleteCategoryByCategoryId, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = Id
                };
                try
                {
                    command.Parameters.Add(nameParam);
                }
                catch (Exception)
                {
                    _commonLogger.Info("Error in command.Parametrs CategoryRepository/Delete");
                    throw;
                }
                command.ExecuteNonQuery();
            }
        }

        public Category Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetCategoryByCategoryId, connection);
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
                    _commonLogger.Info("Error connection with DB CategoryRepository/Get");
                    throw;
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                    Category category = null;
                    try
                    {
                        if (reader.Read())
                        {
                            category = this.ParseToCategory(reader);
                        }
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error reader with DB CategoryRepository/Get");
                        throw;
                    }
                    return category;
                }
            }
        }

        public List<Category> GetCategoryList()
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetCategoryList, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB CategoryRepository/GetCategoryist");
                    throw;
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Category> productList = new List<Category>();
                    if (reader.HasRows)
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                productList.Add(ParseToCategory(reader));
                            }
                        }
                        catch (Exception)
                        {
                            _commonLogger.Info("Error reader with DB CategoryRepository/GetCategoryist");
                            throw;
                        }
                    }
                    return productList;
                }
            }
        }

        public void Save(Category model)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                
                SqlCommand command = new SqlCommand(DbConstant.Command.SaveCategory, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                }
                catch (System.Exception)
                {
                    _commonLogger.Info("Error connection with DB CategoryRepository/Save");
                    throw;
                }
                SqlParameter paramId = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = model.CategoryId
                };
                SqlParameter paramName = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = model.CategoryName
                };
                SqlParameter paramCategory = new SqlParameter
                {
                    ParameterName = "ParentId",
                    Value = model.ParentId
                };
                try
                {
                    command.Parameters.Add(paramId);
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramCategory);
                }
                catch (Exception)
                {
                     _commonLogger.Info("Error command.Parameters.Add in CategoryRepository/Save");
                    throw;
                }
          
                command.ExecuteNonQuery();
            }
        }

        private Category ParseToCategory(SqlDataReader reader)
        {
            try
            {
                return new Category()
                {
                    CategoryId = (int)reader["Id"],
                    CategoryName = reader["Name"].ToString(),
                    ParentId = (int)reader["ParentId"]
                };
            }
            catch (Exception)
            {
                _commonLogger.Info("Input model is notValid CategoryRepository/ParseToCategory");
                var model = new Category();
                model = null;
                return model;
            }
        }
    }
}