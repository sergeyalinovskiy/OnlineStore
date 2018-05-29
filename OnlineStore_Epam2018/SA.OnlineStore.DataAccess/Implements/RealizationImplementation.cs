using SA.OnlineStore.Common.Const;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Implements
{
    public class RealizationImplementation : IRealizationImplementation
    {
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(DbConstant.connectionString);
            return connection;
        }

        public IDbCommand GetCommand(SqlConnection connection, string storedProcedure)
        {
            //var connection = GetConnection();
            //connection.Open();
            var command = new SqlCommand(storedProcedure, connection) { CommandType = CommandType.StoredProcedure };
            return command;
        }

        public void AddParametr(IDbCommand cmd, string parametrName,object value, DbType paramType)
        {
            IDataParameter sqlParametr = cmd.CreateParameter();

            sqlParametr.DbType = paramType;
            sqlParametr.ParameterName = (parametrName.StartsWith("@")) ? parametrName : "@" + parametrName;
            sqlParametr.Value = value;
            
            cmd.Parameters.Add(sqlParametr);
        }

        public T GetFieldValue<T>(IDataReader reader, string fieldName)
        {
            var value = reader.GetValue(reader.GetOrdinal(fieldName));
            return (T)value;
        }
    }
}
