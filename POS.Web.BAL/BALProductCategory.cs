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
    public class BALProductCategory
    {
        DALProductCategory _objDALProductCategory = new DALProductCategory();
        POS_PRODUCT_CATEGORY _objProductCategoryEntity = new POS_PRODUCT_CATEGORY();
        Notify objNotify = new Notify();

        public List<POS_PRODUCT_CATEGORY> List()
        {
            List<POS_PRODUCT_CATEGORY> lst = new List<POS_PRODUCT_CATEGORY>();
            try
            {
                lst = _objDALProductCategory.GetProductCategory();
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
        public POS_PRODUCT_CATEGORY GetById(long? id)
        {
            try
            {
                _objProductCategoryEntity = _objDALProductCategory.GetById(id);
                return _objProductCategoryEntity;
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
        public Notify Create(POS_PRODUCT_CATEGORY ProductCategoryModel)
        {

            try
            {
                objNotify.RowEffected = _objDALProductCategory.CreateProductCategory(ProductCategoryModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "ProductCategory Not Created";
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
        public Notify Update(POS_PRODUCT_CATEGORY ProductCategoryModel)
        {
            try
            {
                objNotify.RowEffected = _objDALProductCategory.UpdateProductCategory(ProductCategoryModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "ProductCategory Not Updated";
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
                rowAffected = _objDALProductCategory.DeleteProductCategory(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "ProductCategory Not Deleted";
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
                code = _objDALProductCategory.GetMaxCode();
                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_PRODUCT_CATEGORY> ProductCategorySelectList()
        {
            IEnumerable<POS_PRODUCT_CATEGORY> lst = null;
            try
            {
                lst = _objDALProductCategory.ProductCategorySelectList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
