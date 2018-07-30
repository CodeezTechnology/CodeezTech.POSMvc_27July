using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    class Validation
    {
        //Funtion to test for positive integer
        public static string TrimWord(string val)
        {
            if (val == null || val == "")
            {
                return val;
            }
            else if (val.IndexOf("',<>") != -1)
            {
                //return \
            }
            return val;
        }
        public static bool IsNaturalNumber(string strNumber)
        {
            Regex objNotNaturalNumber = new Regex("[^0-9]");
            Regex objNaturalNumber = new Regex("[0*[1-9][0-9]*");

            return !objNotNaturalNumber.IsMatch(strNumber) && objNaturalNumber.IsMatch(strNumber);
        }
        //Funtion to test for positive integer with zero inclusive
        public static bool IsWholeNumber(string strNumber)
        {
            Regex objNotNaturalNumber = new Regex("[^0-9]");
            return !objNotNaturalNumber.IsMatch(strNumber);
        }
        //Funtion to test for integer for both positive & negative
        public static bool isInteger(string strNumber)
        {
            Regex objNotInteger = new Regex("[^0-9-]");
            Regex objInteger = new Regex("[^-0-9]+$|^[0-9]+$");

            return !objNotInteger.IsMatch(strNumber) && objInteger.IsMatch(strNumber);
        }
        //Funtion to test for psotive number both integer & real
        public static bool IsPositiveNumber(string strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9-]");
            Regex objPositivePattern = new Regex("[^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            return !objNotPositivePattern.IsMatch(strNumber) && objPositivePattern.IsMatch(strNumber) && !objTwoDotPattern.IsMatch(strNumber);
        }
        //Funtion to test wheather the string in valid number or not
        public static bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9-]");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            string strValidRealPattern = "^([-][.][-.][0-9])[0-9]*[.]*[0-9]+$";
            string strValidIntegerPattern = "^[-]|[0-9][0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                    !objTwoDotPattern.IsMatch(strNumber) &&
                    !objTwoMinusPattern.IsMatch(strNumber) &&
                     objNumberPattern.IsMatch(strNumber);
        }
        //Funtion to test string is alphabet
        public static bool IsAlphabet(string strChar)
        {
            Regex objAlphabetPattern = new Regex("[^a-zA-Z]");
            return !objAlphabetPattern.IsMatch(strChar);
        }
        //Funtion to test string is alphanumeric
        public static bool IsAlphanumeric(string str)
        {
            Regex objAlphanumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphanumericPattern.IsMatch(str);
        }
        //Function to check is Email
        public static bool IsEmail(string email)
        {
            string _regex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            Regex objEmailPattern = new Regex(_regex);
            return objEmailPattern.IsMatch(email);
        }
        //Function to check is URL
        public static bool IsURL(string url)
        {
            string _regex = @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            Regex objURLPattern = new Regex(_regex);
            return objURLPattern.IsMatch(url);
        }
        public static bool IsEmpty(string str)
        {
            if (str == "" || string.IsNullOrEmpty(str) || str == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsVarchar(string str)
        {
            Regex _regex = new Regex("");
            if (_regex.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsBoolean(string str)
        {
            if (str.Equals("True") || str.Equals("False") || str.Equals("Yes") || str.Equals("No"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsDateFormat(string str)
        {
            Regex _regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
            if (_regex.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsSame(string str1, string str2)
        {
            if (str1.Equals(str2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string RemoveLastString(string str, string removeStr)
        {
            int _index = str.LastIndexOf(removeStr);
            if (_index > 0)
            {
                str = str.Substring(0, _index);
            }
            return str;
        }
        public static bool IsContainInvalidCharacter(string str)
        {
            if (str.Contains("'") || str.Contains("\"") ||str.Contains("<") ||str.Contains(">") ||str.Contains("--") ||str.Contains(";"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsDate(string str)
        {
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(str);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
