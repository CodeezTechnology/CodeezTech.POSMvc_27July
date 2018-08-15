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
    public class BALProductType
    {
        DALProductType _objDALProductType = new DALProductType();
        POS_PRODUCT_TYPE _objProductTypeEntity = new POS_PRODUCT_TYPE();
        Notify objNotify = new Notify();

        public List<POS_PRODUCT_TYPE> List()
        {
            List<POS_PRODUCT_TYPE> lst = new List<POS_PRODUCT_TYPE>();
            try
            {
                lst = _objDALProductType.GetProductType();
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
        public POS_PRODUCT_TYPE GetById(long? id)
        {
            try
            {
                _objProductTypeEntity = _objDALProductType.GetById(id);
                return _objProductTypeEntity;
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
        public Notify Create(POS_PRODUCT_TYPE ProductTypeModel)
        {

            try
            {
                objNotify.RowEffected = _objDALProductType.CreateProductType(ProductTypeModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "ProductType Not Created";
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
        public Notify Update(POS_PRODUCT_TYPE ProductTypeModel)
        {
            try
            {
                objNotify.RowEffected = _objDALProductType.UpdateProductType(ProductTypeModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "ProductType Not Updated";
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
                rowAffected = _objDALProductType.DeleteProductType(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "ProductType Not Deleted";
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
                code = _objDALProductType.GetMaxCode();
                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_PRODUCT_TYPE> ProductTypeSelectList()
        {
            IEnumerable<POS_PRODUCT_TYPE> lst = null;
            try
            {
                lst = _objDALProductType.ProductTypeSelectList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
