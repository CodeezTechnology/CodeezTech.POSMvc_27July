using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
   public class Global
    {
        public static string OracleDateTimeFormat = "DD-MON-YYYY HH:MI:SS AM";
        public static string OracleDateFormat = "DD-MON-YYYY";
        public static string OracleTimeFormat = "hh24:mi:ss";
        public static string TimeFormat = "HH:MM";
        public static string DateFormat = "dd-MM-yyyy";



    }
   public class eActivityOn
   {
       public static string User_Login = "User Login";
       public static string Admin_Login = "Admin Login";
       public static string SuperAdmin_Login = "Super Admin Login";
   }
   public class eAction
   {
       public static string Insert = "Insert";
       public static string Update = "Update";
       public static string Delete = "Delete";
       public static string Navigate = "Navigate";
   }
   public class eActivityCode
   {
       public static string Insert = "0";
       public static string Update = "1";
       public static string Delete = "2";
       public static string Navigate = "3";

   }
   public class eRamrks
   {
       public static string Updated_Successfully = "Updated Successfully";
       public static string Saved_Successfully = "Saved Successfully";
       public static string Deleted_Successfully = "Deleted Successfully";
       public static string Login_Successfully = "Login Successfully";
   }
   public class Notify
   {
       public string NotifyMessage { get; set; }
       public int RowEffected { get; set; }
   }
   public class Error
   {
       public string Breadcrum { get; set; }
       public string ErrorMsg { get; set; }
   }
}
