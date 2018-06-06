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
    using System.Linq;
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
                    Value = item.Category.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "SeasonsId",
                    Value = item.Season.SeasonId
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
                    Value = item.Category.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "SeasonsId",
                    Value = item.Season.SeasonId
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProductListByProductId);
                _realization.AddParametr(command,"Id", id, DbType.Int32);
                var productTable = _realization.CreateTable("Products");
                productTable = _realization.FillInTable(productTable, command);
                var @product = FillEntity(productTable);
                return @product; 
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
                var command = _realization.GetCommand(_connection,DbConstant.Command.DeleteProductByProductId);
                _realization.AddParametr(command, "Id", id, DbType.Int32);
                _realization.ExecCommand(command);
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetProducts);
                var productTable = _realization.CreateTable("Products");
                productTable = _realization.FillInTable(productTable, command);
                var list = CreateListFromTable(productTable);
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


        private List<Product> CreateListFromTable(DataTable table)
        {
            List<Product> productsList = new List<Product>();
            var list = table.AsEnumerable().Select(m =>
             {
                 return new Product()
                 {
                     Id = m.Field<int>("Id"),
                     Name = m.Field<string>("Name"),
                     Category = new Category()
                     {
                         CategoryId = m.Field<int>("CategoryId"),
                         CategoryName = m.Field<string>("CategoryName"),
                         ParentId = m.Field<int>("ParentId")
                     },
                     Season = new Season()
                     {
                         SeasonId = m.Field<int>("SeasonsId"),
                         SeasonName = m.Field<string>("SeasonsName")
                     },
                     Picture = m.Field<string>("Picture"),
                     Description = m.Field<string>("Description"),
                     Count = m.Field<int>("Count"),
                     Price = m.Field<int>("Price")
                 };
             }).ToList();
            return list;
        }

        private Product FillEntity(DataTable table)
        {
            var product = table.AsEnumerable().Select(m =>
            {
                return new Product()
                {
                    Id = m.Field<int>("Id"),
                    Name = m.Field<string>("Name"),
                    Category = new Category()
                    {
                        CategoryId = m.Field<int>("CategoryId"),
                        CategoryName = m.Field<string>("CategoryName"),
                        ParentId = m.Field<int>("ParentId")
                    },
                    Season = new Season()
                    {
                        SeasonId = m.Field<int>("SeasonsId"),
                        SeasonName = m.Field<string>("SeasonsName")
                    },
                    Picture = m.Field<string>("Picture"),
                    Description = m.Field<string>("Description"),
                    Count = m.Field<int>("Count"),
                    Price = m.Field<int>("Price")
                };
            }).First();
            return product;
        }

    }
}