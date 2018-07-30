using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class BOSysTransLog
    {
        private static long _sNo;
        private static string _date;
        private static int _acitivityCode;
        private static string _activityOn;
        private static long _updaterId;
        private static string _updatorDateTime;
        private static string _remarks;
        private static string _action;
        private static string _referenceName;
        private static string _refernceValues;
        private static string _fieldName;
        private static string _fieldOldValues;
        private static string _fieldNewValues;
        private static string _updatePreviousDateTime;
        private static string _changesIn;

      

        public long SNo
        {
            get { return _sNo; }
            set { _sNo = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int ActivityCode
        {
            get { return _acitivityCode; }
            set { _acitivityCode = value; }
        }
        public string ActivityOn
        {
            get { return _activityOn; }
            set { _activityOn = value; }
        }
        public long UpdaterId
        {
            get { return _updaterId; }
            set { _updaterId = value; }
        }
        public string UpdaterDateTime
        {
            get { return _updatorDateTime; }
            set { _updatorDateTime = value; }
        }
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public string ReferenceName
        {
            get { return _referenceName; }
            set { _referenceName = value; }
        }
        public string ReferenceValue
        {
            get { return _refernceValues; }
            set { _refernceValues = value; }
        }
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }
        public string FieldOldValues
        {
            get { return _fieldOldValues; }
            set { _fieldOldValues = value; }
        }
        public string FieldNewValues
        {
            get { return _fieldNewValues; }
            set { _fieldNewValues = value; }
        }
        public string UpdatePreviousDateTime
        {
            get { return _updatePreviousDateTime; }
            set { _updatePreviousDateTime = value; }
        }
        public string ChangesIn
        {
            get { return _changesIn; }
            set { _changesIn = value; }
        }
    }
    public class BOSysLogReferences
    {
        public string FieldNames { get; set; }
        public string FieldNewValues { get; set; }
        public string FieldOldValues { get; set; }
    }
    
}
