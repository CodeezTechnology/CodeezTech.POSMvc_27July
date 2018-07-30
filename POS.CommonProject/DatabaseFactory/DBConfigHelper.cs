using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.Data;
using System.Data.Common;


namespace CodeezTech.POS.CommonProject
{
   public class DBConfigHelper
    {
        private static string _dbConnectionString;
        private static string _dbProviderName;

        public DBConfigHelper()
        {
            _dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSConStr"].ConnectionString.ToString();
            _dbProviderName = System.Configuration.ConfigurationManager.ConnectionStrings["POSConStr"].ProviderName;
        }

        public static string DBConnectionString
        {
            get
            {
                return _dbConnectionString;
            }
        }
        public static string DBProviderName
        {
            get
            {
                return _dbProviderName;
            }
        }
        private static DatabaseProviderType _providerType;

        public static DatabaseProviderType Provider
        {
            get
            {
                if (_dbProviderName == "System.Data.SqlClient")
                {
                    _providerType = DatabaseProviderType.Sql;
                }
                else if (_dbProviderName == "System.Data.OracleClient")
                {
                    _providerType = DatabaseProviderType.Oracle;
                }
                else if (_dbProviderName == "System.Data.OleDBClient")
                {
                    _providerType = DatabaseProviderType.OleDb;
                }
                else if (_dbProviderName == "System.Data.OdbcClient")
                {
                    _providerType = DatabaseProviderType.Odbc;
                }
                
                return _providerType;
            }
        }
    }
}
