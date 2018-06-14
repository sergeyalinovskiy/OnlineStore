using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Repositorys
{
    public interface IRealizationImplementation
    {
        SqlConnection GetConnection();
        IDbCommand GetCommand(SqlConnection connection,string storedProcedure);
        void AddParametr(IDbCommand cmd, string parametrName, object value, DbType paramType);
        T GetFieldValue<T>(IDataReader reader, string fieldName);
       
        DataTable CreateTable(string tableName);
        DataTable FillInTable(DataTable table, IDbCommand command);
    }
}
