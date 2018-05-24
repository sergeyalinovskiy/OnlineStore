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
        public List<Season> GetSeasonList()
        {
            using (SqlConnection connection = new SqlConnection(DbConstant.connectionString))
            {
                using (SqlCommand command = new SqlCommand(DbConstant.Command.GetSeasonList, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {
                        _commonLogger.Info("Error connection SeassonRepository");
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Season> productList = new List<Season>();
                        try
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    productList.Add(ParseToSeason(reader));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            _commonLogger.Info("Error reader SeassonRepository/GetSeasonList");
                        }
                        return productList;
                    }
                }
            }
        }

        private Season ParseToSeason(SqlDataReader reader)
        {
            return new Season()
            {
                SeasonId = (int)reader["Id"],
                SeasonName = reader["Name"].ToString()
            };
        }
    }
}
