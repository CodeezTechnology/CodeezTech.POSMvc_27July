using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
   public class BOfrmCompanyDetail
    {
        private long _companyId;
        private string _companyCode;
        private string _companyDescription;
        private string _companyLogo;
        private string _httpHostAddress;
        private string _ntnNo;
        private string _registeredBy;
        private bool _isActive;
        private bool _isPosted;
     
     

        //Branches
        private long _branchId;
        private string _branchCode;
        private string _branchDesc;
        private string _branchName;
        private string _mobile;
        private string _telephone;
        private string _email;
        private string _emailPassword;
        private string _address;
        private long _cityId;
        private long _stateId;
        private long _countryId;
        private string _createdBy;
        private string _modifiedBy;
        private DateTime _createdWhen;
        private DateTime _modifiedWhen;
     

        public long CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        public string CompanyCode
        {
            get { return _companyCode; }
            set { _companyCode = value; }
        }
        public string NTNNo
        {
            get { return _ntnNo; }
            set { _ntnNo = value; }
        }
        public string RegisteredBy
        {
            get { return _registeredBy; }
            set { _registeredBy = value; }
        }
        public long BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }
        public string BranchDescription
        {
            get { return _branchDesc; }
            set { _branchDesc = value; }
        }
        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }
        public long CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
        public long StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }
        public long CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }
       
        public string CompanyDescription
        {
            get { return _companyDescription; }
            set { _companyDescription = value; }
        }
        public string CompanyLogo
        {
            get { return _companyLogo; }
            set { _companyLogo = value; }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string EmailPassword
        {
            get { return _emailPassword; }
            set { _emailPassword = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public bool IsPosted
        {
            get { return _isPosted; }
            set { _isPosted = value; }
        }
        public string HttpHostAddress 
        {
            get { return _httpHostAddress; }
            set { _httpHostAddress = value; }
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
        
    }
}
