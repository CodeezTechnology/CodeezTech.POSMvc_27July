using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.BAL
{
  public class BALCashierCounter
    {
        DALCashierCounter _objDALCashierCounter = new DALCashierCounter();
        POS_CASHIER_COUNTER _objCashierCounterEntity = new POS_CASHIER_COUNTER();
        Notify objNotify = new Notify();

        public List<POS_CASHIER_COUNTER> List()
        {
            List<POS_CASHIER_COUNTER> lst = new List<POS_CASHIER_COUNTER>();
            try
            {
                lst = _objDALCashierCounter.List();
                return lst;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException(ex.Message.ToString());
            }
        }
        public POS_CASHIER_COUNTER GetById(long? id)
        {
            try
            {
                _objCashierCounterEntity = _objDALCashierCounter.GetById(id);
                return _objCashierCounterEntity;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException(ex.Message.ToString());
            }
        }
        public Notify Create(POS_CASHIER_COUNTER CompanyModel)
        {

            try
            {
                int rowAffected = _objDALCashierCounter.Create(CompanyModel);
                if (rowAffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Company Not Created";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException(ex.Message.ToString());
            }
        }
        public Notify Update(POS_CASHIER_COUNTER CompanyModel)
        {
            try
            {
                int rowAffected = _objDALCashierCounter.Update(CompanyModel);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Company Not Updated";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException(ex.Message.ToString());
            }
        }
        public Notify Delete(long id)
        {
            int rowAffected = 0;
            try
            {
                rowAffected = _objDALCashierCounter.Delete(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Company Not Deleted";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                    ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException(ex.Message.ToString());
            }
        }
        public string GetMaxCode()
        {
            string code = string.Empty;
            try
            {
                code = _objDALCashierCounter.GetMaxCode();

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
    }
}
