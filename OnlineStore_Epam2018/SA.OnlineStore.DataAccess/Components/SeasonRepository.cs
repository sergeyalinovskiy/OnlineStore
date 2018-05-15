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

    public class SeasonRepository : ISeasonRepository
    {
        private readonly ICommonLogger _commonLogger;

        public SeasonRepository(ICommonLogger commonLogger)
        {
            _commonLogger = commonLogger;
        }
        public List<SeasonModel> GetSeasonList()
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                SqlCommand command = new SqlCommand(DbConstant.Command.GetSeasonList, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    _commonLogger.Info("Error connection SeassonRepository");
                }
                var reader = command.ExecuteReader();
                List<SeasonModel> productList = new List<SeasonModel>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productList.Add(ParseToSeason(reader));
                    }
                }
                reader.Close();
                return productList;
            }
        }

        private SeasonModel ParseToSeason(SqlDataReader reader)
        {
            return new SeasonModel()
            {
                SeasonId = (int)reader["Id"],
                SeasonName = reader["Name"].ToString()
            };
        }
    }
}
