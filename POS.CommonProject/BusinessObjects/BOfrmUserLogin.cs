using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class BOfrmUserLogin
    {
        private long _userId;
        private string _userCode;
        private string _userName;
        private string _password;
        private string _email;
        private bool _isActive;
        private int _loginLevel;
        private string _masterPassword;
        private bool _isPosted;
        private long _accessGroupId;
        private bool _isDBAutoUpdate;
        private string _createdBy;
        private string _modifiedBy;
        private DateTime _createdWhen;
        private DateTime _modifiedWhen;
        private string _userMsg;
        private bool _isLoginPermission;
        private string _formName;

    
        private long _branchId;
     


        public long UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public long BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }
        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public int LoginLevel
        {
            get { return _loginLevel; }
            set { _loginLevel = value; }
        }
        public string MasterPassword
        {
            get { return _masterPassword; }
            set { _masterPassword = value; }
        }
        public bool IsPosted
        {
            get { return _isPosted; }
            set { _isPosted = value; }
        }
        public long AccessGroupId
        {
            get { return _accessGroupId; }
            set { _accessGroupId = value; }
        }
        public bool DBAutoUpdator
        {
            get { return _isDBAutoUpdate; }
            set { _isDBAutoUpdate = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        public DateTime CreatedWhen
        {
            get { return _createdWhen; }
            set { _createdWhen = value; }
        }
        public DateTime ModifiedWhen
        {
            get { return _modifiedWhen; }
            set { _modifiedWhen = value; }
        }
        public string UserValidateMsg
        {
            get { return _userMsg; }
            set { _userMsg = value; }
        }
        public bool IsLoginPermission
        {
            get { return _isLoginPermission; }
            set { _isLoginPermission = value; }
        }
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
    }
}
