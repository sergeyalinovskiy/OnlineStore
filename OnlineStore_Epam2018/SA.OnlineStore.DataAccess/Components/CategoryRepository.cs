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
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }

        public CategoryModel Get(int Id)
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
                var reader = command.ExecuteReader();
                CategoryModel category = null;
                if (reader.Read())
                {
                    category = this.ParseToCategory(reader);
                }
                reader.Close();
                return category;
            }
        }

        public List<CategoryModel> GetCategoryList()
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
                var reader = command.ExecuteReader();
                List<CategoryModel> productList = new List<CategoryModel>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productList.Add(ParseToCategory(reader));
                    }
                }
                reader.Close();
                return productList;
            }
        }

        public void Save(CategoryModel model)
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

                command.Parameters.Add(paramId);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramCategory);
          
                command.ExecuteNonQuery();
            }
        }

        private CategoryModel ParseToCategory(SqlDataReader reader)
        {
            try
            {
                return new CategoryModel()
                {
                    CategoryId = (int)reader["Id"],
                    CategoryName = reader["Name"].ToString(),
                    ParentId = (int)reader["ParentId"]
                };
            }
            catch (Exception)
            {
                _commonLogger.Info("Input model is notValid CategoryRepository/ParseToCategory");
                var model = new CategoryModel();
                model = null;
                return model;
            }
        }
    }
}