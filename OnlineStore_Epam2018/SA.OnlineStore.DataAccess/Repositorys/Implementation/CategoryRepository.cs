﻿namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Implements;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    #endregion

    public class CategoryRepository : IRepository<Category>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;
        private readonly SqlConnection _connection;
        public CategoryRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Category item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.SaveCategory);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.CategoryName
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "ParentId",
                    Value = item.ParentId
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

        public void Delete(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.DeleteCategoryByCategoryId);
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

        public IReadOnlyCollection<Category> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetCategoryList);
                var categorysTable = _realization.CreateTable("Categorys");
                categorysTable = _realization.FillInTable(categorysTable, command);
                var list = ParseToCategoryList(categorysTable);
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

        public Category GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetCategoryByCategoryId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                var categoryTable = _realization.CreateTable("Category");
                categoryTable = _realization.FillInTable(categoryTable, command);
                var @category= ParseToCategory(categoryTable);
                return @category;
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

        public void Update(Category item)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.SaveCategory);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.CategoryId
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.CategoryName
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "ParentId",
                    Value = item.ParentId
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

        private List<Category> ParseToCategoryList(DataTable table)
        {
            var list = table.AsEnumerable().Select(m =>
            {
                return new Category()
                {
                    CategoryId = m.Field<int>("Id"),
                    CategoryName = m.Field<string>("Name"),
                    ParentId = m.Field<int>("ParentId")
                   
                };
            }).ToList();
            return list;
        }

        private Category ParseToCategory(DataTable table)
        {
            var category = table.AsEnumerable().Select(m =>
            {
                return new Category()
                {
                    CategoryId = m.Field<int>("Id"),
                    CategoryName = m.Field<string>("Name"),
                    ParentId = m.Field<int>("ParentId")
                };
            }).First();
            return category;
        }
    }
}