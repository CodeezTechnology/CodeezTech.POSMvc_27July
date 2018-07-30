using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class BOCompanyBranch
    {
        private long _branchId;
        private string _branchCode;
        private string _branchDescription;
        private string _branchName;
        private string _mobile;
        private string _telephone;
        private string _email;
        private string _emailPassword;
        private string _address;
        private long _companyId;
        private long _cityId;
        private long _stateId;
        private long _countryId;
        private string _createdBy;
        private string _modifiedBy;
        private DateTime _createdWhen;
        private DateTime _modifiedWhen;

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
            get { return _branchDescription; }
            set { _branchDescription = value; }
        }
        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
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
        public long CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
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
        public DateTime CreateWhen
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
