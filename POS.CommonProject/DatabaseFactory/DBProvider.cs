using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;

namespace CodeezTech.POS.CommonProject
{
   public class DBProvider
    {
        private static string _objFactory = null;
       
        public static string GetDataProvider(DatabaseProviderType provider)
        {
            
            switch (provider)
            {
                case DatabaseProviderType.Sql:
                    _objFactory = "System.Data.SqlClient";
                    break;
                case DatabaseProviderType.OleDb:
                    _objFactory = "System.Data.OracleClient";
                    break;
                case DatabaseProviderType.Oracle:
                    _objFactory = "System.Data.OleDBClient";
                    break;
                case DatabaseProviderType.Odbc:
                    _objFactory = "System.Data.OdbcClient";
                    break;
            }
            return _objFactory;
        }

        public static DbConnection GetConnection(DatabaseProviderType providerType)
        {
            switch (providerType)
            {
                case DatabaseProviderType.Sql:
                    return new SqlConnection();
                case DatabaseProviderType.OleDb:
                    return new OleDbConnection();
                case DatabaseProviderType.Odbc:
                    return new OdbcConnection();
                case DatabaseProviderType.Oracle:
                    return new OracleConnection();
                default:
                    return null;
            }
        }

        public static DbCommand GetCommand(DatabaseProviderType providerType)
        {
            switch (providerType)
            {
                case DatabaseProviderType.Sql:
                    return new SqlCommand();
                case DatabaseProviderType.OleDb:
                    return new OleDbCommand();
                case DatabaseProviderType.Odbc:
                    return new OdbcCommand();
                case DatabaseProviderType.Oracle:
                    return new OracleCommand();
                default:
                    return null;
            }
        }

        public static DbDataAdapter GetDataAdapter(DatabaseProviderType providerType)
        {
            switch (providerType)
            {
                case DatabaseProviderType.Sql:
                    return new SqlDataAdapter();
                case DatabaseProviderType.OleDb:
                    return new OleDbDataAdapter();
                case DatabaseProviderType.Odbc:
                    return new OdbcDataAdapter();
                case DatabaseProviderType.Oracle:
                    return new OracleDataAdapter();
                default:
                    return null;
            }
        }

        public static DbCommandBuilder GetCommandBuilder(DatabaseProviderType providerType)
        {
            switch (providerType)
            {
                case DatabaseProviderType.Sql:
                    return new SqlCommandBuilder();
                case DatabaseProviderType.OleDb:
                    return new OleDbCommandBuilder();
                case DatabaseProviderType.Odbc:
                    return new OdbcCommandBuilder();
                case DatabaseProviderType.Oracle:
                    return new OracleCommandBuilder();
                default:
                    return null;
            }
        }
    }
}
