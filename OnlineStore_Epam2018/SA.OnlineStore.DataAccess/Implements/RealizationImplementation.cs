namespace SA.OnlineStore.DataAccess.Implements
{
    #region Usings
    using SA.OnlineStore.Common.Const;
    using SA.OnlineStore.DataAccess.Repositorys;
    using System.Data;
    using System.Data.SqlClient;
    #endregion
    public class RealizationImplementation : IRealizationImplementation
    {
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(DbConstant.connectionString);
            return connection;
        }

        public IDbCommand GetCommand(SqlConnection connection, string storedProcedure)
        {
            var command = new SqlCommand(storedProcedure, connection) { CommandType = CommandType.StoredProcedure };
            return command;
        }
        
        public DataTable CreateTable(string tableName)
        {
            var table = new DataTable(tableName);
            return table;
        }

        public DataTable FillInTable(DataTable table, IDbCommand command)
        {
            var adapter = new SqlDataAdapter((SqlCommand)command);
            adapter.Fill(table);
            return table;
        }
    }
}