namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Repositorys;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
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
                var command = _realization.GetCommand(_connection, DbConstant.Command.GetSeasonList);
                var seasonssTable = _realization.CreateTable("Seasons");
                seasonssTable = _realization.FillInTable(seasonssTable, command);
                var list = ParseToSeasonList(seasonssTable);
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
           
        public Season GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Season item)
        {
            throw new NotImplementedException();
        }

        private List<Season> ParseToSeasonList(DataTable table)
        {
            var list = table.AsEnumerable().Select(m =>
            {
                return new Season()
                {
                    SeasonId = m.Field<int>("Id"),
                    SeasonName = m.Field<string>("Name")
                };
            }).ToList();
            return list;
        }     
    }
}