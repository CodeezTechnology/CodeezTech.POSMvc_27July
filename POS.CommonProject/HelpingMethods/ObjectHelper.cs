using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class ObjectHelper
    {
        private static BOSysLogReferences _objTransLog = new BOSysLogReferences();
        private static PropertyInfo[] GetProperties(object obj)
        {
            try
            {
                return obj.GetType().GetProperties();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static BOSysLogReferences GetObjectsForTranslogUpdates(object oldData, object newData, bool compare = true)
        {
            Type _propertyType = null;
            var _oldProperties = GetProperties(oldData);
            var _newProperties = GetProperties(newData);
            for (int i = 0; i < _oldProperties.Length; i++)
            {
                _propertyType = _oldProperties[i].GetType();
                if (_propertyType == typeof(int) || _propertyType == typeof(Int16) || _propertyType == typeof(Int32) || _propertyType == typeof(Int64)
                || _propertyType == typeof(string) || _propertyType == typeof(double) || _propertyType == typeof(bool) || _propertyType == typeof(float)
                || _propertyType == typeof(decimal) || _propertyType == typeof(char) || _propertyType == typeof(long) || _propertyType == typeof(short)
                    || _propertyType == typeof(decimal))
                {
                    var _oldVal = _oldProperties[i].GetValue(oldData,null);
                    var _newVal = _newProperties[i].GetValue(newData, null);
                    if (_oldVal == null)
                    {
                        _oldVal = "";
                    }
                    if (_newVal == null)
                    {
                        _newVal = "";
                    }
                    string _description = _oldProperties[i].Name;
                    if (_oldVal.ToString() != _newVal.ToString() || !compare)
                    {
                        _objTransLog.FieldNames += _description + (char)13;
                        _objTransLog.FieldOldValues += _oldVal.ToString() + (char)13;
                        _objTransLog.FieldNewValues += _newVal.ToString() + (char)13;
                    }
                }
            }
            return _objTransLog;
        }
        public static BOSysLogReferences GetCustomObjectForTranslogUpdate(string fieldName, string oldFieldValue, string newFieldValue)
        {
            _objTransLog.FieldNames = fieldName;
            _objTransLog.FieldOldValues = oldFieldValue;
            _objTransLog.FieldNewValues = newFieldValue;
            return _objTransLog;
        }
        public static BOSysLogReferences GetObjectForTranslogInsert(DataTable newDT)
        {
            Type _propertyType = null;
            for (int i = 0; i < newDT.Columns.Count; i++)
            {
                _propertyType = newDT.Columns[i].GetType();

                if (_propertyType == typeof(int) || _propertyType == typeof(Int16) || _propertyType == typeof(Int32) || _propertyType == typeof(Int64)
              || _propertyType == typeof(string) || _propertyType == typeof(double) || _propertyType == typeof(bool) || _propertyType == typeof(float)
              || _propertyType == typeof(decimal) || _propertyType == typeof(char) || _propertyType == typeof(long) || _propertyType == typeof(short)
                  || _propertyType == typeof(decimal))
                {
                    if (newDT.Columns[i] != null || newDT.Columns[i].ToString() != "")
                    {
                        _objTransLog.FieldNames += newDT.Columns[i].ColumnName + (char)13;
                        _objTransLog.FieldNewValues += newDT.Rows[0].ToString() + (char)13;
                    }
                }
            }
            return _objTransLog;
        }
        public static BOSysLogReferences GetObjectsForTranslogUpdates(DataTable oldDT, DataTable newDT)
        {
            Type _propertyType = null;
            for (int i = 0; i < newDT.Columns.Count; i++)
            {
                _propertyType = newDT.Columns[i].GetType();

                if (_propertyType == typeof(int) || _propertyType == typeof(Int16) || _propertyType == typeof(Int32) || _propertyType == typeof(Int64)
              || _propertyType == typeof(string) || _propertyType == typeof(double) || _propertyType == typeof(bool) || _propertyType == typeof(float)
              || _propertyType == typeof(decimal) || _propertyType == typeof(char) || _propertyType == typeof(long) || _propertyType == typeof(short)
                  || _propertyType == typeof(decimal))
                {
                    if (newDT.Rows[0][i].Equals(oldDT.Rows[0][i]))
                    {
                        _objTransLog.FieldNames += newDT.Columns[i].ColumnName + (char)13;
                        _objTransLog.FieldOldValues += oldDT.Rows[0][i].ToString() + (char)13;
                        _objTransLog.FieldNewValues += newDT.Rows[0][i].ToString() + (char)13;
                    }
                }
            }
            return _objTransLog;
        }
        public static BOSysLogReferences GetObjectForTranslogInsert(object objDataNew)
        {
            Type _propertyType = null;
            var _newProperties = objDataNew.GetType().GetProperties();
            for (int i = 0; i < _newProperties.Length; i++)
            {
                _propertyType = _newProperties[i].GetType();
                if (_propertyType == typeof(int) || _propertyType == typeof(Int16) || _propertyType == typeof(Int32) || _propertyType == typeof(Int64)
              || _propertyType == typeof(string) || _propertyType == typeof(double) || _propertyType == typeof(bool) || _propertyType == typeof(float)
              || _propertyType == typeof(decimal) || _propertyType == typeof(char) || _propertyType == typeof(long) || _propertyType == typeof(short)
                  || _propertyType == typeof(decimal))
                {
                    var _newValue = _newProperties[i].GetValue(objDataNew,null);
                    if (_newValue == null)
                    {
                        _newValue = "";
                    }
                    if (_newValue.ToString() != "")
                    {
                        _objTransLog.FieldNames += _newProperties[i].Name + (char)13;
                        _objTransLog.FieldNewValues += _newValue.ToString() + (char)13;
                        _objTransLog.FieldOldValues += " " + (char)13;
                    }
                }
            }
            return _objTransLog;
        }
        public static BOSysLogReferences GetObjectForTranslogDelete(object objData)
        {
            Type _propertyType = null;
            var _newProperties = objData.GetType().GetProperties();
            for (int i = 0; i < _newProperties.Length; i++)
            {
                _propertyType = _newProperties[i].GetType();
                if (_propertyType == typeof(int) || _propertyType == typeof(Int16) || _propertyType == typeof(Int32) || _propertyType == typeof(Int64)
              || _propertyType == typeof(string) || _propertyType == typeof(double) || _propertyType == typeof(bool) || _propertyType == typeof(float)
              || _propertyType == typeof(decimal) || _propertyType == typeof(char) || _propertyType == typeof(long) || _propertyType == typeof(short)
                  || _propertyType == typeof(decimal))
                {
                    var _currentValue = _newProperties[i].GetValue(objData, null);
                    if (_currentValue == null)
                    {
                        _currentValue = "";
                    }
                    if (_currentValue.ToString() != "")
                    {
                        _objTransLog.FieldNames += _newProperties[i].Name + (char)13;
                        _objTransLog.FieldNewValues += " " + (char)13;
                        _objTransLog.FieldOldValues += _currentValue.ToString() + (char)13;
                    }
                }
            }
            return _objTransLog;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            DataTable _dt = new DataTable();
            PropertyDescriptorCollection _properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor colProp in _properties)
            {
                _dt.Columns.Add(colProp.Name, Nullable.GetUnderlyingType(colProp.PropertyType) ?? colProp.PropertyType);
            }
            foreach (T itemValue in data)
            {
                DataRow _newRow = _dt.NewRow();
                foreach (PropertyDescriptor rowProp in _properties)
                {
                    _newRow[rowProp.Name] = rowProp.GetValue(itemValue) ?? DBNull.Value; 
                }
                _dt.Rows.Add(_newRow);
            }
            return _dt;
        }
    }
}
