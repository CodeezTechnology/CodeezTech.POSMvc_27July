using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class BOUserLoginSession
    {
        private long _userSessionId;
        private long _userId;
        private DateTime _loginDateTime;
        private bool _isSuccessUserLogin;
        private string _ipAddress;
        private DateTime _logoutDateTime;
        private bool _isSuccessUserLogout;
        private int _counterId;

        public long UserSessionID
        {
            get { return _userSessionId; }
            set { _userSessionId = value; }
        }
        public long UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public DateTime LoginDateTime
        {
            get { return _loginDateTime; }
            set { _loginDateTime = value; }
        }
        public bool IsSuccessUserLogin
        {
            get { return _isSuccessUserLogin; }
            set { _isSuccessUserLogin = value; }
        }
        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }
        public DateTime LogOutDateTime
        {
            get { return _logoutDateTime; }
            set { _logoutDateTime = value; }
        }
        public bool IsSuccessUserLogOut
        {
            get { return _isSuccessUserLogout; }
            set { _isSuccessUserLogout = value; }
        }
        public int CounterId
        {
            get { return _counterId; }
            set { _counterId = value; }
        }
    }
}
