using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
   public class TimeHelper
    {
        public static double DateTimeToMinutes(DateTime dateTime, string time)
        {
            double _dTime = 0;
            try
            {
               
                DateTime _ref_date = DateTime.MinValue;
                TimeSpan _timeDiff = dateTime.Date.Subtract(_ref_date.Date);
                _dTime = _timeDiff.TotalMinutes + (DateTime.Parse(time).Hour * 60) + DateTime.Parse(time).Minute;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return _dTime;
        }
        public static double TimeToMinutes(string time)
        {
            double _minutes = 0;
            try
            {
                if (time == "" && time == null)
                {
                    return _minutes;
                }
                else
                {
                    string[] _timeSplit = time.Split(':');
                    _minutes = Convert.ToDouble((Convert.ToDouble(_timeSplit[0]) * 60) + (Convert.ToDouble(_timeSplit[1])));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return _minutes;
        }
        public static double HoursToNumber(string hours)
        {
            double _number = 0;
            try
            {
                if (hours == "" && hours == null)
                {
                    return _number;
                }
                else
                {
                    string[] _hoursSplit = hours.Split(':');
                    _number = (Formatter.SetValidValueToDouble(_hoursSplit[0]) + (Formatter.SetValidValueToDouble(_hoursSplit[1]) / 60)) * 100;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return _number;
        }
        public static string MintutesToTime(double minutes)
        {
            string _totalTime = string.Empty, a, b;
            bool _negative = false;
            string _tempValue = "";
            try
            {
                if (minutes < 0)
                {
                    _negative = true;
                    minutes = minutes * -1;
                }
                _totalTime = _negative ? "-" : "";
                int _hours = (int)minutes / 60;
                double _mins = (double)minutes % 60;
                a = Convert.ToString(_hours).ToString().PadLeft(2, '0');
                b = Convert.ToString(_mins).ToString().PadLeft(2, '0');
                _totalTime = _tempValue + a + b;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return _totalTime;
        }
    }
}
