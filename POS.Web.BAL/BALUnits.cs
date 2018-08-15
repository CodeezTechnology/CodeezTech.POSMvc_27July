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
    public class BALUnits
    {
        DALUnits _objDALUnits = new DALUnits();
        POS_UNITS _objUnitsEntity = new POS_UNITS();
        Notify objNotify = new Notify();

        public List<POS_UNITS> List()
        {
            List<POS_UNITS> lst = new List<POS_UNITS>();
            try
            {
                lst = _objDALUnits.GetUnits();
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
        public POS_UNITS GetById(long? id)
        {
            try
            {
                _objUnitsEntity = _objDALUnits.GetById(id);
                return _objUnitsEntity;
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
        public Notify Create(POS_UNITS UnitsModel)
        {

            try
            {
                objNotify.RowEffected = _objDALUnits.CreateUnits(UnitsModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Units Not Created";
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
        public Notify Update(POS_UNITS UnitsModel)
        {
            try
            {
                objNotify.RowEffected = _objDALUnits.UpdateUnits(UnitsModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Units Not Updated";
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
                rowAffected = _objDALUnits.DeleteUnits(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Units Not Deleted";
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
      
        public IEnumerable<POS_UNITS> UnitsSelectList()
        {
            IEnumerable<POS_UNITS> lst = null;
            try
            {
                lst = _objDALUnits.UnitsSelectList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
