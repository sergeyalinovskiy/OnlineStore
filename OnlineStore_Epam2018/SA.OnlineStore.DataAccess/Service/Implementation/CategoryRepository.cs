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
                _realization.GetConnection().Open();
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
                _realization.GetConnection().Close();
            }
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            try
            {
                //_realization.GetConnection().Open();
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.GetCategoryList);

                using (IDataReader reader = command.ExecuteReader())
                {
                    List<Category> categorys = new List<Category>();
                    try
                    {
                        while (reader.Read())
                        {
                            categorys.Add(ParseToCategory(reader));
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
                    return categorys;
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

        public Category GetById(int id)
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.GetCategoryByCategoryId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                using (IDataReader reader = command.ExecuteReader())
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
                        _commonLogger.Info("Error reader with DB ProductRepository/Get");
                        throw;
                    }
                    reader.Close();
                    return category;
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

        public void Update(Category item)
        {
            try
            {
                //_realization.GetConnection().Open();
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
       
        private Category ParseToCategory(IDataReader reader)
        {
            try
            {
                return new Category()
                {
                    CategoryId = _realization.GetFieldValue<int>(reader, "Id"),
                    CategoryName = _realization.GetFieldValue<string>(reader, "Name"),
                    ParentId = _realization.GetFieldValue<int>(reader, "ParentId")
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