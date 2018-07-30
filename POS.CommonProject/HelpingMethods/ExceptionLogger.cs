using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
namespace CodeezTech.POS.CommonProject
{
   public class ExceptionLogger : DBEngine
    {
        static string  _dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["POSConStr"].ConnectionString.ToString();
        string _dbProviderName = System.Configuration.ConfigurationManager.ConnectionStrings["POSConStr"].ProviderName;
        private static string _mstrQuery;
        public static void ErrorLog(Exception ex, ExceptionLevel el, ExceptionType et)
        {
            try
            {
                if (ConfigurationManager.AppSettings["AllowExceptionLogToDB"].ToUpper() == "TRUE")
                {
                    WriteExceptionInDB(ex, el, et);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static void WriteExceptionInDB(Exception ex, ExceptionLevel el, ExceptionType et)
        {
            try
            {
                string _query = string.Empty;
                string _source = ex.Source;
                string _memberType = ex.TargetSite.MemberType.ToString();
                string _method = ex.TargetSite.Name;
                string _form = ex.TargetSite.DeclaringType.Name;
                string _message = ex.Message;
                string _stackTrace = ex.StackTrace;
                string _exceptionLayer = el.ToString();
                string _exceptionType = et.ToString();
                if (DBConfigHelper.Provider == DatabaseProviderType.Sql)
                {
                    SqlParameter[] _objParameters = new SqlParameter[10];
                    //_objParameters[0] = new SqlParameter("SNO", System.Data.SqlDbType.BigInt);
                    //_objParameters[0].Value = GetMaxId();
                    _objParameters[0] = new SqlParameter("@EXCEPTION_LAYER", System.Data.SqlDbType.VarChar);
                    _objParameters[0].Value = _exceptionLayer;
                    _objParameters[1] = new SqlParameter("@SOURCE_LAYER", System.Data.SqlDbType.NVarChar);
                    _objParameters[1].Value = _source;
                    _objParameters[2] = new SqlParameter("@STACKTRACE", System.Data.SqlDbType.NVarChar);
                    _objParameters[2].Value = _stackTrace;
                    _objParameters[3] = new SqlParameter("@ERROR_MESSAGE", System.Data.SqlDbType.VarChar);
                    _objParameters[3].Value = _message;
                    _objParameters[4] = new SqlParameter("@MEMBER_TYPE", System.Data.SqlDbType.VarChar);
                    _objParameters[4].Value = _memberType;
                    _objParameters[5] = new SqlParameter("@METHOD", System.Data.SqlDbType.VarChar);
                    _objParameters[5].Value = _method;
                    _objParameters[6] = new SqlParameter("@FORM", System.Data.SqlDbType.VarChar);
                    _objParameters[6].Value = _form;
                    _objParameters[7] = new SqlParameter("@EXCEPTION_DATETIME", System.Data.SqlDbType.DateTime);
                    _objParameters[7].Value = DateTime.Now.ToString("dd-MMM-yyyy");
                    _objParameters[8] = new SqlParameter("@CLIENT_IP", System.Data.SqlDbType.VarChar);
                    _objParameters[8].Value = "";
                    _objParameters[9] = new SqlParameter("@EXCEPTION_TYPE", System.Data.SqlDbType.VarChar);
                    _objParameters[9].Value = _exceptionType;

                    SqlConnection con = new SqlConnection(_dbConnectionString);
                    SqlCommand _cmd = new SqlCommand();
                    foreach (var param in _objParameters)
                    {
                        _cmd.Parameters.Add(param);
                    }
                    _cmd.Connection = con;
                    _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    _cmd.CommandText = "spSysExceptionLog";
                    if (_cmd.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        _cmd.Connection.Open();
                        int _effectedRow = _cmd.ExecuteNonQuery();
                        _cmd.Connection.Close();
                        _cmd.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
