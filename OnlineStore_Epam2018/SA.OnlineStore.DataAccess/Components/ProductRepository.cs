namespace SA.OnlineStore.DataAccess.Components
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    #endregion

    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(DbConstant.Command.DeleteProductByProductId, connection);
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

        public ProductModel Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetProductByProductId, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = Id
                };
                command.Parameters.Add(nameParam);
                connection.Open();
                var reader = command.ExecuteReader();
                ProductModel product = null;
                if (reader.Read())
                {
                    product = this.ParseToProduct(reader);
                }
                reader.Close();
                return product;
            }
        }

        public void Save(ProductModel model)
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                connection.Open();
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

        public List<ProductModel> GetList()
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetProductList, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var reader = command.ExecuteReader();
                List<ProductModel> productList = new List<ProductModel>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productList.Add(ParseToProduct(reader));
                    }
                }
                reader.Close();
                return productList;
            }
        }

        private ProductModel ParseToProduct(SqlDataReader reader)
        {
            return new ProductModel()
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
    }
}