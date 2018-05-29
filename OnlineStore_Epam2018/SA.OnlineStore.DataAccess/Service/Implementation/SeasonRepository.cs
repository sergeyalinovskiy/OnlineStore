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

    public class SeasonRepository : IRepository<Season>
    {
        private readonly ICommonLogger _commonLogger;
        private readonly IRealizationImplementation _realization;
        private readonly SqlConnection _connection;

        public SeasonRepository(ICommonLogger commonLogger, IRealizationImplementation realization)
        {
            _commonLogger = commonLogger;
            _realization = realization;
            _connection = _realization.GetConnection();
        }

        public void Create(Season item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Season> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _realization.GetCommand(_connection,DbConstant.Command.GetSeasonList);
                using(var reader= command.ExecuteReader())
                {
                    List<Season> seasonList = new List<Season>();
                    try
                    {
                        while (reader.Read())
                        {
                        seasonList.Add(ParseToSeason(reader));
                        }
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error reader SeassonRepository/GetSeasonList");
                    }
                    finally
                    {
                        reader.Close();
                    }
                    return seasonList;
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

        public Season GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Season item)
        {
            throw new NotImplementedException();
        }

        private Season ParseToSeason(IDataReader reader)
        {
            return new Season()
            {
                SeasonId =_realization.GetFieldValue<int>(reader,"Id"),
                SeasonName = _realization.GetFieldValue<string>(reader, "Name")
            };
        }
    }
}
