using SA.OnlineStore.Common.Const;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Components
{
    public class CategoryRepository : ICategoryRepository
    {
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

       




