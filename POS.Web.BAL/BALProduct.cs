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
    public class BALProduct
    {
        DALProduct _objDALProduct = new DALProduct();
        POS_PRODUCT _objProductEntity = new POS_PRODUCT();
        Notify objNotify = new Notify();

        public List<POS_PRODUCT> List()
        {
            List<POS_PRODUCT> lst = new List<POS_PRODUCT>();
            try
            {
                lst = _objDALProduct.GetProduct();
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
        public POS_PRODUCT GetById(long? id)
        {
            try
            {
                _objProductEntity = _objDALProduct.GetById(id);
                return _objProductEntity;
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
        public Notify Create(POS_PRODUCT ProductModel)
        {

            try
            {
                objNotify.RowEffected = _objDALProduct.CreateProduct(ProductModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Created Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Product Not Created";
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
        public Notify Update(POS_PRODUCT ProductModel)
        {
            try
            {
                objNotify.RowEffected = _objDALProduct.UpdateProduct(ProductModel);
                if (objNotify.RowEffected > 0)
                {
                    objNotify.NotifyMessage = "Record Updated Successfully";
                }
                else
                {
                    objNotify.NotifyMessage = "Product Not Updated";
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
                rowAffected = _objDALProduct.DeleteProduct(id);
                if (rowAffected > 0)
                {
                    objNotify.RowEffected = 1;
                    objNotify.NotifyMessage = "Record Deleted Successfully";
                }
                else
                {
                    objNotify.RowEffected = 0;
                    objNotify.NotifyMessage = "Product Not Deleted";
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
                code = _objDALProduct.GetMaxCode();
                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_PRODUCT> ProductSelectList()
        {
            IEnumerable<POS_PRODUCT> lst = null;
            try
            {
                lst = _objDALProduct.ProductSelectList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
