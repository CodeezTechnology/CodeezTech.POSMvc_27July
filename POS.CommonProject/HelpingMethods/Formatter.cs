using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
   public class Formatter
    {
        public static string ArrayToString(string[] val)
        {
            string _result = string.Empty;
            foreach (var item in val)
            {
                if (item != null && item != "")
                {
                    _result += item + ",";
                }
            }
            _result = _result.Substring(0, _result.Length - 1);
            return _result;
        }
        public static string ArrayListToString(ArrayList val)
        {
            string _result = string.Empty;
            foreach (var item in val)
            {
                if (item != null && item != "")
                {
                    _result += item + ",";
                }
            }
            _result = _result.Substring(0, _result.Length - 1);
            return _result;
        }
        public static string ListToString(List<string> val)
        {
            string _result = string.Empty;
            foreach (var item in val)
            {
                if (item != null && item != "")
                {
                    _result += item + ",";
                }
            }
            _result = _result.Substring(0, _result.Length - 1);
            return _result;
        }
        public static string[] ArrayToStringArray(Array val)
        {
            int i = 0;
            string[] result = new string[val.Length];
            foreach (object obj in val)
            {
                if (obj != null)
                {
                    result[i] = obj.ToString();
                    i = i + 1;
                }
            }
            return result;
        }
        public static List<string> ArrayListToStringList(ArrayList val)
        {
            List<string> result = new List<string>();
            foreach (List<string> item in val)
            {
                result.Add(item.ToString());
            }
            return result;
        }
       
        public static DateTime SetValidValueToDateTime(object dc)
        {
            if (dc == DBNull.Value || !string.IsNullOrEmpty(dc.ToString()))
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(dc);
        }
        public static DateTime SetValidValueToDateTime(object dc, bool isNullable)
        {
            if (dc == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(dc);
        }
        public static bool DateTimeIsNull(object dc)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dc)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static DateTime SetValidValueToDateTimeMax(object dc)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return DateTime.MaxValue;
            }
            return Convert.ToDateTime(dc);
        }
        public static int SetValidValueToInt(object dc)
        {
            if (dc == DBNull.Value || dc == "" || string.IsNullOrEmpty(Convert.ToString(dc)))
            {
                return 0;
            }
            return Convert.ToInt32(dc);
        }
        public static int SetValidValueToInt(object dc,bool isNullable)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return 0;
            }
            return (int)(dc);
        }
        public static double SetValidValueToDouble(object dc, bool isNullable)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return 0;
            }
            return Convert.ToDouble(dc);
        }
        public static long SetValidValueToLong(object dc)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return 0;
            }
            return Convert.ToInt64(dc);
        }
        public static char SetValidValueToDouble(object dc)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return '0';
            }
            return Convert.ToChar(dc);
        }
        public static string SetValidValueToString(object dc)
        {
            if (dc == DBNull.Value || dc == "")
            {
                return "0";
            }
            return Convert.ToString(dc);
        }
        public static string SetValidValueToString(object value,bool isNullable)
        {
            if (value == DBNull.Value && isNullable)
            {
                return string.Empty;
            }
            return Convert.ToString(value);
        }
        public static bool SetValidValueToBoolean(object value)
        {
            if (value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            return Convert.ToBoolean(value); 
        }
        public static bool SetValidValueToBoolean(object value,bool IsNullable)
        {
            if (value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            return (bool)(value);
        }
        public static string OracleDateTimeNewFormat(string dateTime, OracleDateFormat oracleDate)
        {
            string _oracleDateTimeFormate = string.Empty;
            switch (oracleDate)
            {
                case OracleDateFormat.OracleDateTime:
                    _oracleDateTimeFormate = "To_Date('" + dateTime + "','" + Global.OracleDateTimeFormat + "')";
                    break;
                case OracleDateFormat.OracleDate:
                    _oracleDateTimeFormate = "To_Date('" + dateTime + "','" + Global.OracleDateFormat + "')";
                    break;
            }
            return _oracleDateTimeFormate;
        }
        public static string OracleDateTimeFormat(string dateTime, OracleDateFormat oracleDate)
        {
            string _oracleDateTimeFormate = string.Empty;
            switch (oracleDate)
            {
                case OracleDateFormat.OracleDateTime:
                    _oracleDateTimeFormate = "To_Date('" + dateTime + "','" + Global.OracleDateTimeFormat + "')";
                    break;
                case OracleDateFormat.OracleDate:
                    string str = Convert.ToDateTime(dateTime).ToString("dd/MMM/yyyy");
                    _oracleDateTimeFormate = "To_Date('" + str + "','" + Global.OracleDateFormat + "')";
                    break;
            }
            return _oracleDateTimeFormate;
        }
        public static string OracleDate(string dateTime, OracleDateFormat oracleDate,bool isTrue)
        {
            string _oracleDateTimeFormate = string.Empty;
            switch (oracleDate)
            {
                case OracleDateFormat.OracleDate:
                    _oracleDateTimeFormate = "To_Date('" + dateTime + "','" + Global.OracleDateFormat + "')";
                    break;
            }
            return _oracleDateTimeFormate;
        }
        public static string OracleTime(string dateTime, OracleDateFormat oracleDate)
        {
            string _oracleDateTimeFormate = string.Empty;
            switch (oracleDate)
            {
                case OracleDateFormat.OracleTime:
                    _oracleDateTimeFormate = "To_Date('" + dateTime + "','" + Global.OracleDateFormat + "')";
                    break;
            }
            return _oracleDateTimeFormate;
        }
        public static bool GetBooleanFieldValue(System.Data.DataRow dataRow, string fieldName)
        {
            bool _fieldValue = false;
            try
            {
                if (dataRow[fieldName].ToString() == "1" || dataRow[fieldName].ToString().ToUpper() == "True".ToUpper())
                {
                    _fieldValue = true;
                }
                else
                {
                    _fieldValue = false;
                }
            }
            catch (Exception ex)
            {
                _fieldValue = false;
            }
            return _fieldValue;
        }
        public static bool GetBooleanFieldValue(object dc)
        {
            bool _fieldValue = false;
            try
            {
                if (dc.ToString() == "1" || dc.ToString().ToUpper() == "True".ToUpper())
                {
                    _fieldValue = true;
                }
                else
                {
                    _fieldValue = false;
                }
            }
            catch (Exception ex)
            {
                _fieldValue = false;
            }
            return _fieldValue;
        }
        public static int GetBooleanFieldValueInt(System.Data.DataRow dataRow, string fieldName)
        {
            int _fieldValue = 0;
            try
            {
                if (dataRow[fieldName].ToString() == "1" || dataRow[fieldName].ToString().ToUpper() == "True".ToUpper())
                {
                    _fieldValue = 1;
                }
                else
                {
                    _fieldValue = 0;
                }
            }
            catch (Exception ex)
            {
                _fieldValue = 0;
            }
            return _fieldValue;
        }
        public static bool SetIntegerToBoolean(int value)
        {
            bool _bVal = false;
            if (value == 1)
            {
                _bVal = true;
            }
            else if (value == 0)
            {
                _bVal = false;
            }
            return _bVal;
        }
        public static bool SetDoubleToBoolean(double value)
        {
            bool _bVal = false;
            if (value == 1)
            {
                _bVal = true;
            }
            else if (value == 0)
            {
                _bVal = false;
            }
            return _bVal;
        }
        public static double SetDoubleToBoolean(bool value)
        {
            double _dVal = 0;
            if (value == true)
            {
                _dVal = 1;
            }
            else if (value == false)
            {
                _dVal = 0;
            }
            return _dVal;
        }
        public static bool CheckValidValueToDateTime(object dc)
        {
            DateTime _dateTime = new DateTime();
            bool isTrue = true;
            try
            {
                _dateTime = Convert.ToDateTime(dc);
            }
            catch (Exception)
            {
                isTrue = false;
            }
            return isTrue;
        }
        public static bool CheckValidValueToBoolean(object value)
        {
            try
            {
                if (value == DBNull.Value || value.ToString().ToUpper() == "false" || value.ToString() == "0")
                {
                    return false;
                }
                else if (value.ToString().ToUpper() == "false" || value.ToString() == "0")
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static string ConvertTrueFalseToYesNo(string val)
        {
            string _result = string.Empty;
            if (val.ToUpper() == "True".ToUpper() || val == "1")
            {
                _result = "Yes";
            }
            else if (val == "False" || val == "0" || string.IsNullOrEmpty(val))
            {
                _result = "No";
            }
            return _result;
        }
        public static string ConvertYesNoToTrueFalse(string val, bool returnBlank)
        {
            string _result = string.Empty;
            if (val.ToUpper() == "Yes".ToUpper() || val == "1")
            {
                _result = "True";
            }
            else if (val.ToUpper() == "No".ToUpper() || val == "0" || string.IsNullOrEmpty(val) || returnBlank == false)
            {
                _result = "False";
            }
            else if (string.IsNullOrEmpty(val) || returnBlank == true)
            {
                _result = "";
            }
            return _result;
        }
        public static string ConvertTrueFalseToDenyAccept(object obj)
        {
            string val = string.Empty;
            if (obj == DBNull.Value)
            {
                val = "";
            }
            else
            {
                val = obj.ToString();
            }
            if (val.ToUpper() == "True".ToUpper() || val == "1")
            {
                val = "Accepted";
            }
            else if (val.ToUpper() == "False".ToUpper() || val == "0")
            {
                val = "Deny";
            }
            return val;
        }
    }
    public class FormatterHtml
    {
        public static string SetValidValue(string value)
        {
            return value.Trim().Replace("'", " ");
        }
    }
}
