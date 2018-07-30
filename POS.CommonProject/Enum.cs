using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
   //public class Enum
   // {
        public enum DatabaseProviderType
        {
            Sql,
            Oracle,
            OleDb,
            Odbc
        }
        public enum OracleDateFormat
        {
            OracleDateTime,
            OracleDate,
            OracleTime
        }
        public enum ExceptionLevel
        {
            DAL,
            BAL,
            API,
            UI
        }
        public enum ExceptionType
        {
            Ask,
            Error
        }
        public enum LoginLevel : int
        {
            User = 1,
            Admin = 2,
            SuperAdmin = 3
        }
        public enum AlertType
        {
            Error,
            Warning,
            Success,
            Info
        }
      
  //  }
}
