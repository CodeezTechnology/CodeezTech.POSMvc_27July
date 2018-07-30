using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class DBEngine : Object,IDisposable
    {
        #region Variable Declaration
        
        private string _mstrServerName;
        private string _mstrDatabaseName;
        private string _mstrUserID;
        private string _mstrPassword;

        private string MstrConnectionString;
        public string MstrQuery;
        public SqlParameter[] MstrSQLParameters;

        public DbConnection ObjConnection;
        public DbCommand ObjCommand;
        public DbDataAdapter ObjDataAdapter;
        public DbCommandBuilder ObjCommandBuilder;
        public DbTransaction ObjTransaction;
        public DataTable ObjDataTable;

        private string _inlineSQL;

        #endregion

        #region Constructors

        private static DatabaseProviderType _providerType;

        public DBEngine()
        {
            //string _dbProviderName = DBConfigHelper.DBProviderName;
           
            //   if (_dbProviderName == SqlClientFactory.Instance.ToString())
            //    {
            //        _providerType = DatabaseProviderType.Sql;
            //    }
            //    else if (_dbProviderName == OracleClientFactory.Instance.ToString())
            //    {
            //        _providerType = DatabaseProviderType.Oracle;
            //    }
            //    else if (_dbProviderName == OleDbFactory.Instance.ToString())
            //    {
            //        _providerType = DatabaseProviderType.OleDb;
            //    }
            //    else if (_dbProviderName == OdbcFactory.Instance.ToString())
            //    {
            //        _providerType = DatabaseProviderType.Odbc;
            //    }
            DBConfigHelper _config = new DBConfigHelper();
            string _dbConnectionString = DBConfigHelper.DBConnectionString;
            DbProviderFactory _factory = DbProviderFactories.GetFactory(DBProvider.GetDataProvider(DBConfigHelper.Provider));
            ObjConnection = DBProvider.GetConnection(DBConfigHelper.Provider);
            ObjCommand = DBProvider.GetCommand(DBConfigHelper.Provider);
            ObjDataAdapter = DBProvider.GetDataAdapter(DBConfigHelper.Provider);
            ObjCommandBuilder = DBProvider.GetCommandBuilder(DBConfigHelper.Provider);
            
           // DbProviderFactory _factory = DbProviderFactories.GetFactory(_dbProviderName);

            ObjConnection = _factory.CreateConnection();
            ObjConnection.ConnectionString = _dbConnectionString;

           // ObjCommand = _factory.CreateCommand();
            ObjCommand = ObjConnection.CreateCommand();
            ObjCommand.CommandText = MstrQuery;
            
            ObjDataAdapter = _factory.CreateDataAdapter();
            ObjDataAdapter.SelectCommand = ObjConnection.CreateCommand();
            ObjDataAdapter.SelectCommand.Connection = ObjConnection;
            
            ObjCommandBuilder = _factory.CreateCommandBuilder();
            ObjCommandBuilder.DataAdapter = ObjDataAdapter;

            MstrQuery = "";
        }
        #endregion

        #region Database Connection Open Close Methods

        public bool OpenDatabaseConnection()
        {
            try
            {
                if (ObjConnection.State != ConnectionState.Open)
                {
                    ObjConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool CloseDatabaseConnection()
        {
            try
            {
                if (ObjConnection.State != ConnectionState.Closed)
                {
                    ObjConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        #endregion

     

        #region Transaction Methods

        public void StartTransaction(IsolationLevel iso)
        {
            try
            {
                OpenDatabaseConnection();
                ObjTransaction = ObjConnection.BeginTransaction(iso);
                ObjCommand.Transaction = ObjTransaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void StartTransaction()
        {
            try
            {
                OpenDatabaseConnection();
                ObjTransaction = ObjConnection.BeginTransaction();
                ObjCommand.Transaction = ObjTransaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CommitTransaction()
        {
            try
            {
                ObjTransaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RollBackTransaction()
        {
            try
            {
                ObjTransaction.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Database Execution Methods

        public DataSet ExecuteDataSet()
        {
            DataSet _ds = new DataSet(); 
            try
            {
                if (MstrQuery != "")
                {
                    ObjCommand.CommandType = CommandType.StoredProcedure;
                    ObjDataAdapter.SelectCommand.CommandText = MstrQuery;
                    OpenDatabaseConnection();
                    ObjDataAdapter.Fill(_ds);
                }
                
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message,ex);
            }
            MstrQuery = "";
            return _ds;
        }
        public void ExecuteOnMyDataSet(ref DataSet refMyDataSet)
        {
            DataSet _ds = new DataSet();
            try
            {
                if (MstrQuery != "")
                {
                    ObjCommand.CommandType = CommandType.StoredProcedure;
                    ObjDataAdapter.SelectCommand.CommandText = MstrQuery;
                    OpenDatabaseConnection();
                    ObjDataAdapter.Fill(refMyDataSet);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            MstrQuery = "";
        }
        public DataTable ExecuteDataTable()
        {
            DataSet _ds = new DataSet();
            try
            {
                if (MstrQuery != "")
                {
                    ObjCommand.CommandType = CommandType.StoredProcedure;
                    ObjDataAdapter.SelectCommand.CommandText = MstrQuery;
                    OpenDatabaseConnection();
                    ObjDataAdapter.Fill(_ds);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            MstrQuery = "";
            if (_ds.Tables[0] != null && _ds.Tables[0].Rows.Count > 0)
            {
                return _ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public IDataReader ExecuteIDataReader()
        {
            DbDataReader _dataReader = null;
            DataTable _dt = new DataTable();
            try
            {
                ObjDataAdapter.SelectCommand.CommandText = MstrQuery;
                ObjCommand.CommandType = CommandType.StoredProcedure;
                OpenDatabaseConnection();
                _dataReader = ObjCommand.ExecuteReader();
                _dt.Load(_dataReader);
                _dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return _dt.CreateDataReader();
        }
        //public int ExecuteNonQuery()
        //{
        //    int iRowsAffected = 0;
        //    try
        //    {
        //        ObjCommand.CommandText = MstrQuery;
        //        if (ObjConnection.State == ConnectionState.Closed)
        //        {
        //            ObjConnection.Open();
        //            iRowsAffected = ObjCommand.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new SystemException(ex.Message, ex);
        //    }
        //    ObjCommand.Parameters.Clear();
        //    MstrQuery = "";
        //    return iRowsAffected;
        //}
        public string ExecuteScaler()
        {
            object _objScaler = "";
            try
            {
                ObjCommand.CommandType = CommandType.StoredProcedure;
                ObjCommand.CommandText = MstrQuery;
                if (MstrSQLParameters != null)
                {
                    for (int i = 0; i < MstrSQLParameters.Length; i++)
                    {
                        ObjCommand.Parameters.Add(MstrSQLParameters[i]);
                    }
                }
                MstrQuery = "";
                OpenDatabaseConnection();
                _objScaler = ObjCommand.ExecuteScalar();
                if (string.IsNullOrEmpty(Convert.ToString(_objScaler)))
                {
                    _objScaler = "";
                }
                ObjCommand.Parameters.Clear();
                MstrSQLParameters = null;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return Convert.ToString(_objScaler);
        }
        public string ExecuteScalerInlineSQL()
        {
            object _objScaler = "";
            try
            {
                ObjCommand.CommandText = _inlineSQL;
                OpenDatabaseConnection();
                _objScaler = ObjCommand.ExecuteScalar();
                if (string.IsNullOrEmpty(Convert.ToString(_objScaler)))
                {
                    _objScaler = "";
                }
                _inlineSQL = "";
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return Convert.ToString(_objScaler);
        }
        public DataTable ExecuteDataReader()
        {
            DataTable _dt = new DataTable();
            DbDataReader _dr = null;
            try
            {
                OpenDatabaseConnection();
                ObjCommand.CommandText = MstrQuery;
                ObjCommand.CommandType = CommandType.StoredProcedure;
                if (MstrSQLParameters != null)
                {
                    for (int i = 0; i < MstrSQLParameters.Length; i++)
                    {
                        ObjCommand.Parameters.Add(MstrSQLParameters[i]);
                    }
                }
                _dr = ObjCommand.ExecuteReader();
                ObjCommand.Parameters.Clear();
                _dt.Load(_dr);
                _dr.Close();
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            MstrQuery = "";
            return _dt;
        }
        public DataTable ExecuteStoredProcedureDataTable()
        {
            DataTable _dt = new DataTable();
            try
            {
                OpenDatabaseConnection();
                ObjCommand.CommandText = MstrQuery;
                MstrQuery = "";
                ObjCommand.CommandType = CommandType.StoredProcedure;
                ObjCommand.CommandTimeout = 30;
                if (MstrSQLParameters != null)
                {
                    for (int i = 0; i < MstrSQLParameters.Length; i++)
                    {
                        ObjCommand.Parameters.Add(MstrSQLParameters[i]);
                    }
                }
                ObjDataAdapter.SelectCommand = ObjCommand;
                ObjDataAdapter.Fill(_dt);
                ObjCommand.Parameters.Clear();
                MstrSQLParameters = null;
              
             
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return _dt;
        }
        public int ExecuteNonQuery()
        {
            int iRowsAffected = 0;
            try
            {
                OpenDatabaseConnection();
                ObjCommand.CommandText = MstrQuery;
                ObjCommand.CommandType = CommandType.StoredProcedure;
                ObjCommand.CommandTimeout = 30;
                if (MstrSQLParameters != null)
                {
                    for (int i = 0; i < MstrSQLParameters.Length; i++)
                    {
                        ObjCommand.Parameters.Add(MstrSQLParameters[i]);
                    }
                }
                iRowsAffected = ObjCommand.ExecuteNonQuery();
                ObjCommand.Parameters.Clear();
                MstrQuery = "";
                MstrSQLParameters = null;
                return iRowsAffected;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        
        public bool TestDBConnectivity(string dbConStr, string dbProvider)
        {
            try
            {
                DbProviderFactory _factoryTest = DbProviderFactories.GetFactory(dbProvider);
                DbConnection _objConn = _factoryTest.CreateConnection();
                _objConn.ConnectionString = dbConStr;
                _objConn.Open();
                _objConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void UpdateTable(DataSet dataSet)
        {
            int iAffected = 0;
            try
            {
                ObjDataAdapter.SelectCommand.CommandText = MstrQuery;
                ObjCommand.CommandType = CommandType.StoredProcedure;
                ObjCommandBuilder.DataAdapter = ObjDataAdapter;

                ObjDataAdapter.InsertCommand = ObjCommandBuilder.GetInsertCommand();
                ObjDataAdapter.UpdateCommand = ObjCommandBuilder.GetUpdateCommand();
                ObjDataAdapter.DeleteCommand = ObjCommandBuilder.GetDeleteCommand();

                iAffected = ObjDataAdapter.Update(dataSet);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }
        public int GetMaxId(string columnName, string tableName)
        {
            
            int _maxId = 0;
            string _id = string.Empty;
            try
            {
                _inlineSQL = "SELECT MAX(" + columnName + ") FROM " + tableName + "";
                _id = Convert.ToString(ExecuteScalerInlineSQL());
                if (string.IsNullOrEmpty(_id) == null && _id == "0")
                {
                    _maxId = 1;
                }
                else
                {
                    _maxId = Convert.ToInt32(_id) + 1;
                }
            }
            catch (Exception ex)
            {
                _maxId = -1;
                throw new SystemException(ex.Message, ex);
            }
           
            return _maxId;
        }
        public string GetMaxCode(string columnName, string tableName)
        {
            string _maxCode = string.Empty;
            long _maxId = 0;
            string _id = string.Empty;
            try
            {
                _inlineSQL = "SELECT MAX(" + columnName + ") FROM " + tableName + "";
                _id = Convert.ToString(ExecuteScalerInlineSQL());
                if (string.IsNullOrEmpty(_id) == null && _id == "0")
                {
                    _maxCode = "0001";
                }
                else
                {
                    _maxId = Convert.ToInt64(_id) + 1;
                    _maxCode = _maxId.ToString().PadLeft(4, '0');
                    
                }
            }
            catch (Exception ex)
            {
                _maxCode = "-1";
                throw new SystemException(ex.Message, ex);
            }
            _inlineSQL = "";
            return _maxCode;
        }
     
        public bool CheckTableExistence(string iTableName)
        {
            bool _bVal = false;
            DataTable _dt = new DataTable();
            try
            {
                if (DBConfigHelper.Provider == DatabaseProviderType.Sql)
                {
                    MstrQuery = "SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA_COLUMNS WHERE TABLE_NAME = '" + iTableName + "'";
                }
                else if (DBConfigHelper.Provider == DatabaseProviderType.Oracle)
                {
                    MstrQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA_COLUMNS WHERE UPPER(TABLE_NAME) = '" + iTableName.ToUpper() + "'";
                }
                _dt = ExecuteDataTable();
                if (_dt.Rows.Count > 0 && _dt != null)
                {
                    _bVal = true;
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return _bVal;
        }
        public bool CheckFieldExistence(string iColumnName,string iTableName)
        {
            bool _bVal = false;
            DataTable _dt = new DataTable();
            try
            {
                if (DBConfigHelper.Provider == DatabaseProviderType.Sql)
                {
                    MstrQuery = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA_COLUMNS WHERE TABLE_NAME = '" + iTableName + "' AND COLUMN_NAME = '" + iColumnName + "'";
                }
                else if (DBConfigHelper.Provider == DatabaseProviderType.Oracle)
                {
                    MstrQuery = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA_COLUMNS WHERE UPPER(TABLE_NAME) = '" + iTableName.ToUpper() + "' AND UPPER(COLUMN_NAME) = '" + iColumnName.ToUpper() + "'";
                }
                _dt = ExecuteDataTable();
                if (_dt.Rows.Count > 0 && _dt != null)
                {
                    _bVal = true;
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
            return _bVal;
        }
        public void AddColumn(string tableName, string columnName, string dataType)
        {
            try
            {
                if (CheckFieldExistence(columnName,tableName) == true)
                {
                    MstrQuery = "ALTER TABLE {0} ADD {1} {2}";
                    ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message, ex);
            }
        }
        #endregion

        #region Properties

        public string ServerName
        {
            get { return _mstrServerName; }
        }
        public string Database
        {
            get { return _mstrDatabaseName; }
        }
        public string UserID
        {
            get { return _mstrUserID; }
        }
        public string Password
        {
            get { return _mstrPassword; }
        } 

        #endregion

        #region Dispose
        public void Dispose()
        {
            ObjConnection.Dispose();
            ObjConnection = null;

            ObjCommand.Parameters.Clear();
            ObjCommand.Dispose();
            ObjCommand = null;

            ObjDataAdapter.Dispose();
            ObjDataAdapter = null;

            ObjCommandBuilder.Dispose();
            ObjDataAdapter = null;

            
        }
        #endregion
      
        
    }
   
}
