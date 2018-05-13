namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    #endregion

    public class CategoryRepository : ICategoryRepository
    {
        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                connection.Open();
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
                connection.Open();
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
                connection.Open();
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
                connection.Open();
                SqlCommand command = new SqlCommand(DbConstant.Command.SaveCategory, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

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
            return new CategoryModel()
            {
                CategoryId = (int)reader["Id"],
                CategoryName = reader["Name"].ToString(),
                ParentId = (int)reader["ParentId"]
            };
        }
    }
}

       




