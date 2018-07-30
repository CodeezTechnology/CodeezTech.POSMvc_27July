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
    public class BALUser
    {
        DALUser _objDALUser = new DALUser();
        POS_USER _objUserEntity = new POS_USER();
        Notify objNotify = new Notify();
        public POS_USER Login(POS_USER viewModel)
        {
            POS_USER objUser = new POS_USER();
            try
            {
                POS_USER _objUser = _objDALUser.Login(viewModel);
                if (_objUser != null)
                {
                    objUser = _objUser;
                    if (objUser.ISACTIVE_FLAG == false)
                    {
                        objUser.NotifyMessage = "User in not activated";
                    }
                    else if (objUser.LOGIN_TYPE == 1)
                    {
                        objUser.NotifyMessage = "user";
                    }
                    else if (objUser.LOGIN_TYPE == 2)
                    {
                        objUser.NotifyMessage = "admin";
                    }
                    else if (objUser.LOGIN_TYPE == 3)
                    {
                        objUser.NotifyMessage = "superadmin";
                    }
                }
                else
                {
                    objUser.NotifyMessage = "Invalid user or password.";
                }
                return _objUser;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User credentials not correct in Business Layer");
            }

        }

        public List<POS_USER> List()
        {
            List<POS_USER> lst = new List<POS_USER>();
            try
            {
                lst = _objDALUser.List();
                return lst;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User Info not completed in Business Layer");
            }
        }
        public POS_USER GetById(long? id)
        {
            try
            {
                _objUserEntity = _objDALUser.GetById(id);
                return _objUserEntity;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User Info not completed error occurred in Business Layer");
            }
        }
        public Notify Create(POS_USER userModel)
        {

            try
            {
                objNotify.RowEffected = _objDALUser.Create(userModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "User Not Created";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User not created error occurred in Business Layer");
            }
        }
        public Notify Update(POS_USER userModel)
        {
            try
            {
                objNotify.RowEffected = _objDALUser.Update(userModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "User Not Updated";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User not updated error occurred in Business Layer");
            }
        }
        public Notify Delete(long id)
        {
            int rowAffected = 0;
            try
            {
                rowAffected = _objDALUser.Delete(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "User Not Deleted";
                }
                return objNotify;
            }
            catch (Exception ex)
            {
                if (ex is DALException)
                    throw ex;
                else
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new BALException("User not deleted error occurred in Business Layer");
            }
        }
        public string GetMaxCode()
        {
            string code = string.Empty;
            int maxCode = 0;
            try
            {
                code = _objDALUser.GetMaxCode();

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_BRANCH> GetCompanyBranch()
        {
            IEnumerable<POS_BRANCH> lst = null;
            try
            {
                lst = _objDALUser.GetCompanyBranch();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
