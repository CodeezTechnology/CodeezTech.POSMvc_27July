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
    public class BALCompanyBranch
    {
      DALCompanyBranch _objDALBranch = new DALCompanyBranch();
        POS_BRANCH _objBranchEntity = new POS_BRANCH();
        Notify objNotify = new Notify();
     
        public List<POS_BRANCH> List()
        {
            List<POS_BRANCH> lst = new List<POS_BRANCH>();
            try
            {
                lst = _objDALBranch.List();
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
        public POS_BRANCH GetById(long? id)
        {
            try
            {
                _objBranchEntity = _objDALBranch.GetById(id);
                return _objBranchEntity;
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
        public Notify Create(POS_BRANCH BranchModel)
        {

            try
            {
                int rowAffected = _objDALBranch.Create(BranchModel);
                if (rowAffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Branch Not Created";
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
        public Notify Update(POS_BRANCH BranchModel)
        {
            try
            {
                int rowAffected = _objDALBranch.Update(BranchModel);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Branch Not Updated";
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
                rowAffected = _objDALBranch.Delete(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Branch Not Deleted";
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
                code = _objDALBranch.GetMaxCode();

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
