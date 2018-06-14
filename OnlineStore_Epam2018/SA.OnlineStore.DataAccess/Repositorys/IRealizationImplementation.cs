namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
    using System.Data;
    using System.Data.SqlClient;
    #endregion
    public interface IRealizationImplementation
    {
        SqlConnection GetConnection();
        IDbCommand GetCommand(SqlConnection connection,string storedProcedure);
        DataTable CreateTable(string tableName);
        DataTable FillInTable(DataTable table, IDbCommand command);
    }
}